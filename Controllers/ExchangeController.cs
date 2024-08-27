using Microsoft.AspNetCore.Mvc;

namespace clnbilling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeController : ControllerBase
    {
        [HttpPost]
        [Route("info")]
        public IActionResult Get_exchange_rate()
        {
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update_exchange_rate()
        {
            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete_exchange_rate()
        {
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register_exchage_rate()
        {
            return Ok();
        }
    }
}
