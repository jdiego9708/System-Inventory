using EntidadesInventory.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ServiceInventory.Interfaces
{
    public interface IServiceInventory
    {
        Task<(string rpta, DataSet ds)> BuscarPedidos(string tipo_busqueda, string texto_busqueda);
        Task<(string rpta, int id_tipo)> InsertarCatalogo(Catalogo catalogo);
        Task<(string rpta, DataSet ds)> BuscarCatalogo(string tipo_busqueda, string texto_busqueda);
        Task<(string rpta, DataSet ds)> LoadCatalogo(string tipo_busqueda, string texto_busqueda);
        Task<(string rpta, List<object> objects)> Login(int pin, string fecha);
    }
}
