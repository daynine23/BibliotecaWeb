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
    public partial class Libros01 : Form
    {
        LibroBL objLibroBL = new LibroBL();
        public Libros01()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            dtgLibro.DataSource = objLibroBL.ListarLibro();
        }

        private void Libros01_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Libro02 Lib02 = new Libro02();
            Lib02.ShowDialog();
            CargarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Libro03 Lib03 = new Libro03();
            String strcod;
            strcod = dtgLibro.CurrentRow.Cells[0].Value.ToString();

            Lib03.Codigo = strcod;
            Lib03.ShowDialog();
            CargarDatos();

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Libro04 Lib04 = new Libro04();
            Lib04.ShowDialog();
            CargarDatos();
            
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult vrpta;
                vrpta = MessageBox.Show("Esta seguro de eliminar el registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (vrpta == DialogResult.Yes)
                {
                    String strcod;
                    strcod = dtgLibro.CurrentRow.Cells[0].Value.ToString();

                    if (objLibroBL.EliminarLibro(strcod) == true)
                    {
                        CargarDatos();
                    }
                    else
                    {
                        throw new Exception("No se puso eliminar el registro");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
