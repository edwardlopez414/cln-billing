using clnbilling.DataDTO;
using clnbilling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace clnbilling.settings
{
    public class Business_Logic
    {
        private static Random random = new Random();
        #region area de sobrecarga de metodos validaciones de modelos
        public (ErrorModel, bool) Validate_model(ClientDTO model)
        {  
             string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
             string NumberPattern = @"^\d+$";
             ErrorModel error = new ErrorModel();
          
            if(string.IsNullOrEmpty(model.first_name))
            {
                error.status = "empty field";
                error.error_text = "the first_name field cannot be empty";
                return(error, true);
            }
            if (string.IsNullOrEmpty(model.middle_name))
            {
                error.status = "empty field";
                error.error_text = "the middle_name field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.last_name1))
            {
                error.status = "empty field";
                error.error_text = "the last_name1 field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.last_name2))
            {
                error.status = "empty field";
                error.error_text = "the last_name1 field cannot be empty";
                return (error, true);
            }
            if (model.age <= 17)
            {
                error.status = "empty field";
                error.error_text = "the age field must be greater than 17 years";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.country_id))
            {
                error.status = "empty field";
                error.error_text = "the country_id field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.state))
            {
                error.status = "empty field";
                error.error_text = "the state field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.address_line1))
            {
                error.status = "empty field";
                error.error_text = "the state field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.address_line2))
            {
                error.status = "empty field";
                error.error_text = "the state field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.email))
            {
                error.status = "empty field";
                error.error_text = "the state field cannot be empty";
                return (error, true);
            }
            // Validar el formato del email
            if (!Regex.IsMatch(model.email, EmailPattern))
            {
                error.status = "invalid format";
                error.error_text = "the email format is invalid";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.phone))
            {
                error.status = "empty field";
                error.error_text = "the phone field cannot be empty";
                return (error, true);
            }
            if (!Regex.IsMatch(model.phone, NumberPattern))
            {
                error.status = "invalid format";
                error.error_text = "the phone format is invalid";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.phone_extension))
            {
                error.status = "empty field";
                error.error_text = "the phone_extension field cannot be empty";
                return (error, true);
            }
            if (!Regex.IsMatch(model.phone_extension, NumberPattern))
            {
                error.status = "invalid format";
                error.error_text = "the phone_extension format is invalid";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.postal_code))
            {
                error.status = "empty field";
                error.error_text = "the phone_extension field cannot be empty";
                return (error, true);
            }

            return (error, false);

        }

        public (ErrorModel, bool, string) Validate_model(SearchClientDTO model)
        {
            ErrorModel error = new ErrorModel();

            if (model.search_all)
            {
                error.status = "empty field";
                error.error_text = "the country_id field cannot be empty";
                return (error, false, "all");
            }
            if (string.IsNullOrEmpty(model.country_id))
            {
                error.status = "empty field";
                error.error_text = "the country_id field cannot be empty";
                return (error, true , "");
            }

            if (string.IsNullOrEmpty(model.code)) // si code es vacio validamos los otros criterios de busqueda
            {
                if (!string.IsNullOrEmpty(model.firt_name) && !string.IsNullOrEmpty(model.middle_name)) 
                {
                    return (error, false, "name");
                }
                else
                {
                    error.status = "empty field";
                    error.error_text = "the firt_name field or middle_name field cannot be empty";
                    return (error, true, "");
                }
            }
            else 
            {
                return (error, false, "code");
            }
                       
        }

        public (ErrorModel, bool) Validate_model(UpdateClientDTO model)
        {
            string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            string NumberPattern = @"^\d+$";
            ErrorModel error = new ErrorModel();

            if (string.IsNullOrEmpty(model.code))
            {
                error.status = "empty field";
                error.error_text = "the code field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.first_name))
            {
                error.status = "empty field";
                error.error_text = "the first_name field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.middle_name))
            {
                error.status = "empty field";
                error.error_text = "the middle_name field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.last_name1))
            {
                error.status = "empty field";
                error.error_text = "the last_name1 field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.last_name2))
            {
                error.status = "empty field";
                error.error_text = "the last_name1 field cannot be empty";
                return (error, true);
            }
            if (model.age <= 17)
            {
                error.status = "empty field";
                error.error_text = "the age field must be greater than 17 years";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.country_id))
            {
                error.status = "empty field";
                error.error_text = "the country_id field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.state))
            {
                error.status = "empty field";
                error.error_text = "the state field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.address_line1))
            {
                error.status = "empty field";
                error.error_text = "the state field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.address_line2))
            {
                error.status = "empty field";
                error.error_text = "the state field cannot be empty";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.email))
            {
                error.status = "empty field";
                error.error_text = "the state field cannot be empty";
                return (error, true);
            }
            // Validar el formato del email
            if (!Regex.IsMatch(model.email, EmailPattern))
            {
                error.status = "invalid format";
                error.error_text = "the email format is invalid";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.phone))
            {
                error.status = "empty field";
                error.error_text = "the phone field cannot be empty";
                return (error, true);
            }
            if (!Regex.IsMatch(model.phone, NumberPattern))
            {
                error.status = "invalid format";
                error.error_text = "the phone format is invalid";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.phone_extension))
            {
                error.status = "empty field";
                error.error_text = "the phone_extension field cannot be empty";
                return (error, true);
            }
            if (!Regex.IsMatch(model.phone_extension, NumberPattern))
            {
                error.status = "invalid format";
                error.error_text = "the phone_extension format is invalid";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.postal_code))
            {
                error.status = "empty field";
                error.error_text = "the phone_extension field cannot be empty";
                return (error, true);
            }

            return (error, false);
        }

        public (ErrorModel, bool) Validate_model(DeleteClientDTO model)
        {
            ErrorModel error = new ErrorModel();
            if (string.IsNullOrEmpty(model.code))
            {
                error.status = "empty field";
                error.error_text = "the code field cannot be empty";
                return (error, true);
            }
            else
            {
                return (error, false);
            }
        }
        #endregion

        #region Validate para exchange
        public (ErrorModel, bool) Validate_model(ExchangeDTO model)
        {
            ErrorModel error = new ErrorModel();
            if (model.sale_rate > 0)
            {
                error.status = "empty field";
                error.error_text = "the field must be greater than zero";
                return (error, true);
            }
            if (string.IsNullOrEmpty(model.currency))
            {
                error.status = "empty field";
                error.error_text = "the currency field cannot be empty";
                return (error, true);
            }
            else
            {
                return (error, false);
            }
        }
        #endregion

        #region CONFIGURACION DE MODELOS
        public Client config_client(ClientDTO model)
        {
            Client client = new Client
            {
                code = GenerateCode(),
                first_name = model.first_name,
                middle_name = model.middle_name,
                last_name1 = model.last_name1,
                last_name2 = model.last_name2,
                age = model.age,
                country_id = model.country_id,
                state = model.state,
                address_line1 = model.address_line1,
                address_line2 = model.address_line2,
                email = model.email,
                phone = model.phone,
                phone_extension = model.phone_extension,
                postal_code = model.postal_code,
                is_active = true,
                created_date = DateTime.Now,    
                last_updated_date = DateTime.Now,
            };

            return client; 
        }

        public Client config_client(Client model, UpdateClientDTO model_update)
        {

            model.first_name = model_update.first_name;
            model.middle_name = model_update.middle_name;
            model.last_name1 = model_update.last_name1;
            model.last_name2 = model_update.last_name2;
            model.age = model_update.age;
            model.country_id = model_update.country_id;
            model.state = model_update.state;
            model.address_line1 = model_update.address_line1;
            model.address_line2 = model_update.address_line2;
            model.email = model_update.email;
            model.phone = model_update.phone;
            model.phone_extension = model_update.phone_extension;
            model.postal_code = model_update.postal_code;
            model.last_updated_date = DateTime.Now;
            return model;
        }
        #endregion


        public static string GenerateCode()
        {
            // Generar los 6 dígitos iniciales
            string firstPart = GenerateDigits(6);

            // Generar los 4 dígitos después del guion
            string secondPart = GenerateDigits(4);

            // Generar una letra aleatoria
            char letter = (char)random.Next('A', 'Z' + 1);

            // Construir el código final
            return $"{firstPart}-{secondPart}{letter}";
        }

        private static string GenerateDigits(int length)
        {
            char[] digits = new char[length];
            for (int i = 0; i < length; i++)
            {
                digits[i] = (char)random.Next('0', '9' + 1);
            }
            return new string(digits);
        }

        public Exchange_rate config_exchange( Exchange_rate exchange,ExchangeDTO model)
        {

            exchange.currency = model.currency;
            exchange.sale_rate = model.sale_rate;
            exchange.registered = DateTime.Now;

          
            return exchange;
        }
        public Exchange_rate config_exchange(ExchangeDTO model)
        {
            Exchange_rate exchange = new Exchange_rate
            {
                currency = model.currency,
                sale_rate = model.sale_rate,
                registered = DateTime.Now
            };

            return exchange;
        }

        internal Product config_product(Product? product, UpdateProductsDTO model)
        {

            product.sku = model.new_sku;
            product.name = model.name;
            product.description = model.description;
            product.country_id = model.country_id;
            product.currency = model.currency;
            product.amount = model.amount;
            product.is_active = model.is_active;
            product.units = model.units;
            return product;
        }

        internal Product config_product(InsertProductDTO model)
        {
            Product product = new Product
            {
                sku = model.sku,
                name = model.name,
                description = model.description,
                country_id = model.country_id,
                currency = model.currency,
                amount = model.amount,
                is_active = model.is_active,
                units = model.units
            };
            return product;
        }

        internal Product_view config_product(Product? product, decimal exchange)
        {

            Product_view view = new Product_view
            {
                sku = product.sku,
                name = product.name,
                description = product.description,
                country_id = product.country_id,
                currency = product.currency,
                amount = product.amount,
                is_active = product.is_active,
                units = product.units,
                currency2 = "USD",
                amount_2 = (product.currency == "NIO") ? (product.amount / exchange) : (product.amount * exchange)
            };
            return view;
        }
    }
}
