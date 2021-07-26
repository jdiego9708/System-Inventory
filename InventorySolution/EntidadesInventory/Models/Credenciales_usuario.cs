namespace EntidadesInventory.Models
{
    using EntidadesInventory.Helpers;
    using System;
    using System.Data;

    public class Credenciales_usuario : MainViewModel
    {
        public Credenciales_usuario()
        {

        }

        public Credenciales_usuario(DataRow row)
        {
            try
            {
                this.Id_credencial = Convert.ToInt32(row["Id_credencial"]);
                this.Id_usuario = Convert.ToInt32(row["Id_usuario"]);
                this.Usuario = new Usuarios(row);
                this.Fecha_credencial = Convert.ToDateTime(row["Fecha_credencial"]);
                this.Hora_credencial = TimeSpanConvert.StringToTimeSpan(row["Hora_credencial"].ToString());
                this.Password = Convert.ToString(row["Password"]);
                this.Estado_credencial = Convert.ToString(row["Estado_credencial"]);
            }
            catch (Exception ex)
            {
                GetErrorModel(ex.Message, this);
            }
        }

        public int Id_credencial { get; set; }

        public int Id_usuario { get; set; }

        public Usuarios Usuario { get; set; }

        public DateTime Fecha_credencial { get; set; }

        public TimeSpan Hora_credencial { get; set; }

        public string Password { get; set; }

        public string Estado_credencial { get; set; }
    }
}
