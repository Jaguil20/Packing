using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packing
{
    public partial class Packing : Form
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
        public string constring = "";
        public Packing()
        {
            InitializeComponent();
        }
        public static string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException
                   ("The string which needs to be decrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }

        private void conexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Constring tform = new Constring();
            tform.Parent = Parent;
            if (tform.ShowDialog() == DialogResult.OK)
            {
                string tstrr = Properties.Settings.Default.constr;
                if (tstrr.Length > 0)
                {

                    constring = Decrypt(tstrr);
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { this.Close(); }
        }
    }
}
