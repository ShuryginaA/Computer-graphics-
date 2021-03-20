﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace img_processing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap image;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files |*.png;*.jpg;*.bmp|ALL files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
          
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImg =((Filters)e.Argument).processImg(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImg;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sepia();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void brightnessIncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BrightnessInc();
            backgroundWorker1.RunWorkerAsync(filter);

        }
         private void SobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void dirationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool[,] mask = new bool[3, 3];
            mask[0, 0] = false;
            mask[0, 1] = true;
            mask[0, 2] = false;
            mask[1, 0] = true;
            mask[1, 1] = true;
            mask[1, 2] = true;
            mask[2, 0] = false;
            mask[2, 1] = true;
            mask[2, 2] = false;        
            MathMorf dil = new Dilation();
            //backgroundWorker2.RunWorkerAsync(dil);
            Bitmap resultImage = dil.procImg(image,mask,3, 3/*,backgroundWorker2*/);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool[,] mask = new bool[3, 3];
            mask[0, 0] = false;
            mask[0, 1] = true;
            mask[0, 2] = false;
            mask[1, 0] = true;
            mask[1, 1] = true;
            mask[1, 2] = true;
            mask[2, 0] = false;
            mask[2, 1] = true;
            mask[2, 2] = false;
            MathMorf eros = new Erosion();
            // backgroundWorker2.RunWorkerAsync(eros);
            Bitmap resultImage = eros.procImg(image, mask, 3, 3/*, backgroundWorker2*/);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool[,] mask = new bool[3, 3];
            mask[0, 0] = true;
            mask[0, 1] = true;
            mask[0, 2] = true;
            mask[1, 0] = true;
            mask[1, 1] = true;
            mask[1, 2] = true;
            mask[2, 0] = true;
            mask[2, 1] = true;
            mask[2, 2] = true;
            MathMorf open = new Opening();
             //backgroundWorker2.RunWorkerAsync(open);
            Bitmap resultImage = open.procImg(image, mask, 3, 3/*, backgroundWorker2*/);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool[,] mask = new bool[3, 3];
            mask[0, 0] = true;
            mask[0, 1] = true;
            mask[0, 2] = true;
            mask[1, 0] = true;
            mask[1, 1] = true;
            mask[1, 2] = true;
            mask[2, 0] = true;
            mask[2, 1] = true;
            mask[2, 2] = true;
            MathMorf close = new Closing();
            //backgroundWorker2.RunWorkerAsync(close);
            Bitmap resultImage = close.procImg(image, mask, 3, 3 /*backgroundWorker2*/);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();

        }

        private void gradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool[,] mask = new bool[3, 3];
            mask[0, 0] = false;
            mask[0, 1] = true;
            mask[0, 2] = false;
            mask[1, 0] = true;
            mask[1, 1] = true;
            mask[1, 2] = true;
            mask[2, 0] = false;
            mask[2, 1] = true;
            mask[2, 2] = false;
            MathMorf grad = new Gradient();
            //backgroundWorker2.RunWorkerAsync(grad);
            Bitmap resultImage = grad.procImg(image, mask, 3, 3/*, backgroundWorker2*/);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            //В разработке, фиксить пересечение потоков
        }
    }
}
