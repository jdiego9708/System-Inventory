namespace EntidadesInventory.Models
{
    using System;
    using System.Data;

    public class Reglas_usuario : MainViewModel
    {
        public Reglas_usuario()
        {

        }

        public Reglas_usuario(DataRow row)
        {
            try
            {
                this.Id_regla_usuario = Convert.ToInt32(row["Id_regla_usuario"]);
                this.Id_regla = Convert.ToInt32(row["Id_regla"]);
                this.Regla = new Reglas(row);
                this.Id_usuario = Convert.ToInt32(row["Id_usuario"]);
                this.Usuario = new Usuarios(row);
                this.Estado_regla = Convert.ToString(row["Estado_regla"]);
            }
            catch (Exception ex)
            {
                 GetErrorModel(ex.Message, this);
            }
        }

        public int Id_regla_usuario { get; set; }

        public int Id_regla { get; set; }

        public Reglas Regla { get; set; }

        public int Id_usuario { get; set; }

        public Usuarios Usuario { get; set; }

        public string Estado_regla { get; set; }

        
    }
}
