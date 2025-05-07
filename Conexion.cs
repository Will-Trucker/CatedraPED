using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Libreria de SQL
using System.Data.SqlClient; 

namespace CatedraPED
{
    internal class Conexion
    {
        private SqlConnection connection;

        // Constructor que inicializa la conexión
        public Conexion()
        {
            string server = "SW"; // Reemplaza con la dirección de tu servidor
            string database = "catedra_ped"; // Nombre de tu base de datos
            string user = "root"; // Tu nombre de usuario
            string password = "123456"; // Tu contraseña

            // Cadena de conexión
            string connectionString = $"Server={server};Database={database};User Id={user};Password={password};";

            connection = new SqlConnection(connectionString);
        }

        // Método para abrir la conexión
        public void Abrir()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexión exitosa a la base de datos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
            }
        }

        // Método para cerrar la conexión
        public void Cerrar()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Conexión cerrada.");
            }
        }

        // Método para verificar si la conexión está abierta (opcional)
        public bool EstaConectado()
        {
            return connection.State == System.Data.ConnectionState.Open;
        }

        // (Opcional) Exponer la conexión para consultas
        public SqlConnection ObtenerConexion()
        {
            return connection;
        }

        public void testQuery()
        {
            try
            {
                string query = "SELECT GETDATE()";
                SqlCommand sqlCommand = new SqlCommand(query,connection);
                object result = sqlCommand.ExecuteScalar();
                Console.WriteLine("Consulta respondio a la fecha: " + result.ToString());


            }
            catch (Exception e)
            {
                Console.WriteLine("Error al ejecutar la consulta " + e.Message);
            }
        }
    }
}
