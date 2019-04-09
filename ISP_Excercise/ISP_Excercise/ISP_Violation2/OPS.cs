using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.ISP_Violation2
{
    /// <summary>
    /// Implementing the User-Classes and OPS like this, User1 depends on OP2() and OP3().
    /// Therefore, each change in these Methods force User1 to be recompiled even though User1 doesn´t use OP2() or OP3().
    /// Same goes for User2 and User3 and the Methods they don´t use.
    /// </summary>
    public class OPS
    {
        public void OP1()
        {

        }

        public void OP2()
        {

        }

        public void OP3()
        {

        }
    }
}
