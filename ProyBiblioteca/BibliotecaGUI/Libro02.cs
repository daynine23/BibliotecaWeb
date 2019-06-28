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
    public partial class Libro02 : Form
    {
        LibroBE objLibroBE = new LibroBE();
        LibroBL objLibroBL = new LibroBL();
        AutorBL objAutorBL = new AutorBL();
        CategoriaBL objCategoriaBL = new CategoriaBL();
        EditorialBL objEditorialBL = new EditorialBL();
        IdiomaBL objIdiomaBL = new IdiomaBL();
        public Libro02()
        {
            InitializeComponent();
        }

        private void Libro02_Load(object sender, EventArgs e)
        {
            try
            {
                //LLENAMOS EL COMBO BOX de Autor
                cboAutor.DataSource = objAutorBL.ListarAutor();
                cboAutor.DisplayMember = "NomApe_Autor";
                cboAutor.ValueMember = "IdAutor";

                //LLENAMOS EL COMBO BOX de Categoria
                cboCategoria.DataSource = objCategoriaBL.ListarCategoria();
                cboCategoria.DisplayMember = "Nombre_Categoria";
                cboCategoria.ValueMember = "IdCategoria";

                //LLENAMOS EL COMBO BOX de Editorial
                cboEditorial.DataSource = objEditorialBL.ListarEditorial();
                cboEditorial.DisplayMember = "Nombre_Editorial";
                cboEditorial.ValueMember = "IdEditorial";

                //LLENAMOS EL COMBO BOX de Idioma
                cboIdioma.DataSource = objIdiomaBL.ListarIdioma();
                cboIdioma.DisplayMember = "Nombre_Idioma";
                cboIdioma.ValueMember = "IdIdioma";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                // CARGO MI ENTIDAD DE NEGOCIOS
                
                objLibroBE.Id_Autor = cboAutor.SelectedValue.ToString();
                objLibroBE.Id_Categoria = cboCategoria.SelectedValue.ToString();
                objLibroBE.Id_Editorial = cboEditorial.SelectedValue.ToString();
                objLibroBE.Id_Idioma = cboIdioma.SelectedValue.ToString();
                objLibroBE.Tit_Libro = txtTitulo.Text.Trim();
                objLibroBE.Año_Lanz = txtAño.Text.Trim();

                if (objLibroBL.InsertarLibro(objLibroBE) == true)
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("No se inserto el regsitro. Verifique.");
                }

            }
            catch (Exception ex)

            {

                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAño_Validating(object sender, CancelEventArgs e)
        {
            if (txtAño.Text.Trim().Length < 4 & txtAño.Text.Trim().Length != 0)
            {
                //Se Cancela el ingreso
                e.Cancel = true;
                MessageBox.Show("El año consta de 4 digitos", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAño.SelectAll();
            }
            else
            {

                if (txtAño.Text.Trim() == String.Empty)
                {
                    e.Cancel = true;
                    MessageBox.Show("Campo es Obligatorio");
                    

                }
            }
        }

        private void txtTitulo_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtTitulo = (TextBox)sender;
            if (txtTitulo.Text.Trim() == String.Empty)
            {
                e.Cancel = true;
                MessageBox.Show("Nota es obligatoria");
                
            }
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }
    }
}
