using System;
using System.Windows.Forms;
using KeyVerification;


namespace CGC
{
    public partial class MainForm : Form
    {
        private AuthorizationProcessor authorizationProcessor;

        public MainForm()
        {
            InitializeComponent();
            authorizationProcessor = new AuthorizationProcessor();
        }

        private void AuthorizationForm_Shown(object sender, EventArgs e)
        {
            CenterScreenForm(this);
        }

        private void CenterScreenForm(MainForm mf)
        {
            mf.Left = (Screen.PrimaryScreen.Bounds.Width - mf.Width) / 2;
            mf.Top = (Screen.PrimaryScreen.Bounds.Height - mf.Height) / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != String.Empty)
            {
                Clipboard.SetText(textBox2.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = Clipboard.GetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = authorizationProcessor.GenerateCDKey(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = textBox1.Text.Length == 32;
        }
    }
}
