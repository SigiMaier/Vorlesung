using System;
using System.IO;

namespace SRP.SRP_Violation
{
    /// <summary>
    /// SRP Violation: User Class should only Add something to somewhere and nothing else.
    /// User Class does things that it is not supposed to do!
    /// User Class should add something to somewhere and not doing any logging activity/writing something directly to 
    /// a file.
    /// If we need an other Logger or write the Error somewhere else, we need to change the User Class, what is clearly
    /// a violation of the SRP.
    /// </summary>
    public class User
    {
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
