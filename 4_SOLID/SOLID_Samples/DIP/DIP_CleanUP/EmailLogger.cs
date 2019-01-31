using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.DIP_CleanUP
{
    public class EmailLogger : ILogger
    {
        public void LogException(Exception exception)
        {
            // Logs Error via Email
        }
    }
}
