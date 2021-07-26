using ServiceInventory.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccesoDatosInventory;
using AccesoDatosInventory.Interfaces;

namespace ServiceInventory.Services
{
    public class ServiceInventoryMain : IServiceInventory
    {
        public IAccesoDatosUsuarios IAccesoDatosUsuarios { get; set; }
        public IAccesoDatosMovimientos IAccesoDatosMovimientos { get; set; }
        public IAccesoDatosPedidos IAccesoDatosPedidos { get; set; }
        public IAccesoDatosProductos IAccesoDatosProductos { get; set; }

        public ServiceInventoryMain(IAccesoDatosUsuarios accesoDatosUsuarios,
            IAccesoDatosMovimientos accesoDatosMovimientos, 
            IAccesoDatosPedidos accesoDatosPedidos,
            IAccesoDatosProductos accesoDatosProductos)
        {
            this.IAccesoDatosUsuarios = accesoDatosUsuarios;
            this.IAccesoDatosMovimientos = accesoDatosMovimientos;
            this.IAccesoDatosPedidos = accesoDatosPedidos;
            this.IAccesoDatosProductos = accesoDatosProductos;
        }

        public async Task<(string rpta, List<object> objects)> Login(int pin, string fecha)
        {
            return await this.IAccesoDatosUsuarios.Login(pin, fecha);
        }
    }
}
