using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaADO;
using BibliotecaBE;
using System.Data;

namespace BibliotecaBL
{
    public class LectorBL
    {
        LectorADO objLectorADO = new LectorADO();

        public Boolean InsertarLector(LectorBE objLectorBE)
        {
            return objLectorADO.InsertarLector(objLectorBE);
        }

        public Boolean ActualizarLector(LectorBE objLectorBE)
        {
            return objLectorADO.ActualizarLector(objLectorBE);
        }

        public Boolean EliminarLector(String strcod)
        {
            return objLectorADO.EliminarLector(strcod);
        }

        public LectorBE ConsultarLector(String strcod)
        {
            return objLectorADO.ConsultarLector(strcod);
        }


        public DataTable ListarLector()
        {
            return objLectorADO.ListarLector();
        }
    }
}
