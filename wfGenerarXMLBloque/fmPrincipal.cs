using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfGenerarXMLBloque
{
    public partial class fmPrincipal : Form
    {
        fmIndividual findividual = new fmIndividual();
        fmBloque fbloque = new fmBloque();
         public fmPrincipal()
        {
            InitializeComponent();
        }

        private void obtenerXMLPorBloqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fbloque.MdiParent = this;
            fbloque.Show();
        }

        private void obtenerXMLIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findividual.MdiParent = this;
            findividual.Show();
        }
    }
}
