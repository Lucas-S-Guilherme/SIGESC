using System.ComponentModel.DataAnnotations;

namespace SistemaEscalas.Dtos
{
    public class LoginDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "O campo Username deve ter no mínimo 5 caracteres.")]
        public required string Username { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O campo Password deve ter no mínimo 5 caracteres.")]
        public required string Password { get; set; }
    }
}