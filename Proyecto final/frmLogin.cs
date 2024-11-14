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

            int idPerfil = ConectarBDD.consultarPerfil(txtUsuario.Text, txtContraseña.Text);
            ConectarBDD.cerrar();

            if (idPerfil > 0) // Si el IdPerfil es mayor que 0, el usuario existe
            {
                FrmDashboard frmDashboard = new FrmDashboard(idPerfil, txtUsuario.Text); // Pasa el IdPerfil y el nombre de usuario al dashboard 
                frmDashboard.Show();
                this.Close();
                MessageBox.Show($"{idPerfil}");
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

        int m, mx, my;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X; 
            my = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}
