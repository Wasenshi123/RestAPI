using System.Web.Http;
using System.Web.Http.Results;
using Wasenshi.CreditCard.BLL.Interfaces;
using Wasenshi.CreditCard.Libs.Enums;
using Wasenshi.CreditCard.Libs.Models;

namespace Wasenshi.CreditCard.WebAPI.Controllers
{
    [RoutePrefix("CreditCard")]
    public class CreditCardValidationController : ApiController
    {
        private readonly ICreditCardBll _creditCardBll;

        public CreditCardValidationController(ICreditCardBll creditCardBll)
        {
            _creditCardBll = creditCardBll;
        }

        [Route("Validate")]
        [HttpPost]
        public IHttpActionResult ValidateCard(Card card)
        {

            var result = _creditCardBll.ValidateCreditCard(card);

            return Ok(result);
        }
    }
}
