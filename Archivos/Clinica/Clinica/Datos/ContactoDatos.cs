using Clinica.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.CompilerServices;

namespace Clinica.Datos
{
    public class ContactoDatos
    {
        public List<AsignarCitas> listar()
        {

            var olista = new List<AsignarCitas>();

            var cn = new conectar();

            using (var conectar = new SqlConnection(cn.getCadenaSQL()))
            {
                conectar.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conectar);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new AsignarCitas()
                        {
                            Idcitas = Convert.ToInt32(dr["Idcitas"]),
                            nombre = dr["nombre"].ToString(),
                            telefono = dr["telefono"].ToString(),
                            correo = dr["correo"].ToString(),
                            fecha = dr["fecha"].ToString(),
                            hora = dr["hora"].ToString(),
                            comentario = dr["comentario"].ToString()
                        });
                    }
                }


            }

            return olista;
        }
        public AsignarCitas Obtener(int Idcitas)
        {

            var ocitas = new AsignarCitas();

            var cn = new conectar();

            using (var conectar = new SqlConnection(cn.getCadenaSQL()))
            {
                conectar.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener", conectar);
                cmd.Parameters.AddWithValue("Idcitas", Idcitas);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        ocitas.Idcitas = Convert.ToInt32(dr["Idcitas"]);
                        ocitas.nombre = dr["nombre"].ToString();
                        ocitas.telefono = dr["telefono"].ToString();
                        ocitas.correo = dr["correo"].ToString();
                        ocitas.fecha = dr["fecha"].ToString();
                        ocitas.hora = dr["hora"].ToString();
                        ocitas.comentario = dr["comentario"].ToString();

                    }
                }


            }

            return ocitas;
        }

        public bool guardar(AsignarCitas ocitas)
        {
            bool rpta;

            try
            {
                var cn = new conectar();

                using (var conectar = new SqlConnection(cn.getCadenaSQL()))
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardar", conectar);
                    cmd.Parameters.AddWithValue("nombre", ocitas.nombre);
                    cmd.Parameters.AddWithValue("telefono", ocitas.telefono);
                    cmd.Parameters.AddWithValue("correo", ocitas.correo);
                    cmd.Parameters.AddWithValue("fecha", ocitas.fecha);
                    cmd.Parameters.AddWithValue("hora", ocitas.hora);
                    cmd.Parameters.AddWithValue("comentario", ocitas.comentario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

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

        public bool editar(AsignarCitas ocitas)
        {
            bool rpta;

            try
            {
                var cn = new conectar();

                using (var conectar = new SqlConnection(cn.getCadenaSQL()))
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand("sp_editar", conectar);
                    cmd.Parameters.AddWithValue("Idcitas", ocitas.Idcitas);
                    cmd.Parameters.AddWithValue("nombre", ocitas.nombre);
                    cmd.Parameters.AddWithValue("telefono", ocitas.telefono);
                    cmd.Parameters.AddWithValue("correo", ocitas.correo);
                    cmd.Parameters.AddWithValue("fecha", ocitas.fecha);
                    cmd.Parameters.AddWithValue("hora", ocitas.hora);
                    cmd.Parameters.AddWithValue("comentario", ocitas.comentario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

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

        public bool eliminar(int Idcitas)
        {
            bool rpta;

            try
            {
                var cn = new conectar();

                using (var conectar = new SqlConnection(cn.getCadenaSQL()))
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminar", conectar);
                    cmd.Parameters.AddWithValue("Idcitas", Idcitas);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

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
