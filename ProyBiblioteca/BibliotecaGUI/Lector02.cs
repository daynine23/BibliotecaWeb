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
    public partial class Lector02 : Form
    {
        LectorBE objLectorBE = new LectorBE();
        LectorBL objLectorBL = new LectorBL();
        DistritoBL objDistritoBL = new DistritoBL();
        public Lector02()
        {
            InitializeComponent();
        }

        private void Lector02_Load(object sender, EventArgs e)
        {
            try
            {
                //LLENAMOS EL COMBO BOX de Distrito
                cboDistrito.DataSource = objDistritoBL.ListarDistrito();
                cboDistrito.DisplayMember = "Nombre_Distrito";
                cboDistrito.ValueMember = "IdDistrito";

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

                objLectorBE.Nom_Lector = txtNombre.Text.Trim();
                objLectorBE.ApePat_Lector = txtApePat.Text.Trim();
                objLectorBE.ApeMat_Lector = txtApeMat.Text.Trim();
                objLectorBE.Dni = txtDni.Text.Trim();
                objLectorBE.Dir = txtDir.Text.Trim();
                objLectorBE.Tel = txtTel.Text.Trim();
                objLectorBE.Email_Lector = txtEmail.Text.Trim();
                objLectorBE.Id_Distrito = cboDistrito.SelectedValue.ToString();

                if (objLectorBL.InsertarLector(objLectorBE) == true)
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("No se inserto el registro. Verifique.");
                }

            }
            catch (Exception ex)

            {

                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten digitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten digitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }
    }
}
