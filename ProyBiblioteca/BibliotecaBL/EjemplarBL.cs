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
    public class EjemplarBL
    {
        EjemplarADO objEjemplarADO = new EjemplarADO();

        public Boolean InsertarEjemplar(EjemplarBE objEjemplarBE)
        {
            return objEjemplarADO.InsertarEjemplar(objEjemplarBE);
        }

        public Boolean ActualizarEjemplar(EjemplarBE objEjemplarBE)
        {
            return objEjemplarADO.ActualizarEjemplar(objEjemplarBE);
        }

        public DataTable ListarEjemplar()
        {
            return objEjemplarADO.ListarEjemplar();
        }

        public EjemplarBE ConsultarEjemplar(String strcod)
        {
            return objEjemplarADO.ConsultarEjemplar(strcod);
        }
    }
}
