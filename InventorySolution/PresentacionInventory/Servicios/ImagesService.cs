using PresentacionInventory.Properties;
using System;
using System.Drawing;
using System.IO;

namespace PresentacionInventory.Servicios
{
    public class ImagesService
    {
        public static Image ObtenerImagen(string nombre_imagen, out string ruta_destino)
        {
            ruta_destino =
                Convert.ToString(MainSettings.Default.Ruta_images);
            Image Imagen;
            try
            {
                if (File.Exists(Path.Combine(ruta_destino, nombre_imagen)))
                    Imagen = Image.FromFile(Path.Combine(ruta_destino, nombre_imagen));
                else
                    Imagen = Resources.SIN_IMAGENES;

            }
            catch (Exception)
            {
                Imagen = Resources.SIN_IMAGENES;
            }
            return Imagen;
        }

        public static Image ObtenerImagen(string ruta_imagen)
        {
            Image Imagen;
            try
            {
                if (File.Exists(ruta_imagen))
                    Imagen = Image.FromFile(ruta_imagen);
                else
                    Imagen = Resources.SIN_IMAGENES;

            }
            catch (Exception)
            {
                Imagen = Resources.SIN_IMAGENES;
            }
            return Imagen;
        }
    }
}
