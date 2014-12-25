using System;
using System.Drawing;
using System.Windows.Forms;

//Position modify: X += 1, Y = panel1.Height - 2;

namespace CGC
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            if (!Config.LoadFromConfigurationFile())
            {
                MessageBox.Show("Ошибка загрузки файла конфигурация. Сброс настроек!", "Ошибка загрузки файла конфигурации!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ProgramData.SetDefaults();
                this.RefreshAll();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            statusStrip1.Items[0].Text = "X: " + Convert.ToString(e.X + 1) + " Y: " + Convert.ToString(panel1.Height - e.Y - 2);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterScreenForm(this);
            this.AllowTransparency = true;
            ProgramData.LoadToSegmentComboBox(comboBox1);
            ProgramData.ChangePanelColor(panel2, comboBox1.SelectedIndex);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Вы только что пытались сломать программу. Не вышло :(", "Потрачено!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.SelectedIndex = 0;
            }
            ProgramData.ChangePanelColor(panel2, comboBox1.SelectedIndex);
            pictureBox1.Refresh();            
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = '\0';
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            panel1.Focus();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.Opacity = 0.3 + 0.07 * trackBar1.Value;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            SetPointFuct(new Point(e.X, e.Y));
            panel1.Refresh();
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetPointFuct(new Point(e.X, e.Y));
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ProgramData.PaintLayer(e);
        }

        private void SetPointFuct(Point pos)
        {
            ProgramData.SetPoint(pos, comboBox1.SelectedIndex);
            comboBox1.SelectedIndex = comboBox1.SelectedIndex < 19 ? comboBox1.SelectedIndex + 1 : 0; 
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            ProgramData.DrawPointOnAlf(comboBox1.SelectedIndex, e);
        }

        private void CenterScreenForm(MainForm mf)
        {
            mf.Left = (Screen.PrimaryScreen.Bounds.Width - mf.Width) / 2;
            mf.Top = (Screen.PrimaryScreen.Bounds.Height - mf.Height) / 2;
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            settingsForm.ShowDialog();
            RefreshAll();            
        }

        private void RefreshAll()
        {
            panel1.Refresh();
            pictureBox1.Refresh();
            panel2.Refresh();
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

        private void menuStrip1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Главное меню программы";
            statusStrip1.Items[0].Visible = true;
        }

        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void файлToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Работа с файлами";
            statusStrip1.Items[0].Visible = true;
        }

        private void файлToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void открытьToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Открыть сохраненный файл программы";
            statusStrip1.Items[0].Visible = true;
        }

        private void открытьToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void сохранитьToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Сохранить изменения в открытом файле";
            statusStrip1.Items[0].Visible = true;                
        }

        private void сохранитьToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void сохранитьКакToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Создать файл сохранения в новом расположении";
            statusStrip1.Items[0].Visible = true;  
        }

        private void сохранитьКакToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;  
        }

        private void настройкиToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Настройка программы и массы объекта";
            statusStrip1.Items[0].Visible = true;  
        }

        private void настройкиToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void выходToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Выход из программы";
            statusStrip1.Items[0].Visible = true;  
        }

        private void выходToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void операцииToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Выполнение операций с координатами";
            statusStrip1.Items[0].Visible = true; 
        }

        private void операцииToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false; 
        }

        private void рассчитатьОТЦToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Выполнить рассчет общего центра тяжести";
            statusStrip1.Items[0].Visible = true; 
        }

        private void рассчитатьОТЦToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void очиститьКоординатыToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Очистить координаты точек";
            statusStrip1.Items[0].Visible = true; 
        }

        private void очиститьКоординатыToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void захватКоординатToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Перенос координат в Excel";
            statusStrip1.Items[0].Visible = true; 
        }

        private void захватКоординатToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void дляТекущегоСлояToolStripMenuItem1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Очистить координаты точек для текущего слоя";
            statusStrip1.Items[0].Visible = true; 
        }

        private void дляТекущегоСлояToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false; 
        }

        private void дляВсехСлоевToolStripMenuItem1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Очистить координаты точек для всех слоев";
            statusStrip1.Items[0].Visible = true; 
        }

        private void дляВсехСлоевToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false; 
        }

        private void дляТекущегоСлояToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Выполнить рассчет общего центра тяжести для текущего слоя";
            statusStrip1.Items[0].Visible = true; 
        }

        private void дляТекущегоСлояToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false; 
        }

        private void дляВсехСлоевToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Выполнить рассчет общего центра тяжести для всех слоев";
            statusStrip1.Items[0].Visible = true; 
        }

        private void дляВсехСлоевToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false; 
        }

        private void справкаToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Содержит справочную информацию";
            statusStrip1.Items[0].Visible = true; 
        }

        private void справкаToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false; 
        }

        private void просмотрСправкиToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Просмотр справки";
            statusStrip1.Items[0].Visible = true;
        }

        private void просмотрСправкиToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void оПрограммеToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Просмотр информации о версии программы и авторах";
            statusStrip1.Items[0].Visible = true;
        }

        private void оПрограммеToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Список сегментов";
            statusStrip1.Items[0].Visible = true;
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Цвет точки активного сегмента";
            statusStrip1.Items[0].Visible = true;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Это Альф. Он подскажет где находится активный сегмент";
            statusStrip1.Items[0].Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void comboBox2_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Список слоев";
            statusStrip1.Items[0].Visible = true;
        }

        private void comboBox2_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Добавить новый слой";
            statusStrip1.Items[0].Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Удалить активный слой";
            statusStrip1.Items[0].Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Переименовать текущий слой";
            statusStrip1.Items[0].Visible = true;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ProgramData.ChangePanelColor(panel2, comboBox1.SelectedIndex);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Config.SaveToConfigurationFile())
            {
                if (MessageBox.Show("Произошла ошибка сохранения настроек программы!\n Закрыть программу не сохранив настройки?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Config.SaveToConfigurationFile();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About fm = new About();
            fm.ShowDialog();
        }

        private void очиститьКоординатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистить координаты точек для текущего слоя?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                ProgramData.ClearLayer(true);
                comboBox1.SelectedIndex = 0;
                panel1.Refresh();
            }
        }

        private void рассчитатьОТЦToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramData.CheckAllPointSet())
            {
                ProgramData.CGCActiveLayerCalculate();
                Point cgc = ProgramData.GetCGCActiveLayer(); //+375336188816
                panel1.Refresh();
                MessageBox.Show("Общий центр тяжести успешно найден!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Установлены координаты не всех сегментов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void захватКоординатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelTransfer fm = new ExcelTransfer(this.Height, this.Width, this.Location);
            this.Hide();
            fm.ShowDialog();
            this.Show();
        }

        private void просмотрСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "CGCalculator.chm");
        }     

        private void MyKeyPressEventHandler(Object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(Convert.ToString((int)e.KeyChar));
            if(ProgramData.plusKeys.Contains((int)e.KeyChar))
            {
                ProgramData.IncPointRadius();
            }
            if (ProgramData.minusKeys.Contains((int)e.KeyChar))
            {
                ProgramData.DecPointRadius();
            }
            panel1.Refresh();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           openFileDialog1.FileName = "";
           openFileDialog1.ShowDialog();
           Config.OpenSavedFile(openFileDialog1.FileName);
           сохранитьToolStripMenuItem.Enabled = true;
           this.Text = "CG Calculator ''" + openFileDialog1.FileName + "''";
           panel1.Refresh();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();
            Config.SaveFile(saveFileDialog1.FileName);
            this.Text = "CG Calculator ''" + saveFileDialog1.FileName + "''";
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config.SaveFile();
        }
    }
}