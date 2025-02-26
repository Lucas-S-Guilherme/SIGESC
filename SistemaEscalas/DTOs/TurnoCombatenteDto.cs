using System.ComponentModel.DataAnnotations;

namespace SistemaEscalas.Dtos
{
    public class TurnoCombatenteDto
    {
        [Required]
        public required int CombatenteId { get; set; }

        [Required]
        public required int TurnoId { get; set; }

        [Required]
        public required DateTime HoraInicio { get; set; }

        [Required]
        public required DateTime HoraFim { get; set; }

        public string? StatusDescanso { get; set; }
    }
}