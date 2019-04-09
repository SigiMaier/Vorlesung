using Employee.Contracts;

namespace Employee
{
    public class HourReporter : IHourReporter
    {
        public string ReportHours()
        {
            var hour = CalculateRealHours();
            return "Hours Report";
        }

        private double CalculateRealHours()
        {
            return 2;
        }
    }
}
