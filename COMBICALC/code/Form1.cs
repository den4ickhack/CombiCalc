using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CCcode1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            operationComboBox.SelectedItem = "Сочетания";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(nTextBox.Text, out int n) && int.TryParse(kTextBox.Text, out int k))
            {
                string operation = operationComboBox.SelectedItem.ToString();
                double result = 0;
                string solution = ""; // Строка для хранения подробного решения

                if (operation == "Сочетания")
                {
                    result = CalculateCombinations(n, k);
                    solution = $"{operation} C({n}, {k}) = {n}! / ({k}! * ({n} - {k})!) = ";

                    for (int i = n; i > n - k; i--)
                    {
                        solution += i;
                        if (i > n - k + 1)
                        {
                            solution += " * ";
                        }
                    }

                    solution += $" / (";

                    for (int i = k; i >= 1; i--)
                    {
                        solution += i;
                        if (i > 1)
                        {
                            solution += " * ";
                        }
                    }

                    solution += $") = ({result})";
                }
                else if (operation == "Перестановки")
                {
                    result = CalculatePermutations(n, k);
                    solution = $"{operation} P({n}, {k}) = {n}! / ({n} - {k}!) = ";

                    for (int i = n; i >= n - k + 1; i--)
                    {
                        solution += i;
                        if (i > n - k + 1)
                        {
                            solution += " * ";
                        }
                    }

                    solution += $" = ({result})";
                }
                else if (operation == "Разложения")
                {
                    result = CalculateArrangements(n, k);
                    solution = $"{operation} A({n}, {k}) = {n}^{k} = ";

                    for (int i = 1; i <= k; i++)
                    {
                        solution += n;
                        if (i < k)
                        {
                            solution += " * ";
                        }
                    }

                    solution += $" = ({result})";
                }

                // Выводим результат и подробное решение
                solutionLabel.Text = solution;
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные целые числа для n и k.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private double CalculateCombinations(int n, int k)
        {
            if (k < 0 || k > n)
            {
                // Обработка некорректных входных данных
                MessageBox.Show("Значение k должно быть от 0 до n.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            // Расчет сочетаний C(n, k)
            double result = Factorial(n) / (Factorial(k) * Factorial(n - k));
            return result;
        }
        private double CalculatePermutations(int n, int k)
        {
            if (k < 0 || k > n)
            {
                // Обработка некорректных входных данных
                MessageBox.Show("Значение k должно быть от 0 до n.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            // Расчет перестановок P(n, k)
            double result = Factorial(n) / Factorial(n - k);
            return result;
        }
        private double CalculateArrangements(int n, int k)
        {
            if (k < 0)
            {
                // Обработка некорректных входных данных
                MessageBox.Show("Значение k должно быть неотрицательным.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            // Расчет разложений A(n, k)
            double result = Math.Pow(n, k);
            return result;
        }
        private double Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                double result = 1;
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
                return result;
            }
        }

        private void nTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void operationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (operationComboBox.SelectedItem == "Сочетания")
            {
                FuncLabel.Text = "C(n,k)";
            }
            else if (operationComboBox.SelectedItem == "Перестановки")
            {
                FuncLabel.Text = "P(n,k)";
            }
            else if (operationComboBox.SelectedItem == "Разложения")
            {
                FuncLabel.Text = "A = n^k";
            }
        }
    }
}

