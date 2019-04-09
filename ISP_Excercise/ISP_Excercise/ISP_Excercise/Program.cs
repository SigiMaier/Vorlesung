using ISP.ISP_CleanUP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_Excercise
{
    class Program
    {
        static void Main(string[] args)
        {
            OPS oPS = new OPS();
            User1 user1 = new User1(oPS);
        }
    }
}
