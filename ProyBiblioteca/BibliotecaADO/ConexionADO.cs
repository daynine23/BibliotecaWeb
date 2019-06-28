using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BibliotecaADO
{
    class ConexionADO
    {
        public string GetCnx() //manager se va hasta el appconfig y busca el nombre de la cadena de conexion
        {
            string strCnx = 
                ConfigurationManager.ConnectionStrings["Biblioteca2"].ConnectionString;/*ir y buscar la cadena de conexion*/
            if (object.ReferenceEquals(strCnx, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strCnx;
            }
        }

    }
}
