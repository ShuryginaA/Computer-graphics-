using System;
using System.ComponentModel;
using System.Drawing;

namespace img_processing
{
    class GrayWorld:Filters
    {
        public override Bitmap processImg(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resImg = new Bitmap(sourceImage.Width, sourceImage.Height);
            int avgR = 0, avgG = 0, avgB = 0;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resImg.Width * 50));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    avgR += color.R;
                    avgG += color.G;
                    avgB += color.B;
                }
            }
            avgR = Clamp(avgR / (sourceImage.Width *sourceImage.Height), 0, 255);
            avgG = Clamp(avgG / (sourceImage.Width *sourceImage.Height), 0, 255);
            avgB = Clamp(avgB / (sourceImage.Width*sourceImage.Height), 0, 255);
            int avg = Clamp((avgR + avgG + avgB) / 3, 0, 255);
            
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress(50 + (int)((float)i / resImg.Width * 50));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    int resR = Clamp((int)((float)color.R * avg / avgR), 0, 255);
                    int resG = Clamp((int)((float)color.G * avg / avgG), 0, 255);
                    int resB = Clamp((int)((float)color.B * avg / avgB), 0, 255);
                    resImg.SetPixel(i, j, Color.FromArgb(resR, resG, resB));
                }
            }
            return resImg;
        }

        protected override Color calcNewPixColor(Bitmap sourceImg, int i, int j)
        {
            throw new NotImplementedException();
        }
    }
}
