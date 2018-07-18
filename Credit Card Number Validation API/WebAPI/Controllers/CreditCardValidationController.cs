using System;
using System.Data.Entity.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
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
            if (String.IsNullOrWhiteSpace(card.Number))
            {
                throw new ArgumentException("Card Number cannot be empty.");
            }

            var result = _creditCardBll.ValidateCreditCard(card);

            if (result.Result == ResultType.Invalid)
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
            if (result.Result == ResultType.DoesNotExist)
            {
                return Content(HttpStatusCode.NotFound, result);
            }

            return Ok(result);
        }
    }
}
