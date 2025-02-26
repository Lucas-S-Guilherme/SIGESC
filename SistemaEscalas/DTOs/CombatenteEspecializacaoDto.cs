using System.ComponentModel.DataAnnotations;

namespace SistemaEscalas.Dtos
{
    public class CombatenteEspecializacaoDto
    {
        [Required]
        public required int CombatenteId { get; set; }

        [Required]
        public required int EspecializacaoId { get; set; }
    }
}