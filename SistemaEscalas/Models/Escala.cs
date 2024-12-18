
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{

    [Table("escala")]
    public class Escala
    {
        public int id {get; set;}
        public string? tipo {get; set;}
        public DateTime dataInicio {get; set;}
        public DateTime dataFinal {get; set;}
        public string? descricao {get; set;}
        public string? local_trabalho {get; set;}
        public string? regime_trabalho {get;set;}
        

    }
}