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
    public interface IAccesoDatosCatalogo
    {
        Task<(string rpta, int id_tipo)> InsertarCatalogo(Catalogo catalogo);
        Task<(string rpta, DataSet ds)> BuscarCatalogo(string tipo_busqueda, string texto_busqueda);
    }
}
