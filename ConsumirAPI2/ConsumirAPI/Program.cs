// See https://aka.ms/new-console-template for more information


using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ConsumirAPI.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic;

class Program
{

    // Reemplaza esta cadena de conexión con la tuya
    static string connectionString = "Server=DESKTOP-GLVK46U;Database=Almacenamiento;Integrated Security=True";
    static RespuestaAPI? respuesta  = null;

    static async Task Main(string[] args)
    {
        string dateFormat = "yyyy-MM-ddTHH:mm:ss"; // Declarar dateFormat aquí
        var url = "https://a33.wms.ocs.oraclecloud.com/holascharff/wms/lgfapi/v10/entity/item/?company_id__code=BBVA&create_ts__gt=2020-01-01T11:42:40&create_ts__lt=2023-11-18T11:42:40&values_list=item_alternate_code,description,create_ts&page_size=1000";
        RespuestaAPI respuestaAPI = null;

        using (var client = new HttpClient())
        {
            var username = "integracion";
            var password = "inicio01";
            var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

            client.Timeout = TimeSpan.FromSeconds(30);

         

            try
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    // Imprime la respuesta JSON antes de intentar deserializarla
                    Console.WriteLine("Respuesta JSON:");
                    Console.WriteLine(content);

                    // Intenta deserializar usando Newtonsoft.Json
                    respuestaAPI = JsonConvert.DeserializeObject<RespuestaAPI>(content);

                    // ... Resto del código ...

                    Console.WriteLine($"{respuestaAPI.result_count} {respuestaAPI.page_count} {respuestaAPI.page_nbr} {respuestaAPI.next_page}");

                    foreach (var item in respuestaAPI.results)
                    {
                        Console.WriteLine($"{item.item_alternate_code} {item.description} {item.create_ts}");
                    }

                    // Mover la lógica de la base de datos aquí dentro del bloque using
                    using (SqlConnection connection = new Conexion(connectionString).CrearConexion())
                    {
                        
                        try
                        {
                            // Abrir la conexión
                            connection.Open();
                            Console.WriteLine("Conexión a la base de datos abierta correctamente.");

                            // Iterar sobre los resultados de la API y llamar al procedimiento almacenado
                            foreach (var item in respuestaAPI.results)
                            {
                                // Convertir la cadena a DateTime

                                DateTime createTs;

                                if (DateTime.TryParseExact(item.create_ts.ToString(dateFormat), dateFormat, null, System.Globalization.DateTimeStyles.None, out createTs))
                                {
                                    // Llamada al procedimiento almacenado para la tabla 'results'
                                    InsertarDatosEnBD(connection, item.item_alternate_code, item.description, createTs);

                                    // Llamada al nuevo procedimiento almacenado para la tabla 'RespuestaAPI'
                                    InsertarDatosEnRespuestaAPI(connection, respuestaAPI.result_count, respuestaAPI.page_count, respuestaAPI.page_nbr, respuestaAPI.next_page);
                                }
                                else
                                {
                                    Console.WriteLine($"Error al convertir 'create_ts' a DateTime para el item {item.item_alternate_code}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            Console.WriteLine($"Error al abrir la conexión: {ex.Message}");
                        }
                        finally
                        {
                            Conexion.CerrarConexion(connection); // Cierra la conexión de manera segura
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
            }

            Console.ReadKey();

           
        }




        // ...

        // Método para llamar al procedimiento almacenado InsertarDatosDesdeAPI:
        static void InsertarDatosEnBD(SqlConnection connection, string itemAlternateCode, string description, DateTime createTs)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("InsertarDatosDesdeAPI", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@item_alternate_code", itemAlternateCode);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@create_ts", createTs);

                    // Ejecutar el procedimiento almacenado
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar datos: {ex.Message}");
            }
        }




        // Método para llamar al procedimiento almacenado InsertarDatosEnRespuestaAPI:


        static void InsertarDatosEnRespuestaAPI(SqlConnection connection, int resultCount, int pageCount, int pageNbr, string nextPage)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("InsertarDatosEnRespuestaAPI", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@result_count", resultCount);
                    command.Parameters.AddWithValue("@page_count", pageCount);
                    command.Parameters.AddWithValue("@page_nbr", pageNbr);
                    command.Parameters.AddWithValue("@next_page", nextPage);

                    // Ejecutar el procedimiento almacenado
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar datos en RespuestaAPI: {ex.Message}");
            }
        }





    }







}


 

