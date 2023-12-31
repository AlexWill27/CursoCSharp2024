using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Este código es parte de una aplicación de Windows Forms en C# que parece ser un CRUD (Crear, Leer, Actualizar y Eliminar) interactuando con una base de datos
//utilizando ADO.NET. Aquí hay una explicación del código:

namespace Crud_WindowsForms_AdoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Form1_Load: Este método se ejecuta cuando el formulario se carga. Llama al método Refresh para llenar el DataGridView con datos de la base de datos.
        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        //Refresh: Este método crea una instancia de la clase PeopleDB y utiliza su método Get para obtener datos de la base de datos y luego los muestra en el DataGridView.

        private void Refresh()
        {
            //// Al cargar el formulario, se refresca el DataGridView con datos de la base de datos.
            PeopleDB oPeopleDB = new PeopleDB();
            dataGridView1.DataSource = oPeopleDB.Get();
        }



       
        private void button1_Click(object sender, EventArgs e)
        {

            //Aqui debemos crear un boton y verificar si estamos realmente conectados a una BD.

            //PeopleDB oPeople = new PeopleDB();

            //if (oPeople.Ok())
            //{
            //    MessageBox.Show("Estamos Conectados a la BD");
            //}
            //else
            //{
            //    MessageBox.Show("No se concto que penita");
            //}


        }

        //button1_Click_1: Este botón recarga los datos llamando al método Refresh.
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Botón de recarga de datos.
            Refresh();
        }

        //button2_Click: Este botón abre un nuevo formulario (FrmNuevo) para agregar un nuevo registro a la base de datos y luego llama a Refresh para actualizar la vista.
        private void button2_Click(object sender, EventArgs e)
        {
            // Botón para agregar un nuevo registro.
            FrmNuevo frm = new FrmNuevo();

            frm.ShowDialog();
            Refresh();
        }

        //button3_Click: Este botón abre un nuevo formulario (FrmNuevo) para editar un registro existente seleccionado en el DataGridView y luego llama a Refresh
        //para actualizar la vista.
        private void button3_Click(object sender, EventArgs e)
        {
            // Botón para editar un registro existente.
            int? Id = GetId();
            if (Id != null)
            {
                FrmNuevo frmEdit = new FrmNuevo(Id);
                frmEdit.ShowDialog();
                Refresh();
            }
        }

        //button4_Click: Este botón elimina un registro existente seleccionado en el DataGridView y luego llama a Refresh para actualizar la vista.
        private void button4_Click(object sender, EventArgs e)
        {
            // Botón para eliminar un registro existente.
            int? Id = GetId();
            try
            {
                if (Id != null)
                {
                    PeopleDB oPeopleDB = new PeopleDB();
                    oPeopleDB.Delete((int)Id);
                    Refresh();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al eliminar" + ex.Message);
            }
            

        }


        #region HELPER

        //GetId: Este método intenta obtener el ID de la fila seleccionada en el DataGridView. Retorna null si hay un error.

        private int? GetId()
        {

            try
            {
                // Obtiene el ID de la fila seleccionada en el DataGridView.
                //return int.Parse(...): Retorna el valor entero obtenido de la celda.
                return int.Parse(
                  //dataGridView1 es un objeto DataGridView, y Rows es una colección que representa las filas del DataGridView.
                  //dataGridView1.CurrentRow representa la fila actualmente seleccionada.
                  
                  //.Cells[0]: Cells es una colección que representa las celdas en una fila del DataGridView. [0] indica que queremos la primera celda de la fila.
                  //.Value: Value es la propiedad que contiene el valor de la celda.
                  //.ToString(): Convierte el valor de la celda a su representación en formato de cadena.
                  //int.Parse(...): Convierte la cadena resultante a un valor entero. Si no se puede realizar la conversión (por ejemplo, si el valor
                  //no es un número válido), se lanzará una excepción.

                  dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

            }
            //catch: Captura cualquier excepción que pueda ocurrir durante la conversión a entero.
            catch
            {
                //return null;: Si ocurre una excepción, el método retorna null. La declaración de retorno es int?, lo que significa que el método puede
                //retornar un entero o null.
                return null;
            }

            //En resumen, la función de este código es obtener el valor numérico de la primera celda de la fila seleccionada en el DataGridView.
            //Si el valor no se puede convertir a entero (por ejemplo, si la celda está vacía o contiene un valor no numérico), se devuelve null.
        }








        #endregion

        //En términos simples, #region y #endregion son herramientas visuales para organizar y estructurar el código de manera más limpia y legible.
        //No afectan la ejecución del programa y son completamente opcionales; su propósito principal es mejorar la experiencia de desarrollo y mantenimiento del código.

    }
}
