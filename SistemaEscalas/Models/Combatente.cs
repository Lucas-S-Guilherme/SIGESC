namespace SistemaEscalas.Models
{
    public class Combatente 
    {
        public int Id {get; set;}
        public string? Nome {get; set;}

        public string? CPF {get; set;}

        public DateOnly DataNascimento {get; set;}

        public string? Telefone {get; set;}

        public string? Email {get; set;}

        public string? Matricula {get; set;}

        public DateTime UltimoTurnoTrabalhado {get;set;}       


    }
}