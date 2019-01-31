
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BadDesign
{
    class IpcTools
    {
        public class FtpFileInfo
        {
            public enum FtpFileTypes
            {
                Unknown,
                Directory,
                File
            };
            public String Line;
            public String FullPath { get { return Path + (Path.EndsWith("/") ? "" : "/") + Name; } }
            public String Path;
            public String Name;
            public long   Size;
            public DateTime date;
            public int Level;
            public String Rights;
            public String Owner;
            public String Group;
            public FtpFileTypes Type;
        };

        public Action<string> OutputCallback = null;

        private FTP_Bad FTPAccess;

        private String Uri { get; set; }
        private NetworkCredential NetworkCredential { get; set; }



        public IpcTools(string ipAddress, string user, string password)
        {
            FTPAccess = new FTP_Bad(ipAddress, user, password);
        }

        private void PrintText(string msg)
        {
            if (OutputCallback == null)
                return;

            OutputCallback(msg);
            System.Diagnostics.Trace.TraceInformation(msg);
        }

        private int GetMonthFromString(string month)
        {
            month = month.ToLower();
            if      (month.StartsWith("jan")) return  1;
            else if (month.StartsWith("feb")) return  2;
            else if (month.StartsWith("mar")) return  3;
            else if (month.StartsWith("apr")) return  4;
            else if (month.StartsWith("may")) return  5;
            else if (month.StartsWith("jun")) return  6;
            else if (month.StartsWith("jul")) return  7;
            else if (month.StartsWith("aug")) return  8;
            else if (month.StartsWith("sep")) return  9;
            else if (month.StartsWith("oct")) return 10;
            else if (month.StartsWith("nov")) return 11;
            else if (month.StartsWith("dec")) return 12;
            else return 1;
        }

        public void GetAllFilesRecursive(string path, List<FtpFileInfo> globalFileList, int level)
        {
            //PrintText("Processing " + path);
            List<string> dirList = new List<string>();

            IList<String> detailedFileListStrings = GetDetailedFileNameList(path);
            List<FtpFileInfo> localFileList = new List<FtpFileInfo>();

            for (int ii = 0; ii < detailedFileListStrings.Count; ii++)
            {
                String detailedFileString = detailedFileListStrings[ii];

                // remove the /path/
                detailedFileString = detailedFileString.Substring(path.Length);
                if (detailedFileString[0] == '/')
                    detailedFileString = detailedFileString.Remove(0, 1);

                // eliminate all '  ' double blanks
                while (detailedFileString.IndexOf("  ") >= 0)
                    detailedFileString = detailedFileString.Replace("  ", " ");

                string[] items = detailedFileString.Split(' ');

                String fileName = items[items.Length-1];

                if (String.IsNullOrEmpty(fileName) || fileName == "." || fileName == "..")
                    continue;

                FtpFileInfo ftpFile = new FtpFileInfo();
                ftpFile.Line   = detailedFileString;
                ftpFile.Level  = level;
                ftpFile.Path   = path;
                ftpFile.Name   = fileName;
                ftpFile.Type   = items[0][0] == 'd' ? FtpFileInfo.FtpFileTypes.Directory : FtpFileInfo.FtpFileTypes.File;
                ftpFile.Rights = items[0].Remove(0, 1);
                ftpFile.Owner  = items[2];
                ftpFile.Group  = items[3];
                ftpFile.Size   = Convert.ToInt64(items[4]);
                ftpFile.date   = new DateTime(Convert.ToInt32(items[7]), GetMonthFromString(items[5]), Convert.ToInt32(items[6])); 

                localFileList.Add(ftpFile);

                PrintText(String.Format("{0, 10}  {1}", ftpFile.Size, ftpFile.FullPath));
            }

            level++;

            foreach(FtpFileInfo ftpFile in localFileList)
            {
                if (ftpFile.Type == FtpFileInfo.FtpFileTypes.Directory)
                {
                    GetAllFilesRecursive(ftpFile.FullPath, globalFileList, level);
                }

                globalFileList.Add(ftpFile);
            }
        }

        public IList<String> GetDetailedFileNameList(string path)
        {
            IList<string> files = new List<string>();

            if (!FTPAccess.FileExistsViaFtpRequest(path))
                return files;

            FTPAccess.TryGetFilelist(path, out files, true);
            return files;
        }

        private long GetFileSizes(List<string> fileList)
        {
            long sizeOverAll = 0;
            try
            {
                foreach (String file in fileList)
                {

                    try
                    {
                        FtpWebRequest reqSize = (FtpWebRequest)FtpWebRequest.Create(this.Uri + file);
                        reqSize.ConnectionGroupName = "Test";
                        reqSize.Credentials = this.NetworkCredential;
                        reqSize.Method = WebRequestMethods.Ftp.GetFileSize;
                        reqSize.UseBinary = true;
                        FtpWebResponse respSize = (FtpWebResponse)reqSize.GetResponse();
                        long size = respSize.ContentLength;
                        respSize.Close();

                        PrintText(String.Format("{0,10} {1,-30}", size, file));

                        sizeOverAll += size;

                    }
                    catch (Exception ex)
                    {
                        if (ex is WebException && file.Contains("FTPD_PIP."))
                        { 
                            // this is a temporary file of the FTP Daemon
                            // do nothing
                        }
                        else
                        { 
                            PrintText(String.Format("FAILURE could not get file size:", file));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // wenn er hier vorbeikommt, dann ist das Verzeichnis leer
                MessageBox.Show(ex.Message + (ex.InnerException == null ? "" : ("\n" + ex.InnerException.InnerException)));
            }

            return sizeOverAll;
        }
    }
}
