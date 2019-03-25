using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.SRP_Violation2
{
    public class COO
    {
        public void ReportEmployeeHours()
        {
            Employee employee = new Employee();
            string report = employee.ReportHours();
        }
    }
}
