using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packing
{
    public partial class Packing : Form
    {
        string UpcCode;
        string Corte;
        string Estilo;
        string Bulto;
        string Secuencia;

        public Packing()
        {
            InitializeComponent();
        }

        private void Packing_Load(object sender, EventArgs e)
        {
            txtUpcTag.Focus();
        }

        private void Packing_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!txtUpcTag.Focused)
            {
                txtUpcTag.Focus();
                txtUpcTag.Text += e.KeyChar;
                txtUpcTag.SelectionStart = txtUpcTag.Text.Length;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUpcTag_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtUpcTag_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                UpcCode = txtUpcTag.Text;
                Corte = UpcCode.Substring(0, 7);
                Bulto = UpcCode.Substring(7, 3);
                Secuencia = UpcCode.Substring(10, 3);

                txtCorte.Text = Corte;
                txtBulto.Text = Bulto;
                txtSecuencia.Text = Secuencia;
            }
        }
    }
}
