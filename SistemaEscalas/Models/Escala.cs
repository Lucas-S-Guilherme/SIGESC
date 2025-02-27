using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SistemaEscalas.Models
{
    public class Escala
    {
        // Construtor com parâmetros obrigatórios
        public Escala(Usuario usuario, ICollection<TurnoTrabalho> turnosTrabalho)
        {
            Usuario = usuario;
            TurnosTrabalho = turnosTrabalho;
        }

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

        // Remova o 'required'
        public Usuario Usuario { get; set; }

        // Remova o 'required'
        public ICollection<TurnoTrabalho> TurnosTrabalho { get; set; }
    }
}