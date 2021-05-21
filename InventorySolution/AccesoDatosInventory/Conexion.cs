using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosInventory
{
    public class Conexion
    {
        public static string ObtenerCadenaDeConexion()
        {
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InventarioBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public static string Cn = ObtenerCadenaDeConexion();

        public static async Task<string> EjecutarConsultaCadena(string consulta, bool returnIdentity)
        {
            string rpta = "OK";
            SqlConnection cnn = new SqlConnection
            {
                ConnectionString = Cn
            };
            try
            {
                await cnn.OpenAsync();
                SqlCommand cmd = new SqlCommand(consulta, cnn);

                if (returnIdentity)
                {
                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    Id_generado = id;
                    if (id > 0)
                        rpta = "OK";
                    else
                        throw new Exception("La identificación única (ID) no se obtuvo correctamente");
                }
                else
                {
                    rpta = await cmd.ExecuteNonQueryAsync() >= 1 ? "OK" : "ERROR";
                }
            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return rpta;
        }

        public static async Task<(string rpta, DataTable dt)> EjecutarConsultaDt(string consulta)
        {
            string rpta = "OK";
            DataTable tabla = new DataTable();
            try
            {
                SqlConnection cnn = new SqlConnection
                {
                    ConnectionString = Cn
                };

                await cnn.OpenAsync();
                SqlCommand m = new SqlCommand(consulta, cnn);
                SqlDataAdapter da = new SqlDataAdapter(m);

                da.Fill(tabla);

                if (tabla.Rows.Count < 1)
                    tabla = null;

                return (rpta, tabla);
            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
                return (rpta, null);
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                return (rpta, null);
            }
        }

        public static int Id_generado;
    }
}
