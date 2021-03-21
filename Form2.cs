using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGLab1._2
{
    public partial class Form2 : Form
    {
        public Form2(Form1 image)
        {
            InitializeComponent();
            Gistogramm.Series[0].Points.Clear();
            for (int i = 0; i < 256; i++)
            {
               Gistogramm.Series[0].Points.AddXY(i, image.GistogrammPoints[i]);
            }
        }
    }
}
