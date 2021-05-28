namespace AccesoDatosInventory
{
    using EntidadesInventory.Models;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class DMovimientos
    {
        #region CONSTRUCTOR VACIO
        public DMovimientos()
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

        #region METODO INSERTAR MOVIMIENTO
        public async Task<(string rpta, int id)> InsertarMovimiento(Movimientos movimiento)
        {
            int id_movimiento = 0;
            int contador = 0;
            string rpta = string.Empty;          

            try
            {
                await SqlCon.OpenAsync();

                SqlCommand SqlCmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Insertar_movimiento",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_movimiento = new()
                {
                    ParameterName = "@Id_movimiento",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_movimiento);

                SqlParameter Id_tipo_movimiento = new()
                {
                    ParameterName = "@Id_tipo_movimiento",
                    SqlDbType = SqlDbType.Int,
                    Value = movimiento.Id_tipo_movimiento,
                };
                SqlCmd.Parameters.Add(Id_tipo_movimiento);
                contador++;

                SqlParameter Fecha_movimiento = new()
                {
                    ParameterName = "@Fecha_movimiento",
                    SqlDbType = SqlDbType.Date,
                    Value = movimiento.Fecha_movimiento,
                };
                SqlCmd.Parameters.Add(Fecha_movimiento);
                contador++;

                SqlParameter Hora_movimiento = new()
                {
                    ParameterName = "@Hora_movimiento",
                    SqlDbType = SqlDbType.Time,
                    Value = movimiento.Hora_movimiento,
                };
                SqlCmd.Parameters.Add(Hora_movimiento);
                contador++;

                SqlParameter Descripcion_movimiento = new()
                {
                    ParameterName = "@Descripcion_movimiento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = movimiento.Descripcion_movimiento.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Descripcion_movimiento);
                contador++;

                SqlParameter Estado_movimiento = new()
                {
                    ParameterName = "@Estado_movimiento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = movimiento.Estado_movimiento.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Estado_movimiento);
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
                    id_movimiento = Convert.ToInt32(SqlCmd.Parameters["@Id_movimiento"].Value);
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
            return (rpta, id_movimiento);
        }
        #endregion

        #region METODO EDITAR MOVIMIENTO
        public async Task<string> EditarMovimiento(Movimientos movimiento)
        {
            int contador = 0;
            string rpta = string.Empty;

            try
            {
                await SqlCon.OpenAsync();

                SqlCommand SqlCmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Insertar_movimiento",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_movimiento = new()
                {
                    ParameterName = "@Id_movimiento",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_movimiento);

                SqlParameter Id_tipo_movimiento = new()
                {
                    ParameterName = "@Id_tipo_movimiento",
                    SqlDbType = SqlDbType.Int,
                    Value = movimiento.Id_tipo_movimiento,
                };
                SqlCmd.Parameters.Add(Id_tipo_movimiento);
                contador++;

                SqlParameter Fecha_movimiento = new()
                {
                    ParameterName = "@Fecha_movimiento",
                    SqlDbType = SqlDbType.Date,
                    Value = movimiento.Fecha_movimiento,
                };
                SqlCmd.Parameters.Add(Fecha_movimiento);
                contador++;

                SqlParameter Hora_movimiento = new()
                {
                    ParameterName = "@Hora_movimiento",
                    SqlDbType = SqlDbType.Time,
                    Value = movimiento.Hora_movimiento,
                };
                SqlCmd.Parameters.Add(Hora_movimiento);
                contador++;

                SqlParameter Descripcion_movimiento = new()
                {
                    ParameterName = "@Descripcion_movimiento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = movimiento.Descripcion_movimiento.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Descripcion_movimiento);
                contador++;

                SqlParameter Estado_movimiento = new()
                {
                    ParameterName = "@Estado_movimiento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = movimiento.Estado_movimiento.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Estado_movimiento);
                contador++;

                rpta = await SqlCmd.ExecuteNonQueryAsync() >= 1 ? "OK" : "NO";

                if (rpta != "OK")
                {
                    if (this.Mensaje_error != null)
                    {
                        rpta = this.Mensaje_error;
                    }
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
            return rpta;
        }
        #endregion

        #region METODO BUSCAR MOVIMIENTOS
        public async Task<(string rpta, DataSet ds)> BuscarMovimientos(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";
            DataSet ds = new();

            try
            {
                await this.SqlCon.OpenAsync();

                SqlCommand Sqlcmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Buscar_movimientos",
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
