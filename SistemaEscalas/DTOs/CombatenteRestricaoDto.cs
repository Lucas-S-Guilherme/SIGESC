using System.ComponentModel.DataAnnotations;

namespace SistemaEscalas.Dtos
{
    public class CombatenteRestricaoDto
    {
        [Required]
        public required int CombatenteId { get; set; }

        [Required]
        public required int RestricaoId { get; set; }
    }
}