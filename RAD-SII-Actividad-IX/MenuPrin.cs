using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAD_SII_Actividad_IX
{
    public partial class MenuPrin : Form
    {
        public MenuPrin()
        {
            InitializeComponent();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VPaciente categoria = new VPaciente();
            categoria.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VMedico categoria = new VMedico();
            categoria.Show();
        }

        private void gruposDeDescuentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VCita categoria = new VCita();
            categoria.Show();
        }
    }
}
