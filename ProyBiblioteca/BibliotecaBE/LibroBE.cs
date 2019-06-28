using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBE
{
    public class LibroBE
    {
        private String mvarId_Libro;
        public String Id_Libro
        {
            get { return mvarId_Libro; }
            set { mvarId_Libro = value; }
        }
        private String mvartit_Libro;
        public String Tit_Libro
        {
            get { return mvartit_Libro; }
            set { mvartit_Libro = value; }
        }
        private String mvarId_Autor;
        public String Id_Autor
        {
            get { return mvarId_Autor; }
            set { mvarId_Autor = value; }
        }

        private String mvarId_Categoria;
        public String Id_Categoria
        {
            get { return mvarId_Categoria; }
            set { mvarId_Categoria = value; }
        }

        private String mvarId_Editorial;
        public String Id_Editorial
        {
            get { return mvarId_Editorial; }
            set { mvarId_Editorial = value; }
        }

        private String mvarId_Idioma;
        public String Id_Idioma
        {
            get { return mvarId_Idioma; }
            set { mvarId_Idioma = value; }
        }

        private String mvarAño_Lanz;
        public String Año_Lanz
        {
            get { return mvarAño_Lanz; }
            set { mvarAño_Lanz = value; }
        }
    }
}
