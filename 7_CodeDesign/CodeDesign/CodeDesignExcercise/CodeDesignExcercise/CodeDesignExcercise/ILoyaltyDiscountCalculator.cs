namespace CodeDesignExcercise
{
    public interface ILoyaltyDiscountCalculator
    {
        decimal ApplyDiscount(decimal price, int timeOfHavingAccountInYears);
    }
}