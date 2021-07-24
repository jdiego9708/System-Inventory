namespace PresentacionInventory
{
    using AccesoDatosInventory;
    using AccesoDatosInventory.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using PresentacionInventory.Formularios.FormsPrincipales;
    using ServiceInventory.Interfaces;
    using ServiceInventory.Services;
    using System;
    using System.Windows.Forms;

    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            using var serviceProvider = services.BuildServiceProvider();
            var frmLogin = serviceProvider.GetRequiredService<FrmLogin>();
            Application.Run(frmLogin);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IAccesoDatosUsuarios, DUsuarios>()
                .AddScoped<IAccesoDatosProductos, DProductos>()
                .AddScoped<IServiceInventory, ServiceInventory>()
                .AddScoped<FrmLogin>();
        }
    }
}
