using EntidadesInventory.Models;
using System.Data;
using System.Threading.Tasks;

namespace ServiceInventory.Interfaces
{
    public interface IServiceInventory
    {
        Task<(string rpta, int id_tipo)> InsertarCatalogo(Catalogo catalogo);
        Task<(string rpta, DataSet ds)> BuscarCatalogo(string tipo_busqueda, string texto_busqueda);
    }
}
