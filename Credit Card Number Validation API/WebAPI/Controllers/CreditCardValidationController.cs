using System.Web.Http;

namespace WebAPI.Controllers
{
    public class CreditCardValidationController : ApiController
    {
        public IHttpActionResult Index()
        {

            return this.Ok();
        }
    }
}
