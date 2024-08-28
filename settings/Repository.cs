using clnbilling.CLNDbcontext;
using clnbilling.DataDTO;
using clnbilling.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace clnbilling.settings
{
    public class Repository
    {
        clnDbcontext dbcontext;
        public Repository(clnDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        #region metodos de interaccion con Db concerniente a client
        public (ErrorModel, bool) save_client(Client model)
        {
            ErrorModel error = new ErrorModel();
            try 
            {
                dbcontext.Client.Add(model);
                dbcontext.SaveChanges();
                return (error, false);
            }catch
            (Exception ex)
            {
                error.error_text = ex.Message;
                error.status = ex.Source;
                return (error, true);
            }
        }
        public (ErrorModel, bool) update_client(Client model)
        {
            ErrorModel error = new ErrorModel();
            try
            {
                dbcontext.Client.Update(model);
                dbcontext.SaveChanges();
                return (error, false);
            }
            catch
            (Exception ex)
            {
                error.error_text = ex.Message;
                error.status = ex.Source;
                return (error, true);
            }
        }
        public (List<Client>,ErrorModel, bool) select_client_by_code(string code)
        {
            ErrorModel error = new ErrorModel();
            try
            {
                var clients = dbcontext.Client.Where(c => c.code == code).ToList();
                return (clients, error, false);
            }
            catch
            (Exception ex)
            {
                List<Client> clients = new List<Client>();
                error.error_text = ex.Message;
                error.status = ex.Source;
                return (clients, error, true);
            }
        }
        public (List<Client>, ErrorModel, bool) select_client_by_name(SearchClientDTO model)
        {
            ErrorModel error = new ErrorModel();
            try
            {
                var clients = dbcontext.Client.Where(c => c.first_name == model.firt_name && c.middle_name == model.middle_name).ToList();
                return (clients, error, false);
            }
            catch
            (Exception ex)
            {
                List<Client> clients = new List<Client>();
                error.error_text = ex.Message;
                error.status = ex.Source;
                return (clients, error, true);
            }
        }

        public (List<Client>, ErrorModel, bool) select_all()
        {
            ErrorModel error = new ErrorModel();
            try
            {
                var clients = dbcontext.Client.ToList();
                return (clients, error, false);
            }
            catch
            (Exception ex)
            {
                List<Client> clients = new List<Client>();
                error.error_text = ex.Message;
                error.status = ex.Source;
                return (clients, error, true);
            }
        }
        public (ErrorModel, bool) delete_client(Client model)
        {
            ErrorModel error = new ErrorModel();
            try
            {
                dbcontext.Client.Remove(model);
                dbcontext.SaveChanges();
                return (error, false);
            }
            catch
            (Exception ex)
            {
                error.error_text = ex.Message;
                error.status = ex.Source;
                return (error, true);
            }
        }
        #endregion

        #region metodos de interaccion con Db concerniente a exchange_rate
        public (ErrorModel, bool) register_exchange_rate(Exchange_rate model)
        {
            ErrorModel error = new ErrorModel();
            try
            {
                dbcontext.Exchange_rate.Add(model);
                dbcontext.SaveChanges();
                return (error, false);
            }
            catch
            (Exception ex)
            {
                error.error_text = ex.Message;
                error.status = ex.Source;
                return (error, true);
            }
        }

        public (ErrorModel, bool) update_exchange_rate(Exchange_rate model)
        {
            ErrorModel error = new ErrorModel();
            try
            {
                dbcontext.Exchange_rate.Update(model);
                dbcontext.SaveChanges();
                return (error, false);
            }
            catch
            (Exception ex)
            {
                error.error_text = ex.Message;
                error.status = ex.Source;
                return (error, true);
            }
        }
    
        public (ErrorModel, bool) delete_exchange_rate(Exchange_rate model)
        {
            ErrorModel error = new ErrorModel();
            try
            {
                dbcontext.Exchange_rate.Remove(model);
                dbcontext.SaveChanges();
                return (error, false);
            }
            catch
            (Exception ex)
            {
                error.error_text = ex.Message;
                error.status = ex.Source;
                return (error, true);
            }
        }

        public (List<Exchange_rate>,ErrorModel, bool) select_exchange_rate_by_date(ExchangeSearchDTO model)
        {
            List<Exchange_rate> list_exchage = new List<Exchange_rate>();
            ErrorModel error = new ErrorModel();
            try
            {
                list_exchage = dbcontext.Exchange_rate
                    .Where(c => c.registered >= model.start_date && c.registered <= model.end_date)
                    .ToList();

                return (list_exchage,error,false);
            }
            catch
            (Exception ex)
            {
                error.error_text = ex.Message;
                error.status = ex.Source;
                return (list_exchage, error, true);
            }
        }
    }
        #endregion
}

