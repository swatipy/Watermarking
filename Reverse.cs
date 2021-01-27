using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
namespace Filtermap
{
    class Reverse
    {
        public static Bitmap Reversetobmp(int[,] inimg) {
        int R = 0, G = 0, B = 0;
       
            Bitmap bi = new Bitmap(inimg.GetLength(0), inimg.GetLength(1));
       
            for (int i = 0; i < bi.Height; i++)
            {
                for (int j = 0; j < bi.Width; j++)
                {
                    Color pixel = bi.GetPixel(i, j);


                    try
                    {

                        if (inimg[j, i] < 0)
                        {
                            if (j + 1 < 256 && j - 1 >= 0 && i + 1 < 256 && i - 1 >= 0)
                            {
                                if (inimg[j + 1, i] > 0 && inimg[j - 1, i] > 0 && inimg[j, i + 1] > 0 && inimg[j, i - 1] > 0)

                                    inimg[j, i] = 1;
                                else
                                    inimg[j, i] = 0;
                            }
                            else
                            {

                                inimg[j, i] = 0;
                            }

                        }






                    }
                    catch (Exception e)
                    {
                        e.ToString();
                    }
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
       
    


