//Este código es parte de un programa en C# que realiza operaciones básicas de CRUD (Crear, Leer, Actualizar y Eliminar) en una base de datos SQL Server
//utilizando ADO.NET. Aquí hay una explicación paso a paso del código:

//1) Espacios de nombres y declaración de clases:
//Se importan los espacios de nombres necesarios.
//Se define la clase PeopleDB, que actuará como una clase de acceso a la base de datos para la entidad "People".
//También se define la clase People que representa la entidad "People" con propiedades como Id, Name y Age.

//using System;
//Este statement importa el espacio de nombres base System, que proporciona las clases fundamentales del Framework de Clase Base (Base Class Library) de .NET.
//Esto incluye clases para manipulación de cadenas, entrada/salida estándar, manejo de excepciones, y más.

//using System.Collections.Generic;
//Este statement importa el espacio de nombres System.Collections.Generic, que contiene las clases y interfaces para colecciones genéricas en .NET,
//como List<T>, Dictionary<K, V>, entre otras.

//using System.Linq;
//Este statement importa el espacio de nombres System.Linq, que proporciona extensiones de consultas LINQ (Language-Integrated Query) para trabajar
//con colecciones de datos de manera más expresiva.

//using System.Text;
//Este statement importa el espacio de nombres System.Text, que contiene clases para manipulación y representación de texto, como StringBuilder, que es útil
//para construir cadenas de manera eficiente.

//using System.Threading.Tasks;
//Este statement importa el espacio de nombres System.Threading.Tasks, que proporciona clases y funciones para trabajar con tareas y operaciones asíncronas.

//using System.Data.SqlClient;
//Este statement importa el espacio de nombres System.Data.SqlClient, que contiene clases para interactuar con bases de datos SQL Server utilizando
//ADO.NET (ActiveX Data Objects .NET). En este caso, se usa para establecer conexiones y ejecutar consultas en una base de datos SQL Server.

//using System.Runtime.Remoting.Messaging;
//Este statement importa el espacio de nombres System.Runtime.Remoting.Messaging, que proporciona clases relacionadas con la mensajería y comunicación entre
//componentes de software en el contexto de la remoting (comunicación remota) en .NET. En este código en particular, parece no estar relacionado directamente con
//las operaciones de base de datos y puede ser un import no utilizado o una referencia a código legado. Puedes intentar eliminarlo y ver si afecta el funcionamiento
//del programa.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

//Este bloque de código define un espacio de nombres llamado Crud_WindowsForms_AdoNet. Un espacio de nombres en C# es una manera de organizar y estructurar el código
//alrededor de un tema específico o funcionalidad. Dentro de este espacio de nombres, puedes definir clases, estructuras, interfaces y otros elementos.

namespace Crud_WindowsForms_AdoNet
{
    public class PeopleDB
    {    
        //Campos:
        //private string connectionString: Almacena la cadena de conexión a la base de datos SQL Server.
        private string connectionString = "Data Source=DESKTOP-GLVK46U;Initial Catalog=CrudWindowsForm;Integrated Security=True;";

        //Métodos:
        //public bool Ok(): Verifica si es posible abrir una conexión a la base de datos. Devuelve true si la conexión es exitosa, de lo contrario, devuelve false.
        public bool Ok()
        {

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch
            {

                return false;
            }

            return true;

        }

        //public List<People> Get(): Recupera una lista de objetos People desde la base de datos. Utiliza una consulta SQL para seleccionar registros de la tabla people.
        //Este método Get está diseñado para recuperar datos de la base de datos
       
        public List<People> Get()
        {
            // Crear una lista para almacenar objetos People
            //Se crea una lista llamada people para almacenar objetos People.
            List<People> people = new List<People>();

            // Consulta SQL para seleccionar todos los registros de la tabla 'people'
            //Se define la consulta SQL en la variable query para seleccionar todos los campos (id, name, age) de la tabla people
            string query = "select id,name,age from people";


            //Se utiliza un bloque using para garantizar que la conexión a la base de datos (SqlConnection) se cierre correctamente después de su uso.
            // Crear una conexión a la base de datos utilizando la cadena de conexión almacenada en 'connectionString'
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear un comando SQL con la consulta y la conexión
                //Se crea un objeto SqlCommand llamado command con la consulta SQL y la conexión.
                SqlCommand command = new SqlCommand(query, connection);

                //Se intenta abrir la conexión a la base de datos dentro de un bloque try.
                try 
                {
                    // Abrir la conexión a la base de datos
                    connection.Open();
                    // Ejecutar la consulta y obtener un lector de datos
                    //Se ejecuta la consulta utilizando ExecuteReader() para obtener un lector de datos (SqlDataReader).
                    SqlDataReader reader = command.ExecuteReader();



                    // Iterar a través de los resultados
                    //Se itera a través de los resultados utilizando un bucle while (reader.Read()).
                    while (reader.Read())
                    {
                        // Crear un nuevo objeto People para cada registro en la base de datos
                        //Dentro del bucle, se crea un nuevo objeto People (oPeople) y se asignan valores desde el lector de datos.
                        People oPeople = new People();

                        // Asignar valores desde el lector de datos al objeto People

                        oPeople.Id = reader.GetInt32(0);
                        oPeople.Name = reader.GetString(1);
                        oPeople.Age = reader.GetInt32(2);
                        // Agregar el objeto People a la lista
                        //El objeto People se agrega a la lista people.
                        people.Add(oPeople);
                    
                    }
                    // Cerrar el lector de datos y la conexión
                    //Se cierra el lector de datos y la conexión a la base de datos.
                    reader.Close();
                    connection.Close();


                }
                //Si se produce alguna excepción, se captura y se lanza con un mensaje de error personalizado.
                catch (Exception ex) 
                {
                    // Capturar cualquier excepción y lanzarla con un mensaje personalizado
                    throw new Exception("Hay un erro en la BD : " + ex.Message);
                }
            }

            // Devolver la lista de objetos People recuperados de la base de datos
            //Finalmente, se devuelve la lista de objetos People que se han recuperado de la base de datos.
            return people;

          
        }



        //public People Get(int Id): Recupera un objeto People específico según el ID proporcionado. Utiliza una consulta SQL con un parámetro para filtrar los resultados.
        //Este método Get está diseñado para recuperar un objeto People específico de la base de datos según un ID proporcionado
        public People Get(int Id)
        {
            //Se define la consulta SQL en la variable query para seleccionar campos específicos (id, name, age) de la tabla people donde el ID coincide con el
            //parámetro proporcionado.
            // Consulta SQL para seleccionar un registro específico de la tabla 'people' basado en el ID
            string query = "select id,name,age from people" +
                " where id=@id";


            //Se utiliza un bloque using para garantizar que la conexión a la base de datos (SqlConnection) se cierre correctamente después de su uso.
            // Crear una conexión a la base de datos utilizando la cadena de conexión almacenada en 'connectionString'


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear un comando SQL con la consulta y la conexión
                //Se crea un objeto SqlCommand llamado command con la consulta SQL y la conexión.
                SqlCommand command = new SqlCommand(query, connection);
                // Agregar un parámetro al comando para representar el valor del ID
                //Se agrega un parámetro al comando (@id) para representar el valor del ID proporcionado.
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    //Se intenta abrir la conexión a la base de datos dentro de un bloque try.
                    // Abrir la conexión a la base de datos
                    connection.Open();
                    // Ejecutar la consulta y obtener un lector de datos
                    //Se ejecuta la consulta utilizando ExecuteReader() para obtener un lector de datos (SqlDataReader).
                    SqlDataReader reader = command.ExecuteReader();
                    // Leer el primer (y único) registro del resultado
                    //Se utiliza reader.Read() para avanzar al primer (y único) registro en el resultado.
                    reader.Read();

                    //Se crea un nuevo objeto People (oPeople) y se asignan valores desde el lector de datos.
                    // Crear un nuevo objeto People
                    People oPeople = new People();

                    // Asignar valores desde el lector de datos al objeto People
                        oPeople.Id = reader.GetInt32(0);
                        oPeople.Name = reader.GetString(1);
                        oPeople.Age = reader.GetInt32(2);

                    // Cerrar el lector de datos y la conexión
                    //Se cierra el lector de datos y la conexión a la base de datos.
                    reader.Close();
                    connection.Close();

                    // Devolver el objeto People recuperado de la base de datos
                    return oPeople;
                    


                }
                catch (Exception ex)
                {
                    //Si se produce alguna excepción, se captura y se lanza con un mensaje de error personalizado.
                    // Capturar cualquier excepción y lanzarla con un mensaje personalizado
                    throw new Exception("Hay un erro en la BD : " + ex.Message);
                }
            }


  


        }

        //public void Add(string Name, int Age): Agrega un nuevo registro a la base de datos con el nombre y la edad proporcionados.
        //Este método Add está diseñado para agregar un nuevo registro a la base de datos en la tabla 'people'.
        public void Add(string Name, int Age)
        {
            // Consulta SQL para insertar un nuevo registro en la tabla 'people'
            //Se define la consulta SQL en la variable query para insertar un nuevo registro en la tabla people con los campos name y age.
            string query = "insert into people(name, age) values" 
                
                + "(@name,@age)";

            //Se utiliza un bloque using para garantizar que la conexión a la base de datos (SqlConnection) se cierre correctamente después de su uso.
            //Crear una conexión a la base de datos utilizando la cadena de conexión almacenada en 'connectionString'
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear un comando SQL con la consulta y la conexión
               // Se crea un objeto SqlCommand llamado command con la consulta SQL y la conexión.
                SqlCommand command = new SqlCommand(query, connection);

                // Agregar parámetros al comando para representar los valores de 'name' y 'age'
                //Se agregan parámetros al comando (@name y @age) para representar los valores de 'name' y 'age' que se desean insertar.
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@age", Age);


                try
                {
                    // Abrir la conexión a la base de datos
                    //Se intenta abrir la conexión a la base de datos dentro de un bloque try.
                    connection.Open();
                    // Ejecutar la consulta para insertar el nuevo registro
                    //Se ejecuta la consulta utilizando ExecuteNonQuery() para insertar el nuevo registro en la tabla.
                    command.ExecuteNonQuery();
                    // Cerrar la conexión a la base de datos
                    //e cierra la conexión a la base de datos.
                    connection.Close();


                }
                catch (Exception ex)
                {
                    // Capturar cualquier excepción y lanzarla con un mensaje personalizado
                    //Si se produce alguna excepción, se captura y se lanza con un mensaje de error personalizado.
                    throw new Exception("Hay un erro en la BD : " + ex.Message);
                }
            }

            //Este método es responsable de agregar un nuevo registro a la base de datos 'people' con el nombre (Name) y la edad (Age) proporcionados como parámetros.
        }





        //public void Update(string Name, int Age, int Id): Actualiza un registro existente en la base de datos con el nombre, la edad y el ID proporcionados.

        //Este método Update está diseñado para actualizar un registro existente en la base de datos en la tabla 'people'. 
        public void Update(string Name, int Age, int Id)
        {  //Se define la consulta SQL en la variable query para actualizar un registro en la tabla people estableciendo el nuevo valor de name y age donde id coincida
           //con el id proporcionado.
            // Consulta SQL para actualizar un registro en la tabla 'people' basado en el 'id' proporcionado
            string query = "update people set name=@name, age=@age" +
                " where id=@id";

            //Se utiliza un bloque using para garantizar que la conexión a la base de datos (SqlConnection) se cierre correctamente después de su uso.
            // Crear una conexión a la base de datos utilizando la cadena de conexión almacenada en 'connectionString'
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear un comando SQL con la consulta y la conexión
                //Se crea un objeto SqlCommand llamado command con la consulta SQL y la conexión.
                SqlCommand command = new SqlCommand(query, connection);
                // Agregar parámetros al comando para representar los nuevos valores de 'name', 'age' e 'id'
                //Se agregan parámetros al comando (@name, @age y @id) para representar los nuevos valores de 'name', 'age' e 'id' que se desean actualizar.
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@age", Age);
                command.Parameters.AddWithValue("@id", Id);


                try
                {
                    // Abrir la conexión a la base de datos
                    //Se intenta abrir la conexión a la base de datos dentro de un bloque try.
                    connection.Open();
                    // Ejecutar la consulta para actualizar el registro
                    //Se ejecuta la consulta utilizando ExecuteNonQuery() para actualizar el registro en la tabla.
                    command.ExecuteNonQuery();
                    // Cerrar la conexión a la base de datos
                    //Se cierra la conexión a la base de datos.
                    connection.Close();


                }
                catch (Exception ex)
                {
                    // Capturar cualquier excepción y lanzarla con un mensaje personalizado
                    //Si se produce alguna excepción, se captura y se lanza con un mensaje de error personalizado.
                    throw new Exception("Hay un erro en la BD : " + ex.Message);
                }
            }

            //Este método es responsable de actualizar un registro en la base de datos 'people' con nuevos valores de nombre (Name) y edad (Age) donde
            //el Id coincida con el Id proporcionado.

        }

        //public void Delete(int Id): Elimina un registro de la base de datos según el ID proporcionado.

        //Este método Delete pertenece a la clase PeopleDB y se encarga de eliminar un registro de la base de datos. 
        public void Delete(int Id)
        {
            //Define una cadena de texto que representa una consulta SQL de eliminación. En este caso, la consulta borra un registro de la tabla "people" donde
            //el campo "id" es igual al parámetro @id.

            string query = "delete from people" +
                " where id=@id";

            //Crea una nueva instancia de la clase SqlConnection para establecer la conexión con la base de datos. 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Luego, crea un objeto SqlCommand utilizando la consulta SQL y la conexión.
                SqlCommand command = new SqlCommand(query, connection);

                //Parámetros de la Consulta:
                //Agrega un parámetro @id al comando y le asigna el valor del parámetro Id pasado al método. Este valor se utilizará en la consulta SQL
                //para determinar cuál registro debe ser eliminado.


                command.Parameters.AddWithValue("@id", Id);


                try
                {
                    //Abre la conexión con la base de datos, ejecuta la consulta de eliminación utilizando ExecuteNonQuery() (ya que no devuelve resultados) y
                    //luego cierra la conexión. Cualquier excepción que ocurra durante este proceso se captura en el bloque catch, y se lanza una nueva excepción
                    //con un mensaje de error.
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();


                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un erro en la BD : " + ex.Message);
                }
            }

            //Este método, en resumen, se utiliza para borrar un registro de la tabla "people" en la base de datos, identificado por el valor del parámetro Id.
            //La gestión de excepciones ayuda a manejar posibles errores durante la ejecución de la consulta SQL.

        }
    }

         

    public class People
    {
        //public int Id { get; set; }: Propiedad para el ID de una persona.
        public int Id { get; set; }

        //public string Name { get; set; }: Propiedad para el nombre de una persona.
        public string Name { get; set; }

        //public int Age { get; set; }: Propiedad para la edad de una persona.
        public int Age { get; set; }
    } 




}


//Estas clases y métodos están diseñados para realizar operaciones CRUD (Create, Read, Update, Delete) en una base de datos SQL Server llamada CrudWindowsForm,
//específicamente en la tabla people.