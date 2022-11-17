using Clinica.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.CompilerServices;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Clinica.Datos
{
    public class InventarioDatos
    {
        public List<Inventario> listInventario()
        {
            var oinventario = new List<Inventario>();
            var cm = new conectar();

            using (var conectar = new SqlConnection(cm.getCadenaSQL()))
            {
                conectar.Open();
                SqlCommand cmdl = new SqlCommand("sp_listarinventario", conectar);
                cmdl.CommandType = CommandType.StoredProcedure;

                using (var drm = cmdl.ExecuteReader())
                {
                    while (drm.Read())
                    {
                        oinventario.Add(new Inventario()
                        {
                            Idinventario = Convert.ToInt32(drm["Idinventario"]),
                            descripcion = drm["descripcion"].ToString(),
                            unitario = drm["unitario"].ToString(),
                            ingreso = drm["ingreso"].ToString(),
                            precio = drm["precio"].ToString(),
                            codigo = drm["codigo"].ToString(),
                            cantidad = drm["cantidad"].ToString(),

                        });
                    }
                }


            }

            return oinventario;
        }

        public Inventario Obtenerinventario(int Idinventario)
        {

            var oinve = new Inventario();

            var cm = new conectar();

            using (var conectar = new SqlConnection(cm.getCadenaSQL()))
            {
                conectar.Open();
                SqlCommand cmdl = new SqlCommand("sp_obtenerinventario", conectar);
                cmdl.Parameters.AddWithValue("Idinventario", Idinventario);
                cmdl.CommandType = CommandType.StoredProcedure;

                using (var drm = cmdl.ExecuteReader())
                {
                    while (drm.Read())
                    {

                        oinve.Idinventario = Convert.ToInt32(drm["Idinventario"]);
                        oinve.descripcion = drm["descripcion"].ToString();
                        oinve.unitario = drm["unitario"].ToString();
                        oinve.ingreso = drm["ingreso"].ToString();
                        oinve.precio = drm["precio"].ToString();
                        oinve.codigo = drm["codigo"].ToString();
                        oinve.cantidad = drm["cantidad"].ToString();


                    }
                }


            }

            return oinve;
        }

        public bool guardarinventario(Inventario oinve)
        {
            bool rpta;

            try
            {
                var cm = new conectar();

                using (var conectar = new SqlConnection(cm.getCadenaSQL()))
                {
                    conectar.Open();
                    SqlCommand cmdl = new SqlCommand("sp_guardarinventario", conectar);
                    cmdl.Parameters.AddWithValue("descripcion", oinve.descripcion);
                    cmdl.Parameters.AddWithValue("unitario", oinve.unitario);
                    cmdl.Parameters.AddWithValue("ingreso", oinve.ingreso);
                    cmdl.Parameters.AddWithValue("precio", oinve.precio);
                    cmdl.Parameters.AddWithValue("codigo", oinve.codigo);
                    cmdl.Parameters.AddWithValue("cantidad", oinve.cantidad);
                    cmdl.CommandType = CommandType.StoredProcedure;
                    cmdl.ExecuteNonQuery();

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

        public bool editarinventario(Inventario oinve)
        {
            bool rpta;

            try
            {
                var cm = new conectar();

                using (var conectar = new SqlConnection(cm.getCadenaSQL()))
                {
                    conectar.Open();
                    SqlCommand cmdl = new SqlCommand("sp_editarinventario", conectar);
                    cmdl.Parameters.AddWithValue("Idinventario", oinve.Idinventario);
                    cmdl.Parameters.AddWithValue("descripcion", oinve.descripcion);
                    cmdl.Parameters.AddWithValue("unitario", oinve.unitario);
                    cmdl.Parameters.AddWithValue("ingreso", oinve.ingreso);
                    cmdl.Parameters.AddWithValue("precio", oinve.precio);
                    cmdl.Parameters.AddWithValue("codigo", oinve.codigo);
                    cmdl.Parameters.AddWithValue("cantidad", oinve.cantidad);
                    cmdl.CommandType = CommandType.StoredProcedure;
                    cmdl.ExecuteNonQuery();

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

        public bool eliminarinventario(int Idinventario)
        {
            bool rpta;

            try
            {
                var cm = new conectar();

                using (var conectar = new SqlConnection(cm.getCadenaSQL()))
                {
                    conectar.Open();
                    SqlCommand cmdl = new SqlCommand("sp_eliminarinventario", conectar);
                    cmdl.Parameters.AddWithValue("Idinventario", Idinventario);
                    cmdl.CommandType = CommandType.StoredProcedure;
                    cmdl.ExecuteNonQuery();

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
