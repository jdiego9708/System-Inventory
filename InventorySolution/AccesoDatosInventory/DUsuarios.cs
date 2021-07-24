namespace AccesoDatosInventory
{
    using AccesoDatosInventory.Interfaces;
    using EntidadesInventory.BindingModels;
    using EntidadesInventory.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;

    public class DUsuarios : IAccesoDatosInventory
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
            string rpta = string.Empty;          

            try
            {
                await SqlCon.OpenAsync();

                SqlCommand SqlCmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Insertar_usuario",
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
                contador++;

                SqlParameter Nombre_usuario = new()
                {
                    ParameterName = "@Nombre_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Nombre_usuario.Trim(),
                };
                SqlCmd.Parameters.Add(Nombre_usuario);
                contador++;

                SqlParameter Telefono_usuario = new()
                {
                    ParameterName = "@Telefono_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Telefono_usuario.Trim(),
                };
                SqlCmd.Parameters.Add(Telefono_usuario);
                contador++;

                SqlParameter Identificacion_usuario = new()
                {
                    ParameterName = "@Identificacion_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Identificacion_usuario.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Identificacion_usuario);
                contador++;

                SqlParameter Email_usuario = new()
                {
                    ParameterName = "@Email_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Email_usuario.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Email_usuario);
                contador++;

                SqlParameter Id_tipo_usuario = new()
                {
                    ParameterName = "@Id_tipo_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = usuario.Id_tipo_usuario,
                };
                SqlCmd.Parameters.Add(Id_tipo_usuario);
                contador++;

                SqlParameter Estado_usuario = new()
                {
                    ParameterName = "@Estado_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Estado_usuario.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Estado_usuario);
                contador++;

                SqlParameter Fecha = new()
                {
                    ParameterName = "@Fecha",
                    SqlDbType = SqlDbType.Date,
                    Value = usuario.Fecha_ingreso,
                };
                SqlCmd.Parameters.Add(Fecha);
                contador++;

                SqlParameter Hora = new()
                {
                    ParameterName = "@Hora",
                    SqlDbType = SqlDbType.Time,
                    Value = DateTime.Now.TimeOfDay,
                };
                SqlCmd.Parameters.Add(Estado_usuario);
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
                    id_usuario = Convert.ToInt32(SqlCmd.Parameters["@Id_usuario"].Value);
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
            return (rpta, id_usuario);
        }
        #endregion

        #region METODO EDITAR USUARIO
        public async Task<(string rpta, int id_usuario)> EditarUsuarios(Usuarios usuario)
        {
            int id_usuario = 0;
            int contador = 0;
            string rpta = string.Empty;

            try
            {
                await SqlCon.OpenAsync();

                SqlCommand SqlCmd = new()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Editar_usuario",
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
                contador++;

                SqlParameter Nombre_usuario = new()
                {
                    ParameterName = "@Nombre_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Nombre_usuario.Trim(),
                };
                SqlCmd.Parameters.Add(Nombre_usuario);
                contador++;

                SqlParameter Telefono_usuario = new()
                {
                    ParameterName = "@Telefono_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Telefono_usuario.Trim(),
                };
                SqlCmd.Parameters.Add(Telefono_usuario);
                contador++;

                SqlParameter Identificacion_usuario = new()
                {
                    ParameterName = "@Identificacion_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Identificacion_usuario.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Identificacion_usuario);
                contador++;

                SqlParameter Email_usuario = new()
                {
                    ParameterName = "@Email_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Email_usuario.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Email_usuario);
                contador++;

                SqlParameter Id_tipo_usuario = new()
                {
                    ParameterName = "@Id_tipo_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = usuario.Id_tipo_usuario,
                };
                SqlCmd.Parameters.Add(Id_tipo_usuario);
                contador++;

                SqlParameter Estado_usuario = new()
                {
                    ParameterName = "@Estado_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Estado_usuario.ToUpper().Trim(),
                };
                SqlCmd.Parameters.Add(Estado_usuario);
                contador++;

                SqlParameter Fecha = new()
                {
                    ParameterName = "@Fecha",
                    SqlDbType = SqlDbType.Date,
                    Value = usuario.Fecha_ingreso,
                };
                SqlCmd.Parameters.Add(Fecha);
                contador++;

                SqlParameter Hora = new()
                {
                    ParameterName = "@Hora",
                    SqlDbType = SqlDbType.Time,
                    Value = DateTime.Now.TimeOfDay,
                };
                SqlCmd.Parameters.Add(Estado_usuario);
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

        #region METODO LOGIN
        public async Task<(string rpta, List<object> objects)> Login(int pin, string fecha)
        {
            string rpta = "OK";

            List<object> objects = new();
            EmpleadoBindingModel empleado = new();
            Turnos turno = new();

            DataSet ds = new("Login");
            SqlConnection SqlCon = new();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                StringBuilder consulta = new();
                SqlCommand Sqlcmd;
                SqlCon.ConnectionString = Conexion.Cn;
                await SqlCon.OpenAsync();
                Sqlcmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Login",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter PIN = new()
                {
                    ParameterName = "@PIN",
                    SqlDbType = SqlDbType.Int,
                    Value = pin,
                };
                Sqlcmd.Parameters.Add(PIN);

                SqlParameter Fecha = new()
                {
                    ParameterName = "@Fecha",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = fecha.Trim()
                };
                Sqlcmd.Parameters.Add(Fecha);

                SqlDataAdapter SqlData = new(Sqlcmd);
                await Task.Run(() => SqlData.Fill(ds));

                bool result = false;
                string tipo_usuario = "";
                //1->Primer tabla es la respuesta
                DataTable dtRespuesta = ds.Tables[0];
                if (dtRespuesta.Rows.Count > 0)
                {
                    //Comprobar respuesta
                    string respuestaSQL = Convert.ToString(dtRespuesta.Rows[0]["Respuesta"]);
                    if (respuestaSQL.Equals("OK"))
                    {
                        tipo_usuario = Convert.ToString(dtRespuesta.Rows[0]["Tipo_usuario"]);
                        result = true;
                    }
                    else
                        throw new Exception(respuestaSQL);
                }
                else
                    throw new Exception("No se encontró la respuesta del procedimiento");

                if (result)
                {
                    if (tipo_usuario.Equals("CAJERO") ||
                        tipo_usuario.Equals("ADMINISTRADOR") ||
                        tipo_usuario.Equals("MESERO") ||
                        tipo_usuario.Equals("COCINERO"))
                    {
                        if (ds.Tables.Count >= 3)
                        {
                            DataTable dtEmpleado = ds.Tables[1];

                            //Obtener la credencial
                            if (dtEmpleado.Rows.Count > 0)
                                empleado = new EmpleadoBindingModel(dtEmpleado.Rows[0]);
                            else
                                throw new Exception("No se encontraron las credenciales");

                            DataTable dtTurno = ds.Tables[2];

                            //Obtener el último turno
                            if (dtTurno.Rows.Count > 0)
                                turno = new Turnos(dtTurno.Rows[0]);
                            else
                                throw new Exception("No se encontró el turno");

                            objects.Add(empleado);
                            objects.Add(turno);
                        }
                        else
                        {
                            throw new Exception("Las tablas del procedimiento Login no vienen completas, son 3 y vienen: " +
                                ds.Tables.Count);
                        }
                    }
                    else
                    {
                        rpta = "No tiene acceso al sistema debido a su cargo";
                    }
                }
                else
                {
                    throw new Exception("No se pudo iniciar sesión");
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

            return (rpta, objects);
        }

        public async Task<(string rpta, EmpleadoBindingModel empleado, DataTable dtEmpleado)> ClaveMaestra(int codigo)
        {
            string rpta = "OK";

            EmpleadoBindingModel empleado = new();

            DataTable dt = new("ClaveMaestra");
            SqlConnection SqlCon = new();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                StringBuilder consulta = new();
                consulta.Append("SELECT TOP 1 * " +
                    "FROM Empleados " +
                    "WHERE Codigo_maestro = " + codigo);

                SqlCommand Sqlcmd;
                SqlCon.ConnectionString = Conexion.Cn;
                await SqlCon.OpenAsync();
                Sqlcmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta.ToString(),
                    CommandType = CommandType.Text,
                };

                SqlDataAdapter SqlData = new(Sqlcmd);
                SqlData.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    empleado = new EmpleadoBindingModel(dt.Rows[0]);
                }
                else
                    dt = null;
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

            return (rpta, empleado, dt);
        }

        #endregion
    }
}
