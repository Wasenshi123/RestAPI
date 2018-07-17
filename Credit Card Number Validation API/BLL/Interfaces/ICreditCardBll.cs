using Wasenshi.CreditCard.Libs.Models;

namespace Wasenshi.CreditCard.BLL.Interfaces
{
    public interface ICreditCardBll
    {
        ValidateResult ValidateCreditCard(Card card);
    }
}
