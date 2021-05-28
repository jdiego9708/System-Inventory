namespace EntidadesInventory.Models
{
    using EntidadesInventory.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Pedidos
    {
        public Pedidos()
        {

        }

        public Pedidos(DataRow row)
        {
            try
            {
                this.Id_pedido = Convert.ToInt32(row["Id_pedido"]);
                this.Fecha_pedido = Convert.ToDateTime(row["Fecha_pedido"]);
                this.Hora_pedido = TimeSpanConvert.StringToTimeSpan(row["Hora_pedido"].ToString());
                this.Id_tipo_pedido = Convert.ToInt32(row["Id_tipo_pedido"]);
                this.Tipo_pedido = new Catalogo(row);
                this.Id_cliente = Convert.ToInt32(row["Id_cliente"]);
                this.Cliente = new Usuarios(row);
                this.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
                this.Empleado = new Usuarios(row);
                this.Observaciones_pedido = Convert.ToString(row["Observaciones_pedido"]);
                this.CantidadClientes = Convert.ToInt32(row["CantidadClientes"]);
                this.Informacion_adicional = Convert.ToString(row["Informacion_adicional"]);
                this.Estado_pedido = Convert.ToString(row["Estado_pedido"]);
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex.Message, null);
            }
        }

        public int Id_pedido { get; set; }

        public DateTime Fecha_pedido { get; set; }

        public TimeSpan Hora_pedido { get; set; }

        public int Id_tipo_pedido { get; set; }

        public Catalogo Tipo_pedido { get; set; }

        public int Id_cliente { get; set; }

        public Usuarios Cliente { get; set; }

        public int Id_empleado { get; set; }

        public Usuarios Empleado { get; set; }

        public string Observaciones_pedido { get; set; }

        public int CantidadClientes { get; set; }

        public string Informacion_adicional { get; set; }

        public string Estado_pedido { get; set; }

        public List<Detalle_pedido> Detalle_pedido { get; set; }

        public event EventHandler OnError;
    }
}
