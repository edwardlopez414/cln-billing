using Microsoft.AspNetCore.Mvc;

namespace clnbilling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public IActionResult Register()
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
        [Route("delete_invoice")]
        public IActionResult Delete_invoice()
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
