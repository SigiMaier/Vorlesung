
using Employee.Contracts;

namespace GeneralManagement
{
    public class COO
    {
        private readonly IHourReporter hourReporter;

        public COO(IHourReporter hourReporter)
        {
            this.hourReporter = hourReporter;
        }


        public string GetEmployeeHourRating()
        {
            return this.hourReporter.ReportHours();
        }

    }
}
