using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace BadDesign
{
    public class FTP_Bad
    {
        //private Logger log = Logger.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private Object lockObject = new Object();

        protected string uri;
        protected NetworkCredential networkCredential;

        public FTP_Bad(string ipAddress, string user, string password)
        {
            this.uri = "ftp://" + ipAddress;
            this.networkCredential = new NetworkCredential(user, password);
        }

        public bool IsConnected 
        {
            get 
            {
                string workingDirectory;
                return TryGetWorkingDirectory(out workingDirectory); 
            } 
        }

        public bool TryGetWorkingDirectory(out string workingDirectory)
        {
            workingDirectory = String.Empty;
            try
            {
                string tmpWorkingDirectory = GetWorkingDirectory();
                if (tmpWorkingDirectory != null)
                {
                    workingDirectory = tmpWorkingDirectory;
                    return true;
                }
            }
            catch (Exception ex)
            {
                //log.Exception(ex);
            }
            return false;
        }

        /// <summary>
        /// returns the list of files contained in the given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns>null if failure</returns>
        private IList<string> GetFilelist(string path, bool detailed)
        {
            List<string> files = new List<string>();

            FtpWebResponse ftpResponse = null;
            StreamReader  serverStream = null;
         
            path = EditPath(path);

            lock (this.lockObject)
            {
                try
                {
                    string requestMethod = detailed ? WebRequestMethods.Ftp.ListDirectoryDetails : WebRequestMethods.Ftp.ListDirectory;

                    FtpWebRequest ftpRequest = GetFtpWebRequestObject(path, requestMethod, true);
                    ftpRequest.Timeout          = 10000;// 10 * 1000  Timeout does NOT work!
                    ftpRequest.ReadWriteTimeout = 10000;// 10 * 1000  Timeout does NOT work!

                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                    if (ftpResponse != null && ftpResponse.StatusCode == FtpStatusCode.OpeningData)
                    {
                        serverStream = new StreamReader(ftpResponse.GetResponseStream());

                        string line = serverStream.ReadLine();

                        while (line != null)
                        {
                            line = line.Trim();

                            if (line != "." && line != "..")
                            {
                                files.Add(path + line);
                            }

                            line = serverStream.ReadLine();
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    //log.Exception(ex);
                    files = null;
                }
                finally
                {
                    if (serverStream != null)
                    {
                        serverStream.Close();
                    }

                    if (ftpResponse != null)
                    {
                        ftpResponse.Close();
                    }
                }
            }
            
            return files;
        }

        public bool TryGetFilelist(string path, out IList<string> files, bool detailed)
        {           
            int retryCounter = 0;

            // since FTP Request without connected IPC lasts very long
            // TryGetFileList might have a duration of 120 seconds till it fails
            // may be a ping in the beginning of GetFileList 
            // could help to reduce time till failure 
            while (((files = GetFilelist(path, detailed)) == null) && retryCounter < 5)
            {
                System.Threading.Thread.Sleep(150);
                retryCounter++;
            }

            if (files == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool FileExists(string path)
        {
            string folder = path.Contains("/") ? path.Substring(0, path.LastIndexOf("/")) : "";

            IList<string> files = GetFilelist(folder, false);

            if (files == null)
            {
                return false;
            }

            foreach (string filename in files)
            {
                if (filename == path)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Ladet eine Datei vom Server
        /// </summary>
        /// <param name="sourceFile">Absoluter Pfad am Server Bsp: /stripmap/out/sm.map</param>
        /// <param name="destinationFile">Lokales Ziel</param>
        protected Stream DownloadFile(string sourceFile, bool useBinary)
        {
            int bufferLength = 2048;
            int readLength   = 0;
            byte[] buffer    = new byte[bufferLength];

            FtpWebResponse ftpWebResponse = null;
            Stream serverStream = null;
            Stream outputStream = new MemoryStream();

            try
            {
                FtpWebRequest ftpRequest = GetFtpWebRequestObject(sourceFile, WebRequestMethods.Ftp.DownloadFile, useBinary);
                ftpRequest.ReadWriteTimeout = 30000; // 30 * 1000 ms = 30 s

                ftpWebResponse = (FtpWebResponse)ftpRequest.GetResponse();
                if (ftpWebResponse != null && ftpWebResponse.StatusCode == FtpStatusCode.OpeningData)
                {
                    serverStream = ftpWebResponse.GetResponseStream();
                }

                if (serverStream != null)
                {
                    readLength = serverStream.Read(buffer, 0, bufferLength);
                }

                while (readLength > 0)
                {
                    outputStream.Write(buffer, 0, readLength);
                    readLength = serverStream.Read(buffer, 0, bufferLength);
                }
            }
            catch(Exception ex)
            {
                //log.Exception(ex);
                return null;
            }
            finally
            {
                if (serverStream != null)
                {
                    serverStream.Close();
                }

                if (ftpWebResponse != null)
                {
                    ftpWebResponse.Close();
                }
            }
            return outputStream;
        }
        
        /// <summary>
        /// retrieves a file from server
        /// </summary>
        /// <param name="sourceFile">absolute path at server, e.g. /stripmap/out/sm.map</param>
        /// <param name="outputStream">destination</param>
        public bool TryDownloadFile(string sourceFile, Stream outputStream, bool useBinary)
        {
            try
            {
                Stream downloadStream = DownloadFile(sourceFile, useBinary);
                if (downloadStream == null)
                    return false;

                downloadStream.Seek(0, SeekOrigin.Begin);

                // copy content of downloaded stream to output stream
                int length = 2048;
                Byte[] buffer = new Byte[length];
                int bytesRead = downloadStream.Read(buffer, 0, length);
                while (bytesRead > 0)
                {
                    outputStream.Write(buffer, 0, bytesRead);
                    bytesRead = downloadStream.Read(buffer, 0, length);
                }

                downloadStream.Close();

                return true;
            }
            catch (Exception ex)
            {
                //log.Exception(ex);
            }

            return false;
        }

        /// <summary>
        /// Ladet eine lokale Datei zum Server
        /// </summary>
        /// <param name="sourceStream">Stream mit Daten</param>
        /// <param name="destinationFile">Name und Pfad der Datei auf dem Server. Der Pfad muss immer absolut sein! Bsp: /stripmap/out/sm.map</param>
        private bool UploadFile(Stream sourceStream, string destinationFile, bool useBinary)
        {
            int bufferLength = 2048;
            byte[] buffer = new byte[bufferLength];
            int readLength;
            Stream streamToServer = null;

            try
            {
                FtpWebRequest ftpRequest = GetFtpWebRequestObject(destinationFile, WebRequestMethods.Ftp.UploadFile, useBinary);
                ftpRequest.ReadWriteTimeout = 30000; // 30 * 1000 ms = 30 s
                ftpRequest.ContentLength = sourceStream.Length;

                streamToServer = ftpRequest.GetRequestStream();

                readLength = sourceStream.Read(buffer, 0, bufferLength);

                while (readLength != 0)
                {
                    streamToServer.Write(buffer, 0, readLength);
                    readLength = sourceStream.Read(buffer, 0, bufferLength);
                }
            }
            catch(Exception ex)
            {
                if (ex is InvalidOperationException || ex is WebException || ex is ProtocolViolationException)
                {
                    //log.Exception(ex);
                    return false;
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                if (streamToServer != null)
                {
                    streamToServer.Close();
                }
            }
            return true;
        }

        public bool TryUploadFile(Stream sourceStream, string destinationFile, bool useBinary)
        {
            try
            {
                return UploadFile(sourceStream, destinationFile, useBinary);
            }
            catch (Exception ex)
            {
                //log.Exception(ex);
            }
            return false;
        }

        protected bool DeleteFile(string destinationFile)
        {
            bool returnValue;
           
            FtpWebResponse ftpResponse = null;
            
            try
            {
                FtpWebRequest ftpRequest = GetFtpWebRequestObject(destinationFile, WebRequestMethods.Ftp.DeleteFile, true);
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                if (ftpResponse != null && ftpResponse.StatusCode == FtpStatusCode.FileActionOK)
                {
                    returnValue = (ftpResponse.StatusCode == FtpStatusCode.FileActionOK);
                    
                    if (!returnValue)
                    {
                        throw new Exception("FTP Delete File of file: "+ destinationFile+ " failed!\n" + 
                                            "Reason: "+ ftpResponse.StatusDescription);
                    }
                }
            }
            catch(Exception ex)
            {
                if (ex is InvalidOperationException || ex is WebException)
                {
                    //log.Exception(ex);
                    return false;
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                if (ftpResponse != null)
                {
                    ftpResponse.Close();
                }
            }
            return true;
        }

        public bool TryDeleteFile(string destinationFile)
        {
            try
            {
                return DeleteFile(destinationFile);
            }
            catch (Exception ex)
            {
                //log.Exception(ex);
            }
            return false;
        }

        protected FtpWebRequest GetFtpWebRequestObject(string path, string requestMethod, bool useBinary)
        {            
            FtpWebRequest ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(this.uri + path);

            ftpWebRequest.KeepAlive = false;            
            ftpWebRequest.UseBinary = useBinary;
            ftpWebRequest.Method    = requestMethod;

            //Der FtpWebRequest wird eine Gruppe zugewisen, sodass die selbe Verbindung verwendet wird
            ftpWebRequest.ConnectionGroupName = "ServiceTool";

            //Die Verbindungen werden auf 2 beschränkt
            ftpWebRequest.ServicePoint.ConnectionLimit = 2;

            return ftpWebRequest;
        }

        private static string EditPath(string path)
        {
            path = path.Trim();

            if (!path.EndsWith("/"))
            {
                path += "/";
            }
            return path;
        }

        private void GetFileFromFtp(string sourceFile, Stream outputStream, bool useBinary)
        {
            int bufferLength = 2048;
            int readLength   = 0;
            byte[] buffer    = new byte[bufferLength];

            FtpWebResponse ftpWebResponse = null;
            Stream serverStream = null;

            try
            {
                FtpWebRequest ftpRequest = GetFtpWebRequestObject(sourceFile, WebRequestMethods.Ftp.DownloadFile, useBinary);

                ftpWebResponse = (FtpWebResponse)ftpRequest.GetResponse();
                if (ftpWebResponse != null && ftpWebResponse.StatusCode == FtpStatusCode.OpeningData)
                {
                    serverStream = ftpWebResponse.GetResponseStream();
                }

                if (serverStream != null)
                {
                    readLength = serverStream.Read(buffer, 0, bufferLength);
                }

                while (readLength > 0)
                {
                    outputStream.Write(buffer, 0, readLength);
                    readLength = serverStream.Read(buffer, 0, bufferLength);
                }
            }
            catch(Exception ex)
            {
                //log.Exception(ex);
            }
            finally
            {
                if (serverStream != null)
                {
                    serverStream.Close();
                }

                if (ftpWebResponse != null)
                {
                    ftpWebResponse.Close();
                }
            }
        }

        private string GetWorkingDirectory()
        {
            FtpWebResponse ftpWebResponse = null;

            try
            {
                FtpWebRequest ftpRequest = GetFtpWebRequestObject(string.Empty, WebRequestMethods.Ftp.PrintWorkingDirectory, true);
                ftpRequest.Timeout = 5 * 1000; // 5 s

                ftpWebResponse = (FtpWebResponse)ftpRequest.GetResponse();
                
                if (ftpWebResponse != null && ftpWebResponse.StatusCode == FtpStatusCode.PathnameCreated)
                {
                    return ftpWebResponse.ResponseUri.AbsolutePath;
                }
                else
                {
                    string logInfo = string.Format("GetWorkingDirectory Result Status: {0} StatusCode: {1}",
                                                   ftpWebResponse != null,
                                                   ftpWebResponse != null ? ftpWebResponse.StatusCode.ToString() : string.Empty);
                    throw new WebException(logInfo);
                }
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException || ex is WebException)
                {
                    //log.Exception(ex);
                    return null;
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                if (ftpWebResponse != null)
                {
                    ftpWebResponse.Close();
                }
            }
        }

        private bool DirectoryExistsViaFtpRequest(string path)
        {
            FtpWebResponse ftpResponse = null;

            try
            {
                FtpWebRequest ftpWebRequest = GetFtpWebRequestObject(path, WebRequestMethods.Ftp.ListDirectory, true);
                ftpWebRequest.Timeout          = 5 * 1000; // 5 seconds
                ftpWebRequest.ReadWriteTimeout = 5 * 1000; // 5 seconds

                if (ftpWebRequest == null)
                {
                    //log.Error("DirectoryExistsViaFtpRequest ftpWebRequest is null");
                    return false;
                }

                ftpResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
                bool resultStatus = ftpResponse != null && ftpResponse.StatusCode == FtpStatusCode.OpeningData;
                return resultStatus;
            }
            catch (Exception ex)
            {
                //log.Exception(ex);
                if (ex is InvalidOperationException || ex is WebException)
                {
                    return false;
                }
                else
                {
                    // TODO soll die wirklich weitergereicht werden?
                    throw;
                }
            }
            finally
            {   
                if (ftpResponse != null)
                {
                    ftpResponse.Close();
                }
            }
        }

        public bool FileExistsViaFtpRequest(string path)
        {
            //Pfad muss mit / enden
            if (!path.EndsWith("/"))
                path += "/";

            FtpWebRequest ftpWebRequest = GetFtpWebRequestObject(path, WebRequestMethods.Ftp.ListDirectory, true);
                ftpWebRequest.Timeout          = 5 * 1000; // 5 seconds
                ftpWebRequest.ReadWriteTimeout = 5 * 1000; // 5 seconds

            //Der FtpWebRequest wird eine Gruppe zugewisen, sodass die selbe Verbindung verwendet wird
            ftpWebRequest.ConnectionGroupName = "Test";

            //Die Verbindungen werden auf 2 beschränkt
            ftpWebRequest.ServicePoint.ConnectionLimit = 2;

            ftpWebRequest.KeepAlive = false;            
            ftpWebRequest.UseBinary = true;
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            try
            {
                // es wird eine LIst Files Abfrage gemacht, die auch die FileDetails mitanzeigt
                // denn die funktioniert auch, wenn das Verzeichnis leer ist
                // wirft aber eine Exception, wenn das Verzeichnis NICHT existiert
                WebResponse ftpResponse = ftpWebRequest.GetResponse();
                ftpResponse.Close();
            }
            catch (Exception ex)
            {
                // Hier die exceptions noch genauer prüfen
                //MessageBox.Show(ex.Message + (ex.InnerException == null ? "" : ("\n" + ex.InnerException.InnerException)));
                //MessageBox.Show("File not found: " + path);
                return false;
            }

            return true;
        }
    }
}
