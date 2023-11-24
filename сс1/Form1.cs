using System;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace CC2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Загрузка
        private void Form1_Load(object sender, EventArgs e)
        {
            labelSo4et.BackColor = Color.Transparent;
            PanelSettings.Visible = false;
            comboBox1.Text = "Выберите тему...";

            OtvetSo4et.Multiline = true;
            OtvetSo4et.Height = 80;

            OtvetPerest.Multiline = true;
            OtvetPerest.Height = 80;

            OtvetRazm.Multiline = true;
            OtvetRazm.Height = 80;

            ResPerest.Multiline = true;
            ResPerest.Height = 200;

            ResRazm.Multiline = true;
            ResRazm.Height = 200;

            ResSo4et.Multiline = true;
            ResSo4et.Height = 200;

            So4et.Visible = false;
            Razm.Visible = false;
            Perest.Visible = false;
            tabControlDiscret.Visible = false;
            button1.Visible = false;

		}


		// Кнопка вывода всех функций
		private void button1_Click_1(object sender, EventArgs e)
		{
			if (So4et.Visible == true) // Вывод Сочетаний
			{
				PanelSettings.Visible = false;
				long nS;
				long kS;

				if (long.TryParse(So4etN.Text, out nS) && long.TryParse(So4etK.Text, out kS) && nS >= kS)
				{
					string solution;
					string result;

					GetBinCoeff(nS, kS, out solution, out result);

					OtvetSo4et.Text = result;
					ResSo4et.Text = solution;
				}
				else
				{
					MessageBox.Show("Введите правильное значение");
				}
			}
			else if (Razm.Visible == true) // Вывод размещений
			{
				PanelSettings.Visible = false;
				long nR, kR;

				if (long.TryParse(RazmN.Text, out nR) && long.TryParse(RazmK.Text, out kR) && nR >= kR)
				{
					string solution;
					string result;

					GetRazmCoeff(nR, kR, out solution, out result);

					OtvetRazm.Text = result;
					ResRazm.Text = solution;
				}
				else
				{
					MessageBox.Show("Введите правильное значение");
				}
			}
			else if (Perest.Visible == true) // Вывод перестановок
			{
				PanelSettings.Visible = false;
				long nP;

				if (long.TryParse(PerestN.Text, out nP))
				{
					string solution;
					string result;

					GetPerestCoeff(nP, out solution, out result);

					OtvetPerest.Text = result;
					ResPerest.Text = solution;
				}
				else
				{
					MessageBox.Show("Введите правильное значение");
				}
			}

            if (checkBoxResult.Checked == true)
            {
				string textS = "\nC: " + ResSo4et.Text + "\n";
                textS = textS.Replace("System.Windows.Forms.TextBox, Text: ", "");
                File.AppendAllText("Result.txt", textS);
                string textP = "\nP: " + ResPerest.Text + "\n";
                textP = textP.Replace("System.Windows.Forms.TextBox, Text: ", "");
                File.AppendAllText("Result.txt", textP);
				string textR = "\nR: " + ResRazm.Text + "\n";
				textP = textR.Replace("System.Windows.Forms.TextBox, Text: ", "");
				File.AppendAllText("Result.txt", textR);
				File.AppendAllText("Result.txt", "------------------------------------------------------");
            }
            else
            {
				File.WriteAllText("Result.txt", "Функция сохранения отключена. Подробнее - настройки.");
			}
		}



		//Home кнопка
		private void Home(object sender, EventArgs e)
        {
            So4et.Visible = false;
            Razm.Visible = false;
            Perest.Visible = false;
            PanelSettings.Visible = false;
            PanelHome.Visible = true;
            tabControlDiscret.Visible = false;
            button1.Visible = false;
            comboBox1.SelectedItem = null;
            if (labelLang.Text == "RU")
            {
                comboBox1.Text = "Выберите тему...";
            }
            else comboBox1.Text = "Select...";
        }


		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (comboBox1.SelectedIndex == 1)
            {
                tabControlDiscret.Visible = true;
                So4et.Visible = true;
                Razm.Visible = true;
                Perest.Visible = true;
                button1.Visible=true;
                PanelSettings.Visible = false;
            }
        }






        // Методы вычисления всех функций
        private BigInteger Factorial(BigInteger n)
        {
            if (n < 0)
                return BigInteger.MinusOne; // or any other large number

            if (n == 0 || n == 1)
                return 1;

            BigInteger result = 1;
            for (BigInteger i = n; i >= 1; i--)
            {
                result *= i;
            }

            return result;
        }
        private void GetBinCoeff(BigInteger nS, BigInteger kS, out string solution, out string result)
        {
            if (kS == 0 || kS == nS)
            {
                solution = $"C({nS}, {kS}) = 1";
                result = "1";
            }
            else if (kS > nS)
            {
                solution = $"C({nS}, {kS}) = 0";
                result = "0";
            }
            else
            {
                BigInteger numerator = Factorial(nS);
                BigInteger denominator = Factorial(kS) * Factorial(nS - kS);

                if (denominator == BigInteger.MinusOne)
                {
                    solution = $"C({nS}, {kS}) = Cannot calculate factorial for negative numbers";
                    result = "Cannot calculate factorial for negative numbers";
                }
                else
                {
                    string numeratorString = "";
                    string denominatorString = "";

                    for (BigInteger i = nS; i > nS - kS; i--)
                    {
                        numeratorString += i.ToString() + " * ";
                    }

                    for (BigInteger i = kS; i >= 1; i--)
                    {
                        denominatorString += i.ToString() + " * ";
                    }
                    denominatorString = denominatorString.Substring(0, denominatorString.Length - 3); // remove the last " * "

                    result = $"{numerator / denominator}";
                    solution = $"C({nS}, {kS}) = {nS}! / ({kS}! * ({nS} - {kS})!) = {numeratorString} / {denominatorString} = {result}";
                }
            }
        }
        private void GetRazmCoeff(long nR, long kR, out string solution, out string result)
        {
            StringBuilder sb = new StringBuilder();
            if (kR == 0)
            {
                solution = "1";
                result = "1";
            }
            else if (kR > nR)
            {
                solution = "0";
                result = "0";
            }
            else
            {
                BigInteger resultR = 1;
                for (long i = nR; i > nR - kR; i--)
                {
                    resultR *= i;
                }
                BigInteger finalResult = resultR;
                solution = nR.ToString() + "! / (" + nR.ToString() + " - " + kR.ToString() + ")! = " + sb.ToString();
                result = finalResult.ToString();

                // Добавляем подробное решение
                sb.Clear();
                sb.Append(nR.ToString());
                for (long i = nR - 1; i >= nR - kR + 1; i--)
                {
                    sb.Append(" * " + i.ToString());
                }
                sb.Append(" = " + finalResult.ToString());
                solution += " " + sb.ToString();
            }
        }
        private void GetPerestCoeff(long nP, out string solution, out string result)
        {
            StringBuilder sb = new StringBuilder();
            if (nP == 0)
            {
                solution = "1";
                result = "1";
            }
            else
            {
                BigInteger n = new BigInteger(nP);
                BigInteger p = new BigInteger(nP);
                BigInteger resultP = new BigInteger(1);

                while (p > 0)
                {
                    sb.Append(n.ToString());
                    if (p > 1)
                    {
                        sb.Append(" * ");
                    }
                    else
                    {
                        sb.Append(" = ");
                    }
                    resultP *= n;
                    n--;
                    p--;
                }
                sb.Append(resultP.ToString());
                solution = sb.ToString();
                result = resultP.ToString();
            }
        }



        // Темная тема
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) //Dark
            {
                this.BackColor = Color.FromArgb(48, 56, 65); //Фон

                //Razm
                Razm.BackColor = Color.FromArgb(48, 56, 65); //Вкладка
                Razm.ForeColor = Color.FromArgb(232, 69, 69); //Текст
                ResRazm.BackColor = Color.FromArgb(58, 71, 80); //Белое поле
                ResRazm.ForeColor = Color.FromArgb(232, 69, 69); //Текст решения
                RazmK.ForeColor = Color.FromArgb(232, 69, 69); // K
                RazmN.ForeColor = Color.FromArgb(232, 69, 69); // N
                RazmK.BackColor = Color.FromArgb(58, 71, 80); //Поле K
                RazmN.BackColor = Color.FromArgb(58, 71, 80); //Поле N
                OtvetRazm.BackColor = Color.FromArgb(58, 71, 80); //Поле ответ
                OtvetRazm.ForeColor = Color.FromArgb(232, 69, 69); //Текст ответа

                //So4et
                So4et.BackColor = Color.FromArgb(48, 56, 65); //Вкладка
                So4et.ForeColor = Color.FromArgb(232, 69, 69); //Текст
                ResSo4et.BackColor = Color.FromArgb(58, 71, 80); //Белое поле
                ResSo4et.ForeColor = Color.FromArgb(232, 69, 69); //Текст решения
                So4etK.ForeColor = Color.FromArgb(232, 69, 69); // K
                So4etN.ForeColor = Color.FromArgb(232, 69, 69); // N
                So4etK.BackColor = Color.FromArgb(58, 71, 80); //Поле K
                So4etN.BackColor = Color.FromArgb(58, 71, 80); //Поле N
                OtvetSo4et.BackColor = Color.FromArgb(58, 71, 80); //Поле ответ
                OtvetSo4et.ForeColor = Color.FromArgb(232, 69, 69); //Текст ответа

                //Perest
                Perest.BackColor = Color.FromArgb(48, 56, 65); //Вкладка
                Perest.ForeColor = Color.FromArgb(232, 69, 69); //Текст
                ResPerest.BackColor = Color.FromArgb(58, 71, 80); //Белое поле
                ResPerest.ForeColor = Color.FromArgb(232, 69, 69); //Текст решения
                PerestN.ForeColor = Color.FromArgb(232, 69, 69); // N
                PerestN.BackColor = Color.FromArgb(58, 71, 80); //Поле N
                OtvetPerest.BackColor = Color.FromArgb(58, 71, 80); //Поле ответ
                OtvetPerest.ForeColor = Color.FromArgb(232, 69, 69); //Текст ответа

                PanelSettings.BackColor = Color.FromArgb(58, 71, 80);//Home
                PanelHome.BackColor = Color.FromArgb(58, 71, 80);//Settings
                PanelSettings.ForeColor = Color.FromArgb(232, 69, 69);
                PanelHome.ForeColor = Color.FromArgb(232, 69, 69);
                labelWelcome.ForeColor = Color.FromArgb(232, 69, 69);
                LabelDark.ForeColor = Color.FromArgb(232, 69, 69);

                button1.ForeColor = Color.FromArgb(232, 69, 69);//Кнопка

                //Copy button
                CopyOtvetRazm.ForeColor = SystemColors.ControlText;
                CopyOtvPerest.ForeColor = SystemColors.ControlText;
                CopyOtvSo4et.ForeColor = SystemColors.ControlText;
                CopyResPerest.ForeColor = SystemColors.ControlText;
                CopyResRazm.ForeColor = SystemColors.ControlText;
                CopyResSo4et.ForeColor = SystemColors.ControlText;
                CopyResRazm.BackColor = Color.FromArgb(58, 71, 80);
                CopyOtvetRazm.BackColor = Color.FromArgb(58, 71, 80);
                CopyOtvPerest.BackColor = Color.FromArgb(58, 71, 80);
                CopyOtvSo4et.BackColor = Color.FromArgb(58, 71, 80);
                CopyResPerest.BackColor = Color.FromArgb(58, 71, 80);
                CopyResRazm.BackColor = Color.FromArgb(58, 71, 80);
                CopyResSo4et.BackColor = Color.FromArgb(58, 71, 80);
                tabControlDiscret.BackColor = Color.FromArgb(0, 65, 106);


            }
            else //White
            {
                this.BackColor = SystemColors.Control; 
                Razm.BackColor = SystemColors.ButtonHighlight;
                Perest.BackColor = SystemColors.ButtonHighlight;
                So4et.BackColor = SystemColors.ButtonHighlight;
                PanelSettings.BackColor = SystemColors.ButtonHighlight;
                PanelHome.BackColor = SystemColors.ButtonHighlight;
                button1.ForeColor = SystemColors.ControlText;
                tabControlDiscret.BackColor = SystemColors.ButtonHighlight;

                CopyResRazm.BackColor = SystemColors.Control;
                CopyOtvetRazm.BackColor = SystemColors.Control;
                CopyOtvPerest.BackColor = SystemColors.Control;
                CopyOtvSo4et.BackColor = SystemColors.Control;
                CopyResPerest.BackColor = SystemColors.Control;
                CopyResRazm.BackColor = SystemColors.Control;
                CopyResSo4et.BackColor = SystemColors.Control;
                tabControlDiscret.BackColor = SystemColors.Control;

                //Razm
                Razm.ForeColor = SystemColors.ControlText;
                RazmK.BackColor = SystemColors.Control;
                RazmK.ForeColor = SystemColors.ControlText;
                RazmN.BackColor = SystemColors.Control;
                RazmN.ForeColor = SystemColors.ControlText;
                OtvetRazm.ForeColor= SystemColors.ControlText;
                OtvetRazm.BackColor= SystemColors.Control;
                ResRazm.ForeColor=  SystemColors.ControlText;
                ResRazm.BackColor=SystemColors.Control;

                //Perest
                Perest.ForeColor = SystemColors.ControlText;
                PerestN.BackColor = SystemColors.Control;
                PerestN.ForeColor = SystemColors.ControlText;
                OtvetPerest.ForeColor = SystemColors.ControlText;
                OtvetPerest.BackColor = SystemColors.Control;
                ResPerest.ForeColor = SystemColors.ControlText;
                ResPerest.BackColor = SystemColors.Control;

                //so4et
                So4et.ForeColor = SystemColors.ControlText;
                So4etK.BackColor = SystemColors.Control;
                So4etK.ForeColor = SystemColors.ControlText;
                So4etN.BackColor = SystemColors.Control;
                So4etN.ForeColor = SystemColors.ControlText;
                OtvetSo4et.ForeColor = SystemColors.ControlText;
                OtvetSo4et.BackColor = SystemColors.Control;
                ResSo4et.ForeColor = SystemColors.ControlText;
                ResSo4et.BackColor = SystemColors.Control;

                LabelDark.ForeColor = SystemColors.ControlText;
                labelWelcome.ForeColor = SystemColors.ControlText;


            }
        }
        private void label5_Paint(object sender, PaintEventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.ForeColor = SystemColors.Control;

            }
            else
            {
                this.ForeColor = SystemColors.ControlText;
            }
        }
		private void LabelDark_MouseClick(object sender, MouseEventArgs e)
		{
			if (checkBox1.Checked == true) { checkBox1.Checked = false; }
			else { checkBox1.Checked = true; }
		}


		//Настройки
		private void panel3_Click(object sender, MouseEventArgs e)
        {
            button1.Visible = false;
            PanelHome.Visible = true;
            Razm.Visible = false;
            Perest.Visible = false;
            So4et.Visible = false;  
            tabControlDiscret.Visible = false;
            if (labelLang.Text == "RU")
            {
                comboBox1.SelectedIndex = 0;
                comboBox1.Text = "Выберите тему...";
            }
            else
            {
                comboBox1.SelectedIndex = 0;
                comboBox1.Text = "Select...";
            }
            if (PanelSettings.Visible == true)
            {
                PanelSettings.Visible = false;
            }
            else if (PanelSettings.Visible == false) { PanelSettings.Visible = true; }

        }




        //Info вкладка
        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            Form2 infoForm = new Form2();
            infoForm.Show();
        }



        //Запрет ввода слов
        private void PerestN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        //Копирование
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OtvetPerest.Text))
            {
                OtvetPerest.Text = " ";
                Clipboard.SetText(OtvetPerest.Text);
            }
            else
            {
                Clipboard.SetText(OtvetPerest.Text);
            }
        }
        private void CopyResPerest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ResPerest.Text))
            {
                ResPerest.Text = " ";
                Clipboard.SetText(ResPerest.Text);
            }
            else
            {
                Clipboard.SetText(ResPerest.Text);
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OtvetRazm.Text))
            {
                OtvetRazm.Text = " ";
                Clipboard.SetText(OtvetRazm.Text);
            }
            else
            {
                Clipboard.SetText(OtvetRazm.Text);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ResRazm.Text))
            {
                ResRazm.Text = " ";
                Clipboard.SetText(ResRazm.Text);
            }
                else
                {
                    Clipboard.SetText(ResRazm.Text);
                }
        }
        private void CopyOtvSo4et_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OtvetSo4et.Text))
            {
                OtvetSo4et.Text = " ";
                Clipboard.SetText(OtvetSo4et.Text);
            }
            else
            {
                Clipboard.SetText(OtvetSo4et.Text);
            }
        }
        private void CopyResSo4et_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ResSo4et.Text))
            {
                ResSo4et.Text = " ";
                Clipboard.SetText(ResSo4et.Text);
            }
            else
            {
                Clipboard.SetText(ResSo4et.Text);
            }
        }



        //Локализация
        private void panelLang_MouseClick(object sender, MouseEventArgs e)
        {
            if (labelLang.Text == "EN")
            {
                labelLang.Text = "RU";
                labelHome.Text = "Домой";
                labelSettings.Text = "Настройки";
                labelSettings.Location = new Point(52, 9);
                labelInfo.Text = "Инфо";
                button1.Text = "Решить";
                labelWelcome.Text = "Добро пожаловать в программу CombiCalc!";
                CopyResSo4et.Text = "Копировать";
                CopyResPerest.Text = "Копировать";
                CopyResRazm.Text = "Копировать";
                CopyOtvetRazm.Text = "Копировать";
                CopyOtvPerest.Text = "Копировать";
                CopyOtvSo4et.Text = "Копировать";
                labelSo4et.Text = "Сочетания";
                labelPerest.Text = "Перестановки";
                labelRazm.Text = "Размещения";
                labelResPerest.Text = "Решение";
                labelResRazm.Text = "Решение";
                labelResSo4et.Text = "Решение";
                labelOtvPerest.Text = "Ответ";
                labelOtvRazm.Text = "Ответ";
                labelOtvSo4et.Text = "Ответ";
                tabPage1.Text = "Сочетания";
                tabPage2.Text = "Размещения";
                tabPage3.Text = "Перестановки";
                comboBox1.Text = "Выберите тему...";
                comboBox1.Items[1] = "Дискретная математика";
                LabelDark.Text = "Темная тема";
            }
            else
            {
                labelLang.Text = "EN";
                labelHome.Text = "Home";
                labelSettings.Text = "Settings";
                labelSettings.Location = new Point(65, 9);
                labelInfo.Text = "Info";
                tabPage1.Text = "Combinations";
                tabPage2.Text = "nPk";
                tabPage3.Text = "Permutations";
                button1.Text = "Solve";
                labelWelcome.Text = "Welcome to the CombiCalc program!";
                CopyResSo4et.Text = "Copy";
                CopyResPerest.Text = "Copy";
                CopyResRazm.Text = "Copy";
                CopyOtvetRazm.Text = "Copy";
                CopyOtvPerest.Text = "Copy";
                CopyOtvSo4et.Text = "Copy";
                labelSo4et.Text = "Combination";
                labelPerest.Text = "nPk";
                labelRazm.Text = "Permutations";
                labelResPerest.Text = "Solution";
                labelResRazm.Text = "Solution";
                labelResSo4et.Text = "Solution";
                labelOtvPerest.Text = "Result";
                labelOtvRazm.Text = "Result";
                labelOtvSo4et.Text = "Result";
                comboBox1.Text = "Select...";
                comboBox1.Items[1] = "Discrete mathematics";
                LabelDark.Text = "Dark Theme";
            }
        }


    }
}


