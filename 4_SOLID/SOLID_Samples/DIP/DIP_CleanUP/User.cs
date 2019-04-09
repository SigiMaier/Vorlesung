using System;

namespace DIP.DIP_CleanUP
{
    /// <summary>
    /// DIP Violation: In order to get a different logger depending on configuration/selection/... an IF-condition is 
    /// implemented. This again violates the SRP, since the User Class should not be responsible to create the 
    /// required Logger instance. In order to satisfy the SRP again we use the DIP and invert the dependency of creating
    /// the Logger to the creator of the User Class ==> see DIP_CleanUP and Executable.
    /// </summary>
    public class User : IPrivileges, IDatabase
    {
        private readonly ILogger logger;

        public User(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

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
                this.logger.LogException(ex);
            }
        }
    }
}
