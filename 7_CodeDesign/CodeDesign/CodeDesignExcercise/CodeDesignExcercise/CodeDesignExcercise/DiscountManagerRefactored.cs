using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDesignExcercise
{
    public class Class2
    {
        public decimal Calculate(decimal amount, int type, int years)
        {
            decimal result = 0;
            decimal disc = (years > 5) ? (decimal)5 / 100 : (decimal)years / 100;
            if (type == 1)
            {
                result = amount;
            }
            else if (type == 2)
            {
                result = (amount - (0.1m * amount)) - disc * (amount - (0.1m * amount));
            }
            else if (type == 3)
            {
                result = (0.7m * amount) - disc * (0.7m * amount);
            }
            else if (type == 4)
            {
                result = (amount - (0.5m * amount)) - disc * (amount - (0.5m * amount));
            }
            return result;
        }
    }

    // Step 1: Naming
    public class DiscountManager
    {
        public decimal ApplyDiscount(decimal price, int accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > 5) ? (decimal)5 / 100 : (decimal)timeOfHavingAccountInYears / 100;
            if (accountStatus == 1)
            {
                priceAfterDiscount = price;
            }
            else if (accountStatus == 2)
            {
                priceAfterDiscount = (price - (0.1m * price)) - (discountForLoyaltyInPercentage * (price - (0.1m * price)));
            }
            else if (accountStatus == 3)
            {
                priceAfterDiscount = (0.7m * price) - (discountForLoyaltyInPercentage * (0.7m * price));
            }
            else if (accountStatus == 4)
            {
                priceAfterDiscount = (price - (0.5m * price)) - (discountForLoyaltyInPercentage * (price - (0.5m * price)));
            }

            return priceAfterDiscount;
        }
    }

    // Step 2: Magic Numbers

    public class DiscountManagerMagicNumbers
    {
        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > 5) ? (decimal)5 / 100 : (decimal)timeOfHavingAccountInYears / 100;

            if (accountStatus == AccountStatus.NotRegistered)
            {
                priceAfterDiscount = price;
            }
            else if (accountStatus == AccountStatus.SimpleCustomer)
            {
                priceAfterDiscount = (price - (0.1m * price)) - (discountForLoyaltyInPercentage * (price - (0.1m * price)));
            }
            else if (accountStatus == AccountStatus.ValuableCustomer)
            {
                priceAfterDiscount = (0.7m * price) - (discountForLoyaltyInPercentage * (0.7m * price));
            }
            else if (accountStatus == AccountStatus.MostValuableCustomer)
            {
                priceAfterDiscount = (price - (0.5m * price)) - (discountForLoyaltyInPercentage * (price - (0.5m * price)));
            }
            return priceAfterDiscount;
        }
    }

    // Step 3: Lesbarkeit

    public class DiscountManagerReadable
    {
        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > 5) ? (decimal)5 / 100 : (decimal)timeOfHavingAccountInYears / 100;

            switch (accountStatus)
            {
                case AccountStatus.NotRegistered:
                    priceAfterDiscount = price;
                    break;
                case AccountStatus.SimpleCustomer:
                    priceAfterDiscount = (price - (0.1m * price));
                    priceAfterDiscount = priceAfterDiscount - (discountForLoyaltyInPercentage * priceAfterDiscount);
                    break;
                case AccountStatus.ValuableCustomer:
                    priceAfterDiscount = (0.7m * price);
                    priceAfterDiscount = priceAfterDiscount - (discountForLoyaltyInPercentage * priceAfterDiscount);
                    break;
                case AccountStatus.MostValuableCustomer:
                    priceAfterDiscount = (price - (0.5m * price));
                    priceAfterDiscount = priceAfterDiscount - (discountForLoyaltyInPercentage * priceAfterDiscount);
                    break;
            }
            return priceAfterDiscount;
        }
    }

    // Step 4: Bugfix Not Available AccountStatus

    public class DiscountManagerBugFix
    {
        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > 5) ?
                (decimal)5 / 100 : (decimal)timeOfHavingAccountInYears / 100;

            switch (accountStatus)
            {
                case AccountStatus.NotRegistered:
                    priceAfterDiscount = price;
                    break;
                case AccountStatus.SimpleCustomer:
                    priceAfterDiscount = (price - (0.1m * price));
                    priceAfterDiscount = priceAfterDiscount
                        - (discountForLoyaltyInPercentage * priceAfterDiscount);
                    break;
                case AccountStatus.ValuableCustomer:
                    priceAfterDiscount = (0.7m * price);
                    priceAfterDiscount = priceAfterDiscount
                        - (discountForLoyaltyInPercentage * priceAfterDiscount);
                    break;
                case AccountStatus.MostValuableCustomer:
                    priceAfterDiscount = (price - (0.5m * price));
                    priceAfterDiscount = priceAfterDiscount
                        - (discountForLoyaltyInPercentage * priceAfterDiscount);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return priceAfterDiscount;
        }
    }

    // Step 5: Adjust Calculation
    public class DiscountManagerCalculationAdjusted
    {
        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > 5) ?
                (decimal)5 / 100 : (decimal)timeOfHavingAccountInYears / 100;

            switch (accountStatus)
            {
                case AccountStatus.NotRegistered:
                    priceAfterDiscount = price;
                    break;
                case AccountStatus.SimpleCustomer:
                    priceAfterDiscount = (price - (0.1m * price));
                    priceAfterDiscount = priceAfterDiscount
                        - (discountForLoyaltyInPercentage * priceAfterDiscount);
                    break;
                case AccountStatus.ValuableCustomer:
                    priceAfterDiscount = (price - (0.3m * price));
                    priceAfterDiscount = priceAfterDiscount
                        - (discountForLoyaltyInPercentage * priceAfterDiscount);
                    break;
                case AccountStatus.MostValuableCustomer:
                    priceAfterDiscount = (price - (0.5m * price));
                    priceAfterDiscount = priceAfterDiscount
                        - (discountForLoyaltyInPercentage * priceAfterDiscount);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return priceAfterDiscount;
        }
    }

    // Step 5.1: Extract Calculation
    public class DiscountManagerExtractedCalcultaion
    {
        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > 5) ?
                (decimal)5 / 100 : (decimal)timeOfHavingAccountInYears / 100;

            switch (accountStatus)
            {
                case AccountStatus.NotRegistered:
                    priceAfterDiscount = price;
                    break;
                case AccountStatus.SimpleCustomer:
                    priceAfterDiscount =
                        CalculatePriceAfterDiscount(price, 0.1m, discountForLoyaltyInPercentage);
                    break;
                case AccountStatus.ValuableCustomer:
                    priceAfterDiscount =
                        CalculatePriceAfterDiscount(price, 0.3m, discountForLoyaltyInPercentage);
                    break;
                case AccountStatus.MostValuableCustomer:
                    priceAfterDiscount =
                        CalculatePriceAfterDiscount(price, 0.5m, discountForLoyaltyInPercentage);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return priceAfterDiscount;
        }

        private static decimal CalculatePriceAfterDiscount(
            decimal price,
            decimal discountForLoyaltyInPercentage,
            decimal discountRate)
        {
            decimal priceAfterDiscount = (price - (discountRate * price));

            priceAfterDiscount = priceAfterDiscount
                - (discountForLoyaltyInPercentage * priceAfterDiscount);

            return priceAfterDiscount;
        }
    }

    // Step 6: Magic Numbers to Constants
    public class DiscountManagerMagicNumbersToConstants
    {
        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;

            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > Constants.MAXIMUM_DISCOUNT_FOR_LOYALITY) ?
                (decimal)Constants.MAXIMUM_DISCOUNT_FOR_LOYALITY / 100 : (decimal)timeOfHavingAccountInYears / 100;

            switch (accountStatus)
            {
                case AccountStatus.NotRegistered:
                    priceAfterDiscount = price;
                    break;
                case AccountStatus.SimpleCustomer:
                    priceAfterDiscount =
                        CalculatePriceAfterDiscount(price, Constants.DISCOUNT_FOR_SIMPLE_CUSTOMERS, discountForLoyaltyInPercentage);
                    break;
                case AccountStatus.ValuableCustomer:
                    priceAfterDiscount =
                        CalculatePriceAfterDiscount(price, Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS, discountForLoyaltyInPercentage);
                    break;
                case AccountStatus.MostValuableCustomer:
                    priceAfterDiscount =
                        CalculatePriceAfterDiscount(price, Constants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS, discountForLoyaltyInPercentage);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return priceAfterDiscount;
        }

        private static decimal CalculatePriceAfterDiscount(
            decimal price,
            decimal discountForLoyaltyInPercentage,
            decimal discountRate)
        {
            decimal priceAfterDiscount = (price - (discountRate * price));

            priceAfterDiscount = priceAfterDiscount
                - (discountForLoyaltyInPercentage * priceAfterDiscount);

            return priceAfterDiscount;
        }
    }

    // Step 7: Final Step
    public class DiscountManagerFinal
    {
        private readonly IAccountDiscountCalculatorFactory factory;
        private readonly ILoyaltyDiscountCalculator loyaltyDiscountCalculator;

        public DiscountManager(IAccountDiscountCalculatorFactory factory, ILoyaltyDiscountCalculator loyaltyDiscountCalculator)
        {
            this.factory = factory;
            this.loyaltyDiscountCalculator = loyaltyDiscountCalculator;
        }

        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;
            priceAfterDiscount = factory.GetAccountDiscountCalculator(accountStatus).ApplyDiscount(price);
            priceAfterDiscount = loyaltyDiscountCalculator.ApplyDiscount(priceAfterDiscount, timeOfHavingAccountInYears);
            return priceAfterDiscount;
        }
    }
}
