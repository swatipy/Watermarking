using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtermap
{
    class extrctbmp
    {
        public static Bitmap extract(int[,] inimg)
        {
            int R = 0, G = 0, B = 0;

            Bitmap bi = new Bitmap(inimg.GetLength(0), inimg.GetLength(1));

            for (int j = 0; j < bi.Width; j++)
            {
                for (int i = 0; i < bi.Height; i++)
                {
                    Color pixel = bi.GetPixel(j, i);

                  

                    R = inimg[j, i];
                    G = inimg[j, i];
                    B = inimg[j, i];
                    if (B > 0)
                        B = 255;
                    else if (B <= 0)
                        B = 0;
                    if (G > 0)
                        G = 255;
                    else if (G <= 0)
                        G = 0;
                    if (R > 0)
                        R = 255;
                    else if (R <= 0)
                        R = 0;

                    bi.SetPixel(j, i, Color.FromArgb(R, G, B));

                }
            }


            return bi;
        }
    }
}
