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
            TreeNode treeNode1 = new TreeNode("Técnico Superior en Publicidad");
            TreeNode treeNode2 = new TreeNode("Analista de Sistemas");
            TreeNode treeNode3 = new TreeNode("Carreras", new TreeNode[] { treeNode1, treeNode2 });
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
            panel2 = new Panel();
            treeView1 = new TreeView();
            panel3 = new Panel();
            tabControl1 = new TabControl();
            tabPageAlumnos = new TabPage();
            tabPageMaterias = new TabPage();
            tabPageExamenes = new TabPage();
            tabPageReportes = new TabPage();
            dataGridView1 = new DataGridView();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageAlumnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            // panel2
            // 
            panel2.Controls.Add(treeView1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 43);
            panel2.Name = "panel2";
            panel2.Size = new Size(174, 550);
            panel2.TabIndex = 1;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeNode1.Name = "NodoPublicidad";
            treeNode1.Text = "Técnico Superior en Publicidad";
            treeNode2.Name = "NodoAnalista";
            treeNode2.Text = "Analista de Sistemas";
            treeNode3.Name = "NodoCarreras";
            treeNode3.Text = "Carreras";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode3 });
            treeView1.Size = new Size(174, 550);
            treeView1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(tabControl1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(174, 43);
            panel3.Name = "panel3";
            panel3.Size = new Size(1018, 550);
            panel3.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageAlumnos);
            tabControl1.Controls.Add(tabPageMaterias);
            tabControl1.Controls.Add(tabPageExamenes);
            tabControl1.Controls.Add(tabPageReportes);
            tabControl1.Location = new Point(21, 18);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(964, 506);
            tabControl1.TabIndex = 0;
            // 
            // tabPageAlumnos
            // 
            tabPageAlumnos.Controls.Add(btnEliminar);
            tabPageAlumnos.Controls.Add(btnModificar);
            tabPageAlumnos.Controls.Add(btnAgregar);
            tabPageAlumnos.Controls.Add(dataGridView1);
            tabPageAlumnos.Location = new Point(4, 29);
            tabPageAlumnos.Name = "tabPageAlumnos";
            tabPageAlumnos.Padding = new Padding(3);
            tabPageAlumnos.Size = new Size(956, 473);
            tabPageAlumnos.TabIndex = 0;
            tabPageAlumnos.Text = "Alumnos";
            tabPageAlumnos.UseVisualStyleBackColor = true;
            // 
            // tabPageMaterias
            // 
            tabPageMaterias.Location = new Point(4, 29);
            tabPageMaterias.Name = "tabPageMaterias";
            tabPageMaterias.Padding = new Padding(3);
            tabPageMaterias.Size = new Size(956, 473);
            tabPageMaterias.TabIndex = 1;
            tabPageMaterias.Text = "Materias";
            tabPageMaterias.UseVisualStyleBackColor = true;
            // 
            // tabPageExamenes
            // 
            tabPageExamenes.Location = new Point(4, 29);
            tabPageExamenes.Name = "tabPageExamenes";
            tabPageExamenes.Padding = new Padding(3);
            tabPageExamenes.Size = new Size(847, 412);
            tabPageExamenes.TabIndex = 2;
            tabPageExamenes.Text = "Exámenes";
            tabPageExamenes.UseVisualStyleBackColor = true;
            // 
            // tabPageReportes
            // 
            tabPageReportes.Location = new Point(4, 29);
            tabPageReportes.Name = "tabPageReportes";
            tabPageReportes.Padding = new Padding(3);
            tabPageReportes.Size = new Size(847, 412);
            tabPageReportes.TabIndex = 3;
            tabPageReportes.Text = "Reportes";
            tabPageReportes.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(42, 34);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(729, 408);
            dataGridView1.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(825, 82);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(825, 220);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(825, 362);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 593);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            Name = "FrmDashboard";
            Text = "FrmDashboard";
            Load += FrmDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageAlumnos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem gestionAcademicaToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private Panel panel3;
        private TabControl tabControl1;
        private TabPage tabPageAlumnos;
        private TabPage tabPageMaterias;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripMenuItem exportarToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem carrerasToolStripMenuItem;
        private ToolStripMenuItem materiasToolStripMenuItem;
        private ToolStripMenuItem examenesToolStripMenuItem;
        private ToolStripMenuItem exámenesToolStripMenuItem;
        private TreeView treeView1;
        private TabPage tabPageExamenes;
        private TabPage tabPageReportes;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private DataGridView dataGridView1;
    }
}