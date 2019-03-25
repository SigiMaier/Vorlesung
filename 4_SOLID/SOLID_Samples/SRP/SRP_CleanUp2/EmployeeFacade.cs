using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.SRP_CleanUp2
{
    public class EmployeeFacade
    {
        private readonly EmployeeData employee = new EmployeeData();
        private readonly PayCalculator payCalculator = new PayCalculator();
        private readonly HourReporter hourReporter = new HourReporter();
        private readonly EmployeeSaver employeeSaver = new EmployeeSaver();

        public void CalculatePay()
        {
            this.employee.Pay = payCalculator.CalculatePay();
        }

        public void ReportHours()
        {
            this.employee.HoursReport = hourReporter.ReportHours();
        }

        public void Save()
        {
            employeeSaver.SaveEmployee(this.employee);
        }
    }
}
