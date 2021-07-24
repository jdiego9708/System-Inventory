namespace EntidadesInventory.BindingModels
{
    using EntidadesInventory.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class EmpleadoBindingModel : Usuarios
    {
        public EmpleadoBindingModel()
        {

        }

        public EmpleadoBindingModel(DataRow row)
        {
            try
            {
                this.Id_usuario = Convert.ToInt32(row["Id_usuario"]);
                this.Fecha_ingreso = Convert.ToDateTime(row["Fecha_ingreso"]);
                this.Nombre_usuario = Convert.ToString(row["Nombre_usuario"]);
                this.Telefono_usuario = Convert.ToString(row["Telefono_usuario"]);
                this.Identificacion_usuario = Convert.ToString(row["Identificacion_usuario"]);
                this.Email_usuario = Convert.ToString(row["Email_usuario"]);
                this.Id_tipo_usuario = Convert.ToInt32(row["Id_tipo_usuario"]);
                this.Tipo_usuario = new Catalogo(row);
                this.Estado_usuario = Convert.ToString(row["Estado_usuario"]);
                this.Credenciales = new Credenciales_usuario(row);
            }
            catch (Exception)
            {
                
            }
        }

        public Credenciales_usuario Credenciales { get; set; }

        public List<Reglas_usuario> Reglas { get; set; }
    }
}
