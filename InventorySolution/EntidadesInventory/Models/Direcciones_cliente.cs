namespace EntidadesInventory.Models
{
    using System;
    using System.Data;

    public class Direcciones_cliente : MainViewModel
    {
        public Direcciones_cliente()
        {

        }

        public Direcciones_cliente(DataRow row)
        {
            try
            {
                this.Id_direccion = Convert.ToInt32(row["Id_direccion"]);
                this.Id_usuario = Convert.ToInt32(row["Id_usuario"]);
                this.Usuario = new Usuarios(row);
                this.Direccion = Convert.ToString(row["Direccion"]);
                this.Referencia_ubicacion = Convert.ToString(row["Referencia_ubicacion"]);
                this.Estado_direccion = Convert.ToString(row["Estado_direccion"]);
            }
            catch (Exception ex)
            {
                 GetErrorModel(ex.Message, this);
            }
        }

        public int Id_direccion { get; set; }

        public int Id_usuario { get; set; }

        public Usuarios Usuario { get; set; }

        public string Direccion { get; set; }

        public string Referencia_ubicacion { get; set; }

        public string Estado_direccion { get; set; }

        
    }
}
