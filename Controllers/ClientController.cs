using clnbilling.DataDTO;
using clnbilling.Models;
using clnbilling.settings;
using Microsoft.AspNetCore.Mvc;

namespace clnbilling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        CLNDbcontext.clnDbcontext clnDbcontext;
        Business_Logic businessLogic;
        public ClientController(CLNDbcontext.clnDbcontext clnDbcontext) 
        {
            this.clnDbcontext = clnDbcontext;
        }
        [HttpPost]
        [Route("info")]
        public IActionResult Get_cliente(SearchClientDTO model)
        {
            //etapa 1 creamos instancias
            businessLogic = new Business_Logic();                                   //clase encargada de encapsular la logica de negocio
            Repository repository = new Repository(clnDbcontext);                   //clase encargada de llevar el control de las interacciones con DB
            List<Client> list_clients = new List<Client>();
            bool validate_select = false;
            ErrorModel error = new ErrorModel();

            //etapa 2 validamos el model del request que estamos obteniendo
            (error, bool validate,string search_criteria) = businessLogic.Validate_model(model);        

            if (validate) return BadRequest(error);

            //etapa 3 buscamos de acuerdo al criterio
            if(search_criteria == "all")  (list_clients, error, validate_select) = repository.select_all();
            if (search_criteria == "code") (list_clients, error, validate_select) = repository.select_client_by_code(model.code!);
            if (search_criteria == "name") (list_clients, error, validate_select) = repository.select_client_by_name(model);
            if (validate_select) return BadRequest(error);

            //etapa 4 retornamos respuesta 200 Ok
            return Ok(list_clients);
        }

        [HttpPost]
        [Route("update_by_code")]
        public IActionResult Update_by_code(UpdateClientDTO model)
        {
            businessLogic = new Business_Logic();                                   //clase encargada de encapsular la logica de negocio
            Repository repository = new Repository(clnDbcontext);                   //clase encargada de llevar el control de las interacciones con DB
            ErrorModel error = new ErrorModel();

            //validamos el request recibido
            (error, bool validate) = businessLogic.Validate_model(model);
            if (validate) return BadRequest(error);

            //buscamos si existe el cliente
            (var client,error,validate) = repository.select_client_by_code(model.code!); //obtenemos el cliente

            if (validate) return BadRequest(error);                                      //validamos si obtuvimos error de DB 

            if (!client.Any())                                                            //validamos si obtuvimos respuesta
            {
                error.error_text= "user not found";
                error.status = "user not found";
               return BadRequest(error);
            }
                   //ajustamos el modelo del cliente
            var final_cclient = businessLogic.config_client(client.FirstOrDefault()!,model);
            (error, bool validate_insert) = repository.update_client(final_cclient);
            //finalmente realizamos el insert
            if (validate_insert) return BadRequest(error);
            //dado que no nos interesa la data del cliente que acabamos de registrar solo retornamos un OK
            return Ok();
        }

        [HttpPost]
        [Route("delete_by_code")]
        public IActionResult Delete_by_code(DeleteClientDTO model)
        {
            businessLogic = new Business_Logic();                                   //clase encargada de encapsular la logica de negocio
            Repository repository = new Repository(clnDbcontext);                   //clase encargada de llevar el control de las interacciones con DB
            ErrorModel error = new ErrorModel();

            //validamos el request recibido
            (error, bool validate) = businessLogic.Validate_model(model);
            if (validate) return BadRequest(error);

            //buscamos si existe el cliente
            (var client, error, validate) = repository.select_client_by_code(model.code!); //obtenemos el cliente

            if (validate) return BadRequest(error);                                      //validamos si obtuvimos error de DB 

            if (!client.Any())                                                            //validamos si obtuvimos respuesta
            {
                error.error_text = "user not found";
                error.status = "user not found";
                return BadRequest(error);
            }
            (error, bool validate_delete_user) = repository.delete_client(client.FirstOrDefault()!);
            //finalmente realizamos el insert
            if (validate_delete_user) return BadRequest(error);
            //dado que no nos interesa la data del cliente que acabamos de registrar solo retornamos un OK
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult register_cliente(ClientDTO model)
        {
            businessLogic = new Business_Logic();                                   //clase encargada de encapsular la logica de negocio
            Repository repository = new Repository(clnDbcontext);                   //clase encargada de llevar el control de las interacciones con DB
            ErrorModel error = new ErrorModel();

            //validamos model 
            (error, bool validate) = businessLogic.Validate_model(model);
            if (validate) {return BadRequest(error); }

            //ajustamos el modelo del cliente
            var client = businessLogic.config_client(model);
            (error, bool validate_insert)= repository.save_client(client);
            //finalmente realizamos el insert
            if (validate_insert) return BadRequest(error);
            //dado que no nos interesa la data del cliente que acabamos de registrar solo retornamos un OK
            return Ok();
        }
    }
}
