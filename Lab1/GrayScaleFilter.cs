﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_processing
{
    class GrayScaleFilter : Filters
    {
        protected override Color calcNewPixColor(Bitmap sourceImg, int i, int j)
        {
            Color sourceColor = sourceImg.GetPixel(i, j);
            int avg = (int)(sourceColor.R * 0.299+sourceColor.G * 0.587+sourceColor.B* 0.114);
            Color resultColor = Color.FromArgb(avg, avg, avg);     
            return resultColor;
        }
    }
}
