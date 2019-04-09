using Employee;
using Employee.Contracts;
using GeneralManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeSaver employeeSaver = new EmployeeSaver();
            IEmployeeSaver employeeSaver2 = new EmployeeSaver2();
            CTO cto = new CTO(employeeSaver2);
        }
    }
}
