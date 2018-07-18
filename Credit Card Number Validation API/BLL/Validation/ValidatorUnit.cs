using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wasenshi.CreditCard.BLL.Validation
{
    public abstract class ValidatorUnit
    {

        public bool Validate(string cardNumber)
        {
            if (!ValidateUtils.IsDigitOnly(cardNumber))
            {
                throw new InvalidCastException($"Expected a valid string of pure numbers, but the value given was : {cardNumber}");
            }

            return ValidateCardNumber(cardNumber);
        }

        protected virtual bool ValidateCardNumber(string number)
        {
            return true;
        }
    }
}
