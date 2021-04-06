using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_processing
{
    class Sepia : Filters
    {
        protected override Color calcNewPixColor(Bitmap sourceImg, int i, int j)
        {
            Color sourceColor = sourceImg.GetPixel(i, j);
            double outputRed = (sourceColor.R * .393) + (sourceColor.G * .769) + (sourceColor.B * .189);
            double outputGreen = (sourceColor.R * .349) + (sourceColor.G * .686) + (sourceColor.B * .168);
            double outputBlue = (sourceColor.R * .272) + (sourceColor.G * .534) + (sourceColor.B * .131);
            return Color.FromArgb(Clamp((int)outputRed, 0, 255), 
                Clamp((int)outputGreen, 0, 255), Clamp((int)outputBlue, 0, 255));
            //Color resultColor = Color.FromArgb((int)(sourceColor.R+2*k), (int)(sourceColor.G+0.5*k), (int)(sourceColor.B-1*k));
            //return Color.FromArgb(Clamp((int)resultColor.R, 0, 255), 
            //    Clamp((int)resultColor.B, 0, 255), Clamp((int)resultColor.B, 0, 255));
        }
    }
}
