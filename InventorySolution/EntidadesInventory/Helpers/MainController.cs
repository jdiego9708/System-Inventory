using EntidadesInventory.Helpers;
using EntidadesInventory.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace EntidadesInventory
{
    public class MainController
    {
        #region PATRON SINGLETON
        private static MainController _Instancia;
        public static MainController GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new MainController();
            }
            return _Instancia;
        }
        #endregion

        public Usuarios ClienteDefault { get; set; }
        public Usuarios EmpleadoLogin { get; set; }
        public Usuarios EmpleadoClaveMaestra { get; set; }
        public Turnos Turno { get; set; }

        public ServiceCollection ServiceColletionMain { get; set; }
        public List<ErrorModel> Errors { get; set; } 
    }
}
