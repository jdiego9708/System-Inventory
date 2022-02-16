namespace AccesoDatosInventory
{
    using AccesoDatosInventory.Interfaces;
    using EntidadesInventory.Models;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class DProductos : IAccesoDatosProductos
    {
        #region CONSTRUCTOR VACIO
        public DProductos()
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

        #region METODO INSERTAR PRODUCTO
        public async Task<(string rpta, int id)> InsertarProducto(Productos producto)
        {
            int id_producto = 0;
            int contador = 0;
            string rpta = string.Empty;          

            try
            {
                await SqlCon.OpenAsync();

                SqlCommand SqlCmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Productos_i",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_producto = new()
                {
                    ParameterName = "@Id_producto",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_producto);

                SqlParameter Id_tipo_producto = new()
                {
                    ParameterName = "@Id_tipo_producto",
                    SqlDbType = SqlDbType.Int,
                    Value = producto.Id_tipo_producto,
                };
                SqlCmd.Parameters.Add(Id_tipo_producto);
                contador++;

                SqlParameter Nombre_producto = new()
                {
                    ParameterName = "@Nombre_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = producto.Nombre_producto.Trim(),
                };
                SqlCmd.Parameters.Add(Nombre_producto);
                contador++;

                SqlParameter Precio_producto = new()
                {
                    ParameterName = "@Precio_producto",
                    SqlDbType = SqlDbType.Decimal,
                    Value = producto.Precio_producto,
                };
                SqlCmd.Parameters.Add(Precio_producto);
                contador++;

                SqlParameter Imagen_producto = new()
                {
                    ParameterName = "@Imagen_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = producto.Imagen_producto.Trim(),
                };
                SqlCmd.Parameters.Add(Imagen_producto);
                contador++;

                SqlParameter Descripcion_producto = new()
                {
                    ParameterName = "@Descripcion_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = producto.Descripcion_producto.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Descripcion_producto);
                contador++;

                SqlParameter Estado_producto = new()
                {
                    ParameterName = "@Estado_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = producto.Estado_producto.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Estado_producto);
                contador++;
                
                SqlParameter Fecha = new()
                {
                    ParameterName = "@Fecha",
                    SqlDbType = SqlDbType.Date,
                    Value = DateTime.Now.ToString("yyyy-MM-dd"),
                };
                SqlCmd.Parameters.Add(Fecha);
                contador++;

                SqlParameter Hora = new()
                {
                    ParameterName = "@Hora",
                    SqlDbType = SqlDbType.Time,
                    Value = DateTime.Now.TimeOfDay,
                };
                SqlCmd.Parameters.Add(Hora);
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
                    id_producto = Convert.ToInt32(SqlCmd.Parameters["@Id_producto"].Value);
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
            return (rpta, id_producto);
        }
        #endregion

        #region METODO EDITAR PRODUCTO
        public async Task<string> EditarProducto(Productos producto)
        {
            int contador = 0;
            string rpta = string.Empty;

            try
            {
                await SqlCon.OpenAsync();

                SqlCommand SqlCmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Productos_u",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_producto = new()
                {
                    ParameterName = "@Id_producto",
                    SqlDbType = SqlDbType.Int,
                    Value = producto.Id_producto,
                };
                SqlCmd.Parameters.Add(Id_producto);

                SqlParameter Id_tipo_producto = new()
                {
                    ParameterName = "@Id_tipo_producto",
                    SqlDbType = SqlDbType.Int,
                    Value = producto.Id_tipo_producto,
                };
                SqlCmd.Parameters.Add(Id_tipo_producto);
                contador++;

                SqlParameter Nombre_usuario = new()
                {
                    ParameterName = "@Nombre_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = producto.Nombre_producto.Trim(),
                };
                SqlCmd.Parameters.Add(Nombre_usuario);
                contador++;

                SqlParameter Precio_producto = new()
                {
                    ParameterName = "@Precio_producto",
                    SqlDbType = SqlDbType.Decimal,
                    Value = producto.Precio_producto,
                };
                SqlCmd.Parameters.Add(Precio_producto);
                contador++;

                SqlParameter Imagen_producto = new()
                {
                    ParameterName = "@Imagen_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = producto.Imagen_producto.Trim(),
                };
                SqlCmd.Parameters.Add(Imagen_producto);
                contador++;

                SqlParameter Descripcion_producto = new()
                {
                    ParameterName = "@Descripcion_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = producto.Descripcion_producto.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Descripcion_producto);
                contador++;

                SqlParameter Estado_producto = new()
                {
                    ParameterName = "@Estado_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = producto.Estado_producto.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Estado_producto);
                contador++;

                SqlParameter Fecha = new()
                {
                    ParameterName = "@Fecha",
                    SqlDbType = SqlDbType.Date,
                    Value = DateTime.Now.ToString("yyyy-MM-dd"),
                };
                SqlCmd.Parameters.Add(Fecha);
                contador++;

                SqlParameter Hora = new()
                {
                    ParameterName = "@Hora",
                    SqlDbType = SqlDbType.Time,
                    Value = DateTime.Now.TimeOfDay,
                };
                SqlCmd.Parameters.Add(Hora);
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

        #region METODO BUSCAR PRODUCTOS
        public async Task<(string rpta, DataSet ds)> BuscarProductos(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";
            DataSet ds = new();

            try
            {
                await this.SqlCon.OpenAsync();

                SqlCommand Sqlcmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Productos_g",
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
            finally
            {
                if (this.SqlCon.State == ConnectionState.Open)
                    this.SqlCon.Close();
            }

            return (rpta, ds);
        }

        #endregion
    }
}
