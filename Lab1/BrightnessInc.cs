using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_processing
{
    class BrightnessInc : Filters
    {
        protected override Color calcNewPixColor(Bitmap sourceImg, int i, int j)
        {
            Color sourceColor = sourceImg.GetPixel(i, j);
            double k = 1.4;
            Color resultColor = Color.FromArgb(Clamp((int)(sourceColor.R*k), 0,255), Clamp((int)(sourceColor.B *k), 0, 255), Clamp((int)(sourceColor.B * k), 0, 255));
            return Color.FromArgb(resultColor.R,
             resultColor.B, resultColor.B);
        }
    }
}
