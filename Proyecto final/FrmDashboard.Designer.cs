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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDashboard));
            panel1 = new Panel();
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            abrirToolStripMenuItem = new ToolStripMenuItem();
            guardarToolStripMenuItem = new ToolStripMenuItem();
            exportarToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            usuarioToolStripMenuItem = new ToolStripMenuItem();
            perfilToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem1 = new ToolStripMenuItem();
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
            btnDashAsignaturas = new Button();
            btnDashCarreras = new Button();
            btnDashAdministrativos = new Button();
            btnDashProfesores = new Button();
            btnDashAlumnos = new Button();
            tbpGestionAcademica = new TabPage();
            panel5 = new Panel();
            tabControl2 = new TabControl();
            tabPage1 = new TabPage();
            panel7 = new Panel();
            textBox10 = new TextBox();
            textBox9 = new TextBox();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            lblEmail = new Label();
            label5 = new Label();
            lblDireccionC = new Label();
            lblDNI = new Label();
            lblApellido = new Label();
            lblNombreAlumno = new Label();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            btnEliminarAlumno = new Button();
            btnModificarAlumno = new Button();
            btnAgregarAlumno = new Button();
            dataGridView1 = new DataGridView();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            tbpReporte = new TabPage();
            panel6 = new Panel();
            panel8 = new Panel();
            panel9 = new Panel();
            panel10 = new Panel();
            dataGridView2 = new DataGridView();
            btnAgregarProfesor = new Button();
            btnModificarProfesor = new Button();
            btnEliminarProfesor = new Button();
            textBox11 = new TextBox();
            button1 = new Button();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            tbpInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).BeginInit();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            tbpGestionAcademica.SuspendLayout();
            panel5.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage1.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            panel6.SuspendLayout();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1191, 37);
            panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, usuarioToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(1191, 30);
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
            // usuarioToolStripMenuItem
            // 
            usuarioToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            usuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { perfilToolStripMenuItem, cerrarSesionToolStripMenuItem, salirToolStripMenuItem1 });
            usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            usuarioToolStripMenuItem.Size = new Size(73, 24);
            usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // perfilToolStripMenuItem
            // 
            perfilToolStripMenuItem.Name = "perfilToolStripMenuItem";
            perfilToolStripMenuItem.Size = new Size(177, 26);
            perfilToolStripMenuItem.Text = "Perfil";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(177, 26);
            cerrarSesionToolStripMenuItem.Text = "Cerrar sesion";
            // 
            // salirToolStripMenuItem1
            // 
            salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            salirToolStripMenuItem1.Size = new Size(177, 26);
            salirToolStripMenuItem1.Text = "Salir";
            // 
            // panel3
            // 
            panel3.Controls.Add(tabControl1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 37);
            panel3.Name = "panel3";
            panel3.Size = new Size(1191, 675);
            panel3.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbpInicio);
            tabControl1.Controls.Add(tbpGestionAcademica);
            tabControl1.Controls.Add(tbpReporte);
            tabControl1.Location = new Point(11, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1147, 667);
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
            tbpInicio.Size = new Size(1139, 634);
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
            panel4.Size = new Size(927, 111);
            panel4.TabIndex = 1;
            // 
            // lblTotalAsignaturas
            // 
            lblTotalAsignaturas.AutoSize = true;
            lblTotalAsignaturas.Location = new Point(741, 67);
            lblTotalAsignaturas.Name = "lblTotalAsignaturas";
            lblTotalAsignaturas.Size = new Size(50, 20);
            lblTotalAsignaturas.TabIndex = 7;
            lblTotalAsignaturas.Text = "label8";
            // 
            // lblTotalAdministrativos
            // 
            lblTotalAdministrativos.AutoSize = true;
            lblTotalAdministrativos.Location = new Point(491, 67);
            lblTotalAdministrativos.Name = "lblTotalAdministrativos";
            lblTotalAdministrativos.Size = new Size(50, 20);
            lblTotalAdministrativos.TabIndex = 6;
            lblTotalAdministrativos.Text = "label7";
            // 
            // lblTotalProfesores
            // 
            lblTotalProfesores.AutoSize = true;
            lblTotalProfesores.Location = new Point(281, 67);
            lblTotalProfesores.Name = "lblTotalProfesores";
            lblTotalProfesores.Size = new Size(50, 20);
            lblTotalProfesores.TabIndex = 5;
            lblTotalProfesores.Text = "label6";
            // 
            // lblTotalAlumnos
            // 
            lblTotalAlumnos.AutoSize = true;
            lblTotalAlumnos.Location = new Point(85, 67);
            lblTotalAlumnos.Name = "lblTotalAlumnos";
            lblTotalAlumnos.Size = new Size(50, 20);
            lblTotalAlumnos.TabIndex = 4;
            lblTotalAlumnos.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(741, 25);
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
            panel2.Controls.Add(btnDashAsignaturas);
            panel2.Controls.Add(btnDashCarreras);
            panel2.Controls.Add(btnDashAdministrativos);
            panel2.Controls.Add(btnDashProfesores);
            panel2.Controls.Add(btnDashAlumnos);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(206, 628);
            panel2.TabIndex = 0;
            // 
            // btnDashExamenes
            // 
            btnDashExamenes.Location = new Point(21, 383);
            btnDashExamenes.Name = "btnDashExamenes";
            btnDashExamenes.Size = new Size(165, 29);
            btnDashExamenes.TabIndex = 8;
            btnDashExamenes.Text = "Examenes";
            btnDashExamenes.UseVisualStyleBackColor = true;
            btnDashExamenes.Click += btnDashExamenes_Click;
            // 
            // btnDashAsignaturas
            // 
            btnDashAsignaturas.Location = new Point(21, 309);
            btnDashAsignaturas.Name = "btnDashAsignaturas";
            btnDashAsignaturas.Size = new Size(165, 29);
            btnDashAsignaturas.TabIndex = 6;
            btnDashAsignaturas.Text = "Asignaturas";
            btnDashAsignaturas.UseVisualStyleBackColor = true;
            btnDashAsignaturas.Click += btnDashAsignaturas_Click;
            // 
            // btnDashCarreras
            // 
            btnDashCarreras.Location = new Point(21, 195);
            btnDashCarreras.Name = "btnDashCarreras";
            btnDashCarreras.Size = new Size(165, 29);
            btnDashCarreras.TabIndex = 5;
            btnDashCarreras.Text = "Carreras";
            btnDashCarreras.UseVisualStyleBackColor = true;
            // 
            // btnDashAdministrativos
            // 
            btnDashAdministrativos.Location = new Point(21, 140);
            btnDashAdministrativos.Name = "btnDashAdministrativos";
            btnDashAdministrativos.Size = new Size(165, 29);
            btnDashAdministrativos.TabIndex = 4;
            btnDashAdministrativos.Text = "Administrativos";
            btnDashAdministrativos.UseVisualStyleBackColor = true;
            // 
            // btnDashProfesores
            // 
            btnDashProfesores.Location = new Point(21, 83);
            btnDashProfesores.Name = "btnDashProfesores";
            btnDashProfesores.Size = new Size(165, 29);
            btnDashProfesores.TabIndex = 3;
            btnDashProfesores.Text = "Profesores";
            btnDashProfesores.UseVisualStyleBackColor = true;
            btnDashProfesores.Click += btnDashProfesores_Click;
            // 
            // btnDashAlumnos
            // 
            btnDashAlumnos.Location = new Point(21, 25);
            btnDashAlumnos.Name = "btnDashAlumnos";
            btnDashAlumnos.Size = new Size(165, 29);
            btnDashAlumnos.TabIndex = 2;
            btnDashAlumnos.Text = "Alumnos";
            btnDashAlumnos.UseVisualStyleBackColor = true;
            btnDashAlumnos.Click += btnDashAlumnos_Click;
            // 
            // tbpGestionAcademica
            // 
            tbpGestionAcademica.Controls.Add(panel5);
            tbpGestionAcademica.Location = new Point(4, 29);
            tbpGestionAcademica.Name = "tbpGestionAcademica";
            tbpGestionAcademica.Padding = new Padding(3);
            tbpGestionAcademica.Size = new Size(1139, 634);
            tbpGestionAcademica.TabIndex = 1;
            tbpGestionAcademica.Text = "Gestion Academica";
            tbpGestionAcademica.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(tabControl2);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 3);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(1133, 628);
            panel5.TabIndex = 0;
            // 
            // tabControl2
            // 
            tabControl2.Appearance = TabAppearance.FlatButtons;
            tabControl2.Controls.Add(tabPage1);
            tabControl2.Controls.Add(tabPage2);
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Controls.Add(tabPage5);
            tabControl2.Controls.Add(tabPage6);
            tabControl2.Location = new Point(3, 21);
            tabControl2.Margin = new Padding(3, 4, 3, 4);
            tabControl2.Multiline = true;
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(1125, 597);
            tabControl2.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel7);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(1117, 561);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Alumnos";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            panel7.Controls.Add(textBox10);
            panel7.Controls.Add(textBox9);
            panel7.Controls.Add(textBox8);
            panel7.Controls.Add(textBox7);
            panel7.Controls.Add(label9);
            panel7.Controls.Add(label8);
            panel7.Controls.Add(label7);
            panel7.Controls.Add(label6);
            panel7.Controls.Add(lblEmail);
            panel7.Controls.Add(label5);
            panel7.Controls.Add(lblDireccionC);
            panel7.Controls.Add(lblDNI);
            panel7.Controls.Add(lblApellido);
            panel7.Controls.Add(lblNombreAlumno);
            panel7.Controls.Add(textBox6);
            panel7.Controls.Add(textBox5);
            panel7.Controls.Add(textBox4);
            panel7.Controls.Add(textBox3);
            panel7.Controls.Add(textBox2);
            panel7.Controls.Add(textBox1);
            panel7.Controls.Add(btnEliminarAlumno);
            panel7.Controls.Add(btnModificarAlumno);
            panel7.Controls.Add(btnAgregarAlumno);
            panel7.Controls.Add(dataGridView1);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(3, 4);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(1111, 553);
            panel7.TabIndex = 1;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(968, 488);
            textBox10.Margin = new Padding(3, 4, 3, 4);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(114, 27);
            textBox10.TabIndex = 23;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(931, 409);
            textBox9.Margin = new Padding(3, 4, 3, 4);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(114, 27);
            textBox9.TabIndex = 22;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(704, 485);
            textBox8.Margin = new Padding(3, 4, 3, 4);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(114, 27);
            textBox8.TabIndex = 21;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(679, 405);
            textBox7.Margin = new Padding(3, 4, 3, 4);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(114, 27);
            textBox7.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(863, 496);
            label9.Name = "label9";
            label9.Size = new Size(86, 20);
            label9.TabIndex = 19;
            label9.Text = "Contraseña:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(850, 416);
            label8.Name = "label8";
            label8.Size = new Size(59, 20);
            label8.TabIndex = 18;
            label8.Text = "Usuario";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(563, 492);
            label7.Name = "label7";
            label7.Size = new Size(146, 20);
            label7.TabIndex = 17;
            label7.Text = "Fecha de nacimiento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(590, 409);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 16;
            label6.Text = "Teléfono";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(322, 503);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 15;
            lblEmail.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(322, 407);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 14;
            label5.Text = "Altura:\r\n";
            // 
            // lblDireccionC
            // 
            lblDireccionC.AutoSize = true;
            lblDireccionC.Location = new Point(322, 351);
            lblDireccionC.Name = "lblDireccionC";
            lblDireccionC.Size = new Size(107, 20);
            lblDireccionC.TabIndex = 13;
            lblDireccionC.Text = "Direccion calle";
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Location = new Point(50, 503);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(35, 20);
            lblDNI.TabIndex = 12;
            lblDNI.Text = "DNI";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(50, 424);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(66, 20);
            lblApellido.TabIndex = 11;
            lblApellido.Text = "Apellido";
            // 
            // lblNombreAlumno
            // 
            lblNombreAlumno.AutoSize = true;
            lblNombreAlumno.Location = new Point(48, 355);
            lblNombreAlumno.Name = "lblNombreAlumno";
            lblNombreAlumno.Size = new Size(64, 20);
            lblNombreAlumno.TabIndex = 10;
            lblNombreAlumno.Text = "Nombre";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(390, 492);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(114, 27);
            textBox6.TabIndex = 9;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(390, 403);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(114, 27);
            textBox5.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(425, 344);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(114, 27);
            textBox4.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(115, 420);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(98, 503);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(114, 27);
            textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 351);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(127, 27);
            textBox1.TabIndex = 4;
            // 
            // btnEliminarAlumno
            // 
            btnEliminarAlumno.Location = new Point(925, 303);
            btnEliminarAlumno.Margin = new Padding(3, 4, 3, 4);
            btnEliminarAlumno.Name = "btnEliminarAlumno";
            btnEliminarAlumno.Size = new Size(86, 31);
            btnEliminarAlumno.TabIndex = 3;
            btnEliminarAlumno.Text = "Eliminar";
            btnEliminarAlumno.UseVisualStyleBackColor = true;
            // 
            // btnModificarAlumno
            // 
            btnModificarAlumno.Location = new Point(925, 199);
            btnModificarAlumno.Margin = new Padding(3, 4, 3, 4);
            btnModificarAlumno.Name = "btnModificarAlumno";
            btnModificarAlumno.Size = new Size(86, 31);
            btnModificarAlumno.TabIndex = 2;
            btnModificarAlumno.Text = "Modificar";
            btnModificarAlumno.UseVisualStyleBackColor = true;
            // 
            // btnAgregarAlumno
            // 
            btnAgregarAlumno.Location = new Point(925, 95);
            btnAgregarAlumno.Margin = new Padding(3, 4, 3, 4);
            btnAgregarAlumno.Name = "btnAgregarAlumno";
            btnAgregarAlumno.Size = new Size(86, 31);
            btnAgregarAlumno.TabIndex = 1;
            btnAgregarAlumno.Text = "Agregar";
            btnAgregarAlumno.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(50, 53);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(784, 243);
            dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel10);
            tabPage2.Controls.Add(panel9);
            tabPage2.Controls.Add(panel8);
            tabPage2.Controls.Add(panel6);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(1117, 561);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Profesor";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 32);
            tabPage3.Margin = new Padding(3, 4, 3, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1117, 561);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Administrativos";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 32);
            tabPage4.Margin = new Padding(3, 4, 3, 4);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1117, 561);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Carreras";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 32);
            tabPage5.Margin = new Padding(3, 4, 3, 4);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1117, 561);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Asignaturas";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 32);
            tabPage6.Margin = new Padding(3, 4, 3, 4);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1117, 561);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Exámenes";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tbpReporte
            // 
            tbpReporte.Location = new Point(4, 29);
            tbpReporte.Name = "tbpReporte";
            tbpReporte.Size = new Size(1139, 634);
            tbpReporte.TabIndex = 2;
            tbpReporte.Text = "Reporte";
            tbpReporte.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.Controls.Add(btnEliminarProfesor);
            panel6.Controls.Add(btnModificarProfesor);
            panel6.Controls.Add(btnAgregarProfesor);
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(991, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(123, 553);
            panel6.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Controls.Add(button1);
            panel8.Controls.Add(textBox11);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(3, 4);
            panel8.Name = "panel8";
            panel8.Size = new Size(988, 41);
            panel8.TabIndex = 1;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Bottom;
            panel9.Location = new Point(3, 339);
            panel9.Name = "panel9";
            panel9.Size = new Size(988, 218);
            panel9.TabIndex = 2;
            // 
            // panel10
            // 
            panel10.Controls.Add(dataGridView2);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(3, 45);
            panel10.Name = "panel10";
            panel10.Size = new Size(988, 294);
            panel10.TabIndex = 3;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(988, 294);
            dataGridView2.TabIndex = 0;
            // 
            // btnAgregarProfesor
            // 
            btnAgregarProfesor.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarProfesor.ForeColor = Color.DimGray;
            btnAgregarProfesor.Location = new Point(18, 121);
            btnAgregarProfesor.Name = "btnAgregarProfesor";
            btnAgregarProfesor.Size = new Size(101, 58);
            btnAgregarProfesor.TabIndex = 0;
            btnAgregarProfesor.Text = "Agregar";
            btnAgregarProfesor.UseVisualStyleBackColor = true;
            // 
            // btnModificarProfesor
            // 
            btnModificarProfesor.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificarProfesor.ForeColor = Color.DimGray;
            btnModificarProfesor.Location = new Point(17, 248);
            btnModificarProfesor.Name = "btnModificarProfesor";
            btnModificarProfesor.Size = new Size(102, 53);
            btnModificarProfesor.TabIndex = 1;
            btnModificarProfesor.Text = "Modificar";
            btnModificarProfesor.UseVisualStyleBackColor = true;
            // 
            // btnEliminarProfesor
            // 
            btnEliminarProfesor.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminarProfesor.ForeColor = Color.DimGray;
            btnEliminarProfesor.Location = new Point(18, 375);
            btnEliminarProfesor.Name = "btnEliminarProfesor";
            btnEliminarProfesor.Size = new Size(101, 53);
            btnEliminarProfesor.TabIndex = 2;
            btnEliminarProfesor.Text = "Eliminar";
            btnEliminarProfesor.UseVisualStyleBackColor = true;
            // 
            // textBox11
            // 
            textBox11.BorderStyle = BorderStyle.None;
            textBox11.Location = new Point(569, 15);
            textBox11.Name = "textBox11";
            textBox11.PlaceholderText = "Buscar";
            textBox11.Size = new Size(254, 20);
            textBox11.TabIndex = 1;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(829, 3);
            button1.Name = "button1";
            button1.Size = new Size(116, 37);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1191, 712);
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
            tbpGestionAcademica.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private Panel panel3;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripMenuItem exportarToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
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
        private Button btnDashAsignaturas;
        private Button btnDashCarreras;
        private Button btnDashAdministrativos;
        private Button btnDashProfesores;
        private Button btnDashAlumnos;
        private DataGridView dgvDashboard;
        private Label lblTituloDashboard;
        private Panel panel5;
        private TabControl tabControl2;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel7;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private Button btnEliminarAlumno;
        private Button btnModificarAlumno;
        private Button btnAgregarAlumno;
        private DataGridView dataGridView1;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label lblDireccionC;
        private Label lblDNI;
        private Label lblApellido;
        private Label lblNombreAlumno;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label lblEmail;
        private Label label5;
        private TextBox textBox10;
        private TextBox textBox9;
        private TextBox textBox8;
        private TextBox textBox7;
        private ToolStripMenuItem usuarioToolStripMenuItem;
        private ToolStripMenuItem perfilToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem1;
        private Panel panel9;
        private Panel panel8;
        private Panel panel6;
        private Panel panel10;
        private DataGridView dataGridView2;
        private Button btnEliminarProfesor;
        private Button btnModificarProfesor;
        private Button btnAgregarProfesor;
        private TextBox textBox11;
        private Button button1;
    }
}