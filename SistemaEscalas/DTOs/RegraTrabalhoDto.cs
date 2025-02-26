using System.ComponentModel.DataAnnotations;

namespace SistemaEscalas.Dtos
{
    public class RegraTrabalhoDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "A descrição deve ter no mínimo 10 caracteres")]
        public required string Descricao { get; set; }

        [Required]
        [Range(1, 48, ErrorMessage = "As horas de descanso mínimas devem estar entre 1 e 48")]
        public required int HorasDescansoMinimas { get; set; }
    }
}