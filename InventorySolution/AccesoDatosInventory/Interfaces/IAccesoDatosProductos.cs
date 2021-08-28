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
    public interface IAccesoDatosProductos
    {
        Task<(string rpta, int id)> InsertarProducto(Productos producto);
        Task<string> EditarProducto(Productos producto);
        Task<(string rpta, DataSet ds)> BuscarProductos(string tipo_busqueda, string texto_busqueda);
    }
}
