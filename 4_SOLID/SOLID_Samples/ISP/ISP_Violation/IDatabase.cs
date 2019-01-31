using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// ISP Violation: A new Client doesn´t only want to Add something to somewhere, but also wants to read data from there.
/// All old Clients now have to implement the Read() method, but they don´t need that. ==> Don´t force someone to use
/// something they don´t need ==> Create new Interface and let User derive from both interfaces.
/// </summary>
namespace ISP.ISP_Violation
{
    public interface IDatabase
    {
        void Add();

        void Read();
    }
}
