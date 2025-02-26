using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{
    public class Combatente 
    {
        [Column("id_ser")]
        public int Id {get; set;}

        [Column("nome_combatente")]
        public string? Nome {get; set;}

        [Column("cpf_combatente")]
        public string? CPF {get; set;}

        [Column("data_nascimento_combatente")]
        public DateOnly DataNascimento {get; set;}

        [Column("telefone_combatente")]
        public string? Telefone {get; set;}

        [Column("email_combatente")]
        public string? Email {get; set;}

        [Column("matricula_combatente")]
        public string? Matricula {get; set;}

        [Column("ultimo_turno_trabalhado")]
        public DateTime UltimoTurnoTrabalhado {get;set;}       


    }
}