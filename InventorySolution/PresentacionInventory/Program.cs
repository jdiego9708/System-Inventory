namespace PresentacionInventory
{
    using AccesoDatosInventory;
    using AccesoDatosInventory.Interfaces;
    using EntidadesInventory;
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

            MainController main = MainController.GetInstancia();
            LoadDependencyInjection(main);        
            using var serviceProvider = main.ServiceColletionMain.BuildServiceProvider();
            var frmLogin = serviceProvider.GetRequiredService<FrmLogin>();
            Application.Run(frmLogin);
        }

        public static void LoadDependencyInjection(MainController main)
        {
            main.ServiceColletionMain = new ServiceCollection();
            ConfigureServices(main.ServiceColletionMain);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IAccesoDatosUsuarios, DUsuarios>()
                .AddScoped<IAccesoDatosProductos, DProductos>()
                .AddScoped<IAccesoDatosMovimientos, DMovimientos>()
                .AddScoped<IAccesoDatosPedidos, DPedidos>()
                .AddScoped<IAccesoDatosProductos, DProductos>()
                .AddScoped<IServiceInventory, ServiceInventoryMain>()
                .AddScoped<FrmLogin>();
        }
    }
}
