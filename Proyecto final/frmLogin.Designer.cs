namespace Proyecto_final
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            btnIngresar = new Button();
            btnCancelar = new Button();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(310, 101);
            label1.Name = "label1";
            label1.Size = new Size(212, 41);
            label1.TabIndex = 0;
            label1.Text = "Proyecto Final";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(272, 199);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(250, 27);
            txtUsuario.TabIndex = 1;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(272, 273);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(250, 27);
            txtContraseña.TabIndex = 2;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(249, 340);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(148, 38);
            btnIngresar.TabIndex = 3;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(415, 340);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(148, 38);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(177, 202);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 5;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(177, 276);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 6;
            label3.Text = "Contraseña";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnIngresar);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            Name = "frmLogin";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Button btnIngresar;
        private Button btnCancelar;
        private Label label2;
        private Label label3;
    }
}
