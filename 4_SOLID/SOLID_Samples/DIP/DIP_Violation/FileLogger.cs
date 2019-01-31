using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.DIP_Violation
{
    public class FileLogger : ILogger
    {
        public void LogException(Exception exception)
        {
            // Logs in File
        }
    }
}
