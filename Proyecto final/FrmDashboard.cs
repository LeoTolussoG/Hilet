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
            CargarDashboard();
        }

        private void FrmDashboard_Load(object sender, EventArgs e) //evento que se activa cuando se abre el formulario
        {
            Cargar_tabla_Empleado_Profesores();
        }

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


        public void Cargar_tabla_Empleado_Profesores()
        {
            ConectarBDD.abrir();
            string consulta = "select * from Empleados";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, ConectarBDD.conectarbdd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dataGridViewProfesor.DataSource = dt;
        }







        private void tbpInicio_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewProfesor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreProfesor.Text = dataGridViewProfesor.SelectedCells[1].Value.ToString();
            txtApellidoProfesor.Text = dataGridViewProfesor.SelectedCells[2].Value.ToString();
            txtDniProfesor.Text = dataGridViewProfesor.SelectedCells[3].Value.ToString();
            txtFechanacimientoProfesor.Text = dataGridViewProfesor.SelectedCells[4].Value.ToString();
            txtDireccionProfesor.Text = dataGridViewProfesor.SelectedCells[5].Value.ToString();
            txtAlturaProfesor.Text = dataGridViewProfesor.SelectedCells[6].Value.ToString();
            txtEmailProfesor.Text = dataGridViewProfesor.SelectedCells[7].Value.ToString();
            txtTelefonoProfesor.Text = dataGridViewProfesor.SelectedCells[8].Value.ToString();
            txtUsuarioProfesor.Text = dataGridViewProfesor.SelectedCells[9].Value.ToString();
            txtContraseñaProfesor.Text = dataGridViewProfesor.SelectedCells[10].Value.ToString();

        }

        private void btnAgregarProfesor_Click(object sender, EventArgs e)
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

        private void btnModificarProfesor_Click(object sender, EventArgs e)
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

        private void btnEliminarProfesor_Click(object sender, EventArgs e)
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











        /*ConfInterfazXperfil(); 
}
private void ConfInterfazXperfil()//Metodo que configura la interfaz segun el perfil (deshabilitando o habilitando botones) que haya ingresado
{
if (PerfilUsuario == "Alumno")
{
btnAdmin.Enabled = false; // Por ejemplo, los alumnos no pueden ver el botón Admin
btnProfesor.Enabled = false;
// Otros botones según necesites
}
else if (RolUsuario == "Profesor")
{
btnAdmin.Enabled = false;
btnAlumno.Enabled = false; // Los profesores no ven lo de alumnos
}
else if (RolUsuario == "Personal Administrativo")
{
btnAdmin.Enabled = false;
btnAlumno.Enabled = false;
btnProfesor.Enabled = false;
}
else if (RolUsuario == "Administrador")
{
// El administrador puede ver todo, así que no deshabilitamos nada
}
}*/
    }
}
