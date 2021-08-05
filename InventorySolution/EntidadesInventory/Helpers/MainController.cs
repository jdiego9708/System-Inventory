using EntidadesInventory.Helpers;
using EntidadesInventory.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Drawing;

namespace EntidadesInventory
{
    public class MainController
    {
        #region PROPIEDADES
        public Usuarios ClienteDefault { get; set; }
        public Usuarios EmpleadoLogin { get; set; }
        public Usuarios EmpleadoClaveMaestra { get; set; }
        public Turnos Turno { get; set; }

        public Color ColorPrincipal { get; set; }
        public ServiceCollection ServiceColletionMain { get; set; }
        public List<ErrorModel> Errors { get; set; }
        #endregion

        #region MÉTODOS

        #endregion

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
    }
}
