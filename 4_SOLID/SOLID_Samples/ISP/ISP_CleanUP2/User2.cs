using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.ISP_CleanUP2
{
    public class User2
    {
        private IU2Ops u2Ops = new OPS();

        public void Op()
        {
            u2Ops.Op2();
        }
    }
}
