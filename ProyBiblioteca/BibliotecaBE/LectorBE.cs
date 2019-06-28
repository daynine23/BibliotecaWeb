using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBE
{
    public class LectorBE
    {
        private String mvarId_Lector;
        public String Id_Lector
        {
            get { return mvarId_Lector; }
            set { mvarId_Lector = value; }
        }
        private String mvarnom_Lector;
        public String Nom_Lector
        {
            get { return mvarnom_Lector; }
            set { mvarnom_Lector = value; }
        }
        private String mvarapePat_Lector;
        public String ApePat_Lector
        {
            get { return mvarapePat_Lector; }
            set { mvarapePat_Lector = value; }
        }

        private String mvarapeMat_Lector;
        public String ApeMat_Lector
        {
            get { return mvarapeMat_Lector; }
            set { mvarapeMat_Lector = value; }
        }


        private String mvardni;
        public String Dni
        {
            get { return mvardni; }
            set { mvardni = value; }
        }

        private String mvardir;
        public String Dir
        {
            get { return mvardir; }
            set { mvardir = value; }
        }

        private String mvartel;
        public String Tel
        {
            get { return mvartel; }
            set { mvartel = value; }
        }

        private String mvarEmail_Lector;
        public String Email_Lector
        {
            get { return mvarEmail_Lector; }
            set { mvarEmail_Lector= value; }
        }

        private String mvarId_Distrito;
        public String Id_Distrito
        {
            get { return mvarId_Distrito; }
            set { mvarId_Distrito = value; }
        }
    }
}
