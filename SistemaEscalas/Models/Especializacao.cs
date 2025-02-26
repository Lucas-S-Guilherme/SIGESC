using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SistemaEscalas.Models
{
    public class Especializacao
    {
        [Column("id_especializacao")]
        public int Id { get; set; }

        [Column("nome_especializacao")]
        public required string Nome { get; set; }

        [Column("descricao_especializacao")]
        public required string Descricao { get; set; }

        [Column("sigla_especializacao")]
        public required string Sigla { get; set; }

        // Propriedade de navegação para os combatentes associados
        public required ICollection<CombatenteEspecializacao> Combatentes { get; set; }
    }
}