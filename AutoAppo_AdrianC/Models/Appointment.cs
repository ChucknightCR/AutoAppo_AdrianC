using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoAppo_AdrianC.Models
{
    public class Appointment
    {


        public RestRequest Request { get; set; }
        public int AppointmentId { get; set; }
        public DateTime AppoDate { get; set; }
        public int AppoStart { get; set; }
        public int AppoEnd { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Notes { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public int ScheduleId { get; set; }
        public int AppoStatusId { get; set; }

        public virtual AppoStatus AppoStatus { get; set; } = null!;
        public virtual Schedule Schedule { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
        public virtual User User { get; set; } = null!;

        //funciones

        public async Task<ObservableCollection<Appointment>> GetAppointmentListByUser()
        {
            try
            {

                //En APIConnection definimos un prefijo para la ruta de consumos de los 
                //end points. Acá tenemos que agregar el resto de la ruta para la función
                //que queremos usar dentro del controller

                string RouteSufix = string.Format("Appointments/GetAppointmentListByUSer?pUserID={0}",
                                                  this.UserId);

                //con esto obtenemos la ruta completa de consumo del API 
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos la info de la llave de seguridad (ApiKey) 
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //ejecución de la llamada al controlador 
                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    //Las colecciones sirven para la mayoria ed controles (vistas) que administran listas
                    //Como listview, collectionview, varrousel, etc


                    var AppoList = JsonConvert.DeserializeObject<ObservableCollection<Appointment>>(response.Content);
                    return AppoList;
                }
                else
                {
                    return null;
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
