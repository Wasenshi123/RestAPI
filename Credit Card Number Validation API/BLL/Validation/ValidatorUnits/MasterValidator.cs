using Wasenshi.CreditCard.Libs.Models;

namespace Wasenshi.CreditCard.BLL.Validation.ValidatorUnits
{
    public class MasterValidator : ValidatorUnit
    {
        protected override bool ValidateCard(Card card)
        {
            if (!ValidateUtils.IsPrimeNumber(card.ExpiryDate.Year))
            {
                return false;
            }
            return base.ValidateCard(card);
        }
    }
}
