namespace EntidadesInventory.Models
{
    using EntidadesInventory.Helpers;
    using System;
    using System.Data;

    public class Movimientos
    {
        public Movimientos()
        {

        }

        public Movimientos(DataRow row)
        {
            try
            {
                this.Id_movimiento = Convert.ToInt32(row["Id_movimiento"]);
                this.Id_tipo_movimiento = Convert.ToInt32(row["Id_tipo_movimiento"]);
                this.Tipo_movimiento = new Catalogo(row);
                this.Fecha_movimiento = Convert.ToDateTime(row["Fecha_movimiento"]);
                this.Hora_movimiento = TimeSpanConvert.StringToTimeSpan(row["Hora_movimiento"].ToString());
                this.Descripcion_movimiento = Convert.ToString(row["Descripcion_movimiento"]);
                this.Estado_movimiento = Convert.ToString(row["Estado_movimiento"]);
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex.Message, null);
            }
        }

        public int Id_movimiento { get; set; }

        public int Id_tipo_movimiento { get; set; }

        public Catalogo Tipo_movimiento { get; set; }

        public DateTime Fecha_movimiento { get; set; }

        public TimeSpan Hora_movimiento { get; set; }

        public string Descripcion_movimiento { get; set; }

        public string Estado_movimiento { get; set; }

        public event EventHandler OnError;
    }
}
