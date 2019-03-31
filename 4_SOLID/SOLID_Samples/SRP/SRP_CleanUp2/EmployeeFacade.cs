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
