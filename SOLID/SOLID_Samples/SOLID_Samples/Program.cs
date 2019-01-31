using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IDatabase> customers = new List<IDatabase>();

            customers.Add(new GoldCustomer(new EmailLogger()));
            customers.Add(new SilverCustomer(new EventViewerLogger()));




            IDatabase customer = new Customer(new FileLogger());


            customer.Add();

            IDatabaseWithRead customerWithRead = new CustomerWithReadFunction();
            customerWithRead.Read();
            customerWithRead.Add();





            //foreach (Customer customer in customers)
            //{
            //    customer.Add();
            //}
        }
    }
}
