using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public FrmDashboard(int idPerfil) //constructor del formulario
        {
            InitializeComponent();
            IdPerfilUsuario = idPerfil;//recibe el id del perfil del usuario
        }
        private void FrmDashboard_Load(object sender, EventArgs e) //evento que se activa cuando se abre el formulario
        {
            CargarDashboard();
            Cargar_tabla_Empleado_Profesores();
            Cargar_tabla_Empleado_Administrativos();
            Cargar_tabla_Alumno();
            Cargar_tabla_Examenes();
            Cargar_tabla_Asignatura();
            CargarPermisos(IdPerfilUsuario);
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
            if (!permisos.Contains("Gestionar Alumnos"))
            {
                btnAgregarAlumno.Enabled = false;
                btnModificarAlumno.Enabled = false;
                btnEliminarAlumno.Enabled = false;
            }
            if (!permisos.Contains("Gestionar Asignaturas"))
            {
                btnAgregarAsignatura.Enabled = false;
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
        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) //Me fijo que haya un reglon seleccionado
            {
                DataGridViewRow row = dgvAlumnos.Rows[e.RowIndex];//asigno los valores a los textbox
                txtIDAlumno.Text = row.Cells["Id_alumno"].Value.ToString();
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
                comando.Parameters.AddWithValue("@Id_perfil", 1);
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


                comando.Parameters.AddWithValue("@Id_alumno", Convert.ToInt32(txtIDAlumno.Text));
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

                comando.Parameters.AddWithValue("@Id_alumno", Convert.ToInt32(txtIDAlumno.Text));
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

        //PESTAÑA GESTION ACADEMICA: ADMINISTRATIVOS
        public void Cargar_tabla_Empleado_Administrativos()         //Carga de registros el datagridview de Administrativos
        {
            ConectarBDD.abrir();
            string consulta = "sp_Cargar_Tabla_Administrativos";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dgvAdministrativos.DataSource = dt;
            ConectarBDD.cerrar();
        }

        private bool Validar_Datos_Administrativo()             //Verifico que los campos cumplan con los requisitos
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

        private void dgvAdministrativos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreAdministrativo.Text = dgvAdministrativos.SelectedCells[1].Value.ToString();
            txtApellidoAdministrativo.Text = dgvAdministrativos.SelectedCells[2].Value.ToString();
            txtDniAdministrativo.Text = dgvAdministrativos.SelectedCells[3].Value.ToString();
            txtDireccionCalleAdministrativo.Text = dgvAdministrativos.SelectedCells[4].Value.ToString();
            txtAlturaAdministrativo.Text = dgvAdministrativos.SelectedCells[5].Value.ToString();
            txtEmailAdministrativo.Text = dgvAdministrativos.SelectedCells[6].Value.ToString();
            dtpFechaNacimientoAdministrativo.Text = dgvAdministrativos.SelectedCells[8].Value.ToString();
            txtTelefonoAdministrativo.Text = dgvAdministrativos.SelectedCells[7].Value.ToString();
            txtUsuarioAdministrativo.Text = dgvAdministrativos.SelectedCells[9].Value.ToString();
            txtContraseñaAdministrativo.Text = dgvAdministrativos.SelectedCells[10].Value.ToString();
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
            if (!Validar_Datos_Administrativo())
            {
                MessageBox.Show("Seleccione un empleado de la lista");
            }
            else
            {
                ConectarBDD.abrir();
                string consulta = "sp_Modificar_Administrativo";
                SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id_empleado", dgvAdministrativos.SelectedCells[0].Value.ToString());
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

        }
        private void btnEliminarAdministrativo_Click(object sender, EventArgs e)
        {
            ConectarBDD.abrir();
            string consulta = "sp_Eliminar_Administrativo";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id_empleado", dgvAdministrativos.SelectedCells[0].Value.ToString());

            comando.ExecuteNonQuery();

            ConectarBDD.cerrar();

            MessageBox.Show("Registro Eliminado!");

            Cargar_tabla_Empleado_Administrativos();
        }



        //PESTAÑA GESTION ACADEMICA: EXAMENES
        public void Cargar_tabla_Examenes()
        {
            ConectarBDD.abrir();
            string consulta = "SELECT E.Id_examenes, E.Nota, E.Fecha, " +
                                      "A.Nombre AS Alumno, " +
                                      "asg.Nombre AS Asignatura, " +
                                      "I.Descripcion AS Instancia, " +
                                      "emp.Nombre AS Profesor " +
                              "FROM Examenes E " +
                              "LEFT JOIN Alumnos A ON E.Id_alumno = A.Id_alumno " +
                              "LEFT JOIN Asignatura asg ON E.Id_asignatura = asg.Id_asignatura " +
                              "LEFT JOIN Instancias I ON E.Id_instancia = I.Id_instancia " +
                              "LEFT JOIN Empleados emp ON E.Id_empleado = emp.Id_empleado";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dgvExamenes.DataSource = dt;
            ConectarBDD.cerrar();
        }
        private void dgvExamenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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

        private void dgvProfesor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProfesor.Rows[e.RowIndex];
                txtIDprofesor.Text = row.Cells["Id_empleado"].Value.ToString();
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

        private bool ValidarIdProfesor(int idEmpleado)
        {
            // Abrir conexión y realizar la consulta de verificación
            ConectarBDD.abrir();
            string consulta = "SELECT 1 FROM Empleados WHERE Id_empleado = @Id_empleado AND Id_perfil <> 2";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.Parameters.AddWithValue("@Id_empleado", idEmpleado);

            // Si la consulta devuelve algún resultado, el ID está en uso por otro perfil
            bool idValido = comando.ExecuteScalar() == null;

            ConectarBDD.cerrar();
            return idValido;
        }

        private void btnAgregarProfesor_Click(object sender, EventArgs e)
        {

            if (!Validar_datos_Profesores())
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }
            // Convertir el ID del profesor ingresado en el TextBox
            if (!int.TryParse(txtIDprofesor.Text, out int idEmpleado))
            {
                MessageBox.Show("Por favor, ingrese un ID válido.");
                return;
            }

            // Validar que el ID no esté en uso por otro perfil
            if (!ValidarIdProfesor(idEmpleado))
            {
                MessageBox.Show("El ID ingresado ya está en uso por otro perfil. Intente con otro ID.");
                return;
            }

            // Abrir la conexión y realizar la inserción
            ConectarBDD.abrir();
            string consulta = "sp_AgregarProfesor";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nombre", txtNombreProfesor.Text);
            comando.Parameters.AddWithValue("@Apellido", txtApellidoProfesor.Text);
            comando.Parameters.AddWithValue("@Dni", txtDniProfesor.Text);
            comando.Parameters.AddWithValue("@Direccion_calle", txtDireccionProfesor.Text);
            comando.Parameters.AddWithValue("@Direccion_num", txtAlturaProfesor.Text);
            comando.Parameters.AddWithValue("@Email", txtEmailProfesor.Text);
            comando.Parameters.AddWithValue("@Telefono", txtTelefonoProfesor.Text);
            comando.Parameters.AddWithValue("@Usuario", txtUsuarioProfesor.Text);
            comando.Parameters.AddWithValue("@Contraseña", txtContraseñaProfesor.Text);

            // Validar y agregar la fecha de nacimiento
            if (DateTime.TryParse(dateTimePickerProfesor.Text, out DateTime fechaNacimiento))
            {
                comando.Parameters.AddWithValue("@F_nacimiento", fechaNacimiento);
            }

            // Ejecutar la consulta
            comando.ExecuteNonQuery();
            ConectarBDD.cerrar();

            MessageBox.Show("Registro Agregado!");

            // Recargar la tabla de profesores
            Cargar_tabla_Empleado_Profesores();

        }

        private void btnModificarProfesor_Click(object sender, EventArgs e)
        {
            ConectarBDD.abrir();

            try
            {
                int idProfesor = Convert.ToInt32(dgvProfesor.CurrentRow.Cells["Id_empleado"].Value);
                int.TryParse(txtDireccionProfesor.Text, out int direccionNum);

                SqlCommand comando = new SqlCommand("sp_ModificarProfesor", ConectarBDD.conectarbdd)
                {
                    CommandType = CommandType.StoredProcedure
                };

                comando.Parameters.AddWithValue("@Id_empleado", idProfesor);
                comando.Parameters.AddWithValue("@Nombre", txtNombreProfesor.Text);
                comando.Parameters.AddWithValue("@Apellido", txtApellidoProfesor.Text);
                comando.Parameters.AddWithValue("@Dni", txtDniProfesor.Text);
                comando.Parameters.AddWithValue("@Direccion_calle", txtDireccionProfesor.Text);
                comando.Parameters.AddWithValue("@Direccion_num", direccionNum);
                comando.Parameters.AddWithValue("@Email", txtEmailProfesor.Text);
                comando.Parameters.AddWithValue("@Telefono", txtTelefonoProfesor.Text);
                comando.Parameters.AddWithValue("@F_nacimiento", dateTimePickerProfesor.Value);
                comando.Parameters.AddWithValue("@Usuario", txtUsuarioProfesor.Text);
                comando.Parameters.AddWithValue("@Contraseña", txtContraseñaProfesor.Text);

                comando.ExecuteNonQuery();
                MessageBox.Show("Profesor modificado exitosamente.");
                Cargar_tabla_Empleado_Profesores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                ConectarBDD.cerrar();
            }
        }

        private void btnEliminarProfesor_Click(object sender, EventArgs e)
        {
            try
            {
                ConectarBDD.abrir();
                string consulta = "sp_EliminarProfesor";
                SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
                comando.CommandType = CommandType.StoredProcedure;

                // Asegurarse de que el ID sea un número válido
                if (!int.TryParse(txtIDprofesor.Text, out int idProfesor))
                {
                    MessageBox.Show("Por favor, ingrese un ID de profesor válido.");
                    return;
                }

                // Agregar el parámetro correcto
                comando.Parameters.AddWithValue("@Id_empleado", idProfesor);

                // Ejecutar el comando
                comando.ExecuteNonQuery();
                MessageBox.Show("Profesor eliminado exitosamente!");

                // Recargar la tabla
                Cargar_tabla_Empleado_Profesores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el profesor: " + ex.Message);
            }
            finally
            {
                ConectarBDD.cerrar();
            }
        }

        private void btnBuscarProfesor_Click(object sender, EventArgs e)
        {
            int IDProfesor;
            if (!int.TryParse(txtBuscarProfesor.Text, out IDProfesor))
            {
                MessageBox.Show("Ingrese una matrícula válida");
                return;
            }

            // Abrir la conexión a la base de datos
            ConectarBDD.abrir();

            // Consulta para obtener el profesor de la tabla empleados cuyo perfil es 2
            string consulta = "SELECT * FROM empleados WHERE Id_empleado = @Id_empleado AND Id_perfil = 2";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.Parameters.AddWithValue("@Id_empleado", IDProfesor);

            // Llenar el DataGridView con los datos del profesor
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvProfesor.DataSource = dt;

            // Cerrar la conexión a la base de datos
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

            string consulta = "select * from Asignatura";
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
                errorProviderDatosVacios.SetError(txtAñoCursadaAsignatura, "El apellido está vacío");
                valido = false;
            }
            return valido;
        }

        private void dgvAsignatura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAsignatura.Rows[e.RowIndex];
                txtIDasignatura.Text = row.Cells["Id_asignatura"].Value.ToString();
                txtNombreAsignatura.Text = row.Cells["Nombre"].Value.ToString();
                txtAñoCursadaAsignatura.Text = row.Cells["Año_cursada"].Value.ToString();
            }
        }

        private void btnAgregarAsignatura_Click(object sender, EventArgs e)
        {
            if (!Validar_datos_Asignatura())
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            // Convertir el ID del profesor ingresado en el TextBox
            if (!int.TryParse(txtIDprofesor.Text, out int idEmpleadoProfesor))
            {
                MessageBox.Show("Por favor, ingrese un ID de empleado válido.");
                return;
            }

            // Abrir la conexión y realizar la inserción
            ConectarBDD.abrir();
            string consulta = "sp_AgregarAsignatura";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            // Agregar parámetros para el procedimiento
            comando.Parameters.AddWithValue("@Nombre", txtNombreAsignatura.Text);
            comando.Parameters.AddWithValue("@Año_cursada", Convert.ToInt32(txtAñoCursadaAsignatura.Text));
            comando.Parameters.AddWithValue("@Id_empleado", idEmpleadoProfesor);

            try
            {
                // Ejecutar la consulta
                comando.ExecuteNonQuery();
                MessageBox.Show("Asignatura Agregada!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al agregar asignatura: {ex.Message}");
            }
            finally
            {
                ConectarBDD.cerrar();
            }

            // Recargar la tabla de asignaturas
            Cargar_tabla_Asignatura();
        }

        private void btnModificarAsignatura_Click(object sender, EventArgs e)
        {
            ConectarBDD.abrir();

            try
            {
                // Obtener el ID de la asignatura seleccionada en el DataGridView
                int idAsignatura = Convert.ToInt32(dgvAsignatura.CurrentRow.Cells["Id_asignatura"].Value);

                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand comando = new SqlCommand("sp_ModificarAsignatura", ConectarBDD.conectarbdd)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Agregar los parámetros necesarios
                comando.Parameters.AddWithValue("@Id_asignatura", idAsignatura);
                comando.Parameters.AddWithValue("@Nombre", txtNombreAsignatura.Text);
                comando.Parameters.AddWithValue("@Año_cursada", Convert.ToInt32(txtAñoCursadaAsignatura.Text)); // Asegúrate de tener un TextBox para el año

                // Ejecutar la consulta
                comando.ExecuteNonQuery();
                MessageBox.Show("Asignatura modificada exitosamente.");

                // Recargar la tabla de asignaturas
                Cargar_tabla_Asignatura();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                ConectarBDD.cerrar();
            }
        }

        private void btnEliminarAsignatura_Click(object sender, EventArgs e)
        {
            ConectarBDD.abrir();

            try
            {
                // Obtener el ID de la asignatura seleccionada en el DataGridView
                int idAsignatura = Convert.ToInt32(dgvAsignatura.CurrentRow.Cells["Id_asignatura"].Value);

                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand comando = new SqlCommand("sp_EliminarAsignatura", ConectarBDD.conectarbdd)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Agregar el parámetro necesario
                comando.Parameters.AddWithValue("@Id_asignatura", idAsignatura);

                // Ejecutar la consulta
                comando.ExecuteNonQuery();
                MessageBox.Show("Asignatura eliminada exitosamente.");

                // Recargar la tabla de asignaturas
                Cargar_tabla_Asignatura();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                ConectarBDD.cerrar();
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

        }

        private void btnCargarAsignaturas_Click(object sender, EventArgs e)
        {
            Cargar_tabla_Asignatura();
        }

        private void btnCargarExamenes_Click(object sender, EventArgs e)
        {
            Cargar_tabla_Examenes();
        }

        private void btnBuscarAsignatura_Click(object sender, EventArgs e)
        {
            int IDAsignatura;
            if (!int.TryParse(txtBuscarAsignatura.Text, out IDAsignatura))
            {
                MessageBox.Show("Ingrese un ID de asignatura válido");
                return;
            }

            // Abrir la conexión a la base de datos
            ConectarBDD.abrir();

            // Consulta para obtener la asignatura asociada con su profesor en la tabla empleados
            string consulta = @"
            SELECT *  FROM Asignatura 
            WHERE Id_asignatura = @Id_asignatura";

            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.Parameters.AddWithValue("@Id_asignatura", IDAsignatura);

            // Llenar el DataGridView con los datos de la asignatura y su profesor
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvAsignatura.DataSource = dt;

            // Cerrar la conexión a la base de datos
            ConectarBDD.cerrar();

            // Verificar si se encontraron resultados
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ninguna asignatura con ese ID.");
            }
        }
    }
}









       