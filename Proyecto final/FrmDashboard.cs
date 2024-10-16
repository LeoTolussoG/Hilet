﻿using System;
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

        public FrmDashboard() //constructor del formulario
        {
            InitializeComponent();
        }
        private void FrmDashboard_Load(object sender, EventArgs e) //evento que se activa cuando se abre el formulario
        {
            CargarDashboard();
            Cargar_tabla_Empleado_Profesores();
            Cargar_tabla_Empleado_Administrativos();
            Cargar_tabla_Alumno();
            Cargar_tabla_Examenes();
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
        private void btnModificarAlumno_Click(object sender, EventArgs e)
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
        private void btnEliminarAlumno_Click(object sender, EventArgs e)
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

        private void dataGridViewProfesor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreProfesor.Text = dgvProfesor.SelectedCells[1].Value.ToString();
            txtApellidoProfesor.Text = dgvProfesor.SelectedCells[2].Value.ToString();
            txtDniProfesor.Text = dgvProfesor.SelectedCells[3].Value.ToString();
            txtFechanacimientoProfesor.Text = dgvProfesor.SelectedCells[4].Value.ToString();
            txtDireccionProfesor.Text = dgvProfesor.SelectedCells[5].Value.ToString();
            txtAlturaProfesor.Text = dgvProfesor.SelectedCells[6].Value.ToString();
            txtEmailProfesor.Text = dgvProfesor.SelectedCells[7].Value.ToString();
            txtTelefonoProfesor.Text = dgvProfesor.SelectedCells[8].Value.ToString();
            txtUsuarioProfesor.Text = dgvProfesor.SelectedCells[9].Value.ToString();
            txtContraseñaProfesor.Text = dgvProfesor.SelectedCells[10].Value.ToString();
        }

        /*private void btnAgregarProfesor_Click(object sender, EventArgs e)
        {
            ConectarBDD.abrir();
            string consulta = " sp_AgregarProfesor";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nombre", txtNombreProfesor.Text);
            comando.Parameters.AddWithValue("@Apellido", txtApellidoProfesor.Text);
            comando.Parameters.AddWithValue("@Dni", txtDniProfesor.Text);
            comando.Parameters.AddWithValue("@F_nacimiento", txtFechanacimientoProfesor.Text);
            comando.Parameters.AddWithValue("@Direccion_calle", txtDireccionProfesor.Text);
            comando.Parameters.AddWithValue("@Direccion_num", txtAlturaProfesor.Text);
            comando.Parameters.AddWithValue("@Email", txtEmailProfesor.Text);
            comando.Parameters.AddWithValue("@Telefono", txtTelefonoProfesor.Text);
            comando.Parameters.AddWithValue("@Usuario", txtUsuarioProfesor.Text);
            comando.Parameters.AddWithValue("@Contraseña", txtContraseñaProfesor.Text);

            MessageBox.Show("Registro Agregado!");

            Cargar_tabla_Empleado_Profesores();


        }
        */
        /*private void btnModificarProfesor_Click(object sender, EventArgs e)
        {
            ConectarBDD.abrir();
            string consulta = "sp_ModificarProfesor";

            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id_empleado", Convert.ToInt32(txtIDProfesor.Text));
            comando.Parameters.AddWithValue("@Nombre", txtNombreProfesor.Text);
            comando.Parameters.AddWithValue("@Apellido", txtApellidoProfesor.Text);
            comando.Parameters.AddWithValue("@Dni", txtDniProfesor.Text);
            comando.Parameters.AddWithValue("@F_nacimiento", txtFechanacimientoProfesor.Text);
            comando.Parameters.AddWithValue("@Direccion_calle", txtDireccionProfesor.Text);
            comando.Parameters.AddWithValue("@Direccion_num", txtAlturaProfesor.Text);
            comando.Parameters.AddWithValue("@Email", txtEmailProfesor.Text);
            comando.Parameters.AddWithValue("@Telefono", txtTelefonoProfesor.Text);
            comando.Parameters.AddWithValue("@Usuario", txtUsuarioProfesor.Text);
            comando.Parameters.AddWithValue("@Contraseña", txtContraseñaProfesor.Text);

            MessageBox.Show("Registro Actualizado!");

            Cargar_tabla_Empleado_Profesores();

        }
*/
        /*private void btnEliminarProfesor_Click(object sender, EventArgs e)
        {
            ConectarBDD.abrir();
            string consulta = "sp_EliminarProfesor";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ID", Convert.ToInt32(txtIDProfesor.Text));

            comando.ExecuteNonQuery();
            MessageBox.Show("Registro Eliminado!");

            Cargar_tabla_Empleado_Profesores();

        }

*/
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

        private void dgvProfesor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreProfesor.Text = dgvProfesor.SelectedCells[1].Value.ToString();
            txtApellidoProfesor.Text = dgvProfesor.SelectedCells[2].Value.ToString();
            txtDniProfesor.Text = dgvProfesor.SelectedCells[3].Value.ToString();
            txtFechanacimientoProfesor.Text = dgvProfesor.SelectedCells[4].Value.ToString();
            txtDireccionProfesor.Text = dgvProfesor.SelectedCells[5].Value.ToString();
            txtAlturaProfesor.Text = dgvProfesor.SelectedCells[6].Value.ToString();
            txtEmailProfesor.Text = dgvProfesor.SelectedCells[7].Value.ToString();
            txtTelefonoProfesor.Text = dgvProfesor.SelectedCells[8].Value.ToString();
            txtUsuarioProfesor.Text = dgvProfesor.SelectedCells[9].Value.ToString();
            txtContraseñaProfesor.Text = dgvProfesor.SelectedCells[10].Value.ToString();
        }

        private void btnAgregarProfesor_Click(object sender, EventArgs e)
        {
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

            DateTime fechaNacimiento;
            if (DateTime.TryParse(txtFechanacimientoProfesor.Text, out fechaNacimiento))
            {
                comando.Parameters.AddWithValue("@F_nacimiento", fechaNacimiento);
            }

            comando.ExecuteNonQuery();
            ConectarBDD.cerrar();
            MessageBox.Show("Registro Agregado!");

            Cargar_tabla_Empleado_Profesores();
        }

        private void btnModificarProfesor_Click(object sender, EventArgs e)
        {

            ConectarBDD.abrir();

            try
            {
                // Obtener el ID del profesor desde el DataGridView
                int idProfesor = Convert.ToInt32(dgvProfesor.CurrentRow.Cells["Id_empleado"].Value);

                // Validar y convertir la altura
                if (!int.TryParse(txtAlturaProfesor.Text, out int direccionNum))
                {
                    MessageBox.Show("La altura debe ser un número válido.");
                    return;
                }

                // Validar y convertir la fecha de nacimiento
                if (!DateTime.TryParse(txtFechanacimientoProfesor.Text, out DateTime fechaNacimiento))
                {
                    MessageBox.Show("La fecha de nacimiento debe ser válida.");
                    return;
                }

                // Crear el comando SQL
                SqlCommand comando = new SqlCommand("sp_ModificarProfesor", ConectarBDD.conectarbdd)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Agregar parámetros (quitamos el @Id_perfil)
                comando.Parameters.AddWithValue("@Id_empleado", idProfesor);
                comando.Parameters.AddWithValue("@Nombre", txtNombreProfesor.Text);
                comando.Parameters.AddWithValue("@Apellido", txtApellidoProfesor.Text);
                comando.Parameters.AddWithValue("@Dni", txtDniProfesor.Text);
                comando.Parameters.AddWithValue("@Direccion_calle", txtDireccionProfesor.Text);
                comando.Parameters.AddWithValue("@Direccion_num", direccionNum);
                comando.Parameters.AddWithValue("@Email", txtEmailProfesor.Text);
                comando.Parameters.AddWithValue("@Telefono", txtTelefonoProfesor.Text);
                comando.Parameters.AddWithValue("@F_nacimiento", fechaNacimiento);
                comando.Parameters.AddWithValue("@Usuario", txtUsuarioProfesor.Text);
                comando.Parameters.AddWithValue("@Contraseña", txtContraseñaProfesor.Text);

                // Ejecutar la modificación
                comando.ExecuteNonQuery();

                MessageBox.Show("Profesor modificado exitosamente.");
                Cargar_tabla_Empleado_Profesores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el profesor: " + ex.Message);
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
                if (!int.TryParse(txtIDProfesor.Text, out int idProfesor))
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

        private void dgvProfesor_Click(object sender, EventArgs e)
        {
            txtNombreProfesor.Text = dgvProfesor.SelectedCells[1].Value.ToString();
            txtApellidoProfesor.Text = dgvProfesor.SelectedCells[2].Value.ToString();
            txtDniProfesor.Text = dgvProfesor.SelectedCells[3].Value.ToString();
            txtFechanacimientoProfesor.Text = dgvProfesor.SelectedCells[4].Value.ToString();
            txtDireccionProfesor.Text = dgvProfesor.SelectedCells[5].Value.ToString();
            txtAlturaProfesor.Text = dgvProfesor.SelectedCells[6].Value.ToString();
            txtEmailProfesor.Text = dgvProfesor.SelectedCells[7].Value.ToString();
            txtTelefonoProfesor.Text = dgvProfesor.SelectedCells[8].Value.ToString();
            txtUsuarioProfesor.Text = dgvProfesor.SelectedCells[9].Value.ToString();
            txtContraseñaProfesor.Text = dgvProfesor.SelectedCells[10].Value.ToString();
        }

    }
}









       