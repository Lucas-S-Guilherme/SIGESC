
namespace SistemaEscalas.Models
{
    public class Usuario
    {
        public int id {get; set;}
        public string? tipo {get; set;}

        public string? nome {get; set;}

        public string? cpf {get; set;}

        public DateOnly dataNascimento {get; set;}

        public string? telefone {get; set;}

        public string? email {get; set;}

        public string? matricula {get; set;}


    }
}