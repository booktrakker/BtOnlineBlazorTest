using BTOnlineBlazor.Data;
using BTOnlineBlazor.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTOnlineBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAppListHandlerController : ControllerBase
    {
        
        private readonly ErrorReporterService errReport;
        private readonly AccountUtilitiesService _appManagerService;

        public GetAppListHandlerController(
        [FromServices] ErrorReporterService err,
        [FromServices] AccountUtilitiesService appManagerService

        )
        {
            
            errReport = err;
            _appManagerService = appManagerService;
        }

        [HttpGet]
        public ActionResult GetAppList([FromQuery] string AccountID)
        {
            string? result = _appManagerService.GetAccount(AccountID)?.AccountName;
            return Ok(result);
        }
    }
}
