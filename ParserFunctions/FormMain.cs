using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParserFunctions
{
    public partial class FormMain : Form
    {
        private double a;
        private double b;
        private int N;

        private List<string> functions;

        private FormGraphics formGraphics;

        private Parser parser;

        private double[] X;
        private double[,] Y;

        public FormMain()
        {
            InitializeComponent();

            functions = new List<string>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(checkInput())
            {
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                N = Convert.ToInt32(textBox3.Text);

                parser = new Parser(functions,a,b,N);

                X = parser.getArrayX();
                Y = parser.getArraysY();

                formGraphics = new FormGraphics();
                formGraphics.setArrays(X, Y, functions);
                formGraphics.Show();
            }
        }


        private bool checkInput()
        {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Введите начало отрезка", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBox2.TextLength == 0)
            {
                MessageBox.Show("Введите конец отрезка", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBox3.TextLength == 0)
            {
                MessageBox.Show("Введите количество точек", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = comboBox1.Text;

            comboBox1.Text = "";

            if (comboBox1.Items.IndexOf(str) == -1)
            {
                comboBox1.Items.Add(str);
                functions.Add(str);
                MessageBox.Show("Успешно добавленно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Такой элемент существует", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = comboBox1.Text;

            comboBox1.Text = "";

            comboBox1.Items.Remove(str);
            functions.Remove(str);
            MessageBox.Show("Успешно удаленно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
