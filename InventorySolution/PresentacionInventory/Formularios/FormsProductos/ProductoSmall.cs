namespace PresentacionInventory.Formularios.FormsProductos
{
    using EntidadesInventory.Models;
    using System;
    using System.Text;
    using System.Windows.Forms;

    public partial class ProductoSmall : UserControl
    {
        public ProductoSmall()
        {
            InitializeComponent();
            this.btnNext.Click += BtnNext_Click;
            this.btnEditInfo.Click += BtnEditInfo_Click;
            this.btnPerfil.Click += BtnPerfil_Click;
        }

        private void BtnPerfil_Click(object sender, EventArgs e)
        {
            this.OnBtnPerfilClick?.Invoke(this.Producto, e);
        }

        private void BtnEditInfo_Click(object sender, EventArgs e)
        {
            this.OnBtnEditClick?.Invoke(this.Producto, e);
        }
    
        private void BtnNext_Click(object sender, EventArgs e)
        {
            this.OnBtnNextClick?.Invoke(this.Producto, e);
        }

        public event EventHandler OnBtnNextClick;
        public event EventHandler OnBtnEditClick;
        public event EventHandler OnBtnPerfilClick;

        private Productos _producto;

        public Productos Producto
        {
            get => _producto;
            set
            {
                _producto = value;
                this.AsignarDatos(value);
            }
        }

        private void AsignarDatos(Productos product)
        {
            StringBuilder info = new();
            info.Append(product.Nombre_producto).Append(Environment.NewLine);
            info.Append(product.Precio_producto.ToString("C"));
            if (!string.IsNullOrEmpty(product.Descripcion_producto))
                info.Append(Environment.NewLine).Append(product.Descripcion_producto);
            this.txtInfo.Text = info.ToString();
        }
    }
}
