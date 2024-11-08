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
        //string cadena = "Data Source = LEOTOLUSSO\\SQLEXPRESS; Initial Catalog = TPFinal; Integrated Security = true";
        //string cadena = "Data Source = 192.168.0.100; Database =u26; User Id =u26; Password =u26";
        string cadena = "server = EVEE\\SQLEXPRESS; database = TPFinal; integrated security = true";
       /// <summary>
       /// string cadena = "Data Source = CAMI\\SQLEXPRESS; Database = TPFinal; Integrated Security = True;";
       /// </summary>
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
        public int consultarPerfil(string usuario, string contraseña)
        {
            conectarbdd.Open();
            int idPerfil = -1; //valor por si no encuentra ningun perfil

            //Busca en alumnos y luego en empleados:
            string consulta = "sp_Acceso_Login";

            SqlCommand comando = new SqlCommand(consulta, conectarbdd);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Contraseña", contraseña);

            SqlDataReader registro = comando.ExecuteReader();

            if (registro.Read())
            {
                idPerfil = Convert.ToInt32(registro["Id_perfil"]); //Devuelve el perfil encontrado
            }
            registro.Close();
            conectarbdd.Close();
            return idPerfil; // retorna el id del perfil o -1 si no lo encontró
        }
    }
}
