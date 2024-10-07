using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    internal class clsConexion
    {
        string cadena = "Data Source = LEOTOLUSSO\\SQLEXPRESS; Initial Catalog = TPFinal; Integrated Security = true";
        //string cadena = "Data Source = 192.168.0.100; Database =u13; User Id =u13; Password =u13";
        //string cadena = "server = EVEE\\SQLEXPRESS; database = Conexionn; integrated security = true";
        public SqlConnection conectarbdd = new SqlConnection();
        public clsConexion()
        {
            conectarbdd.ConnectionString = cadena;
        }
        public void abrir() //metodo abrir
        {
            try
            {
                conectarbdd.Open();
                Console.WriteLine("Conexion abierta");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar con la base de datos" + ex.Message);
            }
        }
        public void cerrar()
        {
            conectarbdd.Close();
        }
        public string consultarPerfil(string usuario, string contraseña)
        {
            conectarbdd.Open();
            //Busca en alumnos y luego en empleados:
            string consulta = "sp_Acceso_Login";

            SqlCommand comando = new SqlCommand(consulta, conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Contraseña", contraseña);

            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                return registro["Tipo_perfil"].ToString(); //Devuelve el perfil encontrado
            }
            else
            {
                return ""; //No se encontró ningún perfil
            }
        }
    }
}
