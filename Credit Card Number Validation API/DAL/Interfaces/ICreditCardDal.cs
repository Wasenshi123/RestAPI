namespace Wasenshi.CreditCard.DAL.Interfaces
{
    public interface ICreditCardDal
    {
        bool CheckCardNumberExist(string cardNumber);
    }
}
