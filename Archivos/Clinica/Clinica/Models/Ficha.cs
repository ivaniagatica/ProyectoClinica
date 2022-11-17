using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public class Ficha
    {
        public int Idficha { get; set; }
        [Required]
        public string? nombreficha { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? apellido { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? nacimiento { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? edad { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? dpi { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? direccion { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? genero { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? doctora { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? tratamiento { get; set; }
    }
}
