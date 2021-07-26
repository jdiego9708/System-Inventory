namespace EntidadesInventory.Models
{
    using EntidadesInventory.Helpers;
    using System;
    using System.Data;

    public class Facturacion : MainViewModel
    {
        public Facturacion()
        {

        }

        public Facturacion(DataRow row)
        {
            try
            {
                this.Id_facturacion = Convert.ToInt32(row["Id_facturacion"]);
                this.Fecha_facturacion = Convert.ToDateTime(row["Fecha_facturacion"]);
                this.Hora_facturacion = TimeSpanConvert.StringToTimeSpan(row["Hora_facturacion"].ToString());
                this.Total_facturacion = Convert.ToDecimal(row["Total_facturacion"]);
                this.Observaciones = Convert.ToString(row["Observaciones"]);
            }
            catch (Exception ex)
            {
                 GetErrorModel(ex.Message, this);
            }
        }

        public int Id_facturacion { get; set; }

        public DateTime Fecha_facturacion { get; set; }

        public TimeSpan Hora_facturacion { get; set; }

        public decimal Total_facturacion { get; set; }

        public string Observaciones { get; set; }

        
    }
}
