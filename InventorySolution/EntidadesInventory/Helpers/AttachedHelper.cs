using EntidadesInventory.Settings;
using System;
using System.Configuration;
using System.IO;

namespace EntidadesInventory.Helpers
{
    public class AttachedHelper
    {
        public static string GuardarArchivo(string archivo, string rutaOrigen)
        {
            string rpta = "OK";
            string rutaDestino = ObtenerRutaDestino();
            try
            {
                string nombre_archivo = string.Concat(archivo);
                bool insert = true;

                if (rutaDestino.Equals(rutaOrigen))
                    insert = false;              

                if (insert)
                {
                    DirectoryInfo DirectoryInfo = new(rutaDestino);
                    string destino = Path.Combine(DirectoryInfo.ToString(), nombre_archivo);
                    File.Copy(rutaOrigen, destino, true);
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public static string ObtenerRutaDestino()
        {
            string ruta;
            try
            {
                ruta = MainSettings.Default.Ruta_images;
            }
            catch (ConfigurationErrorsException ex)
            {
                ruta = ex.Message;
            }

            return ruta;
        }
    }
}
