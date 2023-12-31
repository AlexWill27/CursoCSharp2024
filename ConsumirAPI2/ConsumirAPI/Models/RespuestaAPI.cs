

namespace ConsumirAPI.Models
{
    public class RespuestaAPI
    {

        public int result_count { get; set; }
        public int page_count { get; set; }
        public int page_nbr { get; set; }

        public string? next_page { get; set; }

        public List<results>? results { get; set; }



    }


}
