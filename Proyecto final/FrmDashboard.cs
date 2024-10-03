using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class FrmDashboard : Form
    {
        public string PerfilUsuario { get; set; }// la propiedad va a recibir el perfil desde el login
        public FrmDashboard() //constructor del formulario
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e) //evento que se activa cuando se abre el formulario
        { }
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
