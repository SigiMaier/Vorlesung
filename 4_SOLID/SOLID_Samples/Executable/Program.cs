using LSP.LSP_Violation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executable
{
    class Program
    {
        static void Main(string[] args)
        {
            LSP_ViolationExecute();
            LSP_CleanUPExecute();
            DIP_CleanUPExecute();
        }


        #region LSPViolation
        private static void LSP_ViolationExecute()
        {
            List<User> users = new List<User>()
            {
                new SuperUser(),
                new Administrator(),
                new FileSystem()
            };

            foreach (var user in users)
            {
                user.Add();
            }
        }
        #endregion

        #region LSPCleanUp
        private static void LSP_CleanUPExecute()
        {
            //List<LSP.LSP_CleanUP.User> users = new List<LSP.LSP_CleanUP.User>()
            //{
            //    new LSP.LSP_CleanUP.SuperUser(),
            //    new LSP.LSP_CleanUP.Administrator(),
            //    new LSP.LSP_CleanUP.FileSystem()
            //};
        }
        #endregion

        #region DIPCleanUP
        private static void DIP_CleanUPExecute()
        {
            DIP.DIP_CleanUP.IDatabase user = new DIP.DIP_CleanUP.User(new DIP.DIP_CleanUP.FileLogger());
        }
        #endregion
    }
}
