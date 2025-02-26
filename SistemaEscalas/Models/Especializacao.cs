using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{
    public class Especializacao
    {
        [Column("id_especializacao")]
        public int Id { get; set; }

        [Column("nome_especializacao")]
        public string Nome { get; set; }

        [Column("descricao_especializacao")]
        public string Descricao { get; set; }

        [Column("sigla_especializacao")]
        public string Sigla { get; set; }
    }
}