using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{
    public class Usuario
    {
        [Column("id_usuario")]
        public int Id { get; set; }

        [Column("tipo_usuario")]
        public string Tipo { get; set; }

        [Column("nome_usuario")]
        public string Nome { get; set; }

        [Column("cpf_usuario")]
        public string CPF { get; set; }

        [Column("data_nascimento_usuario")]
        public DateOnly DataNascimento { get; set; }

        [Column("telefone_usuario")]
        public string Telefone { get; set; }

        [Column("email_usuario")]
        public string Email { get; set; }

        [Column("matricula")]
        public string Matricula { get; set; }
    }
}