using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{
    public class Escala
    {
        [Column("id_escala")]
        public int Id { get; set; }

        [Column("nome_escala")]
        public string Nome { get; set; }

        [Column("local_trabalho")]
        public string LocalTrabalho { get; set; }

        [Column("data_inicio")]
        public DateTime DataInicio { get; set; }

        [Column("data_fim")]
        public DateTime DataFim { get; set; }

        [Column("data_confeccao")]
        public DateTime DataConfeccao { get; set; }

        [Column("id_usuario")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}