using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaBE;
using BibliotecaBL;

namespace BibliotecaGUI
{
    public partial class Libro04 : Form
    {
        LibroBE objLibroBE = new LibroBE();
        LibroBL objLibroBL = new LibroBL();
        AutorBL objAutorBL = new AutorBL();
        CategoriaBL objCategoriaBL = new CategoriaBL();
        EditorialBL objEditorialBL = new EditorialBL();
        IdiomaBL objIdiomaBL = new IdiomaBL();
        public Libro04()
        {
            InitializeComponent();
        }

        private String mvarcodigo;

        public String Codigo
        {
            get { return mvarcodigo; }
            set { mvarcodigo = value; }
        }
        private void txtLib_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                
                    objLibroBE = objLibroBL.ConsultarLibro(txtLib.Text);
                    // MOSTRAMOS LOS DATOS DEL LIBRO

                    lblTit.Text = objLibroBE.Tit_Libro;
                    lblAut.Text = objLibroBE.Id_Autor;
                    lblCat.Text = objLibroBE.Id_Categoria;
                    lblEdit.Text = objLibroBE.Id_Editorial;
                    lblIdi.Text = objLibroBE.Id_Idioma;
                    lblAño.Text = objLibroBE.Año_Lanz;

                /*if  (objLibroBL.ConsultarLibro(txtLib.Text) == true)
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("El Libro no existe .");
                }

            }
            catch (Exception ex)

            {

                MessageBox.Show("Error : " + ex.Message);
            }*/

            }
        }
    }
}
