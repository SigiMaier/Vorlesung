using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.OCP_Violation
{
    /// <summary>
    /// OCP Violation: When a new UserType is added, a new "IF" condition has to be added to the GetPrivilegesInPercent()
    /// Method ==> The User Class has to be modified.
    /// With every modification it has to be ensured, that all previous conditions are still working.
    /// Instead of Modifying the User Class should be Extended ==> Everytime a new UserType is added a new Class should
    /// Extend a Base Class
    /// </summary>
    public class User
    {
        public int UserType { get; set; }

        public double GetPrivilegesInPercent(double privileges)
        {
            if (this.UserType == 1)
            {
                return privileges / 30 * 100;
            }
            else
            {
                return privileges / 70 * 100;
            }
        }

        public void Add()
        {
            try
            {
                // Adding something to somewhere...
            }
            catch (Exception ex)
            {
                File.WriteAllText(@"c:\Error.txt", ex.ToString());
            }
        }
    }
}
