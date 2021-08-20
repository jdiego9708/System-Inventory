namespace AccesoDatosInventory
{
    using AccesoDatosInventory.Interfaces;
    using EntidadesInventory.Models;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class DPedidos : IAccesoDatosPedidos
    {
        #region CONSTRUCTOR VACIO
        public DPedidos()
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

        #region METODO INSERTAR PEDIDO
        public async Task<(string rpta, int id)> InsertarPedido(Pedidos pedido)
        {
            int id_pedido = 0;
            int contador = 0;
            string rpta = string.Empty;

            try
            {
                await SqlCon.OpenAsync();

                SqlCommand SqlCmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Pedidos_i",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_pedido = new()
                {
                    ParameterName = "@Id_pedido",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_pedido);

                SqlParameter Fecha_pedido = new()
                {
                    ParameterName = "@Fecha_pedido",
                    SqlDbType = SqlDbType.Date,
                    Value = pedido.Fecha_pedido.ToString("yyyy-MM-dd"),
                };
                SqlCmd.Parameters.Add(Fecha_pedido);
                contador++;

                SqlParameter Hora_pedido = new()
                {
                    ParameterName = "@Hora_pedido",
                    SqlDbType = SqlDbType.Time,
                    Value = pedido.Hora_pedido,
                };
                SqlCmd.Parameters.Add(Hora_pedido);
                contador++;

                SqlParameter Id_tipo_pedido = new()
                {
                    ParameterName = "@Id_tipo_pedido",
                    SqlDbType = SqlDbType.Int,
                    Value = pedido.Id_tipo_pedido,
                };
                SqlCmd.Parameters.Add(Id_tipo_pedido);
                contador++;

                SqlParameter Id_cliente = new()
                {
                    ParameterName = "@Id_cliente",
                    SqlDbType = SqlDbType.Int,
                    Value = pedido.Id_cliente,
                };
                SqlCmd.Parameters.Add(Id_cliente);
                contador++;

                SqlParameter Id_empleado = new()
                {
                    ParameterName = "@Id_empleado",
                    SqlDbType = SqlDbType.Int,
                    Value = pedido.Id_empleado,
                };
                SqlCmd.Parameters.Add(Id_empleado);
                contador++;

                SqlParameter Observaciones_pedido = new()
                {
                    ParameterName = "@Observaciones_pedido",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = pedido.Observaciones_pedido.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Observaciones_pedido);
                contador++;

                SqlParameter CantidadClientes = new()
                {
                    ParameterName = "@CantidadClientes",
                    SqlDbType = SqlDbType.Int,
                    Value = pedido.CantidadClientes,
                };
                SqlCmd.Parameters.Add(CantidadClientes);
                contador++;

                SqlParameter Informacion_adicional = new()
                {
                    ParameterName = "@Informacion_adicional",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = pedido.Informacion_adicional.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Informacion_adicional);
                contador++;

                SqlParameter Estado_pedido = new()
                {
                    ParameterName = "@Estado_pedido",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = pedido.Estado_pedido.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Estado_pedido);
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
                    id_pedido = Convert.ToInt32(SqlCmd.Parameters["@Id_pedido"].Value);
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
            return (rpta, id_pedido);
        }
        #endregion

        #region METODO EDITAR PEDIDO
        public async Task<string> EditarPedido(Pedidos pedido)
        {
            int contador = 0;
            string rpta = string.Empty;

            try
            {
                await SqlCon.OpenAsync();

                SqlCommand SqlCmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Pedidos_u",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_pedido = new()
                {
                    ParameterName = "@Id_pedido",
                    SqlDbType = SqlDbType.Int,
                    Value = pedido.Id_pedido,
                };
                SqlCmd.Parameters.Add(Id_pedido);

                SqlParameter Fecha_pedido = new()
                {
                    ParameterName = "@Fecha_pedido",
                    SqlDbType = SqlDbType.Date,
                    Value = pedido.Fecha_pedido.ToString("yyyy-MM-dd"),
                };
                SqlCmd.Parameters.Add(Fecha_pedido);
                contador++;

                SqlParameter Hora_pedido = new()
                {
                    ParameterName = "@Hora_pedido",
                    SqlDbType = SqlDbType.Time,
                    Value = pedido.Hora_pedido,
                };
                SqlCmd.Parameters.Add(Hora_pedido);
                contador++;

                SqlParameter Id_tipo_pedido = new()
                {
                    ParameterName = "@Id_tipo_pedido",
                    SqlDbType = SqlDbType.Int,
                    Value = pedido.Id_tipo_pedido,
                };
                SqlCmd.Parameters.Add(Id_tipo_pedido);
                contador++;

                SqlParameter Id_cliente = new()
                {
                    ParameterName = "@Id_cliente",
                    SqlDbType = SqlDbType.Int,
                    Value = pedido.Id_cliente,
                };
                SqlCmd.Parameters.Add(Id_cliente);
                contador++;

                SqlParameter Id_empleado = new()
                {
                    ParameterName = "@Id_empleado",
                    SqlDbType = SqlDbType.Int,
                    Value = pedido.Id_empleado,
                };
                SqlCmd.Parameters.Add(Id_empleado);
                contador++;

                SqlParameter Observaciones_pedido = new()
                {
                    ParameterName = "@Observaciones_pedido",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = pedido.Observaciones_pedido.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Observaciones_pedido);
                contador++;

                SqlParameter CantidadClientes = new()
                {
                    ParameterName = "@CantidadClientes",
                    SqlDbType = SqlDbType.Int,
                    Value = pedido.CantidadClientes,
                };
                SqlCmd.Parameters.Add(CantidadClientes);
                contador++;

                SqlParameter Informacion_adicional = new()
                {
                    ParameterName = "@Informacion_adicional",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = pedido.Informacion_adicional.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Informacion_adicional);
                contador++;

                SqlParameter Estado_pedido = new()
                {
                    ParameterName = "@Estado_pedido",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = pedido.Estado_pedido.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Estado_pedido);
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

        #region METODO BUSCAR PEDIDOS
        public async Task<(string rpta, DataSet ds)> BuscarPedidos(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";
            DataSet ds = new();

            try
            {
                await this.SqlCon.OpenAsync();

                SqlCommand Sqlcmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Pedidos_g",
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
