using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Este código corresponde a un formulario (FrmNuevo) en una aplicación de Windows Forms en C# que parece estar diseñada para agregar o editar información
//sobre personas en una base de datos. Vamos a analizar las partes principales del código:

namespace Crud_WindowsForms_AdoNet
{
    public partial class FrmNuevo : Form
    {
        private int? Id;

       // public FrmNuevo(int? Id = null) : Este es el constructor del formulario FrmNuevo.Toma un parámetro opcional Id que representa el identificador de una
       // persona.El int? indica que el parámetro puede ser nulo.
        public FrmNuevo(int? Id = null)
        {
            //InitializeComponent(): Este método es generado automáticamente y se encarga de inicializar todos los componentes del formulario.
            //Esto incluye la creación y disposición de controles visuales que has diseñado en el diseñador de formularios.
            InitializeComponent();

            //this.Id = Id: Aquí, el parámetro Id se asigna a la propiedad Id de la instancia del formulario. La propiedad Id parece ser una variable
            //de instancia que almacena el identificador de una persona.
            this.Id = Id;

            //if (this.Id != null): Se realiza una comprobación para ver si el Id es diferente de null. Esto se hace para determinar si el formulario se está
            //utilizando para editar una persona existente o para agregar una nueva.
            if (this.Id != null)

            //LoadData(): Si Id no es nulo, se llama al método LoadData(). Este método probablemente esté diseñado para cargar información relacionada con el
            //Id proporcionado en los controles del formulario. En el contexto del formulario FrmNuevo, parece que se utiliza para cargar los datos de una persona
            //existente cuando se está editando.
                LoadData();

            //En resumen, este constructor inicializa el formulario, asigna el Id proporcionado a la propiedad Id, y carga los datos correspondientes si el Id no es nulo.
        }


        //Este método se encarga de cargar datos en el formulario. Aquí están los pasos específicos:
        private void LoadData()
        {
            //Se crea una instancia de la clase PeopleDB llamada oPeopleDB.
            PeopleDB oPeopleDB = new PeopleDB();
            //Se llama al método Get de oPeopleDB con el Id actual (si es proporcionado). El resultado se almacena en la variable oPeople.
            People oPeople = oPeopleDB.Get((int)Id);
            //Se asigna el nombre de la persona (oPeople.Name) al texto del control txtName.
            txtName.Text = oPeople.Name;
            //Se asigna la edad de la persona convertida a cadena (oPeople.Age.ToString()) al texto del control txtEdad.
            txtEdad.Text = oPeople.Age.ToString();
        }

        //private void label1_Click(object sender, EventArgs e): Este método se llama cuando se hace clic en el label1 del formulario. Sin embargo, en el código
        //proporcionado, este método está vacío (no realiza ninguna acción).
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e): Este método se ejecuta cuando se hace clic en button1 (un botón) del formulario.
        //Aquí están los pasos específicos:
        private void button1_Click(object sender, EventArgs e)
        {
            //Se crea una nueva instancia de PeopleDB llamada oPeopleDB.
            PeopleDB oPeopleDB = new PeopleDB();
            //Se utiliza una estructura de control try-catch para manejar posibles excepciones.
            try
            {
                //Se verifica si Id es null. Si es null, se llama al método Add de oPeopleDB para agregar una nueva persona con el nombre y edad proporcionados en
                //los controles txtName y txtEdad.
                if (Id == null)

                    oPeopleDB.Add(txtName.Text, int.Parse(txtEdad.Text));

                //Si Id no es null, significa que se está editando una persona existente, y se llama al método Update de oPeopleDB para actualizar el nombre y
                //la edad de la persona con el Id actual.
                else
                    oPeopleDB.Update(txtName.Text, int.Parse(txtEdad.Text), (int)Id);

                //Después de agregar o actualizar, se cierra el formulario actual (this.Close()).
                this.Close();

            }
            //Dentro del bloque catch, se maneja cualquier excepción capturada y se muestra un mensaje de error mediante MessageBox.Show().
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un error al guardar : " + ex.Message);
            }

        }

        //private void FrmNuevo_Load(object sender, EventArgs e): Este método se ejecuta cuando se carga el formulario. Sin embargo, en el código proporcionado,
        //este método está vacío (no realiza ninguna acción).
        private void FrmNuevo_Load(object sender, EventArgs e)
        {

        }
    }
    //En resumen, el formulario FrmNuevo se utiliza para agregar o editar personas en una base de datos, y estos métodos gestionan la carga de datos, la acción al
    //hacer clic en el botón, y algunos eventos relacionados con el formulario.
}
