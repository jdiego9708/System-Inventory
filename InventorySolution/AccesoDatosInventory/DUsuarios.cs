namespace AccesoDatosInventory
{
    using EntidadesInventory.Models;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class DUsuarios
    {
        #region CONSTRUCTOR VACIO
        public DUsuarios()
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

        #region METODO INSERTAR USUARIO
        public async Task<(string rpta, int id_usuario)> InsertarUsuarios(Usuarios usuario)
        {
            int id_usuario = 0;
            int contador = 0;
            //asignamos a una cadena string la variable rpta y la iniciamos en vacía
            string rpta = "";
           
            //Capturador de errores
            try
            {
                await SqlCon.OpenAsync();
                //establecer comando
                SqlCommand SqlCmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Insertar_usuario",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_usuario = new()
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_usuario);

                SqlParameter Fecha_ingreso = new()
                {
                    ParameterName = "@Fecha_ingreso",
                    SqlDbType = SqlDbType.Date,
                    Value = usuario.Fecha_ingreso,
                };
                SqlCmd.Parameters.Add(Fecha_ingreso);
                contador += 1;

                SqlParameter Nombre_usuario = new()
                {
                    ParameterName = "@Nombre_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Nombre_usuario.Trim(),
                };
                SqlCmd.Parameters.Add(Nombre_usuario);
                contador += 1;

                SqlParameter Telefono_usuario = new()
                {
                    ParameterName = "@Telefono_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Telefono_usuario.Trim(),
                };
                SqlCmd.Parameters.Add(Telefono_usuario);
                contador += 1;

                SqlParameter Identificacion_usuario = new()
                {
                    ParameterName = "@Identificacion_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Identificacion_usuario.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Identificacion_usuario);
                contador += 1;

                SqlParameter Email_usuario = new()
                {
                    ParameterName = "@Email_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Email_usuario.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Email_usuario);
                contador += 1;

                SqlParameter Id_tipo_usuario = new()
                {
                    ParameterName = "@Id_tipo_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = usuario.Id_tipo_usuario,
                };
                SqlCmd.Parameters.Add(Id_tipo_usuario);
                contador += 1;

                SqlParameter Estado_usuario = new()
                {
                    ParameterName = "@Estado_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Estado_usuario.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Estado_usuario);
                contador += 1;

                SqlParameter Fecha = new()
                {
                    ParameterName = "@Fecha",
                    SqlDbType = SqlDbType.Date,
                    Value = usuario.Fecha_ingreso,
                };
                SqlCmd.Parameters.Add(Fecha);
                contador += 1;

                SqlParameter Hora = new()
                {
                    ParameterName = "@Hora",
                    SqlDbType = SqlDbType.Time,
                    Value = DateTime.Now.TimeOfDay,
                };
                SqlCmd.Parameters.Add(Estado_usuario);
                contador += 1;

                //Ejecutamos nuestro comando
                //Se puede ejecutar este metodo pero ya tenemos el mensaje que devuelve sql
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
                    id_usuario = Convert.ToInt32(SqlCmd.Parameters["@Id_usuario"].Value);
                }
            }
            //Mostramos posible error que tengamos
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
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return (rpta, id_usuario);
        }
        #endregion

        #region METODO EDITAR USUARIO
        public async Task<(string rpta, int id_usuario)> EditarUsuarios(Usuarios usuario)
        {
            int id_usuario = 0;
            int contador = 0;
            //asignamos a una cadena string la variable rpta y la iniciamos en vacía
            string rpta = "";

            //Capturador de errores
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                await SqlCon.OpenAsync();
                //establecer comando
                SqlCommand SqlCmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Editar_usuario",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_usuario = new()
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = usuario.Id_usuario,
                };
                SqlCmd.Parameters.Add(Id_usuario);

                SqlParameter Fecha_ingreso = new()
                {
                    ParameterName = "@Fecha_ingreso",
                    SqlDbType = SqlDbType.Date,
                    Value = usuario.Fecha_ingreso,
                };
                SqlCmd.Parameters.Add(Fecha_ingreso);
                contador += 1;

                SqlParameter Nombre_usuario = new()
                {
                    ParameterName = "@Nombre_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Nombre_usuario.Trim(),
                };
                SqlCmd.Parameters.Add(Nombre_usuario);
                contador += 1;

                SqlParameter Telefono_usuario = new()
                {
                    ParameterName = "@Telefono_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Telefono_usuario.Trim(),
                };
                SqlCmd.Parameters.Add(Telefono_usuario);
                contador += 1;

                SqlParameter Identificacion_usuario = new()
                {
                    ParameterName = "@Identificacion_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Identificacion_usuario.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Identificacion_usuario);
                contador += 1;

                SqlParameter Email_usuario = new()
                {
                    ParameterName = "@Email_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Email_usuario.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Email_usuario);
                contador += 1;

                SqlParameter Id_tipo_usuario = new()
                {
                    ParameterName = "@Id_tipo_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = usuario.Id_tipo_usuario,
                };
                SqlCmd.Parameters.Add(Id_tipo_usuario);
                contador += 1;

                SqlParameter Estado_usuario = new()
                {
                    ParameterName = "@Estado_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Estado_usuario.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Estado_usuario);
                contador += 1;

                SqlParameter Fecha = new()
                {
                    ParameterName = "@Fecha",
                    SqlDbType = SqlDbType.Date,
                    Value = usuario.Fecha_ingreso,
                };
                SqlCmd.Parameters.Add(Fecha);
                contador += 1;

                SqlParameter Hora = new()
                {
                    ParameterName = "@Hora",
                    SqlDbType = SqlDbType.Time,
                    Value = DateTime.Now.TimeOfDay,
                };
                SqlCmd.Parameters.Add(Estado_usuario);
                contador += 1;

                //Ejecutamos nuestro comando
                //Se puede ejecutar este metodo pero ya tenemos el mensaje que devuelve sql
                rpta = await SqlCmd.ExecuteNonQueryAsync() >= 1 ? "OK" : "NO";

                if (rpta != "OK")
                {
                    if (this.Mensaje_error != null)
                    {
                        rpta = this.Mensaje_error;
                    }
                }
            }
            //Mostramos posible error que tengamos
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
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return (rpta, id_usuario);
        }
        #endregion

        #region METODO BUSCAR USUARIOS
        public async Task<(string rpta, DataSet ds)> BuscarUsuarios(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";
            DataSet ds = new();
            try
            {
                await this.SqlCon.OpenAsync();
                SqlCommand Sqlcmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Buscar_usuarios",
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
