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
    public partial class Lector01 : Form
    {
        LectorBL objLectorBL = new LectorBL();

        public Lector01()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            dtgLector.DataSource = objLectorBL.ListarLector();
        }




        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Lector02 Lec02 = new Lector02();
            Lec02.ShowDialog();
            CargarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Lector03 Lec03 = new Lector03();
            String strcod;
            strcod = dtgLector.CurrentRow.Cells[0].Value.ToString();

            Lec03.Codigo = strcod;
            Lec03.ShowDialog();
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
                    strcod = dtgLector.CurrentRow.Cells[0].Value.ToString();

                    if (objLectorBL.EliminarLector(strcod) == true)
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

        private void Lector01_Load_1(object sender, EventArgs e)
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
    }
}
