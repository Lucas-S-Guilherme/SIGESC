using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SistemaEscalas.Models
{
    public class Restricao
    {
        [Column("id_restricao")]
        public int Id { get; set; }

        [Column("nome_restricao")]
        public required string Nome { get; set; }

        [Column("grupo_restricao")]
        public required string Grupo { get; set; }

        [Column("descricao_restricao")]
        public string Descricao { get; set; }

        // Propriedade de navegação para os combatentes associados
        public ICollection<CombatenteRestricao> Combatentes { get; set; }
    }
}