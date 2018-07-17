using System.Web.Http;
using Wasenshi.CreditCard.BLL.Interfaces;
using Wasenshi.CreditCard.Libs.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("CreditCard")]
    public class CreditCardValidationController : ApiController
    {
        private ICreditCardBll _creditCardBll;

        public CreditCardValidationController(ICreditCardBll creditCardBll)
        {
            _creditCardBll = creditCardBll;
        }

        [Route("Validate")]
        [HttpPost]
        public IHttpActionResult ValidateCard(Card card)
        {


            return Ok(new ValidateResult());
        }
    }
}
