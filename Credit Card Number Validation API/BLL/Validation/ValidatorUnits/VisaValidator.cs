using System;
using Wasenshi.CreditCard.Libs.Models;

namespace Wasenshi.CreditCard.BLL.Validation.ValidatorUnits
{
    public class VisaValidator : ValidatorUnit
    {
        protected override bool ValidateCard(Card card)
        {
            if (!DateTime.IsLeapYear(card.ExpiryDate.Year))
            {
                return false;
            }
            return base.ValidateCard(card);
        }
    }
}
