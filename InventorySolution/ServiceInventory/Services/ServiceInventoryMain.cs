using ServiceInventory.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccesoDatosInventory;
using AccesoDatosInventory.Interfaces;
using System.Data;
using EntidadesInventory.Models;

namespace ServiceInventory.Services
{
    public class ServiceInventoryMain : IServiceInventory
    {
        private IAccesoDatosUsuarios IAccesoDatosUsuarios { get; set; }
        private IAccesoDatosMovimientos IAccesoDatosMovimientos { get; set; }
        private IAccesoDatosPedidos IAccesoDatosPedidos { get; set; }
        private IAccesoDatosProductos IAccesoDatosProductos { get; set; }
        private IAccesoDatosCatalogo IAccesoDatosCatalogo { get; set; }

        public ServiceInventoryMain(IAccesoDatosUsuarios accesoDatosUsuarios,
            IAccesoDatosMovimientos accesoDatosMovimientos,
            IAccesoDatosPedidos accesoDatosPedidos,
            IAccesoDatosProductos accesoDatosProductos,
            IAccesoDatosCatalogo accesoDatosCatalogo)
        {
            this.IAccesoDatosUsuarios = accesoDatosUsuarios;
            this.IAccesoDatosMovimientos = accesoDatosMovimientos;
            this.IAccesoDatosPedidos = accesoDatosPedidos;
            this.IAccesoDatosProductos = accesoDatosProductos;
            this.IAccesoDatosCatalogo = accesoDatosCatalogo;
        }

        public async Task<(string rpta, DataSet ds)> BuscarPedidos(string tipo_busqueda, string texto_busqueda)
        {
            return await this.IAccesoDatosPedidos.BuscarPedidos(tipo_busqueda, texto_busqueda);
        }

        public async Task<(string rpta, DataSet ds)> BuscarCatalogo(string tipo_busqueda, string texto_busqueda)
        {
            return await this.IAccesoDatosCatalogo.BuscarCatalogo(tipo_busqueda, texto_busqueda);
        }

        public async Task<(string rpta, int id_tipo)> InsertarCatalogo(Catalogo catalogo)
        {
            return await this.IAccesoDatosCatalogo.InsertarCatalogo(catalogo);
        }

        public async Task<(string rpta, DataSet ds)> LoadCatalogo(string tipo_busqueda, string texto_busqueda)
        {
            return await this.IAccesoDatosCatalogo.BuscarCatalogo(tipo_busqueda, texto_busqueda);
        }

        public async Task<(string rpta, List<object> objects)> Login(int pin, string fecha)
        {
            return await this.IAccesoDatosUsuarios.Login(pin, fecha);
        }
    }
}
