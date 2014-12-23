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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void CenterScreenForm(About mf)
        {
            mf.Left = (Screen.PrimaryScreen.Bounds.Width - mf.Width) / 2;
            mf.Top = (Screen.PrimaryScreen.Bounds.Height - mf.Height) / 2;
        }

        private void About_Shown(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Версия программы: " + Application.ProductVersion + 'b';
            CenterScreenForm(this); 
        }

        private void About_Load(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Версия программы: " + Application.ProductVersion + 'b';
            CenterScreenForm(this); 
        }
    }
}