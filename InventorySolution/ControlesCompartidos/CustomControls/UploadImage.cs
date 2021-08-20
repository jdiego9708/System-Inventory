using ControlesCompartidos;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using EntidadesInventory.Helpers;
using EntidadesInventory.Models;

namespace ControlesCompartidos
{
    public partial class UploadImage : UserControl
    {
        ConfiguracionImagen configImagen;
        PoperContainer container;

        public UploadImage()
        {
            InitializeComponent();
            this.btnAddImage.Click += BtnSeleccionar_Click;
            this.Load += UploadImage_Load;
            this.btnLimpiar.Click += BtnLimpiar_Click;
            this.btnObservaciones.Click += BtnAgregarComentario_Click;
            this.btnRemover.Click += BtnQuitar_Click;
            this.btnScreen.Click += BtnScreenShot_Click;
            this.btnConfig.Click += BtnConfig_Click;
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (this.onBtnQuitarClick != null)
                this.onBtnQuitarClick(this, e);
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            this.configImagen = new ConfiguracionImagen();
            this.configImagen.numericTiempoCaptura.Value = 1;
            this.container = new PoperContainer(this.configImagen);
            this.container.Show(this.btnConfig);
        }

        public event EventHandler onBtnQuitarClick;
        public event EventHandler onBtnCaptureClick;

        public int Tiempo_capture;
        private void BtnScreenShot_Click(object sender, EventArgs e)
        {
            if (Tiempo_capture == 0)
                Tiempo_capture = 2;

            Tiempo_capture = Convert.ToInt32(this.configImagen.numericTiempoCaptura.Value);
            if (this.onBtnCaptureClick != null)
                this.onBtnCaptureClick(this, e);
        }

        /// <summary>
        ///  Crea una captura de pantalla completa usando ScreenCapture();
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        /// 
        public void FullScreenshotWithClass(String filepath, String filename, ImageFormat format)
        {
            ScreenCapture sc = new ScreenCapture();
            Image img = sc.CaptureScreen();

            string fullpath = filepath + "\\" + filename;

            img.Save(fullpath, format);
        }

        private void BtnAgregarComentario_Click(object sender, EventArgs e)
        {
            MensajesService.InputBox("Comentario", "Guardar", "Cancelar",
                out DialogResult dialog, out string mensaje);
            if (dialog == DialogResult.Yes)
            {
                this.Observaciones = mensaje;
            }
        }

        public void AsignarImagen(Image image, string nombre_imagen)
        {
            this.pxImagen.Image = image;
            this.txtImagen.Text = nombre_imagen;
        }

        public void AsignarImagen(string nombre_imagen)
        {
            string rutaOr;
            Image Imagen = ImagesService.ObtenerImagen(nombre_imagen, out rutaOr);
            this.pxImagen.Image = Imagen;
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.txtImagen.Text = nombre_imagen;
            this.txtImagen.Tag = rutaOr;
            this.Ruta_origen = rutaOr;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtImagen.Text = string.Empty;
            this.txtImagen.Tag = null;
            //this.pxImagen.Image = Resources.SIN_IMAGENES;
        }

        private void UploadImage_Load(object sender, EventArgs e)
        {
            this.txtTitulo.Text = "Imagen " + this.Numero_imagen;
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                //Creo un objeto de tipo OpenFileDialog y lo instancio
                OpenFileDialog archivo = new OpenFileDialog();
                //Esta linea es para que solo se puedan visualizar los archivos con esta extension
                archivo.Filter = "Documentos válidos|*.jpg;*.png;*.jfif";
                //Lo abro como un Dialog
                DialogResult result = archivo.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Image Image = Image.FromFile(archivo.FileName);
                    this.Imagen = Image;
                    this.pxImagen.Image = Image;
                    this.txtImagen.Text = archivo.SafeFileName;
                    this.txtImagen.Tag = archivo.FileName;
                    this.Ruta_origen = archivo.FileName;
                    this.Nombre_imagen = archivo.SafeFileName;
                }
            }
            catch (Exception ex)
            {
                ErrorModel error = new(ex);
                error.CustomMessage = $"Form: {this.Name} | Método: BtnSeleccionar_Click() | ";
                MainViewModel.GetError(error);
                MensajesService.MensajeErrorCompleto(error);
            }
        }

        private string _nombre_imagen;
        private string _ruta_origen;

        private string _ruta_destino;
        private int _numero_imagen;
        private string _tipo_imagen;
        private string _observaciones;
        private Image _imagen;

        private bool _isVisibleBtnConfig;
        private bool _isVisibleBtnObservaciones;
        private bool _isVisibleBtnEliminar;
        private bool _isVisibleBtnLimpiar;
        private bool _isVisibleBtnScreen;

        public string Nombre_imagen { get => _nombre_imagen; set => _nombre_imagen = value; }
        public string Ruta_origen { get => _ruta_origen; set => _ruta_origen = value; }
        public string Ruta_destino { get => _ruta_destino; set => _ruta_destino = value; }
        public int Numero_imagen { get => _numero_imagen; set => _numero_imagen = value; }
        public string Tipo_imagen { get => _tipo_imagen; set => _tipo_imagen = value; }
        public string Observaciones { get => _observaciones; set => _observaciones = value; }
        public Image Imagen { get => _imagen; set => _imagen = value; }

        public bool IsVisibleBtnConfig
        {
            get => _isVisibleBtnConfig;
            set
            {
                _isVisibleBtnConfig = value;
                this.btnConfig.Visible = value;
            }
        }

        public bool IsVisibleBtnObservaciones
        {
            get => _isVisibleBtnObservaciones;
            set
            {
                _isVisibleBtnObservaciones = value;
                this.btnObservaciones.Visible = value;
            }
        }

        public bool IsVisibleBtnEliminar
        {
            get => _isVisibleBtnEliminar;
            set
            {
                _isVisibleBtnEliminar = value;
                this.btnRemover.Visible = value;
            }
        }

        public bool IsVisibleBtnLimpiar
        {
            get => _isVisibleBtnLimpiar;
            set
            {
                _isVisibleBtnLimpiar = value;
                this.btnLimpiar.Visible = value;
            }
        }

        public bool IsVisibleBtnScreen
        {
            get => _isVisibleBtnScreen;
            set
            {
                _isVisibleBtnScreen = value;
                this.btnScreen.Visible = value;
            }
        }
    }
}
