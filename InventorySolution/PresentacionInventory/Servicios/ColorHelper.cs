namespace PresentacionInventory.Servicios
{
    using EntidadesInventory.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;

    public class ColorHelper
    {
        /// <summary>
        /// Método para obtener el color principal de la aplicación
        /// configurada por el usuario
        /// </summary>
        /// <param name="color">Color en string (ARGB) que viene desde MainSettings</param>
        /// <returns>Color convertido desde ARGB</returns>
        public static Color ObtenerColorPrincipal(string color)
        {
            string[] colorconvert = color.Split(",");
            List<int> colors = new();
            for (int i = 0; i <= colorconvert.Length - 1; i++)
            {
                if (int.TryParse(colorconvert[i], out int num))
                {
                    colors.Add(num);
                }
            }

            if (colors.Count == 3)
                return Color.FromArgb(colors[0], colors[1], colors[2]);

            return Color.SteelBlue;
        }

        /// <summary>
        /// Se debe configurar el Tag de los controles del formulario que se
        /// necesiten cambiar de color, la palabra "customColor" debe estar en Tag.
        /// </summary>
        /// <param name="form">Formulario que se desee cambiar el color</param>
        public static void ChangeColorDefault(Form form)
        {
            string color = MainSettings.Default.Color_predeterminado;
            ColorModel colorSelected = LoadColors().Where(x => x.NombreColor.Equals(color)).ToList()[0];
            Color colorDefaultFondo = ObtenerColorPrincipal(colorSelected.ColorFondo);
            Color colorDefaultLetra = ObtenerColorPrincipal(colorSelected.ColorLetra);
            foreach (Control control in form.Controls)
            {
                if (control.Tag != null)
                {
                    string tipo = Convert.ToString(control.Tag);
                    if (tipo.Equals("customColor"))
                    {
                        control.BackColor = colorDefaultFondo;
                        control.ForeColor = colorDefaultLetra;

                        if (control is Panel panel)
                        {
                            foreach(Control c in panel.Controls)
                            {
                                c.BackColor = colorDefaultFondo;
                                c.ForeColor = colorDefaultLetra;
                            }
                        }
                    }
                }
            }
        }

        public static List<ColorModel> LoadColors()
        {
            return new List<ColorModel>
            {
                new ColorModel
                {
                    NombreColor = "Azul",
                    ColorFondo = "3,84,117",
                    ColorLetra = "249,250,250",
                },
                new ColorModel
                {
                    NombreColor = "Verde",
                    ColorFondo = "25,100,6",
                    ColorLetra = "249,250,250",
                },
                new ColorModel
                {
                    NombreColor = "Turquesa",
                    ColorFondo = "20,162,116",
                    ColorLetra = "249,250,250",
                },
            };
        }

        private List<ColorModel> _listColors;

        public List<ColorModel> ListColors
        {
            get
            {
                if (this._listColors == null)
                    this._listColors = LoadColors();

                return _listColors;
            }
            set => _listColors = value;
        }
    }
}
