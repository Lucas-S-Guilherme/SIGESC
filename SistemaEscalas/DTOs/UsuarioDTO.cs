using System.ComponentModel; // usado caso tenha tamanho mínimo [MinLenght]
using System.ComponentModel.DataAnnotations;

namespace SistemaEscalas.DTOs
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? tipo {get; set;}

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? nome {get; set;}
    }
}