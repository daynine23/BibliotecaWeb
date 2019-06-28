using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaADO;
using System.Data;

namespace BibliotecaBL
{
    public class IdiomaBL
    {
        IdiomaADO objIdiomaADO = new IdiomaADO();

        public DataTable ListarIdioma()
        {
            return objIdiomaADO.ListarIdioma();
        }
    }
}
