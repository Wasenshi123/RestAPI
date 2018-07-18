namespace Wasenshi.CreditCard.DAL.Interfaces
{
    public interface ICreditCardRepository
    {
        bool CheckCardNumberExist(string cardNumber);
    }
}
