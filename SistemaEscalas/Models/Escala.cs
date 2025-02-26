using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SistemaEscalas.Models
{
    public class Escala
    {
        [Column("id_escala")]
        public int Id { get; set; }

        [Column("nome_escala")]
        public required string Nome { get; set; }

        [Column("local_trabalho")]
        public required string LocalTrabalho { get; set; }

        [Column("data_inicio")]
        public DateTime DataInicio { get; set; }

        [Column("data_fim")]
        public DateTime DataFim { get; set; }

        [Column("data_confeccao")]
        public DateTime DataConfeccao { get; set; }

        [Column("id_usuario")]
        public int UsuarioId { get; set; }

        public required Usuario Usuario { get; set; }

        // Propriedade de navegação para os turnos de trabalho associados
        public required ICollection<TurnoTrabalho> TurnosTrabalho { get; set; }
    }
}