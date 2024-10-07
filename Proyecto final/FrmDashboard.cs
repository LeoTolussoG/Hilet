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
        { }

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
