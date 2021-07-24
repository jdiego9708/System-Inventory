using ServiceInventory.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccesoDatosInventory;
using AccesoDatosInventory.Interfaces;

namespace ServiceInventory.Services
{
    public class ServiceInventory : IServiceInventory
    {
        public IAccesoDatosInventory IAccesoDatosInventory { get; set; }

        public ServiceInventory(IAccesoDatosInventory iAccesoDatosInventory)
        {
            this.IAccesoDatosInventory = iAccesoDatosInventory;
        }

        public async Task<(string rpta, List<object> objects)> Login(int pin, string fecha)
        {
            return await this.IAccesoDatosInventory.Login(pin, fecha);
        }
    }
}
