using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Contable.Models
{
    public class Cuenta
    {
        [Key]
        public int Id_Cuenta { get; set; }

        [Required(ErrorMessage = "El campo de codigo de cuenta no puede ir vacio")]
        [Display(Name = "Codigo de cuenta")]
        public string? Codigo_Cuenta { get; set; }

        [Required(ErrorMessage = "El campo de nombre de cuenta no puede ir vacio")]
        [Display(Name = "Nombre de cuenta")]
        public string? Nombre_Cuenta { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        public float Saldo_Actual { get; set; }

        public int Id_Clasificacion { get; set; }

        [ForeignKey("Id_Clasificacion")]
        public virtual Clasificacion_Grupo? Clasificacion_Grupo { get; set; } = null!;
    }
}
