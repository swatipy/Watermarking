using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;

namespace Filtermap
{
    class Extbitmap
    {



        public static Bitmap Convolute(Bitmap input)
        {
            Bitmap Obj;
            int Width, Height;
            int[,] inimg;
            int[,] outimg;
            Obj = input;
            Width = Obj.Width;
            Height = Obj.Height;
            inimg = extract.extractimg(input);
            outimg = new int[Width, Height];
            int[,] log = { { 0, -1, 0 }, { -1,4,-1 }, { 0, -1, 0 } };
            int kcols = 3, krows = 3;
            int kcenx = kcols / 2;
            int kceny = krows / 2;
          

            for (int i = 0; i < inimg.GetLength(0); i++)
            {

                for (int j = 0; j < inimg.GetLength(1); j++)
                {
                    for (int m = 0; m < krows; m++)//kernel rows
                    {
                        int mm = krows - 1 - m;//row index of flipped  kernel
                        for (int n = 0; n < kcols; n++)//kernel columns
                        {
                            int nn = kcols - 1 - n;//column index of flipped  kernel
                            int ii = i + (m - kceny);
                            int jj = j + (n - kcenx);
                            if (ii < 0)
                                ii = ii + 1;
                            if (jj < 0)
                                jj = jj + 1;
                            if (ii >= krows)
                                ii = ii - 1;
                            if (jj >= kcols)
                                jj = jj - 1;
                            if (ii >= 0 && ii < inimg.GetLength(0) && jj >= 0 && jj < inimg.GetLength(1))
                            {
                                
                                outimg[i, j] += inimg[ii, jj] * log[mm, nn];
                                
                            }
                        }
                    }
                }
            }
            
         

            Bitmap final = Reverse.Reversetobmp(outimg);



            return final;
        }
    }
}
