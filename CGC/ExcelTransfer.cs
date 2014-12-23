using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CGC
{


    public partial class ExcelTransfer : Form
    {
        private int fmWidth;
        private int fmHeight;
        private System.Drawing.Point fmLocation;
        private ExcelData excelData;

        public ExcelTransfer(int height, int width, System.Drawing.Point location)
        {
            InitializeComponent();
            fmHeight = height;
            fmWidth = width;
            fmLocation = location;
        }

        private void ExcelTransfer_Shown(object sender, EventArgs e)
        {
            this.Height = fmHeight;
            this.Width = fmWidth;
            this.Location = fmLocation;
            SetDataGridDefaults(dataGridView1);
            button1.Visible = false;
            trackBar1.Value = 10;
            this.AllowTransparency = true;
            excelData = new ExcelData();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            statusStrip1.Items[0].Text = "X: " + Convert.ToString(e.X + 1) + " Y: " + Convert.ToString(panel1.Height - e.Y - 2);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            PointADD(e, panel1.Height);
            if (!button1.Visible)
                button1.Visible = true;
        }

        private void SetDataGridDefaults(DataGridView dg)
        {
            dataGridView1.Visible = false;
            dataGridView1.RowCount = 1;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "X";
            dataGridView1.Columns[1].Name = "Y";
            dataGridView1.Columns[0].Width = dataGridView1.Width / 2;
            dataGridView1.Columns[1].Width = dataGridView1.Columns[0].Width - 1;
        }

        private void PointADD(MouseEventArgs e, int height)
        {
            if (!dataGridView1.Visible)
            {
                dataGridView1.Visible = true;
            }
            else
                dataGridView1.RowCount++;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value = Convert.ToString(e.Location.X + 1);
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Value = Convert.ToString(height - e.Location.Y - 2);         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
            dataGridView1.Visible = false;
            button1.Visible = false;
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PointADD(e, panel1.Height);
            if (!button1.Visible)
                button1.Visible = true;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.Opacity = 0.3 + 0.07 * trackBar1.Value;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Очистить таблицу заданных координат";
            statusStrip1.Items[0].Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Координаты выбранных точек";
            statusStrip1.Items[0].Visible = true;
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void trackBar1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Изменение степени прозрачности окна";
            statusStrip1.Items[0].Visible = true;
        }

        private void trackBar1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void файлToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Главное меню программы";
            statusStrip1.Items[0].Visible = true;
        }

        private void файлToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void menuStrip1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Главное меню программы";
            statusStrip1.Items[0].Visible = true;
        }

        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void закрытьToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Вернуться к окну нахождения общего центра тяжести";
            statusStrip1.Items[0].Visible = true;
        }

        private void закрытьToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void переносКоординатToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Перенос координат в Excel";
            statusStrip1.Items[0].Visible = true;
        }

        private void переносКоординатToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void открытьВExcelToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Открыть таблицу координат в программе Excel";
            statusStrip1.Items[0].Visible = true;
        }

        private void открытьВExcelToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void сохранитьИОткрытьToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void открытьВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible)
            {
                statusStrip1.Items[0].Text = "Выполняется открытие программы Excel";
                statusStrip1.Items[0].Visible = true;
                excelData.OpenExcel(dataGridView1);
                this.WindowState = FormWindowState.Minimized;
                statusStrip1.Items[0].Visible = false;
            }
            else
                MessageBox.Show("Задайте минимум одну точку!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ExcelTransfer_Load(object sender, EventArgs e)
        {
            this.Height = fmHeight;
            this.Width = fmWidth;
            this.Location = fmLocation;
        }
    }

    public class ExcelData
    {
        private string filePath;

        public void SetDirectory(string fileString)
        {
            filePath = fileString;
        }

        public void OpenExcel(DataGridView dataGridView)
        {
            Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook ExcelWorkBook;
            Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelWorkSheet.Cells[1, 1] = "№";
            ExcelWorkSheet.Cells[1, 2] = "X";
            ExcelWorkSheet.Cells[1, 3] = "Y";
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                ExcelWorkSheet.Cells[i + 2, 1] = i + 1;
                ExcelWorkSheet.Cells[i + 2, 2] = dataGridView.Rows[i].Cells[0].Value;
                ExcelWorkSheet.Cells[i + 2, 3] = dataGridView.Rows[i].Cells[1].Value;
            }
            ExcelApp.Visible = true;
        }
    }
}
