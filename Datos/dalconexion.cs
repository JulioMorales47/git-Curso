using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dalconexion
    {
        public static string obtenerconexion()
        {
            // conexion
            String conexion = @"Data Source = INGENIERO\SQLEXPRESS;Initial Catalog=CRUD;Integrated Security=True";
            return conexion;
        }
    }
}
