using System;

namespace SRP.SRP_CleanUp
{
    /// <summary>
    /// User Class is not responsible any more for writing the Exception to a File.
    /// It has now only one responsibility and that is to Add somehting to somewhere.
    /// This can be further improved by not letting the User Class create the FileLogger itself and
    /// injecting the required Logger via an Interface (Dependency Injection) and moving the Exception Handling to
    /// a global Exception Handler
    /// </summary>
    public class User
    {
        private readonly FileLogger logger = new FileLogger();

        public void Add()
        {
            try
            {
                // Add something to somewhere
            }
            catch (Exception ex)
            {
                this.logger.WriteLog(ex);
            }
        }
    }
}
