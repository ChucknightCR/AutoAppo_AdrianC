using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoAppo_AdrianC.Models
{
    public  class User
    {
        public RestRequest Request { get; set; }
        const string MimeType = "application/json";
        const string ContentType = "Content-Type";

        public User()
        {
            
        }

        //atributos para la clase. En esteejemplo usarmeos los atributos identicos a la clase del app.
        //Posteriormente usaremos DTO

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LoginPassword { get; set; }
        public string CardId { get; set; }
        public string Address { get; set; }
        public int UserRoleId { get; set; }
        public int UserStatusId { get; set; }

        public virtual UserRole UserRole { get; set; }
        public virtual UserStatus UserStatus { get; set; }
        //public virtual ICollection<Appointment> Appointments { get; set; }
        
        
        //funciones
        public async Task<bool> ValidateLogin()
        {
            try
            {
                //En ApiConnection definimos un prefijo para la ruta de consumo de los end points
                //Acá tenemos que agregar el resto de la ruta para la función que queremos usar dentro del controller

                string RouterSuffix = string.Format("/Users/ValidateUserLogin?pUserName={0}&pPassword={1}",
                                                        this.Email, this.LoginPassword);

                //Con esto obtenemos la ruta completa de consumo del API
                string URL = Services.APIConnection.ProductionURLPrefix + RouterSuffix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //Agregamos la info de la llave de seguridad (API KEY)
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(ContentType, MimeType);

                //ejecución de la llamada al controlador
                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false; 
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;

                //almacenar registro de errores en una bitacora para analisis posterior
                //también puede ser enviarlos a un servidor de captura de errores

                throw;
            }


        }
    }
}
