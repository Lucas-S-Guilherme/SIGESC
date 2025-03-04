using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{
    public class Usuario
    {
        [Column("id_usuario")]
        public int Id { get; set; }

        [Column("tipo_usuario")]
        public required string Tipo { get; set; }

        [Column("nome_usuario")]
        public required string Nome { get; set; }

        [Column("cpf_usuario")]
        public required string CPF { get; set; }

        [Column("data_nascimento_usuario")]
        public DateOnly DataNascimento { get; set; }

        [Column("telefone_usuario")]
        public required string Telefone { get; set; }

        [Column("email_usuario")]
        public required string Email { get; set; }

        [Column("matricula")]
        public required string Matricula { get; set; }

        [Column("senha")]
        public required string Senha { get; set; }

        // Propriedade de navegação para as escalas associadas
        public ICollection<Escala>? Escalas { get; set; }
    }
}