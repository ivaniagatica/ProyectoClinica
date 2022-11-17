using Microsoft.AspNetCore.Mvc;
using Clinica.Models;
using Clinica.Datos;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Web;
using System.IO;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.WebUtilities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;


using System.Data.SqlClient;
using System.Data;




namespace Clinica.Controllers
{
    public class AccesoController : Controller
    {
        static string union = "Server=DESKTOP-PT79KR1;Database=CLINICA_finall;Trusted_Connection=True;Integrated Security=false;User Id=sa;Password=gordo";



        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Usuario ousuario)
        {
            bool registrado;
            string mensaje;


            if(ousuario.clave == ousuario.confirmarClave)
            {
                ousuario.clave = ConvertirSha256(ousuario.clave);

            }
            else
            {
                ViewData["mensaje"] = "Las contraseñas no coinciden ";
                return View();
                    
             }

            using (SqlConnection cnn = new SqlConnection(union))
            {
                SqlCommand cmr = new SqlCommand("sp_RegistrarUsuario", cnn);
                cmr.Parameters.AddWithValue("electronico", ousuario.electronico);
                cmr.Parameters.AddWithValue("clave", ousuario.clave);
                cmr.Parameters.Add("registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmr.Parameters.Add("mensaje", SqlDbType.VarChar,100).Direction = ParameterDirection.Output;
                cmr.CommandType = CommandType.StoredProcedure;

                cnn.Open();
                cmr.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmr.Parameters["registrado"].Value);
                mensaje = cmr.Parameters["mensaje"].Value.ToString();

            }

            ViewData["mensaje"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Login", "Acceso");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult Login(Usuario ousuario)
        {

            ousuario.clave = ConvertirSha256(ousuario.clave);

     

            try
            {
                using (SqlConnection cnn = new SqlConnection(union))
                {
                    SqlCommand cmr = new SqlCommand("sp_validarUsuario", cnn);
                    cmr.Parameters.AddWithValue("electronico", ousuario.electronico);
                    cmr.Parameters.AddWithValue("clave", ousuario.clave);
                    cmr.CommandType = CommandType.StoredProcedure;

                    cnn.Open();
                    ousuario.IdUsuario = Convert.ToInt32(cmr.ExecuteScalar().ToString());

                }
            }
            catch (Exception e)
            {
                string error = e.Message;
           
            }

            if (ousuario.IdUsuario != 0)
            {
                //Session["usuario"] = ousuario;
                return RedirectToAction("Index", "Home");
            }
            else {
                ViewData["mensaje"] = "El usuario/contraseña es incorrecto";
                return View();
            }
                
        }

        public static string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

               foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();

        }

        
    }
}
