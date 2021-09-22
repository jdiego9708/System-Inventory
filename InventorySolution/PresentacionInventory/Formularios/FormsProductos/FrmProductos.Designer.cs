
namespace PresentacionInventory.Formularios.FormsProductos
{
    partial class FrmProductos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnAddUsuario = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBusqueda = new ControlesCompartidos.CustomTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelUsuarios = new ControlesCompartidos.CustomGridPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReportes);
            this.groupBox1.Controls.Add(this.btnAddUsuario);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 78);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.White;
            this.btnReportes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReportes.BackgroundImage")));
            this.btnReportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportes.Location = new System.Drawing.Point(57, 24);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(45, 45);
            this.btnReportes.TabIndex = 10;
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnReportes, "Estadísticas de usuarios");
            this.btnReportes.UseVisualStyleBackColor = false;
            // 
            // btnAddUsuario
            // 
            this.btnAddUsuario.BackColor = System.Drawing.Color.White;
            this.btnAddUsuario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddUsuario.BackgroundImage")));
            this.btnAddUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUsuario.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnAddUsuario.FlatAppearance.BorderSize = 0;
            this.btnAddUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnAddUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddUsuario.ForeColor = System.Drawing.Color.White;
            this.btnAddUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddUsuario.Location = new System.Drawing.Point(6, 24);
            this.btnAddUsuario.Name = "btnAddUsuario";
            this.btnAddUsuario.Size = new System.Drawing.Size(45, 45);
            this.btnAddUsuario.TabIndex = 9;
            this.btnAddUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnAddUsuario, "Agregar un nuevo usuario");
            this.btnAddUsuario.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtBusqueda);
            this.groupBox2.Location = new System.Drawing.Point(132, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(727, 78);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Búsqueda";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.AlignmentDefault = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusqueda.AutoSize = true;
            this.txtBusqueda.BackColor = System.Drawing.Color.White;
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBusqueda.FontStyleDefault = System.Drawing.FontStyle.Regular;
            this.txtBusqueda.FontWordDefault = "Segoe UI";
            this.txtBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBusqueda.ForeColorDefault = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBusqueda.FormatNumber = null;
            this.txtBusqueda.IsDecimal = false;
            this.txtBusqueda.IsEmail = false;
            this.txtBusqueda.IsNumber = false;
            this.txtBusqueda.IsRequired = false;
            this.txtBusqueda.Location = new System.Drawing.Point(6, 24);
            this.txtBusqueda.Multiline = false;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Place_holder = "Búsqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(715, 45);
            this.txtBusqueda.SizeFontDefault = 10.5F;
            this.txtBusqueda.TabIndex = 0;
            this.txtBusqueda.Text_description = "Descripción";
            this.txtBusqueda.Texto = "Búsqueda";
            this.txtBusqueda.Validation = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.panelUsuarios);
            this.groupBox3.Location = new System.Drawing.Point(12, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(847, 422);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resultados";
            // 
            // panelUsuarios
            // 
            this.panelUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUsuarios.AutoScroll = true;
            this.panelUsuarios.Location = new System.Drawing.Point(6, 24);
            this.panelUsuarios.Name = "panelUsuarios";
            this.panelUsuarios.PageSize = 10;
            this.panelUsuarios.Size = new System.Drawing.Size(835, 392);
            this.panelUsuarios.TabIndex = 0;
            // 
            // FrmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(871, 530);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProductos";
            this.Text = "Productos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnAddUsuario;
        private System.Windows.Forms.GroupBox groupBox2;
        private ControlesCompartidos.CustomTextBox txtBusqueda;
        private System.Windows.Forms.GroupBox groupBox3;
        private ControlesCompartidos.CustomGridPanel panelUsuarios;
    }
}