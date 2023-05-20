using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTOnlineBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompleteCheckoutController : ControllerBase
    {
        public CompleteCheckoutController() { }

        [HttpGet]
        public ActionResult ProcessRequest([FromQuery] string amazonCheckoutSessionId)
        {
            return Ok("URL: " + amazonCheckoutSessionId);
        }
    }
}
