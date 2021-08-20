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
    public interface IAccesoDatosPedidos
    {
        Task<(string rpta, int id)> InsertarPedido(Pedidos pedido);
        Task<string> EditarPedido(Pedidos pedido);
        Task<(string rpta, DataSet ds)> BuscarPedidos(string tipo_busqueda, string texto_busqueda);
    }
}
