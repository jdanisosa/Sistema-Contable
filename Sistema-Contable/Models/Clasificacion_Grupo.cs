using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Contable.Models
{
    public class Clasificacion_Grupo
    {
        [Key]
        public int Id_Clasificacion { get; set; }

        [Required(ErrorMessage = "El campo de nombre de clasificación no puede ir vacio")]
        [Display(Name = "Nombre de clasificación")]
        public string? Nombre_Clasificacion { get; set; }

        public int Id_Grupo_Contable { get; set; }

        [ForeignKey("Id_Grupo_Contable")]
        public virtual Grupo_Contable? Grupo_Contable{ get; set; } = null!;
    }
}
