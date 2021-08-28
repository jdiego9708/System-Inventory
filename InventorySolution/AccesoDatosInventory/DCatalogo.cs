namespace AccesoDatosInventory
{
    using AccesoDatosInventory.Interfaces;
    using EntidadesInventory.Models;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class DCatalogo : IAccesoDatosCatalogo
    {
        #region CONSTRUCTOR VACIO
        public DCatalogo()
        {
            this.SqlCon = new SqlConnection(Conexion.Cn);
            this.SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            this.SqlCon.FireInfoMessageEventOnUserErrors = true;
        }
        #endregion

        #region MENSAJE SQL
        private void SqlCon_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.Mensaje_error = e.Message;
        }
        #endregion

        #region PROPIEDADES
        private string mensaje_error;
        public string Mensaje_error
        {
            get
            {
                return mensaje_error;
            }

            set
            {
                mensaje_error = value;
            }
        }
        private readonly SqlConnection SqlCon;
        #endregion

        #region METODO INSERTAR CATALOGO
        public async Task<(string rpta, int id_tipo)> InsertarCatalogo(Catalogo catalogo)
        {
            int id_tipo = 0;
            int contador = 0;
            string rpta = string.Empty;          

            try
            {
                await SqlCon.OpenAsync();

                SqlCommand SqlCmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Catalogo_i",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_tipo = new()
                {
                    ParameterName = "@Id_tipo",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_tipo);

                SqlParameter Id_padre = new()
                {
                    ParameterName = "@Id_padre",
                    SqlDbType = SqlDbType.Int,
                    Value = catalogo.Id_padre,
                };
                SqlCmd.Parameters.Add(Id_padre);
                contador++;

                SqlParameter Nombre_tipo = new()
                {
                    ParameterName = "@Nombre_tipo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = catalogo.Nombre_tipo.Trim(),
                };
                SqlCmd.Parameters.Add(Nombre_tipo);
                contador++;
              
                rpta = await SqlCmd.ExecuteNonQueryAsync() >= 1 ? "OK" : "NO";

                if (rpta != "OK")
                {
                    if (this.Mensaje_error != null)
                    {
                        rpta = this.Mensaje_error;
                    }
                }
                else
                {
                    id_tipo = Convert.ToInt32(SqlCmd.Parameters["@Id_tipo"].Value);
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
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return (rpta, id_tipo);
        }
        #endregion

        #region METODO BUSCAR CATALOGO
        public async Task<(string rpta, DataSet ds)> BuscarCatalogo(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";
            DataSet ds = new();

            try
            {
                await this.SqlCon.OpenAsync();

                SqlCommand Sqlcmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Catalogo_g",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Tipo_busqueda = new()
                {
                    ParameterName = "@Tipo_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = tipo_busqueda.Trim().ToUpper()
                };
                Sqlcmd.Parameters.Add(Tipo_busqueda);

                SqlParameter Texto_busqueda = new()
                {
                    ParameterName = "@Texto_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = texto_busqueda.Trim().ToUpper()
                };
                Sqlcmd.Parameters.Add(Texto_busqueda);

                SqlDataAdapter SqlData = new(Sqlcmd);
                SqlData.Fill(ds);

                if (ds.Tables.Count < 1)
                {
                    rpta = "SIN FILAS";
                    ds = null;
                }
            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
                ds = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                ds = null;
            }

            return (rpta, ds);
        }

        #endregion
    }
}
