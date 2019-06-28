using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaADO;
using System.Data;

namespace BibliotecaBL
{
    public class EditorialBL
    {
        EditorialADO objEditorialADO = new EditorialADO();

        public DataTable ListarEditorial()
        {
            return objEditorialADO.ListarEditorial();
        }
    }
}
