using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SistemaEscalas.Models
{
    public class Funcao
    {
        [Column("id_funcao")]
        public int Id { get; set; }

        [Column("nome_funcao")]
        public required string Nome { get; set; }

        [Column("sigla_funcao")]
        public required string Sigla { get; set; }

        // Propriedade de navegação para os combatentes associados
        public ICollection<CombatenteFuncao>? Combatentes { get; set; }
    }
}