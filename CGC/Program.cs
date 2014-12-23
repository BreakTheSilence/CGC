using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
