using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class Sample2_ExceptionsOverErrorCodes
    {
        public enum Error
        {
            No,
            Special,
            ReallySpecial,
            SomewhatSpecial,
            NotSoReallySpecial
        }

        public Error DoSomething()
        {
            int page = 0;
            Logger log = new Logger();

            if (this.DeletePage(page) == Error.No)
            {
                if (this.DeleteReference(page) == Error.No)
                {
                    if (this.DeleteKey(page) == Error.No)
                    {
                        log.LogInfo("Page deleted");
                    }
                    else
                    {
                        log.LogInfo("Key not deleted");
                    }
                }
                else
                {
                    log.LogInfo("DeleteReference Failed");
                }
            }
            else
            {
                log.LogInfo("Delete Failed");
                return Error.Special;
            }

            return Error.No;
        }

        private Error DeleteKey(int page)
        {
            throw new NotImplementedException();
        }

        private Error DeleteReference(int page)
        {
            throw new NotImplementedException();
        }

        private Error DeletePage(int page)
        {
            throw new NotImplementedException();
        }


        // When returning error codes, then the caller mus deal with the error immediately, see above.
        // If Exceptions are used instead, the error processing code can be seperated and the code can be simplified.

        public void DoSomethingBetter()
        {
            Logger log = new Logger();

            try
            {
                int page = 0;
                this.DeletePage(page);
                this.DeleteReference(page);
                this.DeleteKey(page);
            }
            catch (Exception ex)
            {
                log.LogException(ex);
            }
        }

        // Since try-catach blocks are not so nice to read, it is better to extract the bodies of the 
        // try and catch blocks out into own functions

        public void DoSomethingEvenMoreBetter()
        {
            int page = 0;

            try
            {
                this.DeletePageAndAllReferences(page);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
        }

        private void LogError(Exception ex)
        {
            Logger log = new Logger();
            log.LogException(ex);
        }

        private void DeletePageAndAllReferences(int page)
        {
            this.DeletePage(page);
            this.DeleteReference(page);
            this.DeleteKey(page);
        }
    }
}
