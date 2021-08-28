
namespace PresentacionRestaurant.Formularios.FormsPedidos
{
    partial class FrmPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedido));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnProductos = new System.Windows.Forms.Button();
            this.panelBusqueda = new ControlesCompartidos.CustomGridPanel();
            this.customTextBox1 = new ControlesCompartidos.CustomTextBox();
            this.rdPlatos = new System.Windows.Forms.RadioButton();
            this.rdBebidas = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelProductos = new ControlesCompartidos.CustomGridPanel();
            this.panelCategorias = new ControlesCompartidos.CustomGridPanel();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DarkCyan;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(887, 59);
            this.panel2.TabIndex = 2;
            this.panel2.Tag = "customColor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nuevo pedido para la mesa";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.DarkCyan;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1037, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(281, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "Usuario";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelCategorias);
            this.groupBox1.Location = new System.Drawing.Point(2, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 470);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categorías";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnProductos);
            this.groupBox2.Controls.Add(this.panelBusqueda);
            this.groupBox2.Controls.Add(this.customTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(169, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(445, 505);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Búsqueda de productos";
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.White;
            this.btnProductos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProductos.BackgroundImage")));
            this.btnProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductos.Location = new System.Drawing.Point(11, 24);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(45, 45);
            this.btnProductos.TabIndex = 8;
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.UseVisualStyleBackColor = false;
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBusqueda.AutoScroll = true;
            this.panelBusqueda.Location = new System.Drawing.Point(6, 77);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.PageSize = 10;
            this.panelBusqueda.Size = new System.Drawing.Size(433, 422);
            this.panelBusqueda.TabIndex = 7;
            // 
            // customTextBox1
            // 
            this.customTextBox1.AlignmentDefault = System.Windows.Forms.HorizontalAlignment.Center;
            this.customTextBox1.AutoSize = true;
            this.customTextBox1.BackColor = System.Drawing.Color.White;
            this.customTextBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customTextBox1.FontStyleDefault = System.Drawing.FontStyle.Regular;
            this.customTextBox1.FontWordDefault = "Segoe UI";
            this.customTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customTextBox1.ForeColorDefault = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customTextBox1.FormatNumber = null;
            this.customTextBox1.IsDecimal = false;
            this.customTextBox1.IsEmail = false;
            this.customTextBox1.IsNumber = false;
            this.customTextBox1.IsRequired = false;
            this.customTextBox1.Location = new System.Drawing.Point(62, 25);
            this.customTextBox1.Multiline = false;
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.Place_holder = "Búsqueda";
            this.customTextBox1.Size = new System.Drawing.Size(377, 45);
            this.customTextBox1.SizeFontDefault = 10.5F;
            this.customTextBox1.TabIndex = 6;
            this.customTextBox1.Text_description = "Descripción";
            this.customTextBox1.Texto = "Búsqueda";
            this.customTextBox1.Validation = true;
            // 
            // rdPlatos
            // 
            this.rdPlatos.AutoSize = true;
            this.rdPlatos.Checked = true;
            this.rdPlatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdPlatos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdPlatos.Location = new System.Drawing.Point(7, 65);
            this.rdPlatos.Name = "rdPlatos";
            this.rdPlatos.Size = new System.Drawing.Size(70, 25);
            this.rdPlatos.TabIndex = 0;
            this.rdPlatos.TabStop = true;
            this.rdPlatos.Text = "Platos";
            this.rdPlatos.UseVisualStyleBackColor = true;
            // 
            // rdBebidas
            // 
            this.rdBebidas.AutoSize = true;
            this.rdBebidas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdBebidas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdBebidas.Location = new System.Drawing.Point(84, 65);
            this.rdBebidas.Name = "rdBebidas";
            this.rdBebidas.Size = new System.Drawing.Size(82, 25);
            this.rdBebidas.TabIndex = 5;
            this.rdBebidas.Text = "Bebidas";
            this.rdBebidas.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panelProductos);
            this.groupBox3.Location = new System.Drawing.Point(620, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(267, 505);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Productos seleccionados";
            // 
            // panelProductos
            // 
            this.panelProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProductos.AutoScroll = true;
            this.panelProductos.Location = new System.Drawing.Point(6, 26);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.PageSize = 10;
            this.panelProductos.Size = new System.Drawing.Size(255, 473);
            this.panelProductos.TabIndex = 8;
            // 
            // panelCategorias
            // 
            this.panelCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCategorias.AutoScroll = true;
            this.panelCategorias.Location = new System.Drawing.Point(8, 26);
            this.panelCategorias.Name = "panelCategorias";
            this.panelCategorias.PageSize = 10;
            this.panelCategorias.Size = new System.Drawing.Size(147, 438);
            this.panelCategorias.TabIndex = 9;
            // 
            // FrmPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(889, 568);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.rdBebidas);
            this.Controls.Add(this.rdPlatos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPedido";
            this.Text = "Pedido";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdPlatos;
        private System.Windows.Forms.RadioButton rdBebidas;
        private System.Windows.Forms.GroupBox groupBox3;
        private ControlesCompartidos.CustomTextBox customTextBox1;
        private ControlesCompartidos.CustomGridPanel panelBusqueda;
        private System.Windows.Forms.Button btnProductos;
        private ControlesCompartidos.CustomGridPanel panelProductos;
        private ControlesCompartidos.CustomGridPanel panelCategorias;
    }
}