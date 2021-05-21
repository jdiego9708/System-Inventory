namespace EntidadesInventory.Models
{
    using System;
    using System.Data;

    public class Usuarios
    {
        public Usuarios()
        {

        }

        public Usuarios(DataRow row)
        {
            try
            {
                this.Id_usuario = Convert.ToInt32(row["Id_usuario"]);
                this.Fecha_ingreso = Convert.ToDateTime(row["Fecha_ingreso"]);
                this.Nombre_usuario = Convert.ToString(row["Nombre_usuario"]);
                this.Telefono_usuario = Convert.ToString(row["Telefono_usuario"]);
                this.Identificacion_usuario = Convert.ToString(row["Identificacion_usuario"]);
                this.Email_usuario = Convert.ToString(row["Email_usuario"]);
                this.Id_tipo_usuario = Convert.ToInt32(row["Id_tipo_usuario"]);
                this.Tipo_usuario = new Catalogo(row);
                this.Estado_usuario = Convert.ToString(row["Estado_usuario"]);
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex.Message, null);
            }
        }

        public int Id_usuario { get; set; }

        public DateTime Fecha_ingreso { get; set; }

        public string Nombre_usuario { get; set; }

        public string Telefono_usuario { get; set; }

        public string Identificacion_usuario { get; set; }

        public string Email_usuario { get; set; }

        public int Id_tipo_usuario { get; set; }

        public Catalogo Tipo_usuario { get; set; }

        public string Estado_usuario { get; set; }

        public event EventHandler OnError;
    }
}
