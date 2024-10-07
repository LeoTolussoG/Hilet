namespace Proyecto_final
{
    partial class FrmDashboard
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
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            abrirToolStripMenuItem = new ToolStripMenuItem();
            guardarToolStripMenuItem = new ToolStripMenuItem();
            exportarToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            gestionAcademicaToolStripMenuItem = new ToolStripMenuItem();
            carrerasToolStripMenuItem = new ToolStripMenuItem();
            materiasToolStripMenuItem = new ToolStripMenuItem();
            examenesToolStripMenuItem = new ToolStripMenuItem();
            exámenesToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            panel3 = new Panel();
            tabControl1 = new TabControl();
            tbpInicio = new TabPage();
            dgvDashboard = new DataGridView();
            lblTituloDashboard = new Label();
            panel4 = new Panel();
            lblTotalAsignaturas = new Label();
            lblTotalAdministrativos = new Label();
            lblTotalProfesores = new Label();
            lblTotalAlumnos = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            btnDashExamenes = new Button();
            btnDashMaterias = new Button();
            btnDashAsignaturas = new Button();
            btnDashCarreras = new Button();
            btnDashAdministrativos = new Button();
            btnDashProfesores = new Button();
            btnDashAlumnos = new Button();
            tbpGestionAcademica = new TabPage();
            tbpReporte = new TabPage();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            tbpInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).BeginInit();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1192, 43);
            panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, gestionAcademicaToolStripMenuItem, reportesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1192, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abrirToolStripMenuItem, guardarToolStripMenuItem, exportarToolStripMenuItem, salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(73, 24);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            abrirToolStripMenuItem.Size = new Size(148, 26);
            abrirToolStripMenuItem.Text = "Abrir";
            // 
            // guardarToolStripMenuItem
            // 
            guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            guardarToolStripMenuItem.Size = new Size(148, 26);
            guardarToolStripMenuItem.Text = "Guardar";
            // 
            // exportarToolStripMenuItem
            // 
            exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            exportarToolStripMenuItem.Size = new Size(148, 26);
            exportarToolStripMenuItem.Text = "Exportar";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(148, 26);
            salirToolStripMenuItem.Text = "Salir";
            // 
            // gestionAcademicaToolStripMenuItem
            // 
            gestionAcademicaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { carrerasToolStripMenuItem, materiasToolStripMenuItem, examenesToolStripMenuItem, exámenesToolStripMenuItem });
            gestionAcademicaToolStripMenuItem.Name = "gestionAcademicaToolStripMenuItem";
            gestionAcademicaToolStripMenuItem.Size = new Size(151, 24);
            gestionAcademicaToolStripMenuItem.Text = "Gestion Academica";
            // 
            // carrerasToolStripMenuItem
            // 
            carrerasToolStripMenuItem.Name = "carrerasToolStripMenuItem";
            carrerasToolStripMenuItem.Size = new Size(158, 26);
            carrerasToolStripMenuItem.Text = "Carreras";
            // 
            // materiasToolStripMenuItem
            // 
            materiasToolStripMenuItem.Name = "materiasToolStripMenuItem";
            materiasToolStripMenuItem.Size = new Size(158, 26);
            materiasToolStripMenuItem.Text = "Materias";
            // 
            // examenesToolStripMenuItem
            // 
            examenesToolStripMenuItem.Name = "examenesToolStripMenuItem";
            examenesToolStripMenuItem.Size = new Size(158, 26);
            examenesToolStripMenuItem.Text = "Alumnos";
            // 
            // exámenesToolStripMenuItem
            // 
            exámenesToolStripMenuItem.Name = "exámenesToolStripMenuItem";
            exámenesToolStripMenuItem.Size = new Size(158, 26);
            exámenesToolStripMenuItem.Text = "Exámenes";
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(82, 24);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // panel3
            // 
            panel3.Controls.Add(tabControl1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 43);
            panel3.Name = "panel3";
            panel3.Size = new Size(1192, 550);
            panel3.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbpInicio);
            tabControl1.Controls.Add(tbpGestionAcademica);
            tabControl1.Controls.Add(tbpReporte);
            tabControl1.Location = new Point(12, 29);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1148, 449);
            tabControl1.TabIndex = 0;
            // 
            // tbpInicio
            // 
            tbpInicio.Controls.Add(dgvDashboard);
            tbpInicio.Controls.Add(lblTituloDashboard);
            tbpInicio.Controls.Add(panel4);
            tbpInicio.Controls.Add(panel2);
            tbpInicio.Location = new Point(4, 29);
            tbpInicio.Name = "tbpInicio";
            tbpInicio.Padding = new Padding(3);
            tbpInicio.Size = new Size(1140, 416);
            tbpInicio.TabIndex = 0;
            tbpInicio.Text = "Inicio";
            tbpInicio.UseVisualStyleBackColor = true;
            // 
            // dgvDashboard
            // 
            dgvDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDashboard.Location = new Point(239, 197);
            dgvDashboard.Name = "dgvDashboard";
            dgvDashboard.RowHeadersWidth = 51;
            dgvDashboard.Size = new Size(870, 193);
            dgvDashboard.TabIndex = 3;
            // 
            // lblTituloDashboard
            // 
            lblTituloDashboard.AutoSize = true;
            lblTituloDashboard.Location = new Point(294, 152);
            lblTituloDashboard.Name = "lblTituloDashboard";
            lblTituloDashboard.Size = new Size(50, 20);
            lblTituloDashboard.TabIndex = 2;
            lblTituloDashboard.Text = "label5";
            // 
            // panel4
            // 
            panel4.Controls.Add(lblTotalAsignaturas);
            panel4.Controls.Add(lblTotalAdministrativos);
            panel4.Controls.Add(lblTotalProfesores);
            panel4.Controls.Add(lblTotalAlumnos);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(209, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(928, 111);
            panel4.TabIndex = 1;
            // 
            // lblTotalAsignaturas
            // 
            lblTotalAsignaturas.AutoSize = true;
            lblTotalAsignaturas.Location = new Point(740, 66);
            lblTotalAsignaturas.Name = "lblTotalAsignaturas";
            lblTotalAsignaturas.Size = new Size(50, 20);
            lblTotalAsignaturas.TabIndex = 7;
            lblTotalAsignaturas.Text = "label8";
            // 
            // lblTotalAdministrativos
            // 
            lblTotalAdministrativos.AutoSize = true;
            lblTotalAdministrativos.Location = new Point(491, 66);
            lblTotalAdministrativos.Name = "lblTotalAdministrativos";
            lblTotalAdministrativos.Size = new Size(50, 20);
            lblTotalAdministrativos.TabIndex = 6;
            lblTotalAdministrativos.Text = "label7";
            // 
            // lblTotalProfesores
            // 
            lblTotalProfesores.AutoSize = true;
            lblTotalProfesores.Location = new Point(281, 66);
            lblTotalProfesores.Name = "lblTotalProfesores";
            lblTotalProfesores.Size = new Size(50, 20);
            lblTotalProfesores.TabIndex = 5;
            lblTotalProfesores.Text = "label6";
            // 
            // lblTotalAlumnos
            // 
            lblTotalAlumnos.AutoSize = true;
            lblTotalAlumnos.Location = new Point(85, 66);
            lblTotalAlumnos.Name = "lblTotalAlumnos";
            lblTotalAlumnos.Size = new Size(50, 20);
            lblTotalAlumnos.TabIndex = 4;
            lblTotalAlumnos.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(740, 25);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 3;
            label4.Text = "Materias";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(491, 25);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 2;
            label3.Text = "Administrativos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(281, 25);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 1;
            label2.Text = "Profesores";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(85, 25);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "Alumnos";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnDashExamenes);
            panel2.Controls.Add(btnDashMaterias);
            panel2.Controls.Add(btnDashAsignaturas);
            panel2.Controls.Add(btnDashCarreras);
            panel2.Controls.Add(btnDashAdministrativos);
            panel2.Controls.Add(btnDashProfesores);
            panel2.Controls.Add(btnDashAlumnos);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(206, 410);
            panel2.TabIndex = 0;
            // 
            // btnDashExamenes
            // 
            btnDashExamenes.Location = new Point(21, 358);
            btnDashExamenes.Name = "btnDashExamenes";
            btnDashExamenes.Size = new Size(164, 29);
            btnDashExamenes.TabIndex = 8;
            btnDashExamenes.Text = "Examenes";
            btnDashExamenes.UseVisualStyleBackColor = true;
            btnDashExamenes.Click += btnDashExamenes_Click;
            // 
            // btnDashMaterias
            // 
            btnDashMaterias.Location = new Point(21, 305);
            btnDashMaterias.Name = "btnDashMaterias";
            btnDashMaterias.Size = new Size(164, 29);
            btnDashMaterias.TabIndex = 7;
            btnDashMaterias.Text = "Materias";
            btnDashMaterias.UseVisualStyleBackColor = true;
            // 
            // btnDashAsignaturas
            // 
            btnDashAsignaturas.Location = new Point(20, 253);
            btnDashAsignaturas.Name = "btnDashAsignaturas";
            btnDashAsignaturas.Size = new Size(164, 29);
            btnDashAsignaturas.TabIndex = 6;
            btnDashAsignaturas.Text = "Asignaruras";
            btnDashAsignaturas.UseVisualStyleBackColor = true;
            // 
            // btnDashCarreras
            // 
            btnDashCarreras.Location = new Point(20, 194);
            btnDashCarreras.Name = "btnDashCarreras";
            btnDashCarreras.Size = new Size(164, 29);
            btnDashCarreras.TabIndex = 5;
            btnDashCarreras.Text = "Carreras";
            btnDashCarreras.UseVisualStyleBackColor = true;
            // 
            // btnDashAdministrativos
            // 
            btnDashAdministrativos.Location = new Point(20, 140);
            btnDashAdministrativos.Name = "btnDashAdministrativos";
            btnDashAdministrativos.Size = new Size(164, 29);
            btnDashAdministrativos.TabIndex = 4;
            btnDashAdministrativos.Text = "Administrativos";
            btnDashAdministrativos.UseVisualStyleBackColor = true;
            // 
            // btnDashProfesores
            // 
            btnDashProfesores.Location = new Point(20, 82);
            btnDashProfesores.Name = "btnDashProfesores";
            btnDashProfesores.Size = new Size(164, 29);
            btnDashProfesores.TabIndex = 3;
            btnDashProfesores.Text = "Profesores";
            btnDashProfesores.UseVisualStyleBackColor = true;
            // 
            // btnDashAlumnos
            // 
            btnDashAlumnos.Location = new Point(20, 25);
            btnDashAlumnos.Name = "btnDashAlumnos";
            btnDashAlumnos.Size = new Size(164, 29);
            btnDashAlumnos.TabIndex = 2;
            btnDashAlumnos.Text = "Alumnos";
            btnDashAlumnos.UseVisualStyleBackColor = true;
            btnDashAlumnos.Click += btnDashAlumnos_Click;
            // 
            // tbpGestionAcademica
            // 
            tbpGestionAcademica.Location = new Point(4, 29);
            tbpGestionAcademica.Name = "tbpGestionAcademica";
            tbpGestionAcademica.Padding = new Padding(3);
            tbpGestionAcademica.Size = new Size(1140, 416);
            tbpGestionAcademica.TabIndex = 1;
            tbpGestionAcademica.Text = "Gestion Academica";
            tbpGestionAcademica.UseVisualStyleBackColor = true;
            // 
            // tbpReporte
            // 
            tbpReporte.Location = new Point(4, 29);
            tbpReporte.Name = "tbpReporte";
            tbpReporte.Size = new Size(1140, 416);
            tbpReporte.TabIndex = 2;
            tbpReporte.Text = "Reporte";
            tbpReporte.UseVisualStyleBackColor = true;
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 593);
            Controls.Add(panel3);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            Name = "FrmDashboard";
            Text = "FrmDashboard";
            Load += FrmDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tbpInicio.ResumeLayout(false);
            tbpInicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem gestionAcademicaToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private Panel panel3;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripMenuItem exportarToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem carrerasToolStripMenuItem;
        private ToolStripMenuItem materiasToolStripMenuItem;
        private ToolStripMenuItem examenesToolStripMenuItem;
        private ToolStripMenuItem exámenesToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tbpInicio;
        private Panel panel4;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private TabPage tbpGestionAcademica;
        private TabPage tbpReporte;
        private Label lblTotalAsignaturas;
        private Label lblTotalAdministrativos;
        private Label lblTotalProfesores;
        private Label lblTotalAlumnos;
        private Button btnDashExamenes;
        private Button btnDashMaterias;
        private Button btnDashAsignaturas;
        private Button btnDashCarreras;
        private Button btnDashAdministrativos;
        private Button btnDashProfesores;
        private Button btnDashAlumnos;
        private DataGridView dgvDashboard;
        private Label lblTituloDashboard;
    }
}