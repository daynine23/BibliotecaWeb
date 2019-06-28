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
    public class LibroBL
    {
        LibroADO objLibroADO = new LibroADO();

        public Boolean InsertarLibro(LibroBE objLibroBE)
        {
            return objLibroADO.InsertarLibro(objLibroBE);
        }
        
        public Boolean ActualizarLibro(LibroBE objLibroBE)
        {
            return objLibroADO.ActualizarLibro(objLibroBE);
        }
        
        public Boolean EliminarLibro(String strcod)
        {
            return objLibroADO.EliminarLibro(strcod);
        }
        
        public LibroBE ConsultarLibro(String strcod)
        {
            return objLibroADO.ConsultarLibro(strcod);
        }
        
        public DataTable ListarLibro()
        {
            return objLibroADO.ListarLibro();
        }
    }
}
