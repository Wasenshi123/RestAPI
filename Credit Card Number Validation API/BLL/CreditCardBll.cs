using System.Linq;
using Wasenshi.CreditCard.BLL.Interfaces;
using Wasenshi.CreditCard.DAL.Interfaces;
using Wasenshi.CreditCard.Libs.Enums;
using Wasenshi.CreditCard.Libs.Models;

namespace Wasenshi.CreditCard.BLL
{
    public class CreditCardBll : ICreditCardBll
    {
        private readonly ICreditCardRepository _repository;

        public CreditCardBll(ICreditCardRepository creditCardRepository)
        {
            _repository = creditCardRepository;
        }

        public ValidateResult ValidateCreditCard(Card card)
        {
            if (!IsDigitsOnly(card.Number))
            {
                return ValidateResult.New(ResultType.Invalid, CardTypeEnum.Unknown);
            }

            ResultType result = ResultType.Invalid;
            CardTypeEnum cardType = CardTypeEnum.Unknown;
            if (card.Number.StartsWith("4"))
            {
                // Visa Card
                cardType = CardTypeEnum.Visa;
            }
            else if (card.Number.StartsWith("5"))
            {
                // Master Card
                cardType = CardTypeEnum.Master;;
            }
            else if (card.Number.StartsWith("3"))
            {
                if (card.Number.Length == 15)
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

            bool exist = _repository.CheckCardNumberExist(card.Number);
            if (!exist)
            {
                result = ResultType.DoesNotExist;
            }

            return ValidateResult.New(result, cardType);
        }

        static bool IsDigitsOnly(string str)
        {
            return str.All(c => char.IsDigit(c) || c == '-');
        }
    }
}
