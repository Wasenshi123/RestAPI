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
                return new ValidateResult
                {
                    Result = ResultType.Invalid,
                    CardType = CardTypeEnum.Unknown
                };
            }

            bool exist = _repository.CheckCardNumberExist(card.Number);
            if (!exist)
            {
                return new ValidateResult
                {
                    Result = ResultType.DoesNotExist,
                    CardType = CardTypeEnum.Unknown
                };
            }
            

        }

        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if(c == '-')
                    continue;
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
