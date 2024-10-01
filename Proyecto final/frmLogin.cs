using Microsoft.Win32;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto_final
{
    public partial class frmLogin : Form
    {
        clsConexion ConectarBDD = new clsConexion();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmAlumno frmalumno = new frmAlumno();
            frmProfesor frmprofesor = new frmProfesor();
            frmAdministrativo frmadministrativo = new frmAdministrativo();
            frmAdmin frmadmin = new frmAdmin();

            string dato = ConectarBDD.consultarPerfil(txtUsuario.Text, txtContraseña.Text);

            ConectarBDD.cerrar();

            if (dato != "")
            {
                switch (dato)
                {
                    case "Alumno":
                        DialogResult abrirAlumno = frmalumno.ShowDialog();
                        break;
                    case "Profesor":

                        DialogResult abrirProfesor = frmprofesor.ShowDialog();
                        break;
                    case "Personal Administrativo":
                        DialogResult abrirPersonalAdministrativo = frmadministrativo.ShowDialog();
                        break;
                    case "Administrador":
                        DialogResult abrirAdministrador = frmadmin.ShowDialog();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Usuario y contraseña incorrecto");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }
    }
}
