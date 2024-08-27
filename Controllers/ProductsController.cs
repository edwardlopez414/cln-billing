using Microsoft.AspNetCore.Mvc;

namespace clnbilling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        [Route("info")]
        public IActionResult get_product()
        {
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update_product()
        {
            return Ok();
        }
        [HttpPost]
        [Route("delete")]
        public IActionResult Delete_product()
        {
            return Ok();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register()
        {
            return Ok();
        }
    }
}
