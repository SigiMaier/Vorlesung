using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.ISP_Violation
{
    /// <summary>
    /// LSP Violation: The FileSystem class needs to Calculate its Privileges in Percent but should not add something 
    /// to somewhere. Per Polymorphism Rule it is possible to point via User Class to its Child Class objects ==> see
    /// Program.cs in Executable Project. LSP says, that a Base Class should easily replace the Child Object ==> 
    /// there is need to create two interfaces
    /// </summary>
    public class FileSystem : IPrivileges
    {
        public double GetPrivilegesInPercent(double privileges)
        {
            return privileges / 10 * 100;
        }
    }
}
