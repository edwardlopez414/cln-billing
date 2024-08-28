using clnbilling.CLNDbcontext;
using clnbilling.DataDTO;
using clnbilling.Models;
using clnbilling.settings;
using Microsoft.AspNetCore.Mvc;

namespace clnbilling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeController : ControllerBase
    {
        CLNDbcontext.clnDbcontext clnDbcontext;
        Business_Logic businessLogic;
        public ExchangeController(clnDbcontext clnDbcontext)
        {
            this.clnDbcontext = clnDbcontext;
        }
        [HttpPost]
        [Route("info")]
        public IActionResult Get_exchange_rate(ExchangeSearchDTO model)
        {
            businessLogic = new Business_Logic();                                   //clase encargada de encapsular la logica de negocio
            Repository repository = new Repository(clnDbcontext);                   //clase encargada de llevar el control de las interacciones con DB
            List<Exchange_rate> exchange_list = new List<Exchange_rate>();
            ErrorModel error = new ErrorModel();

            (exchange_list, error, bool validate) = repository.select_exchange_rate_by_date(model);
            if(validate)return BadRequest(error);


            return Ok(exchange_list);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update_exchange_rate(ExchangeDTO model)
        {
            businessLogic = new Business_Logic();                                   //clase encargada de encapsular la logica de negocio
            Repository repository = new Repository(clnDbcontext);                   //clase encargada de llevar el control de las interacciones con DB
            List<Exchange_rate> exchange_list = new List<Exchange_rate>();
            ErrorModel error = new ErrorModel();

            (error, bool validate_model) = businessLogic.Validate_model(model);
            if (validate_model) return BadRequest(error);

            //creamos un objeto de busqueda de exchange
            ExchangeSearchDTO exchange_search = new ExchangeSearchDTO 
            {
                start_date = model.registered,
                end_date = model.registered.AddDays(1).AddTicks(-1)
            };
            
            //buscamos el exchange
            (exchange_list, error, bool validate_exchange) = repository.select_exchange_rate_by_date(exchange_search);
            if(validate_exchange)return BadRequest(error);

            if (!exchange_list.Any())
            {
                error.error_text = "There is no rate configured for the specified day";
                error.status = "not found";
                return BadRequest(error);
            }

            var final_exchange = businessLogic.config_exchange(exchange_list.FirstOrDefault()!, model);

            (error, bool validate) = repository.update_exchange_rate(final_exchange);
            if(validate)return BadRequest(error);

            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete_exchange_rate(ExchangeDTO model)
        {
            businessLogic = new Business_Logic();                                   //clase encargada de encapsular la logica de negocio
            Repository repository = new Repository(clnDbcontext);                   //clase encargada de llevar el control de las interacciones con DB
            List<Exchange_rate> exchange_list = new List<Exchange_rate>();
            ErrorModel error = new ErrorModel();

            (error, bool validate_model) = businessLogic.Validate_model(model);
            if(validate_model) return BadRequest(error);

            //creamos un objeto de busqueda de exchange
            ExchangeSearchDTO exchange_search = new ExchangeSearchDTO
            {
                start_date = model.registered,
                end_date = model.registered.AddDays(1).AddTicks(-1)
            };

            //buscamos el exchange
            (exchange_list, error, bool validate_exchange) = repository.select_exchange_rate_by_date(exchange_search);
            if (validate_exchange) return BadRequest(error);

            if (!exchange_list.Any())
            {
                error.error_text = "There is no rate configured for the specified day";
                error.status = "not found";
                return BadRequest(error);
            }

            var final_exchange = businessLogic.config_exchange(exchange_list.FirstOrDefault()!, model);

            (error, bool validate) = repository.delete_exchange_rate(final_exchange);
            if (validate) return BadRequest(error);

            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register_exchage_rate(ExchangeDTO model)
        {
            businessLogic = new Business_Logic();                                   //clase encargada de encapsular la logica de negocio
            Repository repository = new Repository(clnDbcontext);                   //clase encargada de llevar el control de las interacciones con DB
            List<Exchange_rate> exchange_list = new List<Exchange_rate>();
            ErrorModel error = new ErrorModel();
            (error, bool validate_model) = businessLogic.Validate_model(model);
            if (validate_model) return BadRequest(error);
            var final_exchange = businessLogic.config_exchange(model);

            (error, bool validate) = repository.register_exchange_rate(final_exchange);
            if(validate)return BadRequest(error);
            return Ok();
        }
    }
}
