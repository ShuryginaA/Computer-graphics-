using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace img_processing
{
    class linearStretchingFilter : Filters
    {
        Bitmap recivedImage;
        int minBrt;
        int maxBrt;

        public linearStretchingFilter(Bitmap SI)
        {
            recivedImage = SI;
            minBrt = 255;
            maxBrt = 0;
            for (int x = 0; x < recivedImage.Width; x++)
            {
                for (int y = 0; y < recivedImage.Height; y++)
                {
                    int brt = (int)(recivedImage.GetPixel(x, y).R * 0.299 + recivedImage.GetPixel(x, y).G * 0.587 + recivedImage.GetPixel(x, y).B * 0.114); //Y(NTSC) = 0,299R + 0,587G + 0,114B
                    if (brt < minBrt)
                        minBrt = brt;
                    if (brt > maxBrt)
                        maxBrt = brt;
                }
            }
        }

        override protected Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color resultColor;
            Color sourceColor = sourceImage.GetPixel(x, y);
            int newBrt = Clamp((int)(sourceColor.R * 0.299 + sourceColor.G * 0.587 + sourceColor.B * 0.114 - minBrt), 0, 255) * 255 / (maxBrt - minBrt);
            resultColor = Color.FromArgb(Clamp(sourceColor.R + (int)newBrt, 0, 255),
                                         Clamp(sourceColor.G + (int)newBrt, 0, 255),
                                         Clamp(sourceColor.B + (int)newBrt, 0, 255));
            return resultColor;
        }
    }
}
