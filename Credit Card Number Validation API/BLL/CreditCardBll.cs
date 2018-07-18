using Wasenshi.CreditCard.BLL.Interfaces;
using Wasenshi.CreditCard.BLL.Validation;
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
            if (!ValidateUtils.IsDigitOnly(card.Number))
            {
                return ValidateResult.New(ResultType.Invalid, CardTypeEnum.Unknown);
            }

            card.Number = card.Number.Replace("-", "");
            ResultType result = ResultType.Invalid;
            CardTypeEnum cardType = ValidateUtils.GetCardType(card.Number);
            if(cardType != CardTypeEnum.Unknown)
            {
                ValidatorUnit validator = ValidatorFactory.GetValidator(cardType);
                if (validator.Validate(card))
                {
                    result = ResultType.Valid;
                }
            }

            bool exist = _repository.CheckCardNumberExist(card.Number);
            if (!exist)
            {
                result = ResultType.DoesNotExist;
            }

            return ValidateResult.New(result, cardType);
        }

        
    }
}
