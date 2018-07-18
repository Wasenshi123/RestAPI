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
            var exist = _repository.CheckCardNumberExist(card.Number);
            return new ValidateResult
            {
                Result = exist?ResultType.Valid : ResultType.DoesNotExist,
                CardType = CardTypeEnum.Master
            };
        }
    }
}
