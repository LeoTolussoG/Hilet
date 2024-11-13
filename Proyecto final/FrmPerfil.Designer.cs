namespace Proyecto_final
{
    partial class FrmPerfil
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
            panel1 = new Panel();
            btnSalirPerfil = new Button();
            btnGuardarCambios = new Button();
            textBox3 = new TextBox();
            label4 = new Label();
            groupBox1 = new GroupBox();
            label1 = new Label();
            txtNuevaContraseña = new TextBox();
            txtRepiteContraseña = new TextBox();
            label2 = new Label();
            groupBox3 = new GroupBox();
            label21 = new Label();
            txtUsuarioPerfil = new TextBox();
            txtContraseñaActual = new TextBox();
            label22 = new Label();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(btnSalirPerfil);
            panel1.Controls.Add(btnGuardarCambios);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(groupBox3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(531, 549);
            panel1.TabIndex = 0;
            // 
            // btnSalirPerfil
            // 
            btnSalirPerfil.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalirPerfil.Location = new Point(291, 489);
            btnSalirPerfil.Name = "btnSalirPerfil";
            btnSalirPerfil.Size = new Size(176, 37);
            btnSalirPerfil.TabIndex = 33;
            btnSalirPerfil.Text = "Guardar cambios";
            btnSalirPerfil.UseVisualStyleBackColor = true;
            btnSalirPerfil.Click += btnGuardarCambios_Click;
            // 
            // btnGuardarCambios
            // 
            btnGuardarCambios.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarCambios.Location = new Point(65, 489);
            btnGuardarCambios.Name = "btnGuardarCambios";
            btnGuardarCambios.Size = new Size(176, 37);
            btnGuardarCambios.TabIndex = 32;
            btnGuardarCambios.Text = "Salir";
            btnGuardarCambios.UseVisualStyleBackColor = true;
            btnGuardarCambios.Click += btnSalirPerfil_Click;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(12, 388);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(507, 69);
            textBox3.TabIndex = 31;
            textBox3.Text = "Introduce una contraseña segura\r\n\r\nIntroduce una contraseña nueva que no haya usado antes";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 419);
            label4.Name = "label4";
            label4.Size = new Size(0, 28);
            label4.TabIndex = 30;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNuevaContraseña);
            groupBox1.Controls.Add(txtRepiteContraseña);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 209);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(507, 162);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nueva Contraseña";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 112);
            label1.Name = "label1";
            label1.Size = new Size(255, 21);
            label1.TabIndex = 18;
            label1.Text = "Repita la nueva contraseña";
            // 
            // txtNuevaContraseña
            // 
            txtNuevaContraseña.BackColor = Color.Silver;
            txtNuevaContraseña.BorderStyle = BorderStyle.None;
            txtNuevaContraseña.ForeColor = Color.FromArgb(64, 64, 64);
            txtNuevaContraseña.Location = new Point(279, 49);
            txtNuevaContraseña.Name = "txtNuevaContraseña";
            txtNuevaContraseña.Size = new Size(202, 23);
            txtNuevaContraseña.TabIndex = 19;
            // 
            // txtRepiteContraseña
            // 
            txtRepiteContraseña.BackColor = Color.Silver;
            txtRepiteContraseña.BorderStyle = BorderStyle.None;
            txtRepiteContraseña.ForeColor = Color.FromArgb(64, 64, 64);
            txtRepiteContraseña.Location = new Point(279, 112);
            txtRepiteContraseña.Name = "txtRepiteContraseña";
            txtRepiteContraseña.PasswordChar = '*';
            txtRepiteContraseña.Size = new Size(202, 23);
            txtRepiteContraseña.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(95, 48);
            label2.Name = "label2";
            label2.Size = new Size(175, 21);
            label2.TabIndex = 17;
            label2.Text = "Nueva contraseña";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label21);
            groupBox3.Controls.Add(txtUsuarioPerfil);
            groupBox3.Controls.Add(txtContraseñaActual);
            groupBox3.Controls.Add(label22);
            groupBox3.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(12, 26);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(507, 161);
            groupBox3.TabIndex = 27;
            groupBox3.TabStop = false;
            groupBox3.Text = "Datos actuales";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.White;
            label21.Location = new Point(94, 111);
            label21.Name = "label21";
            label21.Size = new Size(176, 21);
            label21.TabIndex = 18;
            label21.Text = "Contraseña actual";
            // 
            // txtUsuarioPerfil
            // 
            txtUsuarioPerfil.BackColor = Color.Silver;
            txtUsuarioPerfil.BorderStyle = BorderStyle.None;
            txtUsuarioPerfil.ForeColor = Color.FromArgb(64, 64, 64);
            txtUsuarioPerfil.Location = new Point(279, 48);
            txtUsuarioPerfil.Name = "txtUsuarioPerfil";
            txtUsuarioPerfil.Size = new Size(202, 23);
            txtUsuarioPerfil.TabIndex = 19;
            // 
            // txtContraseñaActual
            // 
            txtContraseñaActual.BackColor = Color.Silver;
            txtContraseñaActual.BorderStyle = BorderStyle.None;
            txtContraseñaActual.ForeColor = Color.FromArgb(64, 64, 64);
            txtContraseñaActual.Location = new Point(279, 112);
            txtContraseñaActual.Name = "txtContraseñaActual";
            txtContraseñaActual.PasswordChar = '*';
            txtContraseñaActual.Size = new Size(202, 23);
            txtContraseñaActual.TabIndex = 20;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.White;
            label22.Location = new Point(198, 48);
            label22.Name = "label22";
            label22.Size = new Size(72, 21);
            label22.TabIndex = 17;
            label22.Text = "Usuario";
            // 
            // FrmPerfil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 549);
            Controls.Add(panel1);
            Name = "FrmPerfil";
            Text = "Cambiar contraseñá de usuario";
            Load += FrmPerfil_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox3;
        private Label label21;
        private TextBox txtUsuarioPerfil;
        private TextBox txtContraseñaActual;
        private Label label22;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtNuevaContraseña;
        private TextBox txtRepiteContraseña;
        private Label label2;
        private TextBox textBox3;
        private Label label4;
        private Button btnSalirPerfil;
        private Button btnGuardarCambios;
    }
}