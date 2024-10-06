using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    internal class clsConexion
    {
        //string cadena = "Data Source = LEOTOLUSSO\\SQLEXPRESS; Initial Catalog = tpFinalAnalistas2; Integrated Security = true";
        //string cadena = "Data Source = 192.168.0.100; Database =u13; User Id =u13; Password =u13";
        string cadena = "server = EVEE\\SQLEXPRESS; database = Conexionn; integrated security = true";
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
            string consulta = $@"
                             SELECT P.Tipo_perfil 
                             FROM Perfiles P 
                             JOIN Alumnos A ON P.Id_perfil = A.Id_perfil 
                             WHERE A.Usuario = '{usuario}' AND A.Contrasenia = '{contraseña}'
                             UNION
                             SELECT P.Tipo_perfil 
                             FROM Perfiles P 
                             JOIN Empleados E ON P.Id_perfil = E.Id_perfil 
                             WHERE E.Usuario = '{usuario}' AND E.Contrasenia = '{contraseña}';";

            SqlCommand comando = new SqlCommand(consulta, conectarbdd);
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
