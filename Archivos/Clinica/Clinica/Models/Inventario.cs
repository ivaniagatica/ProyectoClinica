using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace Clinica.Models
{
    public class Inventario
    {
        public int Idinventario { get; set; }
        [Required]
        public string? descripcion { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? unitario { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? ingreso { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? precio { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? codigo { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? cantidad { get; set; }

    }
}
