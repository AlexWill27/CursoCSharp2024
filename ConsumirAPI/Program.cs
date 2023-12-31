<<<<<<< HEAD
﻿// See https://aka.ms/new-console-template for more information


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





=======
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;
using ConsumirAPI.Models;

class Program
{
    static async Task Main()
    {
        
        
            // Step 1: Get data from the API
            await ProcessApiData();
            Console.WriteLine("Process completed.");
        
    }



    static async Task ProcessApiData()
    {
        List<results> allResults = new List<results>();

        // Fetch the first page
        ApiResponse apiResponse = await GetDataFromApi();

        // Process the first page
        await SaveDataToDatabase(apiResponse);

        // Add results to the list
        allResults.AddRange(apiResponse.results);

        // Continue fetching and processing subsequent pages
        while (!string.IsNullOrEmpty(apiResponse.next_page))
        {
            apiResponse = await GetDataFromApi(apiResponse.next_page);
            await SaveDataToDatabase(apiResponse);
            allResults.AddRange(apiResponse.results);
        }
    }



    static async Task<ApiResponse> GetDataFromApi(string apiUrl = null)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                // Use the provided apiUrl if available, otherwise use the default URL
                apiUrl ??= "https://a33.wms.ocs.oraclecloud.com/holascharff/wms/lgfapi/v10/entity/item/?company_id__code=BBVA&create_ts__gt=2020-01-01T11:42:40&create_ts__lt=2023-11-18T11:42:40&values_list=item_alternate_code,description,create_ts&page_size=1000";

                // Add Basic Authentication credentials
                var byteArray = Encoding.ASCII.GetBytes("integracion:inicio01");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("API Response JSON:");
                    Console.WriteLine(json);
                    return JsonSerializer.Deserialize<ApiResponse>(json) ?? throw new Exception("Deserialization error: Null response");
                }
                else
                {
                    throw new Exception($"Error fetching data from the API. Status Code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Unexpected error fetching data from the API: {ex.Message}");
        }
>>>>>>> 8b4155bfd107dc4ea4c04bdd4d2a486a893607f9
    }







<<<<<<< HEAD
}


 

=======


    static async Task<ApiResponse> GetDataFromApi()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://a33.wms.ocs.oraclecloud.com/holascharff/wms/lgfapi/v10/entity/item/?company_id__code=BBVA&create_ts__gt=2020-01-01T11:42:40&create_ts__lt=2023-11-18T11:42:40&values_list=item_alternate_code,description,create_ts&page_size=1000";

                // Add Basic Authentication credentials
                var byteArray = Encoding.ASCII.GetBytes("integracion:inicio01");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("API Response JSON:");
                    Console.WriteLine(json);
                    return JsonSerializer.Deserialize<ApiResponse>(json) ?? throw new Exception("Deserialization error: Null response");
                }
                else
                {
                    throw new Exception($"Error fetching data from the API. Status Code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Unexpected error fetching data from the API: {ex.Message}");
        }
    }

    static async Task SaveDataToDatabase(ApiResponse apiResponse)
    {
        try
        {
            string connectionString = "Data Source=DESKTOP-GLVK46U;Initial Catalog=testerApi;Integrated Security=True;";

            Console.WriteLine("Opening database connection...");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    Console.WriteLine("Inserting into ApiResponse table...");
                    Console.WriteLine($"ResultCount={apiResponse.result_count}, PageCount={apiResponse.page_count}, PageNumber={apiResponse.page_nbr}, NextPage={apiResponse.next_page}, PreviousPage={apiResponse.previous_page}");

                    // Insert into ApiResponse table
                    await InsertApiResponseAsync(connection, apiResponse);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error inserting into ApiResponse table: {ex.Message}");
                }

                foreach (var apiItem in apiResponse.results)
                {
                    await InsertResultsAsync(connection, apiItem);
                }
            }

            Console.WriteLine("Database connection closed.");
        }
        catch (Exception ex)
        {
            throw new Exception($"Unexpected error : {ex.Message}");
        }
    }

    static async Task InsertApiResponseAsync(SqlConnection connection, ApiResponse apiResponse)
    {
        try
        {
            using (SqlCommand command = new SqlCommand("InsertApiResponse", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ResultCount", SqlDbType.Int).Value = apiResponse.result_count;
                command.Parameters.Add("@PageCount", SqlDbType.Int).Value = apiResponse.page_count;
                command.Parameters.Add("@PageNumber", SqlDbType.Int).Value = apiResponse.page_nbr;
                //command.Parameters.Add("@NextPage", SqlDbType.NVarChar, 255).Value = apiResponse.next_page != null ? apiResponse.next_page : DBNull.Value;
                //command.Parameters.Add("@PreviousPage", SqlDbType.NVarChar, 255).Value = string.IsNullOrEmpty(apiResponse.previous_page) ? (object)DBNull.Value : apiResponse.previous_page;

                command.Parameters.Add("@NextPage", SqlDbType.NVarChar, 255).Value = apiResponse.next_page ?? (object)DBNull.Value;
                command.Parameters.Add("@PreviousPage", SqlDbType.NVarChar, 255).Value = string.IsNullOrEmpty(apiResponse.previous_page) ? (object)DBNull.Value : apiResponse.previous_page;



                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Insert into ApiResponse table completed.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error : {ex.Message}");
        }
    }

    static async Task InsertResultsAsync(SqlConnection connection, results apiItem)
    {
        try
        {
            if (string.IsNullOrEmpty(apiItem.item_alternate_code))
            {
                Console.WriteLine("Skipping item with null or empty item_alternate_code.");
                return;
            }

            using (SqlCommand command = new SqlCommand("InsertResults", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ItemAlternateCode", SqlDbType.NVarChar, 255).Value = apiItem.item_alternate_code;
                command.Parameters.Add("@Description", SqlDbType.NVarChar, 255).Value = apiItem.description;

                // Check if CreateTimestamp is not null before setting the parameter
                if (apiItem.create_ts.HasValue)
                {
                    command.Parameters.Add("@CreateTimestamp", SqlDbType.DateTime2).Value = apiItem.create_ts.Value;
                }
                else
                {
                    command.Parameters.Add("@CreateTimestamp", SqlDbType.DateTime2).Value = DBNull.Value;
                }

                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Item inserted successfully.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error : {ex.Message}");
        }
    }

    
}
>>>>>>> 8b4155bfd107dc4ea4c04bdd4d2a486a893607f9
