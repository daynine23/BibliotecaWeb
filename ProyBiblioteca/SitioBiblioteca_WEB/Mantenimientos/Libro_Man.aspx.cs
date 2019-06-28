using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaBE;
using BibliotecaBL;

public partial class Mantenimientos_Libro_Man : System.Web.UI.Page
{
    LibroBE objBE = new LibroBE();
    LibroBL objBL = new LibroBL();
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
        grvLibros.DataSource = objBL.ListarLibro();
        grvLibros.DataBind();
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
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
            if (txtTitulo.Text == String.Empty)
            {
                throw new Exception("El nombre es obligatorio");
            }

            //CARGO MI ENTIDAD DE NEGOCIOS
            objBE.Tit_Libro = txtTitulo.Text.Trim();
            objBE.Id_Autor = txtAutor.Text.Trim();
            objBE.Id_Categoria = txtCategoria.Text.Trim();
            objBE.Id_Editorial = txtEditorial.Text.Trim();
            objBE.Id_Idioma = txtIdioma.Text.Trim();
            objBE.Año_Lanz = txtAño.Text.Trim();



            if (hdfAccion.Value == "A")
            {
                if (objBL.InsertarLibro(objBE) == true)
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
                objBE.Id_Libro = lblID.Text;

                if (objBL.ActualizarLibro(objBE) == true)
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

    protected void grvLibros_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int fila = Convert.ToInt16(e.CommandArgument);//Manejo la fila en la que hizo click

            if (e.CommandName == "Editar")
            {
                String vcod = grvLibros.Rows[fila].Cells[1].Text;

                objBE = objBL.ConsultarLibro(vcod);

                lblID.Text = objBE.Id_Libro;
                txtTitulo.Text = objBE.Tit_Libro;
                txtAutor.Text = objBE.Id_Autor;
                txtCategoria.Text = objBE.Id_Categoria;
                txtEditorial.Text = objBE.Id_Editorial;
                txtIdioma.Text = objBE.Id_Idioma;
                txtAño.Text = objBE.Año_Lanz;

                
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
            if (objBL.EliminarLibro(lblID.Text) == true)
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