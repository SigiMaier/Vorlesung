using ISP.ISP_CleanUP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.IPS_CleanUP
{
    /// <summary>
    /// Other possiblity is, not to let IDatabaseV2 derive from IDatabase and let UserWithRead implement both interfaces.
    /// </summary>
    public interface IDatabaseV2 : IDatabase
    {
        void Read();
    }
}
