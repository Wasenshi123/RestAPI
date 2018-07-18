using System;
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

        public static bool IsPrimeNumber(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
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
                else if(cardNumber.Length == 16)
                {
                    // JCB
                    cardType = CardTypeEnum.JCB;
                }
            }
            return cardType;
        }
    }
}
