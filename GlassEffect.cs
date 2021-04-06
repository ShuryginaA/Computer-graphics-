using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace img_processing
{
    class GlassEffect:Filters
    {
        private readonly Random rand = new Random();
        protected override Color calcNewPixColor(Bitmap sourceImage, int i, int j)
        {
            Color resCol = sourceImage.GetPixel(Clamp((int)(i + (rand.NextDouble() - 0.5) * 10), 0, sourceImage.Width - 1),Clamp((int)(j + (rand.NextDouble() - 0.5) * 10), 0, sourceImage.Height-1 ));
            return resCol;
        }
    }
}
