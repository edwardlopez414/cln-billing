using Microsoft.AspNetCore.Mvc;

namespace clnbilling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        [HttpPost]
        [Route("info")]
        public IActionResult Get_cliente()
        {
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update_client()
        {
            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete_cliente()
        {
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult register_cliente()
        {
            return Ok();
        }
    }
}
