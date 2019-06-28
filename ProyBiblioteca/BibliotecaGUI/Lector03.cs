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
    public partial class Lector03 : Form
    {
        LectorBE objLectorBE = new LectorBE();
        LectorBL objLectorBL = new LectorBL();
        DistritoBL objDistritoBL = new DistritoBL();

        public Lector03()
        {
            InitializeComponent();
        }

        private String mvarcodigo;

        public String Codigo
        {
            get { return mvarcodigo; }
            set { mvarcodigo = value; }
        }

        private void Lector03_Load(object sender, EventArgs e)
        {
            try
            {
                //LLENAMOS EL COMBO BOX de Distrito
                cboDistrito.DataSource = objDistritoBL.ListarDistrito();
                cboDistrito.DisplayMember = "Nombre_Distrito";
                cboDistrito.ValueMember = "IdDistrito";

                objLectorBE = objLectorBL.ConsultarLector(this.Codigo);

                // MOSTRAMOS LOS DATOS DEL LECTOR A ACTUALIZAR
                txtNombre.Text = objLectorBE.Nom_Lector;
                txtApePat.Text = objLectorBE.ApePat_Lector;
                txtApeMat.Text = objLectorBE.ApeMat_Lector;
                txtDni.Text = objLectorBE.Dni;
                txtDir.Text = objLectorBE.Dir;
                txtTel.Text = objLectorBE.Tel;
                txtEmail.Text = objLectorBE.Email_Lector;
                cboDistrito.SelectedValue = objLectorBE.Id_Distrito;

                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            // CARGO MI ENTIDAD DE NEGOCIOS
            try
            { 
            objLectorBE.Id_Distrito = this.Codigo;
            objLectorBE.Nom_Lector = txtNombre.Text.Trim();
            objLectorBE.ApePat_Lector = txtApePat.Text.Trim();
            objLectorBE.ApeMat_Lector = txtApeMat.Text.Trim();
            objLectorBE.Dni = txtDni.Text.Trim();
            objLectorBE.Dir = txtDir.Text.Trim();
            objLectorBE.Tel = txtTel.Text.Trim();
            objLectorBE.Email_Lector = txtEmail.Text.Trim();
            objLectorBE.Id_Distrito = cboDistrito.SelectedValue.ToString();


            if (objLectorBL.ActualizarLector(objLectorBE) == true)
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

