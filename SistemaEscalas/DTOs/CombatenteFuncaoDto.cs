using System.ComponentModel.DataAnnotations;

namespace SistemaEscalas.Dtos
{
    public class CombatenteFuncaoDto
    {
        [Required]
        public required int CombatenteId { get; set; }

        [Required]
        public required int FuncaoId { get; set; }
    }
}