namespace SRP.SRP_CleanUp2
{
    public class EmployeeFacade
    {
        private EmployeeData employee = new EmployeeData();
        private PayCalculator payCalculator = new PayCalculator();
        private HourReporter hourReporter = new HourReporter();
        private EmployeeSaver employeeSaver = new EmployeeSaver();

        public void CalculatePay()
        {
            this.employee.Pay = this.payCalculator.CalculatePay();
        }

        public void ReportHours()
        {
            this.employee.HoursReport = this.hourReporter.ReportHours();
        }

        public void Save()
        {
            this.employeeSaver.SaveEmployee(this.employee);
        }
    }
}
