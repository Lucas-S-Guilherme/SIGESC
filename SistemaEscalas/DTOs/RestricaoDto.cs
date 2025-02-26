using System.ComponentModel.DataAnnotations;

namespace SistemaEscalas.Dtos
{
    public class RestricaoDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "O nome da restrição deve ter no mínimo 5 caracteres")]
        public required string Nome { get; set; }

        [Required]
        [Length(2, 2, ErrorMessage = "O grupo deve ter exatamente 2 caracteres")]
        public required string Grupo { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "A descrição deve ter no mínimo 10 caracteres")]
        public required string Descricao { get; set; }
    }
}