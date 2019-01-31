using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.DIP_Violation
{
    /// <summary>
    /// DIP Violation: In order to get a different logger depending on configuration/selection/... an IF-condition is 
    /// implemented. This again violates the SRP, since the User Class should not be responsible to create the 
    /// required Logger instance. In order to satisfy the SRP again we use the DIP and invert the dependency of creating
    /// the Logger to the creator of the User Class ==> see DIP_CleanUP and Executable.
    /// </summary>
    public class User : IPrivileges, IDatabase
    {
        private ILogger logger;

        public virtual double GetPrivilegesInPercent(double privileges)
        {
            return privileges / privileges * 100;
        }

        public virtual void Add(int exceptionHandle)
        {
            try
            {
                // Adding something to somewhere...
            }
            catch (Exception ex)
            {
                if (exceptionHandle == 1)
                {
                    this.logger = new FileLogger();
                }
                else
                {
                    this.logger = new EmailLogger();
                }

                this.logger.LogException(ex);
            }
        }
    }
}
