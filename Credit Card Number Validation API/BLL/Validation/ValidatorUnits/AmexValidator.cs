using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wasenshi.CreditCard.Libs.Models;

namespace Wasenshi.CreditCard.BLL.Validation.ValidatorUnits
{
    public class AmexValidator : ValidatorUnit
    {
        public AmexValidator()
        {
            CardDigit = 15;
        }

        protected override bool ValidateCard(Card card)
        {
            return base.ValidateCard(card);
        }
    }
}
