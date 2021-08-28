﻿namespace ControlesCompartidos.CustomControls
{
    using EntidadesInventory.BindingModels;
    using System;
    using System.Text;
    using System.Windows.Forms;

    public partial class ProductoSmall : UserControl
    {
        public ProductoSmall()
        {
            InitializeComponent();
            this._producto = new();

            this.btnAdd.Click += BtnAdd_Click;
            this.btnComment.Click += BtnComment_Click;
            this.btnRemove.Click += BtnRemove_Click;
        }

        public event EventHandler? OnAddButtonClick;
        public event EventHandler? OnCommentButtonClick;
        public event EventHandler? OnRemoveButtonClick;

        private void BtnRemove_Click(object? sender, EventArgs e)
        {
            this.OnRemoveButtonClick?.Invoke(this.Producto, e);
        }

        private void BtnComment_Click(object? sender, EventArgs e)
        {
            this.OnCommentButtonClick?.Invoke(this.Producto, e);
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            this.OnAddButtonClick?.Invoke(this.Producto, e);
        }

        private ProductoPedidoBindingModel _producto;
        public ProductoPedidoBindingModel Producto
        {
            get => _producto;
            set
            {
                _producto = value;
                this.AsignarDatos(value);
            }
        }

        private void AsignarDatos(ProductoPedidoBindingModel producto)
        {
            StringBuilder info = new();
            if (producto.DetallePedido == null)
            {
                info.Append("Producto no especificado");
            }
            else
            {
                info.Append(producto.Producto.Nombre_producto).Append(Environment.NewLine);
                info.Append(producto.DetallePedido.Precio.ToString("C")).Append(Environment.NewLine);
                info.Append(producto.DetallePedido.Cantidad);
            }
            this.txtInfo.Text = info.ToString();
        }
    }
}
