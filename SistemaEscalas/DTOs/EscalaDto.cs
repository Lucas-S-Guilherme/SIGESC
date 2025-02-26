using System.ComponentModel.DataAnnotations;

namespace SistemaEscalas.Dtos
{
    public class EscalaDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "O nome da escala deve ter no mínimo 5 caracteres")]
        public required string Nome { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O local de trabalho deve ter no mínimo 5 caracteres")]
        public required string LocalTrabalho { get; set; }

        [Required]
        public required DateTime DataInicio { get; set; }

        [Required]
        public required DateTime DataFim { get; set; }

        [Required]
        public required int UsuarioId { get; set; }
    }
}