namespace Clinica.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        
        public string? electronico { get; set; }

        public string? clave { get; set; }
    
        public string? confirmarClave { get; set; } 
    }

}
