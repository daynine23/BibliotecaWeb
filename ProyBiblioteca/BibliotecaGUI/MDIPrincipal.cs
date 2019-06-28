using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaGUI
{
    public partial class MDIPrincipal : Form
    {
        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Libros01 lib01 = new Libros01();
            lib01.MdiParent = this;
            lib01.Show();
        }

        private void lectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lector01 lec01 = new Lector01();
            lec01.MdiParent = this;
            lec01.Show();
        }

        private void ejemplarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ejemplar01 ejem01 = new Ejemplar01();
            ejem01.MdiParent = this;
            ejem01.Show();
        }
    }
}
