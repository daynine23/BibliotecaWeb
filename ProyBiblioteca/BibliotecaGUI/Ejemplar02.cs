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
    public partial class Ejemplar02 : Form
    {
        EjemplarBE objEjemplarBE = new EjemplarBE();
        EjemplarBL objEjemplarBL = new EjemplarBL();
        LibroBL objLibroBL = new LibroBL();
        public Ejemplar02()
        {
            InitializeComponent();
        }

        private String mvarcodigo;

        public String Codigo
        {
            get { return mvarcodigo; }
            set { mvarcodigo = value; }
        }

        private void Ejemplar02_Load(object sender, EventArgs e)
        {
            try
            {
                //LLENAMOS EL COMBO BOX de titulo
                cboTitulo.DataSource = objLibroBL.ListarLibro();
                cboTitulo.DisplayMember = "Titulo";
                cboTitulo.ValueMember = "IdLibro";

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
                objEjemplarBE.Titulo = this.Codigo;
                objEjemplarBE.Estado = txtEstado.Text.Trim();
                objEjemplarBE.Titulo = cboTitulo.SelectedValue.ToString();


                if (objEjemplarBL.ActualizarEjemplar(objEjemplarBE) == true)
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("No se actualizo el regsitro. Verifique.");
                }
            }
            catch (Exception ex)

            {

                MessageBox.Show("Error : " + ex.Message);
            }
        }
    }
}
