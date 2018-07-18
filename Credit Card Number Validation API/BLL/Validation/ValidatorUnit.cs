using System;
using Wasenshi.CreditCard.Libs.Models;

namespace Wasenshi.CreditCard.BLL.Validation
{
    public abstract class ValidatorUnit
    {

        public bool Validate(Card card)
        {
            ValidateInput(card);
            return ValidateCard(card);
        }

        private void ValidateInput(Card card)
        {
            if (!ValidateUtils.IsDigitOnly(card.Number))
            {
                throw new InvalidCastException($"Expected a valid string of pure numbers, but the value given was : {card.Number}");
            }

            if (card.ExpiryDate < DateTime.UtcNow)
            {
                throw new ArgumentException($"The expiry date is invalid date. : {card.ExpiryDate}");
            }
        }

        protected virtual bool ValidateCard(Card card)
        {
            return true;
        }
    }
}
