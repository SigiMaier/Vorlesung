using Employee.Contracts;

namespace Employee
{
    public class PayCalculator : IPayCalculator
    {
        public double CalculatePay()
        {
            var hours = CalculateRealHours();
            return 100.0;
        }

        private double CalculateRealHours()
        {
            return 2;
        }

    }
}
