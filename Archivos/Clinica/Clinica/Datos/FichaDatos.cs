using Clinica.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.CompilerServices;


namespace Clinica.Datos
{
    public class FichaDatos
    {
        public List<Ficha> listarficha()
        {

            var oficha = new List<Ficha>();
            var cv = new conectar();

            using (var conectar = new SqlConnection(cv.getCadenaSQL()))
            {
                conectar.Open();
                SqlCommand cmds = new SqlCommand("sp_listarficha", conectar);
                cmds.CommandType = CommandType.StoredProcedure;

                using (var dl = cmds.ExecuteReader())
                {
                    while (dl.Read())
                    {
                        oficha.Add(new Ficha()
                        {

                            Idficha = Convert.ToInt32(dl["Idficha"]),
                            nombreficha = dl["nombreficha"].ToString(),
                            apellido = dl["apellido"].ToString(),
                            nacimiento = dl["nacimiento"].ToString(),
                            edad = dl["edad"].ToString(),
                            dpi = dl["dpi"].ToString(),
                            direccion = dl["direccion"].ToString(),
                            genero = dl["genero"].ToString(),
                            doctora = dl["doctora"].ToString(),
                            tratamiento = dl["tratamiento"].ToString()



                        });
                    }
                }
            }
            return oficha;
        }

        public Ficha Obtenerficha(int Idficha)
        {

            var ofichero = new Ficha();

            var cv = new conectar();

            using (var conectar = new SqlConnection(cv.getCadenaSQL()))
            {
                conectar.Open();
                SqlCommand cmds = new SqlCommand("sp_obtenerficha", conectar);
                cmds.Parameters.AddWithValue("Idficha", Idficha);
                cmds.CommandType = CommandType.StoredProcedure;

                using (var dl = cmds.ExecuteReader())
                {
                    while (dl.Read())
                    {

                        ofichero.Idficha = Convert.ToInt32(dl["Idficha"]);
                        ofichero.nombreficha = dl["nombreficha"].ToString();
                        ofichero.apellido = dl["apellido"].ToString();
                        ofichero.nacimiento = dl["nacimiento"].ToString();
                        ofichero.edad = dl["edad"].ToString();
                        ofichero.dpi = dl["dpi"].ToString();
                        ofichero.direccion = dl["direccion"].ToString();
                        ofichero.genero = dl["genero"].ToString();
                        ofichero.doctora = dl["doctora"].ToString();
                        ofichero.tratamiento = dl["tratamiento"].ToString();

                    }
                }


            }

            return ofichero;
        }
        public bool guardarficha(Ficha ofichero)
        {
            bool rpta;

            try
            {
                var cv = new conectar();

                using (var conectar = new SqlConnection(cv.getCadenaSQL()))
                {
                    conectar.Open();
                    SqlCommand cmds = new SqlCommand("sp_guardarficha", conectar);
                    cmds.Parameters.AddWithValue("nombreficha", ofichero.nombreficha);
                    cmds.Parameters.AddWithValue("apellido", ofichero.apellido);
                    cmds.Parameters.AddWithValue("nacimiento", ofichero.nacimiento);
                    cmds.Parameters.AddWithValue("edad", ofichero.edad);
                    cmds.Parameters.AddWithValue("dpi", ofichero.dpi);
                    cmds.Parameters.AddWithValue("direccion", ofichero.direccion);
                    cmds.Parameters.AddWithValue("genero", ofichero.genero);
                    cmds.Parameters.AddWithValue("doctora", ofichero.doctora);
                    cmds.Parameters.AddWithValue("tratamiento", ofichero.tratamiento);
                    cmds.CommandType = CommandType.StoredProcedure;
                    cmds.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool editarficha(Ficha ofichero)
        {
            bool rpta;

            try
            {
                var cv = new conectar();

                using (var conectar = new SqlConnection(cv.getCadenaSQL()))
                {
                    conectar.Open();
                    SqlCommand cmds = new SqlCommand("sp_editarficha", conectar);
                    cmds.Parameters.AddWithValue("Idficha", ofichero.Idficha);
                    cmds.Parameters.AddWithValue("nombreficha", ofichero.nombreficha);
                    cmds.Parameters.AddWithValue("apellido", ofichero.apellido);
                    cmds.Parameters.AddWithValue("nacimiento", ofichero.nacimiento);
                    cmds.Parameters.AddWithValue("edad", ofichero.edad);
                    cmds.Parameters.AddWithValue("dpi", ofichero.dpi);
                    cmds.Parameters.AddWithValue("direccion", ofichero.direccion);
                    cmds.Parameters.AddWithValue("genero", ofichero.genero);
                    cmds.Parameters.AddWithValue("doctora", ofichero.doctora);
                    cmds.Parameters.AddWithValue("tratamiento", ofichero.tratamiento);
                    cmds.CommandType = CommandType.StoredProcedure;
                    cmds.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool eliminarficha(int Idficha)
        {
            bool rpta;

            try
            {
                var cv = new conectar();

                using (var conectar = new SqlConnection(cv.getCadenaSQL()))
                {
                    conectar.Open();
                    SqlCommand cmds = new SqlCommand("sp_eliminarficha", conectar);
                    cmds.Parameters.AddWithValue("Idficha", Idficha);
                    cmds.CommandType = CommandType.StoredProcedure;
                    cmds.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
