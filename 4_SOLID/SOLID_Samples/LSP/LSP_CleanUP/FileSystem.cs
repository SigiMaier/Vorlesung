using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP.LSP_CleanUP
{
    /// <summary>
    /// LSP CleanUP: Now it is not possible to get Errors during runtime, since that that was possible before,
    /// is not possible anymore, since FileSystem is not a Child Class to User ==> See Executable
    /// </summary>
    public class FileSystem : IPrivileges
    {
        public double GetPrivilegesInPercent(double privileges)
        {
            return privileges / 10 * 100;
        }
    }
}
