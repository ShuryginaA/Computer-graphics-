using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace img_processing
{
    abstract class Filters
    {
        public Bitmap processImg(Bitmap sourceImg, BackgroundWorker worker)
        {
            Bitmap resultImg = new Bitmap(sourceImg.Width, sourceImg.Height);
            
            for (int i = 0; i < resultImg.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImg.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < resultImg.Height; j++)
                    resultImg.SetPixel(i, j, calcNewPixColor(sourceImg, i, j));
               
            }


            return resultImg;
        }

        protected abstract Color calcNewPixColor(Bitmap sourceImg, int i, int j);

        public int Clamp(int val,int min,int max)
        {
            if (val < min)
                return min;
            if (val > max)
                return max;
            return val;
        }
    }
    
}
