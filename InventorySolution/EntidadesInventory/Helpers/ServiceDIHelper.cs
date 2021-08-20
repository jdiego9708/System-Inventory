using Microsoft.Extensions.DependencyInjection;

namespace EntidadesInventory.Helpers
{
    public class ServiceDIHelper
    {
        public static T GetService<T>() where T : class
        {
            MainController main = MainController.GetInstancia();
            using var serviceProvider = main.ServiceColletionMain.BuildServiceProvider();
            return (T)serviceProvider.GetService(typeof(T));
        }
    }
}
