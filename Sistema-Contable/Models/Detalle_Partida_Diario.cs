using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Contable.Models
{
    public class Detalle_Partida_Diario
    {
        public int Id_Cuenta { get; set; }
        public int Id_Partida { get; set; }
        public float Debe { get; set; }
        public float Haber { get; set; }
        public float Saldo { get; set; }

        [ForeignKey("Id_Cuenta")]
        public virtual Cuenta? Cuenta { get; set; } = null!;

        [ForeignKey("Id_Partida")]
        public virtual Partida_Diario? Partida_Diario { get; set; } = null!;


    }
}
