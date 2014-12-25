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

        private void button3_Click(object sender, EventArgs e)
        {
            if (authorizationProcessor.IsUserAuthenticated(textBox2.Text))
            {
                authorizationProcessor.SaveCDKeyFile(textBox2.Text);
                MessageBox.Show("Ключ успешно применен и был сохранен в каталоге программы.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Введенный вами ключ неверен! Проверьте правильность ввода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
