using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.ISP_CleanUP2
{
    public class User1
    {
        private IU1Ops u1Ops = new OPS();

        public void Op()
        {
            u1Ops.Op1();
        }
    }
}
