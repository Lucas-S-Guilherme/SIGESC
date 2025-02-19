namespace SistemaEscalas.Models
{
    public class TurnoTrabalho 
    {
        public int Id {get; set;}

        public DateTime DataHoraInicio {get; set;}
        public DateTime DataHoraFim {get; set;}

        public int IdEscala { get; set;}

        
    }
}