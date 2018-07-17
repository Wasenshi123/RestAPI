namespace DAL.Interfaces
{
    public interface ICreditCardDal
    {
        bool CheckCardNumberExist(string cardNumber);
    }
}
