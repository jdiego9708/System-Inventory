namespace PresentacionInventory
{
    using AccesoDatosInventory;
    using AccesoDatosInventory.Interfaces;
    using ControlesCompartidos;
    using ControlesCompartidos.Interfaces;
    using EntidadesInventory;
    using EntidadesInventory.Helpers;
    using EntidadesInventory.Models;
    using Microsoft.Extensions.DependencyInjection;
    using PresentacionInventory.Formularios.FormsPrincipales;
    using PresentacionRestaurant.Formularios.FormsMesas;
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

            try
            {
                MainController main = MainController.GetInstancia();
                LoadDependencyInjection(main);
                using var serviceProvider = main.ServiceColletionMain.BuildServiceProvider();
                var frmLogin = serviceProvider.GetRequiredService<FrmLogin>();
                Application.Run(frmLogin);
            }
            catch (Exception ex)
            {
                ErrorModel error = new(ex);
                error.CustomMessage = $"Error en inyección de dependencia | Form: Program | Método: Main() | ";
                MainViewModel.GetError(error);
                MensajesService.MensajeErrorCompleto(error);
            }
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
                .AddScoped<IAccesoDatosCatalogo, DCatalogo>()
                .AddScoped<IServiceInventory, ServiceInventoryMain>()
                .AddScoped<IServiceList, ServiceList>()
                .AddScoped<FrmLogin>()
                .AddScoped<FrmPrincipal>()
                .AddScoped<FrmMesas>();            
        }
    }
}
