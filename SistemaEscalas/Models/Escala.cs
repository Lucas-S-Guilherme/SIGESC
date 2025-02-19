
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{

    [Table("escala")]
    public class Escala
    {
        public int Id {get; set;}
        public string? Nome {get; set;}
        public string? Local_trabalho {get; set;}
        public DateTime DataInicio {get; set;}
        public DateTime DataFim {get; set;}
        public string? DataConfeccao {get; set;}      
        public int IdUsuario {get;set;}        

    }
}