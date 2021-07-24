using ServiceInventory.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccesoDatosInventory;
using AccesoDatosInventory.Interfaces;

namespace ServiceInventory.Services
{
    public class ServiceInventory : IServiceInventory
    {
        public IAccesoDatosProductos IAccesoDatosInventory { get; set; }
        public IAccesoDatosUsuarios IAccesoDatosUsuarios { get; set; }

        public ServiceInventory(IAccesoDatosProductos accesoDatosInventory,
            IAccesoDatosUsuarios accesoDatosUsuarios)
        {
            this.IAccesoDatosInventory = accesoDatosInventory;
            this.IAccesoDatosUsuarios = accesoDatosUsuarios;
        }

        public async Task<(string rpta, List<object> objects)> Login(int pin, string fecha)
        {
            return await this.IAccesoDatosUsuarios.Login(pin, fecha);
        }
    }
}
