using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Samples
{
    public class Customer : IDatabase, IDiscount
    {
        private ILogger log;

        public Customer(ILogger logger)
        {
            this.log = logger;
        }

        public virtual double GetDiscount(double totalSales)
        {
            return totalSales;
        }

        public virtual void Add()
        {
            try
            {
                // Database, logic code or whatever
            }
            catch (Exception ex)
            {
                log.Handle(ex.ToString());
            }
        }
    }
    public class SilverCustomer : Customer
    {
        public SilverCustomer(ILogger logger) : base(logger)
        {
        }

        public override void Add()
        {
            base.Add();
        }

        public override double GetDiscount(double totalSales)
        {
            return base.GetDiscount(totalSales) - 50;
        }
    }
    public class GoldCustomer : Customer
    {
        public GoldCustomer(ILogger logger) : base(logger)
        {
        }

        public override void Add()
        {
            base.Add();
        }

        public override double GetDiscount(double totalSales)
        {
            return base.GetDiscount(totalSales) - 100;
        }
    }

    public class CustomerWithReadFunction : IDatabaseWithRead
    {
        public void Add()
        {
            Customer customer = new Customer(new EmailLogger());

            customer.Add();
        }

        public void Read()
        {
            // Read logic
        }
    }



    public class Enquiry : IDiscount
    {
        public double GetDiscount(double totalSales)
        {
            return totalSales - 5;
        }
    }
}
