using System.ComponentModel.DataAnnotations;

namespace SistemaEscalas.Dtos
{
    public class FuncaoDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "O nome da função deve ter no mínimo 5 caracteres")]
        public required string Nome { get; set; }

        [Required]
        [Length(4, 4, ErrorMessage = "A sigla deve ter exatamente 4 caracteres")]
        public required string Sigla { get; set; }
    }
}