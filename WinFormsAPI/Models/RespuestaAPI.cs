//Las declaraciones using al principio indican que el código utiliza algunos espacios de nombres específicos en .NET,
//proporcionando acceso a tipos y funcionalidades definidos en esos espacios de nombres.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WinFormsAPI.Models
{

    //La clase RespuestaAPI se declara dentro del espacio de nombres WinFormsAPI.Models y se define como pública.

    public class RespuestaAPI
    {
        //Propiedades de la clase RespuestaAPI:

        //public int Id { get; set; }: Propiedad que representa el identificador (Id) de la respuesta.
        public int Id { get; set; }

        //public int? ResultCount { get; set; }: Propiedad que representa el número de resultados (ResultCount) y puede ser nula.
        public int? ResultCount { get; set; }

        //public int? PageCount { get; set; }: Propiedad que representa el número de páginas (PageCount) y puede ser nula.
        public int? PageCount { get; set; }

        //public int? PageNbr { get; set; }: Propiedad que representa el número de página (PageNbr) y puede ser nula.
        public int? PageNbr { get; set; }

        //public string? NextPage { get; set; }: Propiedad que representa la siguiente página (NextPage) y puede ser nula.
        public string? NextPage { get; set; }

        //Lista de RespuestaAPI dentro de la misma clase:
        //public List<RespuestaAPI> respuestaAPI { get; set; }: Propiedad que representa una lista de objetos RespuestaAPI.
        //Esta propiedad permite almacenar múltiples instancias de la misma clase dentro de la misma instancia de la clase. Ten en cuenta que el nombre de la propiedad (respuestaAPI) debería seguir las convenciones de nombres de C# para ser más consistente.

        public List<RespuestaAPI>? respuestaAPI { get; set; }

        //En resumen, la clase RespuestaAPI parece estar diseñada para representar una respuesta de una API que contiene información como el identificador,
        //el número de resultados, el número de páginas, el número de página y la siguiente página. Además, la clase tiene una propiedad que permite almacenar
        //una lista de objetos RespuestaAPI, lo que podría utilizarse para representar una estructura de respuestas anidadas o una lista de respuestas en sí misma.

    }




}
