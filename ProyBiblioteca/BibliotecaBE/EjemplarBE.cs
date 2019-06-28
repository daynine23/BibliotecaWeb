using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBE
{
    public class EjemplarBE
    {
        private String mvarId_Ejemplar;
        public String Id_Ejemplar
        {
            get { return mvarId_Ejemplar; }
            set { mvarId_Ejemplar = value; }
        }
        private String mvartitulo;
        public String Titulo
        {
            get { return mvartitulo; }
            set { mvartitulo= value; }
        }
        private String mvarEstado;
        public String Estado
        {
            get { return mvarEstado; }
            set { mvarEstado = value; }
        }
    }
}
