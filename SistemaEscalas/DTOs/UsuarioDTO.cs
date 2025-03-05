using System.ComponentModel.DataAnnotations;

namespace SistemaEscalas.Dtos
{
    public class UsuarioDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "O tipo de usuário deve ter no mínimo 5 caracteres")]
        public required string Tipo { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O nome do usuário deve ter no mínimo 5 caracteres")]
        public required string Nome { get; set; }

        [Required]
        [Length(11, 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres")]
        public required string CPF { get; set; }

        [Required]
        public required DateOnly DataNascimento { get; set; }

        [Length(11, 11, ErrorMessage = "O telefone deve ter exatamente 11 caracteres")]
        public string? Telefone { get; set; }

        [EmailAddress(ErrorMessage = "O email deve ser válido")]
        public string? Email { get; set; }

        [Required]
        [MinLength(9, ErrorMessage = "A matrícula deve ter no mínimo 9 caracteres")]
        public required string Matricula { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "A Senha deve ter no mínimo 5 caracteres")]
        public required string Senha { get; set; }        
    }
}