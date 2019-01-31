using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.DIP_Violation
{
    public interface ILogger
    {
        void LogException(Exception exception);
    }
}
