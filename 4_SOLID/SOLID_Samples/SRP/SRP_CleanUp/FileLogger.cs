using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.SRP_CleanUp
{
    public class FileLogger
    {
        public void WriteLog(Exception exception)
        {
            File.WriteAllText(@"c:\Error.txt", exception.ToString());
        }
    }
}
