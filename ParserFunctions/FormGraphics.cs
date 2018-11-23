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
    public partial class FormGraphics : Form
    {
        public FormGraphics()
        {
            InitializeComponent();
        }

        public void setArrays(double[] X,double[,] Y , List<string> str)
        {
            int i = 0;
            foreach(string item in str)
            {
                if (chart1.Series.FindByName(item) == null)
                {
                    chart1.Series.Add(item).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    for (int j = 0; j < X.Length; j++)
                    {
                        chart1.Series[item].Points.AddXY(X[j], Y[i, j]);
                    }
                }

                i++;
            }
        }
    }
}
