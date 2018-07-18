using System.Linq;
using Wasenshi.CreditCard.Libs.Enums;

namespace Wasenshi.CreditCard.BLL
{
    public static class ValidateUtils
    {

        public static bool IsDigitOnly(string str, bool allowDash = true)
        {
            return str.All(c => char.IsDigit(c) || (allowDash ? c == '-' : false));
        }

        public static CardTypeEnum GetCardType(string cardNumber)
        {
            CardTypeEnum cardType = CardTypeEnum.Unknown;
            if (cardNumber.StartsWith("4"))
            {
                // Visa Card
                cardType = CardTypeEnum.Visa;
            }
            else if (cardNumber.StartsWith("5"))
            {
                // Master Card
                cardType = CardTypeEnum.Master; ;
            }
            else if (cardNumber.StartsWith("3"))
            {
                if (cardNumber.Length == 15)
                {
                    // Amex Card
                    cardType = CardTypeEnum.Amex;
                }
                else
                {
                    // JCB
                    cardType = CardTypeEnum.JCB;
                }
            }
            return cardType;
        }
    }
}
