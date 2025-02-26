using System.ComponentModel.DataAnnotations;

namespace SistemaEscalas.Dtos
{
    public class TurnoTrabalhoDto
    {
        [Required]
        public required DateTime DataInicio { get; set; }

        [Required]
        public required DateTime DataFim { get; set; }

        [Required]
        public required int EscalaId { get; set; }
    }
}