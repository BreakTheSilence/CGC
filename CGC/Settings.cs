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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            CenterScreenForm(this);
            LoadValues();
            TemporalColorsSettings.SetSomthingChangedFlag(false);
        }

        private void CenterScreenForm(Settings mf)
        {
            mf.Left = (Screen.PrimaryScreen.Bounds.Width - mf.Width) / 2;
            mf.Top = (Screen.PrimaryScreen.Bounds.Height - mf.Height) / 2;
        }

        private void LoadValues()
        {
            trackBar1.Value = ProgramData.GetPointRadius();
            textBox15.Text = Convert.ToString(ProgramData.GetTotalMass());
            LoadMassPercent();
            comboBox1.Items.Clear();
            TemporalColorsSettings.LoadColors();
            ProgramData.LoadToColorComboBox(comboBox1);
        }

        private void LoadMassPercent()
        {
            decimal[] data;
            ProgramData.GopySegmentsMassPercent(out data);
            TemporalColorsSettings.SetNewSegmentsMassPercent(data);
            textBox1.Text = Convert.ToString(data[0]);
            textBox2.Text = Convert.ToString(data[1]);
            textBox3.Text = Convert.ToString(data[2]);
            textBox4.Text = Convert.ToString(data[3]);
            textBox5.Text = Convert.ToString(data[4]);
            textBox6.Text = Convert.ToString(data[5]);
            textBox7.Text = Convert.ToString(data[6]);
            textBox8.Text = Convert.ToString(data[7]);
            textBox9.Text = Convert.ToString(data[8]);
            textBox10.Text = Convert.ToString(data[9]);
            textBox11.Text = Convert.ToString(data[10]);
            textBox12.Text = Convert.ToString(data[11]);
            textBox13.Text = Convert.ToString(data[12]);
            textBox14.Text = Convert.ToString(data[13]);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Вы только что пытались сломать программу. Не вышло :(", "Потрачено!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.SelectedIndex = 0;
            }
            panel1.BackColor = TemporalColorsSettings.GetColor(comboBox1.SelectedIndex);
            TemporalColorsSettings.SetSomthingChangedFlag(true);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            colorDialog1.ShowDialog();
            TemporalColorsSettings.SetSomthingChangedFlag(true);
            TemporalColorsSettings.SetColor(colorDialog1.Color, comboBox1.SelectedIndex);
            panel1.BackColor = TemporalColorsSettings.GetColor(comboBox1.SelectedIndex);
        }

        private void trackBar1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Изменение диаметра точки";
            statusStrip1.Items[0].Visible = true;
        }

        private void trackBar1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Сохранить изменения";
            statusStrip1.Items[0].Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Содержит список сегментов";
            statusStrip1.Items[0].Visible = true;
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "ЛКМ для выбора цвета";
            statusStrip1.Items[0].Visible = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void textBox15_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Общая масса тела";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox15_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Восстановить умолчания";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox4_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox5_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox6_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox7_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox8_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox9_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox10_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox11_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox12_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox13_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void textBox14_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Процент массы сегмента от общей";
            statusStrip1.Items[0].Visible = true;
        }

        private void Settings_MouseEnter(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Восстановить значения процентов веса сегментов по умолчанию?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                ProgramData.SetDefaults();
                LoadMassPercent();
            }
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TemporalColorsSettings.GetSomthingChangedFlag())
            {
                if (MessageBox.Show("Выйте без сохранения настроек?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private int CheckCorrectInput() // 1 - ошибка конвертации, 2 - ошибка комбо бокса, 3 - ошибка равенства сумма 100, 0 - без ошибок;
        {
            decimal check = 0; 
            try 
            {
                check += Convert.ToDecimal(textBox1.Text) + Convert.ToDecimal(textBox2.Text)
                       + Convert.ToDecimal(textBox3.Text) + Convert.ToDecimal(textBox4.Text)
                       + Convert.ToDecimal(textBox5.Text) + Convert.ToDecimal(textBox6.Text)
                       + Convert.ToDecimal(textBox7.Text) + Convert.ToDecimal(textBox8.Text)
                       + Convert.ToDecimal(textBox9.Text) + Convert.ToDecimal(textBox10.Text)
                       + Convert.ToDecimal(textBox11.Text) + Convert.ToDecimal(textBox12.Text)
                       + Convert.ToDecimal(textBox13.Text) + Convert.ToDecimal(textBox14.Text);
                double checkMass = Convert.ToDouble(textBox15.Text); 
            }
            catch (Exception) { return 1; } 
            if (!CheckComboBoxItems()) 
                return 2;
            if (check != 100) 
                return 3;
            return 0;
        }

        private bool CheckComboBoxItems()
        {
            string[] data = ProgramData.GetRefSegmentsNameArray();
            for (int i = 0; i < ProgramData.GetSegmentsCount() + 1; i++)
            {
                if (comboBox1.Text == data[i])
                    return true;
            }
            return false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox2.Focus();
        }

        private Char CheckEnterChar(Char input)
        {
            if (((input > 47) && (input < 58)) || (input == 44) || (input == 8))
            {
                if (!TemporalColorsSettings.GetSomthingChangedFlag())
                    TemporalColorsSettings.SetSomthingChangedFlag(true);
                return input;
            }
            if (input == 13)
                return input;
            return '\0';
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox3.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox4.Focus();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox5.Focus();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox6.Focus();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox7.Focus();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox8.Focus();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox9.Focus();
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox10.Focus();
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox11.Focus();
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox12.Focus();
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox13.Focus();
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox14.Focus();
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                textBox15.Focus();
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CheckEnterChar(e.KeyChar);
            if (e.KeyChar == 13)
                comboBox1.Focus();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = '\0';
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            TemporalColorsSettings.SetSomthingChangedFlag(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TemporalColorsSettings.GetSomthingChangedFlag())
            {
                switch (CheckCorrectInput())
                {
                    case 0:
                        if (MessageBox.Show("Сохранить изменения настроек?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            if (SaveChanges())
                            {
                                TemporalColorsSettings.SetSomthingChangedFlag(false);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Произошла непредвиденная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            TemporalColorsSettings.SetSomthingChangedFlag(false);
                            this.Close();
                        }
                        break;
                    case 1:
                        MessageBox.Show("Значения в некоторые поля введены некорректно!\nРазрешенными цифрами в поля ввода являются [0-9] и символ ','", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case 3:
                        MessageBox.Show("Cумма процентов не равна 100!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case 2:
                        MessageBox.Show("Изменение содержимого выпадающего списка запрещено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            else
                this.Close();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void RMBPressed(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                TemporalColorsSettings.SetSomthingChangedFlag(true);
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void textBox4_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void textBox5_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void textBox6_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void textBox7_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void textBox8_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void textBox9_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void textBox10_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void textBox11_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void textBox12_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void textBox13_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void textBox14_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void textBox15_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private void comboBox1_MouseDown(object sender, MouseEventArgs e)
        {
            RMBPressed(sender, e);
        }

        private bool SaveChanges()
        {
            try
            {
                decimal[] input = new decimal[14];
                input[0] = Convert.ToDecimal(textBox1.Text);
                input[1] = Convert.ToDecimal(textBox2.Text);
                input[2] = Convert.ToDecimal(textBox3.Text);
                input[3] = Convert.ToDecimal(textBox4.Text);
                input[4] = Convert.ToDecimal(textBox5.Text);
                input[5] = Convert.ToDecimal(textBox6.Text);
                input[6] = Convert.ToDecimal(textBox7.Text);
                input[7] = Convert.ToDecimal(textBox8.Text);
                input[8] = Convert.ToDecimal(textBox9.Text);
                input[9] = Convert.ToDecimal(textBox10.Text);
                input[10] = Convert.ToDecimal(textBox11.Text);
                input[11] = Convert.ToDecimal(textBox12.Text);
                input[12] = Convert.ToDecimal(textBox13.Text);
                input[13] = Convert.ToDecimal(textBox14.Text);
                ProgramData.SetSegmentsMassPercentArray(input);
                ProgramData.SetTotalMass(Convert.ToDecimal(textBox15.Text));
                ProgramData.SetColorMass(TemporalColorsSettings.GetColorArray());
                ProgramData.SetPointRadius(trackBar1.Value);
            }
            catch (Exception) { return false; }
            return true;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            CenterScreenForm(this);
        }
    }

    static public class TemporalColorsSettings
    {
        static Color[] newColors;
        static decimal[] newSegmentsMassPercent;
        static bool somthingChanged;

        static public void SetSomthingChangedFlag(bool sC)
        {
            somthingChanged = sC;
        }

        static public bool GetSomthingChangedFlag()
        {
            return somthingChanged;
        }

        static public void SetNewSegmentsMassPercent(decimal[] array)
        {
            newSegmentsMassPercent = array;
        }

        static public void LoadColors()
        {
            ProgramData.CopyColorsArray(out newColors);
        }

        static public Color GetColor(int comboBoxSelectedIndex)
        {
            return newColors[comboBoxSelectedIndex];
        }

        static public void SetColor(Color cl, int comboBoxSelectedIndex)
        {
            newColors[comboBoxSelectedIndex] = cl;
        }

        static public Color[] GetColorArray()
        {
            return newColors;
        }
    }
}