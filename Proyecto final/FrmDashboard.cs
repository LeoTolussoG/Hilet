using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Proyecto_final
{
    public partial class FrmDashboard : Form
    {
        clsConexion ConectarBDD = new clsConexion();
        public string PerfilUsuario { get; set; }// la propiedad va a recibir el perfil desde el login
        public int IdPerfilUsuario { get; set; }
        public void CargarDashboard()       // metodo que encuentra el total de registros de las tablas
        {
            ConectarBDD.abrir();
            string consulta = "sp_Estado";

            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                lblTotalAlumnos.Text = registro["TotalAlumnos"].ToString();
                lblTotalProfesores.Text = registro["TotalProfesores"].ToString();
                lblTotalAdministrativos.Text = registro["TotalAdministrativos"].ToString();
                lblTotalAsignaturas.Text = registro["TotalMaterias"].ToString();
            }
            ConectarBDD.cerrar();
        }

        public FrmDashboard(int idPerfil, string perfilusuario) //constructor del formulario
        {
            InitializeComponent();
            IdPerfilUsuario = idPerfil;//recibe el id del perfil del usuario
            PerfilUsuario = perfilusuario; // recibe el nombre de usuario logueado
        }
        private void FrmDashboard_Load(object sender, EventArgs e) //evento que se activa cuando se abre el formulario
        {
            CargarDashboard();
            Cargar_tabla_Empleado_Profesores();
            Cargar_tabla_Empleado_Administrativos();
            Cargar_tabla_Alumno();
            Cargar_tabla_Carreras();
            Cargar_tabla_Examenes();
            Cargar_tabla_Asignatura();
            CargarPermisos(IdPerfilUsuario);
            Cargar_ComboBox_Alumnos();//Cargo los comboBox en la pestaña exámenes
            Cargar_ComboBox_Profesor();
            Cargar_ComboBox_Instancias();
            Cargar_ComboBox_Asignatura();

            // cajas de texto para nombres con validación para solo escribir letras
            txtNombreAdministrativo.KeyPress += new KeyPressEventHandler(textBox_sinNumeros);
            txtNombreAlumno.KeyPress += new KeyPressEventHandler(textBox_sinNumeros);
            txtNombreAsignatura.KeyPress += new KeyPressEventHandler(textBox_sinNumeros);
            txtNombreCarrera.KeyPress += new KeyPressEventHandler(textBox_sinNumeros);
            txtNombreProfesor.KeyPress += new KeyPressEventHandler(textBox_sinNumeros);

            // cajas de texto para apellidos con validación para solo escribir letras
            txtApellidoAdministrativo.KeyPress += new KeyPressEventHandler(textBox_sinNumeros);
            txtApellidoAlumno.KeyPress += new KeyPressEventHandler(textBox_sinNumeros);
            txtApellidoProfesor.KeyPress += new KeyPressEventHandler(textBox_sinNumeros);

            // cajas de texto para DNI con validación para ingresar numeros
            txtDniAdministrativo.KeyPress += new KeyPressEventHandler(textBox_soloNumeros);
            txtDNIAlumno.KeyPress += new KeyPressEventHandler(textBox_soloNumeros);
            txtDniProfesor.KeyPress += new KeyPressEventHandler(textBox_soloNumeros);

            // cajas de texto para numeros de telefono con validación para ingresar numeros
            txtTelAlumno.KeyPress += new KeyPressEventHandler(textBox_soloNumeros);
            txtTelefonoAdministrativo.KeyPress += new KeyPressEventHandler(textBox_soloNumeros);
            txtTelefonoProfesor.KeyPress += new KeyPressEventHandler(textBox_soloNumeros);

            // cajas de texto para Altura de calle con validación para ingresar numeros
            txtAlturaAdministrativo.KeyPress += new KeyPressEventHandler(textBox_soloNumeros);
            txtAlturaAlumno.KeyPress += new KeyPressEventHandler(textBox_soloNumeros);
            txtAlturaProfesor.KeyPress += new KeyPressEventHandler(textBox_soloNumeros);
        }
        //METODO PATA TENER LOS PERMISOS DE UN PERFIL ESPECIFICO
        public void CargarPermisos(int idPerfil)
        {
            ConectarBDD.abrir();

            string consulta = "sp_ObtenerPermisosPorPerfil";

            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id_perfil", idPerfil);

            SqlDataReader reader = comando.ExecuteReader(); //ejecuto el comando

            List<string> permisos = new List<string>();

            while (reader.Read())
            {
                permisos.Add(reader["Tipo_permiso"].ToString()); //agrega el permiso a la lista
            }
            ConectarBDD.cerrar();

            AplicarPermisos(permisos);
        }

        public void AplicarPermisos(List<string> permisos)
        {
            //Si el permiso para gestionar alumnos no está en la lista entonces deshabilita el boton
            if (permisos.Contains("Gestionar Alumnos"))
            {
                tabControl2.TabPages.Remove(tabPage1);
            }
            if (permisos.Contains("Gestionar Administrativos"))
            {
                tabControl2.TabPages.Remove(tabPage3);
            }
            if (permisos.Contains("Gestionar Profesores"))
            {
                tabControl2.TabPages.Remove(tabPage2);
            }
            if (permisos.Contains("Gestionar Materias"))
            {
                tabControl2.TabPages.Remove(tabPage4);
            }
            if (permisos.Contains("Gestionar Carreras"))
            {
                tabControl2.TabPages.Remove(tabPage5);
            }
            if (permisos.Contains("Gestionar Usuarios"))
            {
                txtUsuarioAdministrativo.ReadOnly = true;
                txtContraseñaAdministrativo.ReadOnly = true;
                txtUsuarioAlumno.ReadOnly = true;
                txtContraseñaAlumno.ReadOnly = true;
                txtUsuarioProfesor.ReadOnly = true;
                txtContraseñaProfesor.ReadOnly = true;
            }
            if (permisos.Contains("visualizar información personal"))
            {
                //tabControl1.TabPages.Remove(tbpPerfil);
            }
        }

        private void textBox_sinNumeros(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada si es un número
            }
        }
        private void textBox_soloNumeros(object sender, KeyPressEventArgs e)
        {
            if (char.IsAsciiLetter(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada si es un número
            }
        }

        //PESTAÑA INICIO: MUESTRA UN ESTADO GENERAL DE LOS DATOS
        private void btnDashExamenes_Click(object sender, EventArgs e)
        {
            lblTituloDashboard.Text = "Ultimos examenes";

            ConectarBDD.abrir();
            string consulta = "sp_Dash_Examenes";
            SqlDataAdapter comando = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dataTable = new DataTable();

            comando.Fill(dataTable);
            dgvDashboard.DataSource = dataTable;
            ConectarBDD.cerrar();
        }

        private void btnDashAlumnos_Click(object sender, EventArgs e)
        {
            lblTituloDashboard.Text = "Ultimos alumnos registrados";

            ConectarBDD.abrir();
            string consulta = "sp_Dash_Alumnos";
            SqlDataAdapter comando = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dataTable = new DataTable();

            comando.Fill(dataTable);
            dgvDashboard.DataSource = dataTable;
            ConectarBDD.cerrar();
        }

        private void btnDashProfesores_Click(object sender, EventArgs e)
        {
            lblTituloDashboard.Text = "Ultimos Profesores registrados";

            ConectarBDD.abrir();
            string consulta = "sp_Dash_Profesores";
            SqlDataAdapter comando = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dataTable = new DataTable();

            comando.Fill(dataTable);
            dgvDashboard.DataSource = dataTable;
            ConectarBDD.cerrar();
        }

        private void btnDashAsignaturas_Click(object sender, EventArgs e)
        {
            lblTituloDashboard.Text = "Ultimas Asignaturas";

            ConectarBDD.abrir();
            string consulta = "sp_Dash_Asignaturas";
            SqlDataAdapter comando = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dataTable = new DataTable();

            comando.Fill(dataTable);
            dgvDashboard.DataSource = dataTable;
            ConectarBDD.cerrar();
        }
        private void btnDashAdministrativos_Click(object sender, EventArgs e)
        {
            lblTituloDashboard.Text = "Ultimos administrativos registrados";

            ConectarBDD.abrir();
            string consulta = "sp_Dash_Administrativos";
            SqlDataAdapter comando = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dataTable = new DataTable();

            comando.Fill(dataTable);
            dgvDashboard.DataSource = dataTable;
            ConectarBDD.cerrar();
        }
        private void btnDashCarreras_Click(object sender, EventArgs e)
        {
            lblTituloDashboard.Text = "Ultimas carreras";

            ConectarBDD.abrir();
            string consulta = "sp_Dash_Carreras";
            SqlDataAdapter comando = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dataTable = new DataTable();

            comando.Fill(dataTable);
            dgvDashboard.DataSource = dataTable;
            ConectarBDD.cerrar();
        }

        //PESTAÑA GESTION ACADEMICA: ALUMNOS
        public void Cargar_tabla_Alumno()
        {
            ConectarBDD.abrir();
            string consulta = "select * from Alumnos";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dgvAlumnos.DataSource = dt;
            ConectarBDD.cerrar();
        }

        // Evento que oculta las contraseñas en el datagridview
        private void dgvAlumnos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }
        private bool Validar_Datos_Alumno()             //Verifico que los campos cumplan con los requisitos
        {
            errorProviderDatosVacios.Clear();
            bool valido = true;

            if (txtNombreAlumno.Text == "")
            {
                errorProviderDatosVacios.SetError(txtNombreAlumno, "El nombre está vacío");
                valido = false;
            }
            if (txtApellidoAlumno.Text == "")
            {
                errorProviderDatosVacios.SetError(txtApellidoAlumno, "El apellido está vacío");
                valido = false;
            }
            if (txtDNIAlumno.Text == "")
            {
                errorProviderDatosVacios.SetError(txtDNIAlumno, "El DNI está vacío");
                valido = false;
            }
            if (txtDireccionAlumno.Text == "")
            {
                errorProviderDatosVacios.SetError(txtDireccionAlumno, "La Dirección está vacía");
                valido = false;
            }
            if (txtAlturaAlumno.Text == "")
            {
                errorProviderDatosVacios.SetError(txtAlturaAlumno, "La altura está vacía");
                valido = false;
            }
            if (txtEmailAlumno.Text == "")
            {
                errorProviderDatosVacios.SetError(txtEmailAlumno, "El email está vacío");
                valido = false;
            }
            if (dateTimeAlumno.Text == "")
            {
                errorProviderDatosVacios.SetError(dateTimeAlumno, "La fecha de nacimiento está vacáa");
                valido = false;
            }
            if (txtTelAlumno.Text == "")
            {
                errorProviderDatosVacios.SetError(txtTelAlumno, "El teléfono está vacío");
                valido = false;
            }
            if (txtUsuarioAlumno.Text == "")
            {
                errorProviderDatosVacios.SetError(txtUsuarioAlumno, "El usuario está vacío");
                valido = false;
            }
            if (txtContraseñaAlumno.Text == "")
            {
                errorProviderDatosVacios.SetError(txtContraseñaAlumno, "La contraseña está vacía");
                valido = false;
            }
            return valido;

        }
        int IdAlumno;
        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) //Me fijo que haya un reglon seleccionado
            {
                DataGridViewRow row = dgvAlumnos.Rows[e.RowIndex];//asigno los valores a los textbox
                IdAlumno = Convert.ToInt32(row.Cells["Id_alumno"].Value);
                txtNombreAlumno.Text = row.Cells["Nombre"].Value.ToString();
                txtApellidoAlumno.Text = row.Cells["Apellido"].Value.ToString();
                txtDNIAlumno.Text = row.Cells["Dni"].Value.ToString();
                txtDireccionAlumno.Text = row.Cells["Direccion_calle"].Value.ToString();
                txtAlturaAlumno.Text = row.Cells["Direccion_num"].Value.ToString();
                txtEmailAlumno.Text = row.Cells["Email"].Value.ToString();
                txtTelAlumno.Text = row.Cells["Telefono"].Value.ToString();
                dateTimeAlumno.Value = Convert.ToDateTime(row.Cells["F_nacimiento"].Value);
                txtUsuarioAlumno.Text = row.Cells["Usuario"].Value.ToString();
                txtContraseñaAlumno.Text = row.Cells["Contraseña"].Value.ToString();
            }
        }
        private void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            if (Validar_Datos_Alumno())
            {
                ConectarBDD.abrir();
                string consulta = "sp_AgregarAlumno";
                SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Nombre", txtNombreAlumno.Text);
                comando.Parameters.AddWithValue("@Apellido", txtApellidoAlumno.Text);
                comando.Parameters.AddWithValue("@Dni", txtDNIAlumno.Text);
                comando.Parameters.AddWithValue("@F_nacimiento", dateTimeAlumno.Value);
                comando.Parameters.AddWithValue("@Direccion", txtDireccionAlumno.Text);
                comando.Parameters.AddWithValue("@Altura", txtAlturaAlumno.Text);
                comando.Parameters.AddWithValue("@Email", txtEmailAlumno.Text);
                comando.Parameters.AddWithValue("@Telefono", txtTelAlumno.Text);
                comando.Parameters.AddWithValue("@Usuario", txtUsuarioAlumno.Text);
                comando.Parameters.AddWithValue("@Contraseña", txtContraseñaAlumno.Text);

                comando.ExecuteNonQuery();

                MessageBox.Show("Registro Agregado!");

                Cargar_tabla_Alumno();
            }
        }
        private void btnModificarAlumno_Click(object sender, EventArgs e)
        {
            if (Validar_Datos_Alumno())
            {
                ConectarBDD.abrir();
                string consulta = "sp_ModificarAlumno";
                SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
                comando.CommandType = CommandType.StoredProcedure;


                comando.Parameters.AddWithValue("@Id_alumno", IdAlumno);
                comando.Parameters.AddWithValue("@Id_perfil", 1);
                comando.Parameters.AddWithValue("@Nombre", txtNombreAlumno.Text);
                comando.Parameters.AddWithValue("@Apellido", txtApellidoAlumno.Text);
                comando.Parameters.AddWithValue("@DNI", txtDNIAlumno.Text);
                comando.Parameters.AddWithValue("@F_nacimiento", dateTimeAlumno.Value);
                comando.Parameters.AddWithValue("@Direccion", txtDireccionAlumno.Text);
                comando.Parameters.AddWithValue("@Altura", Convert.ToInt32(txtAlturaAlumno.Text));
                comando.Parameters.AddWithValue("@Email", txtEmailAlumno.Text);
                comando.Parameters.AddWithValue("@Telefono", txtTelAlumno.Text);
                comando.Parameters.AddWithValue("@Usuario", txtUsuarioAlumno.Text);
                comando.Parameters.AddWithValue("@Contraseña", txtContraseñaAlumno.Text);


                comando.ExecuteNonQuery();

                MessageBox.Show("Registro Modificado!");

                Cargar_tabla_Alumno();
            }
        }
        private void btnEliminarAlumno_Click(object sender, EventArgs e)
        {
            if (Validar_Datos_Alumno())
            {
                ConectarBDD.abrir();
                string consulta = "sp_EliminarAlumno";
                SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id_alumno", IdAlumno);
                comando.Parameters.AddWithValue("@Id_perfil", 1);

                comando.ExecuteNonQuery();
                MessageBox.Show("Alumno Eliminado exitosamente!");

                Cargar_tabla_Alumno();
            }
        }
        private void btnBuscarAlumno_Click(object sender, EventArgs e)
        {
            //Me fijo que el usuario ingrese un ID válido
            int IDAlumno;
            if (!int.TryParse(txtBuscarAlumno.Text, out IDAlumno))
            {
                MessageBox.Show("Ingrese una matricula válida");
                return;
            }

            ConectarBDD.abrir();

            string consulta = "SELECT * FROM Alumnos WHERE Id_alumno = @Id_alumno";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.Parameters.AddWithValue("@Id_alumno", IDAlumno);

            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dgvAlumnos.DataSource = dt;

            ConectarBDD.cerrar();

            if (dt.Rows.Count == 0) //Acá verifica si el dgvAlumnos tiene filas, si es = 0 entonces no encontró ningún alumno 
            {
                MessageBox.Show("No se encontró ningún alumno con ese ID.");
            }

        }

        //PESTAÑA GESTION ACADEMICA: ADMINISTRATIVOS --------------------------------------------------------------
        public void Cargar_tabla_Empleado_Administrativos()    //Carga de registros el datagridview de Administrativos
        {
            ConectarBDD.abrir();
            string consulta = "sp_Cargar_Tabla_Administrativos";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dgvAdministrativos.DataSource = dt;
            ConectarBDD.cerrar();
        }

        // Evento para ocultar las contraseñas en el datagridview
        private void dgvAdministrativos_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }


        private bool Validar_Datos_Administrativo()     //Verifico que los campos no queden vacios
        {
            errorProviderDatosVacios.Clear();
            bool valido = true;

            if (txtNombreAdministrativo.Text == "")
            {
                errorProviderDatosVacios.SetError(txtNombreAdministrativo, "Nombre esta vacio");
                valido = false;
            }
            if (txtApellidoAdministrativo.Text == "")
            {
                errorProviderDatosVacios.SetError(txtApellidoAdministrativo, "Apellido vacio");
                valido = false;
            }
            if (txtDniAdministrativo.Text == "")
            {
                errorProviderDatosVacios.SetError(txtDniAdministrativo, "DNI vacio");
                valido = false;
            }
            if (txtDireccionCalleAdministrativo.Text == "")
            {
                errorProviderDatosVacios.SetError(txtDireccionCalleAdministrativo, "Direccion vacia");
                valido = false;
            }
            if (txtAlturaAdministrativo.Text == "")
            {
                errorProviderDatosVacios.SetError(txtAlturaAdministrativo, "Altura vacia");
                valido = false;
            }
            if (txtEmailAdministrativo.Text == "")
            {
                errorProviderDatosVacios.SetError(txtEmailAdministrativo, "Email vacio");
                valido = false;
            }
            if (dtpFechaNacimientoAdministrativo.Text == "")
            {
                errorProviderDatosVacios.SetError(dtpFechaNacimientoAdministrativo, "Fecha de nacimiento vacia");
                valido = false;
            }
            if (txtTelefonoAdministrativo.Text == "")
            {
                errorProviderDatosVacios.SetError(txtTelefonoAdministrativo, "telefono vacio");
                valido = false;
            }
            if (txtUsuarioAdministrativo.Text == "")
            {
                errorProviderDatosVacios.SetError(txtUsuarioAdministrativo, "Usuario vacio");
                valido = false;
            }
            if (txtContraseñaAdministrativo.Text == "")
            {
                errorProviderDatosVacios.SetError(txtContraseñaAdministrativo, "Contraseña vacia");
                valido = false;
            }
            return valido;

        }
        int IdAdministrativo;
        private void dgvAdministrativos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAdministrativos.Rows[e.RowIndex];
                IdAdministrativo = Convert.ToInt32(row.Cells["Nro_Personal"].Value);
                txtNombreAdministrativo.Text = row.Cells["Nombre"].Value.ToString();
                txtApellidoAdministrativo.Text = row.Cells["Apellido"].Value.ToString();
                txtDniAdministrativo.Text = row.Cells["Dni"].Value.ToString();
                txtDireccionCalleAdministrativo.Text = row.Cells["Domicilio"].Value.ToString();
                txtAlturaAdministrativo.Text = row.Cells["Altura"].Value.ToString();
                txtEmailAdministrativo.Text = row.Cells["Email"].Value.ToString();
                dtpFechaNacimientoAdministrativo.Text = row.Cells["F_nacimiento"].Value.ToString();
                txtTelefonoAdministrativo.Text = row.Cells["Telefono"].Value.ToString();
                txtUsuarioAdministrativo.Text = row.Cells["Nombre_Usuario"].Value.ToString();
                txtContraseñaAdministrativo.Text = row.Cells["Contraseña"].Value.ToString();
            }
        }
        private void btnAgregarAdministrativo_Click(object sender, EventArgs e)
        {
            if (Validar_Datos_Administrativo())
            {
                ConectarBDD.abrir();
                string consulta = "sp_Agregar_Administrativo";
                SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Nombre", txtNombreAdministrativo.Text);
                comando.Parameters.AddWithValue("@Apellido", txtApellidoAdministrativo.Text);
                comando.Parameters.AddWithValue("@Dni", txtDniAdministrativo.Text);
                comando.Parameters.AddWithValue("@F_nacimiento", dtpFechaNacimientoAdministrativo.Value);
                comando.Parameters.AddWithValue("@Direccion_calle", txtDireccionCalleAdministrativo.Text);
                comando.Parameters.AddWithValue("@Direccion_num", txtAlturaAdministrativo.Text);
                comando.Parameters.AddWithValue("@Email", txtEmailAdministrativo.Text);
                comando.Parameters.AddWithValue("@Telefono", txtTelefonoAdministrativo.Text);
                comando.Parameters.AddWithValue("@Usuario", txtUsuarioAdministrativo.Text);
                comando.Parameters.AddWithValue("@Contraseña", txtContraseñaAdministrativo.Text);

                comando.ExecuteNonQuery();

                ConectarBDD.cerrar();

                MessageBox.Show("Registro Agregado!");

                Cargar_tabla_Empleado_Administrativos();
            }

        }
        private void btnModificarAdministrativo_Click(object sender, EventArgs e)
        {
            if (IdAdministrativo == 0)
            {
                MessageBox.Show("Seleccione un empleado de la lista");
                return;
            }
            if (!Validar_Datos_Administrativo())
            {
                return;
            }

            ConectarBDD.abrir();
            string consulta = "sp_Modificar_Administrativo";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id_empleado", IdAdministrativo);
            comando.Parameters.AddWithValue("@Nombre", txtNombreAdministrativo.Text);
            comando.Parameters.AddWithValue("@Apellido", txtApellidoAdministrativo.Text);
            comando.Parameters.AddWithValue("@Dni", txtDniAdministrativo.Text);
            comando.Parameters.AddWithValue("@F_nacimiento", dtpFechaNacimientoAdministrativo.Value);
            comando.Parameters.AddWithValue("@Direccion_calle", txtDireccionCalleAdministrativo.Text);
            comando.Parameters.AddWithValue("@Direccion_num", txtAlturaAdministrativo.Text);
            comando.Parameters.AddWithValue("@Email", txtEmailAdministrativo.Text);
            comando.Parameters.AddWithValue("@Telefono", txtTelefonoAdministrativo.Text);
            comando.Parameters.AddWithValue("@Usuario", txtUsuarioAdministrativo.Text);
            comando.Parameters.AddWithValue("@Contraseña", txtContraseñaAdministrativo.Text);

            comando.ExecuteNonQuery();

            ConectarBDD.cerrar();

            MessageBox.Show("Registro Modificado!");

            Cargar_tabla_Empleado_Administrativos();

        }
        private void btnEliminarAdministrativo_Click(object sender, EventArgs e)
        {
            if (IdAdministrativo == 0)
            {
                MessageBox.Show("Seleccione un empleado de la lista");
                return;
            }

            ConectarBDD.abrir();
            string consulta = "sp_Eliminar_Administrativo";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;


            comando.Parameters.AddWithValue("@Id_empleado", IdAdministrativo);

            comando.ExecuteNonQuery();

            ConectarBDD.cerrar();

            MessageBox.Show("Registro Eliminado!");

            Cargar_tabla_Empleado_Administrativos();
        }

        private void btnBuscarAdministrativo_Click(object sender, EventArgs e)
        {
            //Me fijo que el usuario ingrese un ID válido
            int IdAdministrativo;
            if (!int.TryParse(txtBuscarAdministrativo.Text, out IdAdministrativo))
            {
                MessageBox.Show("Ingrese una matricula válida");
                return;
            }

            ConectarBDD.abrir();

            string consulta = "SELECT * FROM Empleados WHERE Id_empleado = @Id_empleado and Id_perfil = 3";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.Parameters.AddWithValue("@Id_empleado", IdAdministrativo);

            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dgvAdministrativos.DataSource = dt;

            ConectarBDD.cerrar();

            if (dt.Rows.Count == 0) //Acá verifica si el dgvAlumnos tiene filas, si es = 0 entonces no encontró ningún alumno 
            {
                MessageBox.Show("No se encontró ningún empladeo administrativo con ese ID.");
            }
        }

        //PESTAÑA GESTION ACADEMICA: CARRERAS----------------------------------------------------------------------
        public void Cargar_tabla_Carreras()         //Carga de registros el datagridview de Administrativos
        {
            ConectarBDD.abrir();
            string consulta = "select * from carreras";
            //string consulta = "sp_Cargar_Tabla_Carreras";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dgvCarreras.DataSource = dt;
            ConectarBDD.cerrar();
        }
        private bool Validar_Datos_Carrera()             //Verifico que los campos cumplan con los requisitos
        {
            errorProviderDatosVacios.Clear();
            bool valido = true;

            if (txtNombreCarrera.Text == "")
            {
                errorProviderDatosVacios.SetError(txtNombreCarrera, "Complete el Nombre");
                valido = false;
            }
            if (txtResolucionCarrera.Text == "")
            {
                errorProviderDatosVacios.SetError(txtResolucionCarrera, "Complete el número de resolucion");
                valido = false;
            }
            if (txtPlanEstudioCarrera.Text == "")
            {
                errorProviderDatosVacios.SetError(txtPlanEstudioCarrera, "Complete la Cantidad de años del plan de estudio");
                valido = false;
            }
            return valido;

        }
        int IdCarrera;
        private void dgvCarreras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCarreras.Rows[e.RowIndex];
                IdCarrera = Convert.ToInt32(row.Cells["Id_carrera"].Value);
                txtNombreCarrera.Text = row.Cells["Nombre"].Value.ToString();
                txtResolucionCarrera.Text = row.Cells["Num_res"].Value.ToString();
                txtPlanEstudioCarrera.Text = row.Cells["Año_PlanEstudio"].Value.ToString();
            }
        }

        private void btnAgregarCarreras_Click(object sender, EventArgs e)
        {
            if (Validar_Datos_Carrera())
            {
                ConectarBDD.abrir();
                string consulta = "sp_Agregar_Carrera";
                SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Nombre", txtNombreCarrera.Text);
                comando.Parameters.AddWithValue("@num_res", txtResolucionCarrera.Text);
                comando.Parameters.AddWithValue("@Año_Plan_estudio", txtPlanEstudioCarrera.Text);

                comando.ExecuteNonQuery();

                ConectarBDD.cerrar();

                MessageBox.Show("Registro Agregado!");

                Cargar_tabla_Carreras();
            }
        }

        private void btnModificarCarreras_Click(object sender, EventArgs e)
        {
            if (IdCarrera == 0)
            {
                MessageBox.Show("Seleccione una Carrera de la lista");
                return;
            }
            if (!Validar_Datos_Carrera())
            {
                return;
            }

            ConectarBDD.abrir();
            string consulta = "sp_Modificar_Carrera";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id_carrera", IdCarrera);
            comando.Parameters.AddWithValue("@Nombre", txtNombreCarrera.Text);
            comando.Parameters.AddWithValue("@num_res", txtResolucionCarrera.Text);
            comando.Parameters.AddWithValue("@Año_Plan_estudio", txtPlanEstudioCarrera.Text);

            comando.ExecuteNonQuery();

            ConectarBDD.cerrar();

            MessageBox.Show("Registro Modificado!");

            Cargar_tabla_Carreras();
        }

        private void btnEliminarCarreras_Click(object sender, EventArgs e)
        {
            if (IdCarrera == 0)
            {
                MessageBox.Show("Seleccione una Carrera de la lista");
                return;
            }

            ConectarBDD.abrir();
            string consulta = "sp_Eliminar_Carrera";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id_carrera", IdCarrera);

            comando.ExecuteNonQuery();

            ConectarBDD.cerrar();

            MessageBox.Show("Registro Eliminado!");

            Cargar_tabla_Carreras();

        }

        private void btnBuscarCarrera_Click(object sender, EventArgs e)
        {
            //Me fijo que el usuario ingrese un ID válido
            int IdCarrera;
            if (!int.TryParse(txtBuscarCarrera.Text, out IdCarrera))
            {
                MessageBox.Show("Ingrese una matricula válida");
                return;
            }

            ConectarBDD.abrir();

            string consulta = "SELECT * FROM CarreraS WHERE Id_carrera = @Id_carrera";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.Parameters.AddWithValue("@Id_carrera", IdCarrera);

            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dgvCarreras.DataSource = dt;

            ConectarBDD.cerrar();

            if (dt.Rows.Count == 0) //Acá verifica si el dgvAlumnos tiene filas, si es = 0 entonces no encontró ningún alumno 
            {
                MessageBox.Show("No se encontró una carrera con ese ID.");
            }

        }

        //PESTAÑA GESTION ACADEMICA: EXAMENES----------------------------------------------------------------------
        public void Cargar_tabla_Examenes()
        {
            ConectarBDD.abrir();
            string consulta = "sp_CargarExamenes";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();

            adapter.Fill(dt);
            dgvExamenes.DataSource = dt;

            ConectarBDD.cerrar();
        }
        private bool Validar_Datos_Examen()
        {
            errorProviderDatosVacios.Clear();
            bool valido = true;

            if (cbAlumnoExamen.SelectedIndex == -1)
            {
                errorProviderDatosVacios.SetError(cbAlumnoExamen, "Debe seleccionar un alumno");
                valido = false;
            }
            if (cbAsignaturaExamen.SelectedIndex == -1)
            {
                errorProviderDatosVacios.SetError(cbAsignaturaExamen, "Debe seleccionar una asignatura");
                valido = false;
            }
            if (cbInstanciaExamen.SelectedIndex == -1)
            {
                errorProviderDatosVacios.SetError(cbInstanciaExamen, "Debe seleccionar una instancia");
                valido = false;
            }
            if (cbProfesorExamen.SelectedIndex == -1)
            {
                errorProviderDatosVacios.SetError(cbProfesorExamen, "Debe seleccionar un profesor");
                valido = false;
            }
            if (txtNotaExamen.Text == "")
            {
                errorProviderDatosVacios.SetError(txtNotaExamen, "La calificación está vacía");
                valido = false;
            }
            if (dateTimeExamen.Text == "")
            {
                errorProviderDatosVacios.SetError(dateTimeExamen, "La fecha del examen está vacía");
                valido = false;
            }
            return valido;
        }
        private void dgvExamenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvExamenes.Rows[e.RowIndex];

                string idExamen = row.Cells["Id_examenes"].Value.ToString();
                MessageBox.Show("ID del Examen seleccionado: " + idExamen);
                txtNotaExamen.Text = row.Cells["Nota"].Value.ToString();
                dateTimeExamen.Value = Convert.ToDateTime(row.Cells["Fecha"].Value);
                cbAlumnoExamen.SelectedItem = row.Cells["Alumno"].Value.ToString();
                cbAsignaturaExamen.SelectedItem = row.Cells["Asignatura"].Value.ToString();
                cbInstanciaExamen.SelectedItem = row.Cells["Instancia"].Value.ToString();
                cbProfesorExamen.SelectedItem = row.Cells["Profesor"].Value.ToString();
            }
        }
        public void Cargar_ComboBox_Alumnos()
        {
            ConectarBDD.abrir();
            string consulta = "SELECT Nombre, Apellido FROM Alumnos";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            SqlDataReader reader = comando.ExecuteReader();

            cbAlumnoExamen.Items.Clear(); // Limpia antes de agregar

            while (reader.Read())
            {
                cbAlumnoExamen.Items.Add(reader["Nombre"].ToString() + " " + reader["Apellido"].ToString());
            }

            ConectarBDD.cerrar();
        }
        public void Cargar_ComboBox_Profesor()
        {
            ConectarBDD.abrir();
            string consulta = "SELECT Nombre, Apellido FROM Empleados WHERE Id_perfil = 2";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            SqlDataReader reader = comando.ExecuteReader();

            cbProfesorExamen.Items.Clear(); // Limpia antes de agregar

            while (reader.Read())
            {
                cbProfesorExamen.Items.Add(reader["Nombre"].ToString() + " " + reader["Apellido"].ToString()); //Agrega en el comboBox
            }

            ConectarBDD.cerrar();
        }
        public void Cargar_ComboBox_Instancias()
        {
            ConectarBDD.abrir();
            string consulta = "SELECT Descripcion FROM Instancias";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            SqlDataReader reader = comando.ExecuteReader();

            cbInstanciaExamen.Items.Clear(); // Limpia antes de agregar

            while (reader.Read())
            {
                cbInstanciaExamen.Items.Add(reader["Descripcion"].ToString()); //Agrega en el comboBox
            }

            ConectarBDD.cerrar();
        }
        public void Cargar_ComboBox_Asignatura()
        {
            ConectarBDD.abrir();
            string consulta = "SELECT Nombre FROM Asignatura";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            SqlDataReader reader = comando.ExecuteReader();

            cbAsignaturaExamen.Items.Clear(); // Limpia antes de agregar

            while (reader.Read())
            {
                cbAsignaturaExamen.Items.Add(reader["Nombre"].ToString()); //Agrega en el comboBox
            }

            ConectarBDD.cerrar();
        }
        private void btnAgregarExamen_Click(object sender, EventArgs e)
        {
            if (Validar_Datos_Examen())
            {
                // Esto es un array que separa el nombre y apellido del alumno seleccionado:
                //1ro: Obtiene el valor seleccionado en el ComboBox de alumnos, que adentro tiene el nombre completo como "Juan Pérez".

                //Después, usa el método "Split" para separar el nombre y apellido.(Es un método de los strings, toma un delimitador
                //(como un espacio, una coma, etc.) y divide una cadena en partes según ese delimitador, devolviendo un array de strings.)

                //Después asigna el nombre a "nombreAlumno" y el apellido a "apellidoAlumno".
                string[] nombreCompletoAlumno = cbAlumnoExamen.SelectedItem.ToString().Split(' ');
                string nombreAlumno = nombreCompletoAlumno[0];
                string apellidoAlumno = nombreCompletoAlumno[1];

                // Separar nombre y apellido del profesor seleccionado
                string[] nombreCompletoProfesor = cbProfesorExamen.SelectedItem.ToString().Split(' ');
                string nombreProfesor = nombreCompletoProfesor[0];
                string apellidoProfesor = nombreCompletoProfesor[1];

                ConectarBDD.abrir();
                string consulta = "sp_AgregarExamen";
                SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Nota", txtNotaExamen.Text);
                comando.Parameters.AddWithValue("@Fecha", dateTimeExamen.Value);
                comando.Parameters.AddWithValue("@Nombre_alumno", nombreAlumno);
                comando.Parameters.AddWithValue("@Apellido_alumno", apellidoAlumno);
                comando.Parameters.AddWithValue("@Asignatura", cbAsignaturaExamen.SelectedItem.ToString());
                comando.Parameters.AddWithValue("@Instancia", cbInstanciaExamen.SelectedItem.ToString());
                comando.Parameters.AddWithValue("@Nombre_profesor", nombreProfesor);
                comando.Parameters.AddWithValue("@Apellido_profesor", apellidoProfesor);

                comando.ExecuteNonQuery();

                MessageBox.Show("Registro Agregado!");

                Cargar_tabla_Examenes();
                ConectarBDD.cerrar();
            }
        }
        private void btnModificarExamen_Click(object sender, EventArgs e)
        {
            if (Validar_Datos_Examen()) // Reutiliza la función que valida los datos de entrada
            {
                // Asegúrate de tener el ID del examen seleccionado
                int idExamen = int.Parse(dgvExamenes.CurrentRow.Cells["Id_examenes"].Value.ToString());//CurrentRow te permite acceder a la fila donde actualmente está el cursor,
                                                                                                       //Es para hacer click en una celda y que seleccione la fila completa
                ConectarBDD.abrir();
                string consulta = "sp_ModificarExamen";
                SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id_examenes", idExamen);
                comando.Parameters.AddWithValue("@Nota", int.Parse(txtNotaExamen.Text));
                comando.Parameters.AddWithValue("@Fecha", dateTimeExamen.Value);
                comando.Parameters.AddWithValue("@Nombre_alumno", cbAlumnoExamen.SelectedItem.ToString());
                comando.Parameters.AddWithValue("@Asignatura", cbAsignaturaExamen.SelectedItem.ToString());
                comando.Parameters.AddWithValue("@Instancia", cbInstanciaExamen.SelectedItem.ToString());
                comando.Parameters.AddWithValue("@Nombre_profesor", cbProfesorExamen.SelectedItem.ToString());

                comando.ExecuteNonQuery();
                ConectarBDD.cerrar();

                MessageBox.Show("Exámen modificado");
                Cargar_tabla_Examenes();
            }
        }
        private void btnEliminarExamen_Click(object sender, EventArgs e)
        {
            int idExamen = int.Parse(dgvExamenes.CurrentRow.Cells["Id_examenes"].Value.ToString());

            ConectarBDD.abrir();
            string consulta = "sp_EliminarExamen";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id_examenes", idExamen);

            comando.ExecuteNonQuery();
            ConectarBDD.cerrar();

            MessageBox.Show("Examen eliminado");
            Cargar_tabla_Examenes();

        }

        //PESTAÑA GESTION ACADEMICA: PROFESORES

        public void Cargar_tabla_Empleado_Profesores()
        {
            ConectarBDD.abrir();
            // Solo seleccionamos los empleados con Id_perfil = 2, es decir, profesores
            string consulta = "SELECT * FROM Empleados WHERE Id_perfil = 2";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dgvProfesor.DataSource = dt;
            ConectarBDD.cerrar();
        }

        // Evento que oculta las contraseñas del datagridview
        private void dgvProfesor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }
        private bool Validar_datos_Profesores()
        {
            errorProviderDatosVacios.Clear();
            bool valido = true;

            if (txtNombreProfesor.Text == "")
            {
                errorProviderDatosVacios.SetError(txtNombreProfesor, "El nombre está vacío");
                valido = false;
            }
            if (txtApellidoProfesor.Text == "")
            {
                errorProviderDatosVacios.SetError(txtApellidoProfesor, "El apellido está vacío");
                valido = false;
            }
            if (txtDniProfesor.Text == "")
            {
                errorProviderDatosVacios.SetError(txtDniProfesor, "El DNI está vacío");
                valido = false;
            }
            if (txtDireccionProfesor.Text == "")
            {
                errorProviderDatosVacios.SetError(txtDireccionProfesor, "La Dirección está vacía");
                valido = false;
            }
            if (txtAlturaProfesor.Text == "")
            {
                errorProviderDatosVacios.SetError(txtAlturaProfesor, "La altura está vacía");
                valido = false;
            }
            if (txtEmailProfesor.Text == "")
            {
                errorProviderDatosVacios.SetError(txtEmailProfesor, "El email está vacío");
                valido = false;
            }
            if (dateTimePickerProfesor.Text == "")
            {
                errorProviderDatosVacios.SetError(dateTimePickerProfesor, "La fecha de nacimiento está vacáa");
                valido = false;
            }
            if (txtTelefonoProfesor.Text == "")
            {
                errorProviderDatosVacios.SetError(txtTelefonoProfesor, "El teléfono está vacío");
                valido = false;
            }
            if (txtUsuarioProfesor.Text == "")
            {
                errorProviderDatosVacios.SetError(txtUsuarioProfesor, "El usuario está vacío");
                valido = false;
            }
            if (txtContraseñaProfesor.Text == "")
            {
                errorProviderDatosVacios.SetError(txtContraseñaProfesor, "La contraseña está vacía");
                valido = false;
            }
            return valido;

        }

        int IdProfesor;
        private void dgvProfesor_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProfesor.Rows[e.RowIndex];
                IdProfesor = Convert.ToInt32(row.Cells["Id_empleado"].Value);
                txtNombreProfesor.Text = row.Cells["Nombre"].Value.ToString();
                txtApellidoProfesor.Text = row.Cells["Apellido"].Value.ToString();
                txtDniProfesor.Text = row.Cells["Dni"].Value.ToString();
                txtDireccionProfesor.Text = row.Cells["Direccion_calle"].Value.ToString();
                txtAlturaProfesor.Text = row.Cells["Direccion_num"].Value.ToString();
                txtEmailProfesor.Text = row.Cells["Email"].Value.ToString();
                txtTelefonoProfesor.Text = row.Cells["Telefono"].Value.ToString();
                dateTimePickerProfesor.Value = Convert.ToDateTime(row.Cells["F_nacimiento"].Value);
                txtUsuarioProfesor.Text = row.Cells["Usuario"].Value.ToString();
                txtContraseñaProfesor.Text = row.Cells["Contraseña"].Value.ToString();
            }
        }


        private void btnAgregarProfesor_Click(object sender, EventArgs e)
        {


            if (Validar_datos_Profesores())
            {
                ConectarBDD.abrir();
                string consulta = "sp_AgregarProfesor";
                SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Nombre", txtNombreProfesor.Text);
                comando.Parameters.AddWithValue("@Apellido", txtApellidoProfesor.Text);
                comando.Parameters.AddWithValue("@Dni", txtDniProfesor.Text);
                comando.Parameters.AddWithValue("@F_nacimiento", dateTimePickerProfesor.Value);
                comando.Parameters.AddWithValue("@Direccion_calle", txtDireccionProfesor.Text);
                comando.Parameters.AddWithValue("@Direccion_num", txtAlturaProfesor.Text);
                comando.Parameters.AddWithValue("@Email", txtEmailProfesor.Text);
                comando.Parameters.AddWithValue("@Telefono", txtTelefonoProfesor.Text);
                comando.Parameters.AddWithValue("@Usuario", txtUsuarioProfesor.Text);
                comando.Parameters.AddWithValue("@Contraseña", txtContraseñaProfesor.Text);

                comando.ExecuteNonQuery();

                ConectarBDD.cerrar();

                MessageBox.Show("Registro Agregado!");

                Cargar_tabla_Empleado_Profesores();

            }
        }

        private void btnModificarProfesor_Click(object sender, EventArgs e)
        {
            if (IdProfesor == 0)
            {
                MessageBox.Show("Seleccione un profesor de la lista");
                return;
            }
            if (!Validar_datos_Profesores())
            {
                return;
            }

            ConectarBDD.abrir();
            string consulta = "sp_Modificar_Profesor";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id_empleado", IdProfesor);
            comando.Parameters.AddWithValue("@Nombre", txtNombreProfesor.Text);
            comando.Parameters.AddWithValue("@Apellido", txtApellidoProfesor.Text);
            comando.Parameters.AddWithValue("@Dni", txtDniProfesor.Text);
            comando.Parameters.AddWithValue("@F_nacimiento", dateTimePickerProfesor.Value);
            comando.Parameters.AddWithValue("@Direccion_calle", txtDireccionProfesor.Text);
            comando.Parameters.AddWithValue("@Direccion_num", txtAlturaProfesor.Text);
            comando.Parameters.AddWithValue("@Email", txtEmailProfesor.Text);
            comando.Parameters.AddWithValue("@Telefono", txtTelefonoProfesor.Text);
            comando.Parameters.AddWithValue("@Usuario", txtUsuarioProfesor.Text);
            comando.Parameters.AddWithValue("@Contraseña", txtContraseñaProfesor.Text);

            comando.ExecuteNonQuery();

            ConectarBDD.cerrar();

            MessageBox.Show("Registro Modificado!");

            Cargar_tabla_Empleado_Profesores();


        }

        private void btnEliminarProfesor_Click(object sender, EventArgs e)
        {
            if (IdProfesor == 0)
            {
                MessageBox.Show("Seleccione un profesor de la lista");
                return;
            }

            ConectarBDD.abrir();
            string consulta = "sp_Eliminar_Profesor";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;


            comando.Parameters.AddWithValue("@Id_empleado", IdProfesor);

            comando.ExecuteNonQuery();

            ConectarBDD.cerrar();

            MessageBox.Show("Registro Eliminado!");

            Cargar_tabla_Empleado_Profesores();
        }

        private void btnBuscarProfesor_Click(object sender, EventArgs e)
        {
            // Intentar convertir el texto de búsqueda a un entero y asignarlo a la variable de clase IdProfesor
            if (!int.TryParse(txtBuscarProfesor.Text, out IdProfesor))
            {
                MessageBox.Show("Ingrese una matrícula válida");
                return;
            }

            ConectarBDD.abrir();

            string consulta = "SELECT * FROM empleados WHERE Id_empleado = @Id_empleado AND Id_perfil = 2";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.Parameters.AddWithValue("@Id_empleado", IdProfesor);

            // Llenar el DataGridView con los datos del profesor
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvProfesor.DataSource = dt;

            ConectarBDD.cerrar();

            // Verificar si se encontraron resultados
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ningún Profesor con ese ID.");
            }

        }

        //PESTAÑA GESTION ACADEMICA: ASIGNATURAS
        public void Cargar_tabla_Asignatura()
        {
            ConectarBDD.abrir();

            string consulta = "Select*from Asignatura";

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dgvAsignatura.DataSource = dt;
            ConectarBDD.cerrar();
        }
        private bool Validar_datos_Asignatura()
        {
            errorProviderDatosVacios.Clear();
            bool valido = true;

            if (txtNombreAsignatura.Text == "")
            {
                errorProviderDatosVacios.SetError(txtNombreAsignatura, "El nombre está vacío");
                valido = false;
            }
            if (txtAñoCursadaAsignatura.Text == "")
            {
                errorProviderDatosVacios.SetError(txtAñoCursadaAsignatura, "El Año está vacío");
                valido = false;
            }
            return valido;
        }
        int IdAsignatura;
        private void dgvAsignatura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAsignatura.Rows[e.RowIndex];
                IdAsignatura = Convert.ToInt32(row.Cells["Id_asignatura"].Value);
                txtNombreAsignatura.Text = row.Cells["Nombre"].Value.ToString();
                txtAñoCursadaAsignatura.Text = row.Cells["Año_cursada"].Value.ToString();
            }
        }
        private void btnAgregarAsignatura_Click(object sender, EventArgs e)
        {
            if (Validar_datos_Asignatura())
            {
                ConectarBDD.abrir();
                string consulta = "sp_AgregarAsignatura";
                SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Nombre", txtNombreAsignatura.Text);
                comando.Parameters.AddWithValue("@Año_cursada", Convert.ToInt32(txtAñoCursadaAsignatura.Text));

                comando.ExecuteNonQuery();

                ConectarBDD.cerrar();

                MessageBox.Show("Asignatura Agregada!");

                Cargar_tabla_Asignatura(); // Actualizar DataGridView con las asignaturas
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
            }

        }
        private void btnModificarAsignatura_Click(object sender, EventArgs e)
        {
            if (IdAsignatura == 0)
            {
                MessageBox.Show("Seleccione una asignatura de la lista");
                return;
            }
            if (!Validar_datos_Asignatura())
            {
                return;
            }

            ConectarBDD.abrir();
            string consulta = "sp_ModificarAsignatura";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id_asignatura", IdAsignatura);
            comando.Parameters.AddWithValue("@Nombre", txtNombreAsignatura.Text);
            comando.Parameters.AddWithValue("@Año_cursada", Convert.ToInt32(txtAñoCursadaAsignatura.Text));


            comando.ExecuteNonQuery();

            ConectarBDD.cerrar();

            MessageBox.Show("Registro Modificado!");

            Cargar_tabla_Asignatura();

        }
        private void btnEliminarAsignatura_Click(object sender, EventArgs e)
        {

            if (IdAsignatura == 0)
            {
                MessageBox.Show("Seleccione una asignatura de la lista");
                return;
            }

            ConectarBDD.abrir();
            string consulta = "sp_Eliminar_Asignatura";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;


            comando.Parameters.AddWithValue("@Id_asignatura", IdAsignatura);

            comando.ExecuteNonQuery();

            ConectarBDD.cerrar();

            MessageBox.Show("Registro Eliminado!");

            Cargar_tabla_Asignatura();

        }
        private void btnBuscarAsignatura_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBuscarAsignatura.Text, out IdAsignatura))
            {
                MessageBox.Show("Ingrese una matrícula válida");
                return;
            }

            ConectarBDD.abrir();

            string consulta = @"
            SELECT *  FROM Asignatura 
            WHERE Id_asignatura = @Id_asignatura";

            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.Parameters.AddWithValue("@Id_asignatura", IdAsignatura);

            // Llenar el DataGridView con los datos de la asignatura y su profesor
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvAsignatura.DataSource = dt;

            ConectarBDD.cerrar();

            // Verificar si se encontraron resultados
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ninguna asignatura con ese ID.");
            }
        }

        //CARGAS de todos los registros 

        private void btnCargarAlumnos_Click(object sender, EventArgs e)
        {
            Cargar_tabla_Alumno();
        }
        private void btnCargarProfesores_Click(object sender, EventArgs e)
        {
            Cargar_tabla_Empleado_Profesores();
        }
        private void btnCargarAdministrativos_Click(object sender, EventArgs e)
        {
            Cargar_tabla_Empleado_Administrativos();
        }
        private void btnCargarCarreras_Click(object sender, EventArgs e)
        {
            Cargar_tabla_Carreras();
        }
        private void btnCargarAsignaturas_Click(object sender, EventArgs e)
        {
            Cargar_tabla_Asignatura();
        }
        private void btnCargarExamenes_Click(object sender, EventArgs e)
        {
            Cargar_tabla_Examenes();
        }

        //LIMPIA LOS TEXTBOX
        private void btnLimpiartxtAdministrativos_Click(object sender, EventArgs e)
        {
            IdAdministrativo = 0;
            txtAlturaAdministrativo.Clear();
            txtApellidoAdministrativo.Clear();
            txtBuscarAdministrativo.Clear();
            txtContraseñaAdministrativo.Clear();
            txtDireccionCalleAdministrativo.Clear();
            txtDniAdministrativo.Clear();
            txtEmailAdministrativo.Clear();
            txtNombreAdministrativo.Clear();
            txtTelefonoAdministrativo.Clear();
            txtUsuarioAdministrativo.Clear();
        }

        private void btnLimpiartxtCarreras_Click(object sender, EventArgs e)
        {
            IdCarrera = 0;
            txtBuscarCarrera.Clear();
            txtNombreCarrera.Clear();
            txtPlanEstudioCarrera.Clear();
            txtResolucionCarrera.Clear();
        }

        private void btnLimpiartxtProfesor_Click(object sender, EventArgs e)
        {
            IdProfesor = 0;
            txtBuscarProfesor.Clear();
            txtNombreProfesor.Clear();
            txtApellidoProfesor.Clear();
            txtDniProfesor.Clear();
            txtDireccionProfesor.Clear();
            txtAlturaProfesor.Clear();
            txtEmailProfesor.Clear();
            txtTelefonoProfesor.Clear();
            txtUsuarioProfesor.Clear();
            txtContraseñaProfesor.Clear();
        }

        private void btnLimpiartxtAsignaturas_Click(object sender, EventArgs e)
        {
            IdAsignatura = 0;
            txtNombreAsignatura.Clear();
            txtAñoCursadaAsignatura.Clear();
        }

        private void btnLimpiartxtAlumnos_Click(object sender, EventArgs e)
        {
            IdProfesor = 0;
            txtBuscarAlumno.Clear();
            txtNombreAlumno.Clear();
            txtApellidoAlumno.Clear();
            txtDNIAlumno.Clear();
            dateTimeAlumno.Value = DateTime.Now; // Para poner la fecha actual
            txtDireccionAlumno.Clear();
            txtAlturaAlumno.Clear();
            txtEmailAlumno.Clear();
            txtTelAlumno.Clear();
            txtUsuarioAlumno.Clear();
            txtContraseñaAlumno.Clear();
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPerfil perfilForm = new FrmPerfil(PerfilUsuario);
            perfilForm.ShowDialog();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Close();
        }

    }
}









       