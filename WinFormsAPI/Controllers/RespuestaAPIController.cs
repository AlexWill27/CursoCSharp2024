using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WinFormsAPI.Models;
using System.Net.Http;


namespace WinFormsAPI.Controllers
{
    public class RespuestaAPIController
    {
        //private HttpClient client;: Campo que representa un cliente HTTP para realizar solicitudes.
        private HttpClient client;

        //public RespuestaAPIController(): Constructor de la clase. Inicializa el campo client como una nueva instancia de HttpClient.
        public RespuestaAPIController()
        {
            
            client = new HttpClient();

        }


        //Método GetAllResponseAPI:

        //public async Task<List<RespuestaAPI>> GetAllResponseAPI(): Método asincrónico que devuelve una lista de objetos RespuestaAPI y se comunica con una API.

        public async Task<List<RespuestaAPI>> GetAllResponseAPI()
        {

            try
            {
                //List<RespuestaAPI> responseAPI = new List<RespuestaAPI>();: Inicializa una lista para almacenar las respuestas de la API.

                List<RespuestaAPI> responseAPI = new List<RespuestaAPI>();

                //HttpResponseMessage response = await client.GetAsync("https://localhost:7127/api/Almacen");: Realiza una solicitud GET a la API especificada y
                //guarda la respuesta en response.

                HttpResponseMessage response = await client.GetAsync("https://localhost:7127/api/Almacen");

                //response.EnsureSuccessStatusCode();: Asegura que la solicitud fue exitosa; de lo contrario, lanza una excepción.

                response.EnsureSuccessStatusCode();

                //string responseJson = await response.Content.ReadAsStringAsync();: Lee el contenido de la respuesta como una cadena JSON.
                //La serialización es el proceso de convertir un objeto en un formato que pueda ser fácilmente almacenado o transmitido y, en el contexto del intercambio
                //de datos en aplicaciones, a menudo se refiere a la conversión de objetos en formato JSON.

                string responseJson = await response.Content.ReadAsStringAsync();

                //responseAPI = JsonConvert.DeserializeObject<List<RespuestaAPI>>(responseJson);: Deserializa la cadena JSON en una lista de objetos RespuestaAPI.

                responseAPI = JsonConvert.DeserializeObject<List<RespuestaAPI>>(responseJson);

                return responseAPI;   //return responseAPI;: Devuelve la lista de respuestas de la API.

            }

            //catch (Exception ex) { throw new Exception("Se produjo una excepción: " + ex.Message); }: Captura excepciones y las lanza con un mensaje descriptivo.
            catch (Exception ex)
            {

                throw new Exception("Se produjo una excepcion: " + ex.Message); 
            }

        }


    }
}

//En resumen, esta clase RespuestaAPIController está diseñada para interactuar con una API, realizar una solicitud GET, y deserializar la respuesta JSON en una lista de
//objetos RespuestaAPI. La excepción se maneja y lanza con un mensaje específico en caso de errores.