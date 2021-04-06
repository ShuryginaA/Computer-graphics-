using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_processing
{
    class sharpnessFilter
    {
        public sharpnessFilter()
        {
            int m = 3;
            int n = 3;
            kernel = new float[m, n];
            kernel[0, 0] = kernel[0, 2] = kernel[2, 0] = kernel[2, 2] = 0;
            kernel[0, 1] = kernel[1, 0] = kernel[1, 2] = kernel[2, 1] = -1;
            kernel[1, 1] = 5;
        }
    }
}
