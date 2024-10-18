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
            // Consultamos el perfil del usuario en la BDD usando el m�todo "consultarPerfil"
            // Se le pasa el usuario y la contrase�a que el usuario ingres�
            string perfil = ConectarBDD.consultarPerfil(txtUsuario.Text, txtContrase�a.Text);
            ConectarBDD.cerrar();

            if (perfil != "")
            {   
                
                frmDashboard.PerfilUsuario = perfil;  // Asignamos el perfil del usuario a la propiedad "PerfilUsuario" del frmDashboard
                
                frmDashboard.Show();//Mostramos el formulario Dashboard
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario y contrase�a incorrecto");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContrase�a.Text = "";
        }
        private void btnXCruz_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
