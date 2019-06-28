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
    public partial class Ejemplar01 : Form
    {
        EjemplarBL objEjemplarBL = new EjemplarBL();
        public Ejemplar01()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            dtgEjemplar.DataSource = objEjemplarBL.ListarEjemplar();
        }

        private void Ejemplar01_Load(object sender, EventArgs e)
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Ejemplar03 ejem03 = new Ejemplar03();
            String strcod;
            strcod = dtgEjemplar.CurrentRow.Cells[0].Value.ToString();

            ejem03.Codigo = strcod;
            ejem03.ShowDialog();
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Ejemplar02 Ejem02 = new Ejemplar02();
            Ejem02.ShowDialog();
            CargarDatos();
        }
    }
}
