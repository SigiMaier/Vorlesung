namespace CodeDesignExcercise
{
    public interface IAccountDiscountCalculator
    {
        decimal ApplyDiscount(decimal price);
    }

    public class NotRegisteredDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price;
        }
    }

    public class SimpleCustomerDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price - (DiscountConstants.DISCOUNT_FOR_SIMPLE_CUSTOMERS * price);
        }
    }

    public class VideoSimpleCustomerDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price - 200;
        }
    }

    public class ValuableCustomerDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price - (DiscountConstants.DISCOUNT_FOR_VALUABLE_CUSTOMERS * price);
        }
    }

    public class MostValuableCustomerDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price - (DiscountConstants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS * price);
        }
    }
}