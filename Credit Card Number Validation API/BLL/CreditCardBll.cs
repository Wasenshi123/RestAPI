using Wasenshi.CreditCard.BLL.Interfaces;
using Wasenshi.CreditCard.DAL.Interfaces;
using Wasenshi.CreditCard.Libs.Models;

namespace Wasenshi.CreditCard.BLL
{
    public class CreditCardBll : ICreditCardBll
    {
        private ICreditCardRepository _repository;

        public CreditCardBll(ICreditCardRepository creditCardRepository)
        {
            _repository = creditCardRepository;
        }

        public ValidateResult ValidateCreditCard(Card card)
        {

            return new ValidateResult();
        }
    }
}
