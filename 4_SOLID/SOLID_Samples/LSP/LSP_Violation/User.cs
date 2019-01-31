using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP.LSP_Violation
{
    /// <summary>
    /// User Class is now Closed for Modification but open for Extensions.
    /// </summary>
    public class User
    {
        public virtual double GetPrivilegesInPercent(double privileges)
        {
            return privileges / privileges * 100;
        }

        public virtual void Add()
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
