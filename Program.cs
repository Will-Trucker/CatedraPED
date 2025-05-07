using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CatedraPED
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Conexion conexion = new Conexion();

            conexion.Abrir();

            // Opcional: Verifica si está conectado
            if (conexion.EstaConectado())
            {
                Console.WriteLine("Verificación: La conexión está activa.");
                conexion.testQuery();
            }

            conexion.Cerrar();

        }
    }
}
