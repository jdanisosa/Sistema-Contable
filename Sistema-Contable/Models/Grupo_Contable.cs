using System.ComponentModel.DataAnnotations;

namespace Sistema_Contable.Models
{
    public class Grupo_Contable
    {

        [Key]
        public int Id_Grupo_Contable { get; set; }

        [Required(ErrorMessage = "El campo de nombre de grupo contable no puede ir vacio")]
        [Display(Name = "Nombre de grupo contable")]
        public string? Nombre_Grupo { get; set; }

    }
}
