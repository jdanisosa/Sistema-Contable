using System.ComponentModel.DataAnnotations;

namespace Sistema_Contable.Models
{
    public class Partida_Diario
    {
        [Key]
        public int Id_Partida { get; set; }

        [Display(Name = "Correlativo")]
        public string? Correlativo { get; set; }

        [Display(Name = "No. de documento")]
        public string? Numero_Documento { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Descripcion")]
        public string? Descripcion { get; set; }


    }
}
