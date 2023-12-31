using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace WinFormsAPI.Models: Define el espacio de nombres 
//WinFormsAPI.Models en el que se encuentra la clase Result.

namespace WinFormsAPI.Models    
{
    //public class Result: Define la clase Result como pública, lo que significa que puede ser accedida desde otros lugares fuera del espacio de nombres.
    public class Result
    {
        //Propiedades de la clase Result:
        // Propiedad que representa el identificador (ID) de un resultado.
        //public int Id { get; set; }: Esta propiedad representa el identificador (ID) de un resultado y tiene métodos de lectura y escritura (get y set).

        public int Id { get; set; }

        // Propiedad que representa el código de artículo alternativo.
        //public string? ItemAlternateCode { get; set; }: Esta propiedad representa el código de artículo alternativo y también permite la lectura y escritura.
        public string? ItemAlternateCode { get; set; }

        // Propiedad que representa la descripción de un resultado.
        //public string? Description { get; set; }: Representa la descripción de un resultado, permitiendo su lectura y escritura.
        public string? Description { get; set; }

        // Propiedad que representa la fecha y hora de creación de un resultado.
        //public DateTime? CreateTs { get; set; }: Representa la fecha y hora de creación de un resultado, y también permite la lectura y escritura.
        //La ? después de DateTime indica que el valor puede ser nulo.
        public DateTime? CreateTs { get; set; }

        //En resumen, la clase Result es una estructura de datos simple que encapsula información relacionada con un resultado.
        //Cada instancia de esta clase tiene propiedades que representan diferentes aspectos de la información del resultado, como el ID, el código de artículo alternativo,
        //la descripción y la fecha de creación. Estas propiedades son públicas y pueden ser accedidas y modificadas desde otras partes del código.

    }
}
