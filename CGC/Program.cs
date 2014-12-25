using System;
using System.Windows.Forms;
using KeyVerification;

namespace CGC
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (new AuthorizationProcessor().IsUserAuthenticated())
            {
                Application.Run(new MainForm());
            }
            else
            {
                Application.Run(new AuthorizationForm());
            }
        }
    }
}
