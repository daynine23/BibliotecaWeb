using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaADO;
using System.Data;


namespace BibliotecaBL
{
    public class AutorBL
    {
        AutorADO objAutorADO = new AutorADO();

        public DataTable ListarAutor()
        {
            return objAutorADO.ListarAutor();
        }
    }
}
