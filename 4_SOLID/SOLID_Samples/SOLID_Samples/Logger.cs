using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Samples
{
    public interface ILogger
    {
        void Handle(string message);
    }

    public class FileLogger : ILogger
    {

        public void Handle(string message)
        {
            WriteErrorLog(message);
        }

        private void WriteErrorLog(string message)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", message);
        }
    }

    public class EventViewerLogger : ILogger
    {
        public void Handle(string message)
        {
            // Log messages regarding EventViewer
        }
    }

    public class EmailLogger : ILogger
    {
        public void Handle(string message)
        {
            // Log messages regarding emails
        }
    }
}
