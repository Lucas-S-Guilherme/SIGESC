using System.ComponentModel.DataAnnotations;

namespace SistemaEscalas.Dtos
{
    public class EspecializacaoDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "O nome da especialização deve ter no mínimo 5 caracteres")]
        public required string Nome { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "A descrição deve ter no mínimo 10 caracteres")]
        public required string Descricao { get; set; }

        [Required]
        [Length(4, 4, ErrorMessage = "A sigla deve ter exatamente 4 caracteres")]
        public required string Sigla { get; set; }
    }
}