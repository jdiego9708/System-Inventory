namespace EntidadesInventory.Models
{
    using EntidadesInventory.Helpers;
    using System;
    using System.Data;

    public class Detalle_facturacion : MainViewModel
    {
        public Detalle_facturacion()
        {

        }

        public Detalle_facturacion(DataRow row)
        {
            try
            {
                this.Id_facturacion = Convert.ToInt32(row["Id_facturacion"]);
                this.Id_tipo_detalle = Convert.ToInt32(row["Id_tipo_detalle"]);
                this.Tipo_detalle = new Catalogo(row);
                this.Valor_detalle = Convert.ToDecimal(row["Valor_detalle"]);
                this.Observaciones_detalle = Convert.ToString(row["Observaciones_detalle"]);
            }
            catch (Exception ex)
            {
                 GetErrorModel(ex.Message, this);
            }
        }

        public int Id_facturacion { get; set; }

        public int Id_tipo_detalle { get; set; }

        public Catalogo Tipo_detalle { get; set; }

        public decimal Valor_detalle { get; set; }

        public string Observaciones_detalle { get; set; }     
    }
}
