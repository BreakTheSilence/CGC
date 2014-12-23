using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CGC
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void AuthorizationForm_Shown(object sender, EventArgs e)
        {
            CenterScreenForm(this);
            var authorizationProcessor = new AuthorizationProcessor();
            textBox1.Text = authorizationProcessor.MachineIdHash;
        }

        private void CenterScreenForm(AuthorizationForm mf)
        {
            mf.Left = (Screen.PrimaryScreen.Bounds.Width - mf.Width) / 2;
            mf.Top = (Screen.PrimaryScreen.Bounds.Height - mf.Height) / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Clipboard.GetText();
        }
    }
}
