using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{
    public class Funcao
    {
        [Column("id_funcao")]
        public int Id { get; set; }

        [Column("nome_funcao")]
        public string Nome { get; set; }

        [Column("sigla_funcao")]
        public string Sigla { get; set; }
    }
}