using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDesignExcercise
{
    public class DefaultLoyaltyDiscountCalculator : ILoyaltyDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price, int timeOfHavingAccountInYears)
        {
            decimal discountForLoyaltyInPercentage =
                (timeOfHavingAccountInYears > DiscountConstants.MAXIMUM_DISCOUNT_FOR_LOYALITY) ?
                (decimal)DiscountConstants.MAXIMUM_DISCOUNT_FOR_LOYALITY / 100 :
                (decimal)timeOfHavingAccountInYears / 100;

            return price - (discountForLoyaltyInPercentage * price);
        }
    }

}
