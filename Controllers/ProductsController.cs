using clnbilling.CLNDbcontext;
using clnbilling.DataDTO;
using clnbilling.Models;
using clnbilling.settings;
using Microsoft.AspNetCore.Mvc;

namespace clnbilling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        CLNDbcontext.clnDbcontext clnDbcontext;
        Business_Logic businessLogic;
        public ProductsController(CLNDbcontext.clnDbcontext clnDbcontext)
        {
            this.clnDbcontext = clnDbcontext;
        }
        [HttpPost]
        [Route("info")]
        public IActionResult get_product(ProductDTO model)
        {
            businessLogic = new Business_Logic();                                   //clase encargada de encapsular la logica de negocio
            Repository repository = new Repository(clnDbcontext);                   //clase encargada de llevar el control de las interacciones con DB
            ErrorModel error = new ErrorModel();
            List<Product> list_product = new List<Product>();

            (list_product, error, bool validate) = repository.select_product(model.sku, model.is_active);

            if (validate) return BadRequest(error);

            if (!list_product.Any())
            {
                error.error_text = "The specified product does not exis";
                error.status = "not found";
                return BadRequest(error);
            }

            return Ok(list_product);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update_product(UpdateProductsDTO model)
        {
            businessLogic = new Business_Logic();                                   //clase encargada de encapsular la logica de negocio
            Repository repository = new Repository(clnDbcontext);                   //clase encargada de llevar el control de las interacciones con DB
            ErrorModel error = new ErrorModel();
            List<Product> list_product = new List<Product>();

            (list_product, error, bool validate) = repository.select_product(model.sku!, model.is_active);

            if (validate) return BadRequest(error);

            if (!list_product.Any())
            {
                error.error_text = "The specified product does not exis";
                error.status = "not found";
                return BadRequest(error);
            }

            var final_product = businessLogic.config_product(list_product.FirstOrDefault(), model);

            (error, bool validate_update_products) = repository.update_product(final_product);
            if (validate_update_products) return BadRequest(error);
            return Ok();
        }
        [HttpPost]
        [Route("delete")]
        public IActionResult Delete_product(ProductDTO model)
        {
            businessLogic = new Business_Logic();                                   //clase encargada de encapsular la logica de negocio
            Repository repository = new Repository(clnDbcontext);                   //clase encargada de llevar el control de las interacciones con DB
            ErrorModel error = new ErrorModel();
            List<Product> list_product = new List<Product>();

            (list_product, error, bool validate) = repository.select_product(model.sku!, model.is_active);

            if (validate) return BadRequest(error);

            if (!list_product.Any())
            {
                error.error_text = "The specified product does not exis";
                error.status = "not found";
                return BadRequest(error);
            }

            (error, bool validate_update_products) = repository.delete_product(list_product.FirstOrDefault()!);
            if (validate_update_products) return BadRequest(error);
            return Ok();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(InsertProductDTO model)
        {
            businessLogic = new Business_Logic();                                   //clase encargada de encapsular la logica de negocio
            Repository repository = new Repository(clnDbcontext);                   //clase encargada de llevar el control de las interacciones con DB
            ErrorModel error = new ErrorModel();
            List<Product> list_product = new List<Product>();

            (list_product, error, bool validate) = repository.select_product(model.sku!, model.is_active);

            if (validate) return BadRequest(error);

            if (list_product.Any())
            {
                error.error_text = "The product is already registered";
                error.status = "";
                return BadRequest(error);
            }

            var final_product = businessLogic.config_product(model);

            (error, bool validate_update_products) = repository.update_product(final_product);
            if (validate_update_products) return BadRequest(error);
            return Ok();
        }
    }
}
