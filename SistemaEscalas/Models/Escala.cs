using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SistemaEscalas.Models
{
    public class Escala
    {
        // Construtor padrão (sem parâmetros)
        public Escala()
        {
            TurnosTrabalho = new List<TurnoTrabalho>(); // Inicializa a coleção
        }

        [Column("id_escala")]
        public int Id { get; set; }

        [Column("nome_escala")]
        public required string Nome { get; set; }

        [Column("local_trabalho")]
        public required string LocalTrabalho { get; set; }

        [Column("data_inicio")]
        public required DateTime DataInicio { get; set; }

        [Column("data_fim")]
        public required DateTime DataFim { get; set; }

        [Column("data_confeccao")]
        public DateTime DataConfeccao { get; set; }

        [Column("id_usuario")]
        public required int UsuarioId { get; set; }

        // Propriedade de navegação para o Usuário
        public required Usuario Usuario { get; set; }

        // Propriedade de navegação para os Turnos de Trabalho
        public required ICollection<TurnoTrabalho> TurnosTrabalho { get; set; }
    }
}