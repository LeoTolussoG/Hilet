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
    public partial class FrmPerfil : Form
    {
        clsConexion ConectarBDD = new clsConexion();
        public string PerfilUsuario { get; set; }
        public FrmPerfil(string perfil)
        {
            InitializeComponent();
            PerfilUsuario = perfil;
        }
        private void FrmPerfil_Load(object sender, EventArgs e)
        {
            txtUsuarioPerfil.Text = PerfilUsuario;
        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Validar que las contraseñas coincidan
            if (txtNuevaContraseña.Text != txtRepiteContraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            ConectarBDD.abrir();
            string consulta = "sp_ActualizarContraseña";
            SqlCommand comando = new SqlCommand(consulta, ConectarBDD.conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Usuario", txtUsuarioPerfil.Text);
            comando.Parameters.AddWithValue("@NuevaContraseña", txtNuevaContraseña.Text);

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Contraseña actualizada");
                this.Close(); // Cierra el formulario al terminar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message);
            }
        }

        private void btnSalirPerfil_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
