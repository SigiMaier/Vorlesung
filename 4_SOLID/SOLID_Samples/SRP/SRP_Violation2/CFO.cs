using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.SRP_Violation2
{
    public class CFO
    {
        public void CalculateEmployeePay()
        {
            Employee employee = new Employee();
            double pay = employee.CalculatePay();
        }
    }
}
