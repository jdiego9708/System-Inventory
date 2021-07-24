using EntidadesInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInventory.Helpers
{
    public class ConvertListToDataTable
    {
        public static string ConvertDetallePedido(List<Detalle_pedido> detalles, out DataTable dtDetalles)
        {
            string rpta = "OK";
            dtDetalles = new DataTable("Detalles");
            dtDetalles.Columns.Add("Id_tipo", typeof(int));
            dtDetalles.Columns.Add("Tipo", typeof(string));
            dtDetalles.Columns.Add("Precio", typeof(string));
            dtDetalles.Columns.Add("Cantidad", typeof(int));
            dtDetalles.Columns.Add("Observaciones", typeof(string));

            try
            {
                if (detalles.Count > 0)
                {
                    foreach (Detalle_pedido detalle in detalles)
                    {
                        DataRow newRow = dtDetalles.NewRow();
                        newRow["Id_tipo"] = detalle.Id_tipo;
                        newRow["Tipo"] = detalle.Tipo;
                        newRow["Precio"] = detalle.Precio;
                        newRow["Cantidad"] = detalle.Cantidad;
                        newRow["Observaciones"] = detalle.Observaciones;
                        dtDetalles.Rows.Add(newRow);
                    }
                }
                else
                    dtDetalles = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                dtDetalles = null;
            }

            return rpta;
        }
    }
}
