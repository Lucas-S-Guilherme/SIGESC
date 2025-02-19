namespace SistemaEscalas.Models
{
    public class TurnoCombatente
    {
        public int IdTurnoCombatente { get; set; }
        public int IdCombatente { get; set; }
        public int IdTurno { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public string? StatusDescanso { get; set; }
    }
}