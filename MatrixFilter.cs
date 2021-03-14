using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_processing
{
    class MatrixFilter : Filters
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }

        protected override Color calcNewPixColor(Bitmap sourceImg, int i, int j)
        {
            int radiusX = kernel.GetLength(0)/2;
            int radiusY = kernel.GetLength(1)/2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for(int l= -radiusY;l<=radiusY;l++)
                for (int k= -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(i + k, 0, sourceImg.Width - 1);
                    int idY = Clamp(j + l, 0, sourceImg.Height - 1);
                    Color neighborColor = sourceImg.GetPixel(idX,idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
  
                }
            return Color.FromArgb(Clamp((int)resultR, 0, 255),
                        Clamp((int)resultG, 0, 255), Clamp((int)resultB, 0, 255));

        }
    }
}
