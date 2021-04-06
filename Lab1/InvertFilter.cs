﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_processing
{
    class InvertFilter : Filters
    {
        protected override Color calcNewPixColor(Bitmap sourceImg, int i, int j)
        {
            Color sourceColor = sourceImg.GetPixel(i, j);
            Color resultColor = Color.FromArgb(255- sourceColor.R, 255-sourceColor.G, 255 - sourceColor.B);
            return resultColor;
        }
    }
}
