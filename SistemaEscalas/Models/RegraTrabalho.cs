using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{
    public class RegraTrabalho
    {
        [Column("id_regra_trabalho")]
        public int Id { get; set; }

        [Column("descricao_regra_trabalho")]
        public string Descricao { get; set; }

        [Column("horas_descanso_minimas")]
        public int HorasDescansoMinimas { get; set; }
    }
}