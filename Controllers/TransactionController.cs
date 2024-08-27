using Microsoft.AspNetCore.Mvc;

namespace clnbilling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        [Route("Invoice")]
        public IActionResult Invoice()
        {
           return Ok();
        }

        [HttpPost]
        [Route("Report")]
        public IActionResult Report()
        {
            return Ok();
        }
    }
}
