using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaBE;
using BibliotecaBL;

public partial class Mantenimientos_Lector_Man : System.Web.UI.Page
{
    LectorBE objBE = new LectorBE();
    LectorBL objBL = new LectorBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            try
            {
                Enlazar();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }
    }

    private void Enlazar()
    {
        grvLectores.DataSource = objBL.ListarLector();
        grvLectores.DataBind();

    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        //LIMPIAR LOS CONTROLES
        txtNombres.Text = String.Empty;
        txtApePaterno.Text = String.Empty;
        txtApeMaterno.Text = String.Empty;
        txtDni.Text = String.Empty;
        txtDireccion.Text = String.Empty;
        txtTelefono.Text = String.Empty;
        txtEmail.Text = String.Empty;
        txtDistrito.Text = String.Empty;

        lblMensaje2.Text = String.Empty;
        lblID.Visible = false;
        lblId2.Visible = false;
        hdfAccion.Value = "A";
        PopMant.Show();
    }

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNombres.Text == String.Empty)
            {
                throw new Exception("El nombre es obligatorio");
            }

            //CARGO MI ENTIDAD DE NEGOCIOS
            objBE.Nom_Lector = txtNombres.Text.Trim();
            objBE.ApePat_Lector = txtApePaterno.Text.Trim();
            objBE.ApeMat_Lector = txtApeMaterno.Text.Trim();
            objBE.Dni = txtDni.Text.Trim();
            objBE.Dir = txtDireccion.Text.Trim();
            objBE.Tel = txtTelefono.Text.Trim();
            objBE.Email_Lector = txtEmail.Text.Trim();
            objBE.Id_Distrito = txtDistrito.Text.Trim();



            if (hdfAccion.Value == "A")
            {
                if (objBL.InsertarLector(objBE) == true)
                {
                    Enlazar();
                }
                else
                {

                    throw new Exception("Error al insertar, revisar.");
                }
            }

            if (hdfAccion.Value == "M")
            {
                objBE.Id_Lector = lblID.Text;

                if (objBL.ActualizarLector(objBE) == true)
                {
                    Enlazar();
                }
                else
                {

                    throw new Exception("Error al Actualizar, revisar.");
                }
            }
        }
        catch (Exception ex)
        {
            lblMensaje2.Text = ex.Message;
            PopMant.Show();
        }
    }

    protected void grvLectores_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int fila = Convert.ToInt16(e.CommandArgument);//Manejo la fila en la que hizo click

            if (e.CommandName == "Editar")
            {
                String vcod = grvLectores.Rows[fila].Cells[1].Text;

                objBE = objBL.ConsultarLector(vcod);

                lblID.Text = objBE.Id_Lector;
                txtNombres.Text = objBE.Nom_Lector;
                txtApePaterno.Text = objBE.ApePat_Lector;
                txtApeMaterno.Text = objBE.ApeMat_Lector;
                txtDni.Text = objBE.Dni;
                txtDireccion.Text = objBE.Dir;
                txtTelefono.Text = objBE.Tel;
                txtEmail.Text = objBE.Email_Lector;
                txtDistrito.Text = objBE.Id_Distrito;


                lblMensaje2.Text = String.Empty;
                lblId2.Visible = true;
                lblID.Visible = true;
                hdfAccion.Value = "M";
                PopMant.Show();
            }

        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;

        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            if (objBL.EliminarLector(lblID.Text) == true)
            {
                Enlazar();

            }
            else
            {
                throw new Exception("No se pudo eliminar el registro porque esta asociado a otra tabla");
            }
        }
        catch (Exception ex)
        {
            lblMensaje2.Text = ex.Message;
            PopMant.Show();
        }
    }
}