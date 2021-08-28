namespace ControlesCompartidos.CustomControls
{
    using EntidadesInventory.Models;
    using System;
    using System.Windows.Forms;

    public partial class CategoriaSmall : UserControl
    {
        public CategoriaSmall(Catalogo catalogo)
        {
            InitializeComponent();
            this._catalogo = catalogo;
            this.Catalogo = catalogo;
            this.btnCategoria.Click += BtnCategoria_Click;
        }

        private void BtnCategoria_Click(object? sender, EventArgs e)
        {
            this.OnBtnCatalogo?.Invoke(this.Catalogo, e);
        }

        public event EventHandler? OnBtnCatalogo; 

        private void AsignarDatos(Catalogo categoria)
        {
            this.btnCategoria.Text = categoria.Nombre_tipo;
        }

        private Catalogo _catalogo;

        public Catalogo Catalogo
        {
            get => _catalogo;
            set
            {
                _catalogo = value;
                this.AsignarDatos(value);
            }
        }
    }
}
