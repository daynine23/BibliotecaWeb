using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaADO;
using System.Data;

namespace BibliotecaBL
{
    public class DistritoBL
    {
        DistritoADO objDistritoADO = new DistritoADO();

        public DataTable ListarDistrito()
        {
            return objDistritoADO.ListarDistrito();
        }
    }
}
