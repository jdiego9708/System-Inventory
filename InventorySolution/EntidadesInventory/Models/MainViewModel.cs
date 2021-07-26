using EntidadesInventory.Helpers;
using System.Collections.Generic;

namespace EntidadesInventory.Models
{
    public class MainViewModel
    {
        public static void GetErrorModel(string error, object model)
        {
            MainController main = MainController.GetInstancia();
            ErrorModel errorModel = new(1, error, model);

            if (main.Errors == null)
                main.Errors = new List<ErrorModel>();

            main.Errors.Add(errorModel);
        }
    }
}
