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
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            // Consultamos el perfil del usuario en la BDD usando el método "consultarPerfil"
            // Se le pasa el usuario y la contraseña que el usuario ingresó
            string perfil = ConectarBDD.consultarPerfil(txtUsuario.Text, txtContraseña.Text);
            ConectarBDD.cerrar();

            if (perfil != "")
            {   
                
                frmDashboard.PerfilUsuario = perfil;  // Asignamos el perfil del usuario a la propiedad "PerfilUsuario" del frmDashboard
                
                frmDashboard.Show();//Mostramos el formulario Dashboard
                this.Close();
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
        private void btnXCruz_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
