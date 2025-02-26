using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{
    public class CombatenteEspecializacao
    {
        [Column("id_combatente")]
        public int CombatenteId { get; set; }

        [Column("id_especializacao")]
        public int EspecializacaoId { get; set; }

        public Combatente Combatente { get; set; }
        public Especializacao Especializacao { get; set; }
    }
}