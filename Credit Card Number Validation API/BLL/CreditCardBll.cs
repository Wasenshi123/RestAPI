using Wasenshi.CreditCard.BLL.Interfaces;
using Wasenshi.CreditCard.DAL.Interfaces;
using Wasenshi.CreditCard.Libs.Models;

namespace Wasenshi.CreditCard.BLL
{
    public class CreditCardBll : ICreditCardBll
    {
        private ICreditCardDal _dal;

        public CreditCardBll(ICreditCardDal creditCardDal)
        {
            _dal = creditCardDal;
        }

        public ValidateResult ValidateCreditCard(Card card)
        {

            return new ValidateResult();
        }
    }
}
