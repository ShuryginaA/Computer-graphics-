using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_processing
{
    class medianFilter : Filters
    {
        protected int rad;

        public medianFilter(int rad)
        {
            this.rad = rad;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = rad;
            int radiusY = rad;
            List<int> RValueList = new List<int>();
            List<int> GValueList = new List<int>();
            List<int> BValueList = new List<int>();
            for (int l = -radiusY; l <= radiusY; ++l)
            {
                for (int k = -radiusX; k <= radiusX; ++k)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    RValueList.Add(sourceImage.GetPixel(idX, idY).R);
                    GValueList.Add(sourceImage.GetPixel(idX, idY).G);
                    BValueList.Add(sourceImage.GetPixel(idX, idY).B);
                }
            }
            RValueList.Sort();
            GValueList.Sort();
            BValueList.Sort();
            Color medianFilterResult = Color.FromArgb(RValueList[RValueList.Count / 2], GValueList[GValueList.Count / 2], BValueList[BValueList.Count / 2]);
            return medianFilterResult;
        }
    }
}
