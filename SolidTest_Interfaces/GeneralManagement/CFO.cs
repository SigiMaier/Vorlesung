
using Employee.Contracts;

namespace GeneralManagement
{
    public class CFO
    {
        private readonly IPayCalculator payCalculator;

        public CFO(IPayCalculator payCalculator)
        {
            this.payCalculator = payCalculator;
        }

        public double GetEmployeeHourRating()
        {
            return payCalculator.CalculatePay();
        }

    }
}
