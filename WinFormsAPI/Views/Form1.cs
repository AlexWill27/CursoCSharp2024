//Este c�digo pertenece a una aplicaci�n de Windows Forms (WinForms) en C# que utiliza una interfaz gr�fica para mostrar datos obtenidos de una API web.
//Vamos a analizar cada parte detalladamente:


//Estos son los espacios de nombres importados. WinFormsAPI.Controllers y WinFormsAPI.Models contienen las clases que se utilizan en este formulario.

using System.Security.Policy;
using WinFormsAPI.Controllers;
using WinFormsAPI.Models;




namespace WinFormsAPI
{
    public partial class Form1 : Form
    {
        // Declaraci�n de variables miembro

        //En esta secci�n se declara y define la clase principal del formulario. Se instancian objetos de RespuestaAPIController y RespuestaAPI.
        //Estos objetos se utilizan para realizar llamadas a la API y almacenar la respuesta, respectivamente.

        private RespuestaAPIController RespuestaAPIController;
        private RespuestaAPI responseAPI;


        // Constructor
        public Form1()
        {
            InitializeComponent();
            RespuestaAPIController = new RespuestaAPIController();
            responseAPI = new RespuestaAPI();
        }

   

        private async void GetResponseAPI()
        {
            // Se declara una variable local para almacenar la respuesta de la API
            List<RespuestaAPI> responseAPI = null;

            try
            {
                // Se obtiene la respuesta de la API de manera as�ncrona
                responseAPI = await RespuestaAPIController.GetAllResponseAPI();

                //Se verifica si la respuesta no es nula y tiene un formato de cadena no nula

                if (responseAPI != null && responseAPI.ToString() != null)
                {
                    // Se limpian las filas existentes en el control DataGridView
                    dataGridView1.Rows.Clear(); // Limpiar filas existentes antes de agregar nuevas


                    // Se itera sobre la lista de respuestas y se agrega cada una como una nueva fila en el DataGridView

                    foreach (var response in responseAPI)
                    {
                        //DataGridViewRow row = new DataGridViewRow(); se utiliza para crear una nueva instancia de la clase DataGridViewRow. En el contexto de un
                        //control DataGridView en una aplicaci�n de Windows Forms (WinForms) en C#, esta l�nea est� relacionada con la manipulaci�n y presentaci�n
                        //de datos en el control.

                        //DataGridViewRow: Es una clase en WinForms que representa una fila en un control DataGridView. Un DataGridView es una tabla interactiva
                        //que puede mostrar y permitir la edici�n de datos de una manera tabular.

                        //row: Es una variable local que se declara y se utiliza para referenciar la nueva fila que se crear�. Es de tipo DataGridViewRow, lo que significa
                        //que puede contener una fila de datos que puede ser mostrada en un DataGridView.
                        //new DataGridViewRow(): Esto crea una nueva instancia de la clase 
                        //DataGridViewRow. Esta instancia representa una fila vac�a que se puede llenar con datos y agregar al control DataGridView.

                        //Cuando se trabaja con un control DataGridView, es com�n crear una nueva fila(DataGridViewRow) para luego agregar celdas a esa fila y, finalmente,
                        //agregar la fila al control. En el c�digo que has proporcionado, despu�s de crear la nueva fila(row), se llenan sus celdas con datos espec�ficos
                        //de la respuesta de la API, y luego la fila se agrega al control DataGridView con dataGridView1.Rows.Add(row);.

                        DataGridViewRow row = new DataGridViewRow();
                        //La l�nea row.CreateCells(dataGridView1); se utiliza para inicializar las celdas de la fila (DataGridViewRow) con las columnas del control
                        //DataGridView al que se agregar� la fila.
                        //row: Esta es la variable que representa la fila de datos que est�s creando y agregando al control DataGridView.
                        //CreateCells(dataGridView1): Este m�todo se llama en la instancia de la fila (row) y toma como argumento el control DataGridView al que
                        //se asociar� la fila. Lo que hace este m�todo es crear celdas vac�as basadas en las columnas del control DataGridView proporcionado.
                        //dataGridView1: Es el nombre del control DataGridView al que se est� asociando la fila. Al llamar a CreateCells(dataGridView1), le est�s diciendo
                        //al sistema que cree celdas que coincidan con la estructura de columnas de este control espec�fico.

                        //En resumen, despu�s de ejecutar row.CreateCells(dataGridView1), la fila (row) tiene celdas creadas y listas para ser llenadas con datos
                        //espec�ficos antes de agregarla al control DataGridView. Este enfoque es �til cuando trabajas con datos de API o bases de datos y deseas
                        //presentar esos datos en un control DataGridView.

                        row.CreateCells(dataGridView1);

                        //Esta l�nea se utiliza para asignar el valor de la propiedad ResultCount de un objeto RespuestaAPI a la primera celda (Cells[0]) de una fila
                        //en un control DataGridView. Aqu� hay una explicaci�n detallada:
                        //row.Cells[0]: Accede a la primera celda de la fila (row). Los �ndices en el array Cells corresponden a las columnas del control DataGridView.
                        //En este caso, Cells[0] se refiere a la primera columna.
                        //.Value: Esta propiedad se utiliza para establecer o recuperar el valor contenido en la celda. En este contexto, se est� utilizando para asignar
                        //un valor a la celda.

                        //response.ResultCount: Accede al valor de la propiedad ResultCount del objeto response, que es una instancia de la clase RespuestaAPI. Este valor se
                        //asigna a la celda
                        row.Cells[0].Value = response.ResultCount;
                        row.Cells[1].Value = response.PageCount;
                        row.Cells[2].Value = response.PageNbr;
                        row.Cells[3].Value = response.NextPage;

                        dataGridView1.Rows.Add(row);
                    }
                }
                else // Si la respuesta es nula, se muestra un mensaje de error
                {
                    MessageBox.Show("No se pudo obtener la respuesta de la API o no hay resultados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Si ocurre una excepci�n, se muestra un mensaje de error
                MessageBox.Show($"Error al obtener la respuesta de la API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Manejador de eventos button1_Click:
        private void button1_Click(object sender, EventArgs e)
        {
            // Se llama al m�todo GetResponseAPI cuando se hace clic en el bot�n
            //Este m�todo se llama cuando se hace clic en el bot�n en la interfaz gr�fica. Simplemente llama al m�todo GetResponseAPI para realizar la acci�n de obtener y mostrar la respuesta de la API.
            GetResponseAPI();
        }
    }
}

//Este formulario b�sicamente interact�a con una API web y muestra los resultados en un control DataGridView.