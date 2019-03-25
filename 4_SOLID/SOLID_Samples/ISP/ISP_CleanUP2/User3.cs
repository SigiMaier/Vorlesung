using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.ISP_CleanUP2
{
    public class User3
    {
        private IU3Ops u3Ops = new OPS();

        public void Op()
        {
            u3Ops.Op3();
        }
    }
}
