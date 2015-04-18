using System;
using System.Text;
using System.Windows.Forms;

namespace bpk_keygen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string p = textBox1.Text;
            Algo cracker = new Algo(p);
            string ser = cracker.showSerial();

            if (!cracker.IsSerial) {
                label1.Text = ser;
                label1.Visible = true;
                textBox1.Focus();
                return;
            }

            StringBuilder sbOut = new StringBuilder();

            for (int i = 0; i < ser.Length; i++) {
                sbOut.Append(ser[i]);
                if ((i % 4 == 3) && i > 0 && i < ser.Length - 1)
                    sbOut.Append("-");
            }

            label1.Text = sbOut.ToString();
            label1.Visible = true;
            textBox1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.KeyPress += new KeyPressEventHandler(CheckTextBoxKeys);
        }

        private void CheckTextBoxKeys(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)0x0D)
            {
                e.Handled = true;
                button1_Click(null, null);
            }
            if (e.KeyChar == (char)0x1B) Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label1.Text = null;
            textBox1.Text = null;
            textBox1.Focus();
        }
    }
}