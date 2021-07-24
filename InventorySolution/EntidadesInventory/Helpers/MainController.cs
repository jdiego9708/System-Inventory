using EntidadesInventory.Models;

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
    }
}
