﻿namespace EntidadesInventory.Models
{
    using System;
    using System.Data;

    public class Productos
    {
        public Productos()
        {

        }

        public Productos(DataRow row)
        {
            try
            {
                this.Id_producto = Convert.ToInt32(row["Id_producto"]);
                this.Id_tipo_producto = Convert.ToInt32(row["Id_tipo_producto"]);
                this.Nombre_producto = Convert.ToString(row["Nombre_producto"]);
                this.Precio_producto = Convert.ToDecimal(row["Precio_producto"]);
                this.Descripcion_producto = Convert.ToString(row["Descripcion_producto"]);
                this.Estado_producto = Convert.ToString(row["Estado_producto"]);
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex.Message, null);
            }
        }

        public int Id_producto { get; set; }

        public int Id_tipo_producto { get; set; }

        public string Nombre_producto { get; set; }

        public decimal Precio_producto { get; set; }

        public string Descripcion_producto { get; set; }

        public string Estado_producto { get; set; }

        public event EventHandler OnError;
    }
}
