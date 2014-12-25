using System;
using System.Windows.Forms;

namespace CGC
{
    public partial class AuthorizationForm : Form
    {
        private AuthorizationProcessor authorizationProcessor;

        public AuthorizationForm()
        {
            InitializeComponent();
            authorizationProcessor = new AuthorizationProcessor();
            textBox1.Text = authorizationProcessor.MachineIdHash;
        }

        private void AuthorizationForm_Shown(object sender, EventArgs e)
        {
            CenterScreenForm(this);
            
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
