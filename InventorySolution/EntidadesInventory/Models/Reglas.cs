namespace EntidadesInventory.Models
{
    using System;
    using System.Data;

    public class Reglas : MainViewModel
    {
        public Reglas()
        {

        }

        public Reglas(DataRow row)
        {
            try
            {
                this.Id_regla = Convert.ToInt32(row["Id_regla"]);
                this.Nombre_regla = Convert.ToString(row["Nombre_regla"]);
                this.Estado_regla = Convert.ToString(row["Estado_regla"]);
            }
            catch (Exception ex)
            {
                 GetErrorModel(ex.Message, this);
            }
        }

        public int Id_regla { get; set; }

        public string Nombre_regla { get; set; }

        public string Estado_regla { get; set; }

        
    }
}
