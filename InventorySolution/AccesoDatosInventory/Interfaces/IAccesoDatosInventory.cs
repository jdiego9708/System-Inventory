using EntidadesInventory.BindingModels;
using EntidadesInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosInventory.Interfaces
{
    public interface IAccesoDatosInventory
    {
        Task<(string rpta, int id_usuario)> InsertarUsuarios(Usuarios usuario);
        Task<(string rpta, int id_usuario)> EditarUsuarios(Usuarios usuario);
        Task<(string rpta, DataSet ds)> BuscarUsuarios(string tipo_busqueda, string texto_busqueda);
        Task<(string rpta, List<object> objects)> Login(int pin, string fecha);
        Task<(string rpta, EmpleadoBindingModel empleado, DataTable dtEmpleado)> ClaveMaestra(int codigo);
    }
}
