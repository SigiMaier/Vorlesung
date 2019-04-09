using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.ISP_CleanUP2
{
    public class User1
    {
        private IU1Ops u1Ops;

        public User1(IU1Ops u1Ops)
        {
            this.u1Ops = u1Ops;
        }

        public void Op(IU1Ops u1Ops)
        {
            u1Ops.Op1();
        }
    }
}
