using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public class AsignarCitas
    {
        public int Idcitas { get; set; }
        [Required ]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? telefono { get; set; }
        [Required(ErrorMessage ="El campo telefono es obligatorio")]
        public string? correo { get; set; }
        [Required(ErrorMessage ="El campo correo es obligatorio ")]
        public string? fecha { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio ")]
        public string? hora { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio ")]
        public string? comentario { get; set; }
        


    }

    
}
