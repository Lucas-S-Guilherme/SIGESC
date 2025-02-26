using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{
    public class Restricao
    {
        [Column("id_restricao")]
        public int Id { get; set; }

        [Column("nome_restricao")]
        public string Nome { get; set; }

        [Column("grupo_restricao")]
        public string Grupo { get; set; }

        [Column("descricao_restricao")]
        public string Descricao { get; set; }
    }
}