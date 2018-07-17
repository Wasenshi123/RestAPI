using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("CreditCardApi")]
    public class CreditCardValidationController : ApiController
    {
        public IHttpActionResult Index()
        {

            return this.Ok();
        }
    }
}
