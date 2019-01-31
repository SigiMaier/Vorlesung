using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Samples
{
    public interface IDiscount
    {
        double GetDiscount(double totalSales);
    }

    public interface IDatabase
    {
        void Add();
    }

    public interface IDatabaseWithRead : IDatabase
    {
        void Read();
    }

}
