using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK;
namespace CompGraf2
{
    public partial class Form1 : Form
    {
        int currentlayer = 0;
        View view = new View();
        bool loaded = false;
        Bin bin = new Bin();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Idle += Application_Idle;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string str=dialog.FileName;
                bin.readBIN(str);
                view.SetupView(glControl2.Width, glControl2.Height);
                trackBar1.Maximum = Bin.Z - 1;
                loaded = true;
                glControl2.Invalidate();

            }
        }

        private void glControl2_Load(object sender, EventArgs e)
        {

        }
        bool needReload = false;

        private void glControl2_Paint(object sender, PaintEventArgs e)
        {
            if (loaded)
            {
                if (radioButton1.Checked)
                    view.DrawQuads(currentlayer);
                else
                {
                    if (needReload)
                    {

                        view.generateTextureImage(currentlayer);
                        view.Load2DTexture();
                        needReload = false;
                    }
                    view.DrawTexture();
                }
                glControl2.SwapBuffers();
            }
        }
        void Application_Idle(object sender, EventArgs e)
        {
            while (glControl2.IsIdle)
            {
                displayFPS();
                glControl2.Invalidate();
            }
        }
        int FrameCount;
        DateTime NextFPSUpdate = DateTime.Now.AddSeconds(1);
        void displayFPS()
        {
            if (DateTime.Now >= NextFPSUpdate)
            {
                this.Text = String.Format("CT Visualizer (fps={0})", FrameCount);
                NextFPSUpdate = DateTime.Now.AddSeconds(1);
                FrameCount = 0;
            }
            FrameCount++;
        }
        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            currentlayer = trackBar1.Value;
            needReload = true;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            view.minimum = trackBar2.Value;
            needReload = true;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            view.window = trackBar3.Value;
            needReload = true;
        }
    }
}
