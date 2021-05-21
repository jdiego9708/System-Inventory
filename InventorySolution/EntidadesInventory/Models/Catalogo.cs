namespace EntidadesInventory.Models
{
    using System;
    using System.Data;

    public class Catalogo
    {
        public Catalogo()
        {

        }

        public Catalogo(DataRow row)
        {
            try
            {
                this.Id_tipo = Convert.ToInt32(row["Id_tipo"]);
                this.Id_padre = Convert.ToInt32(row["Id_padre"]);
                this.Nombre_tipo = Convert.ToString(row["Nombre_tipo"]);
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex.Message, null);
            }
        }

        public int Id_tipo { get; set; }

        public int Id_padre { get; set; }

        public string Nombre_tipo { get; set; }

        public event EventHandler OnError;
    }
}
