using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtermap
{
    class blockembed
    {
        public static Bitmap hideblocks(bool[]  arr, Bitmap bmp)
        {
           
            
          int p=0;

         // pass through the rows
            for (int i = 0; i < bmp.Width ; i++)
            {
                // pass through each row
                for (int j = 0; j < bmp.Height; j++)
                {
                    // pass through each row
                    

                        int R = 0, G = 0, B = 0;
                        // holds the pixel that is currently being processed
                        Color pixel = bmp.GetPixel(i, j);

                        G = pixel.G;
                        B = pixel.B;




                        try
                        {
                            if (arr[p]== true)
                            {
                                R = pixel.R | 1;
                            }
                            else
                                R = pixel.R - pixel.R % 2;

                        }
                        catch (Exception e)
                        {
                            e.ToString();
                        }
                        bmp.SetPixel(i, j, Color.FromArgb(R, G, B));

                        p++;



                    }
                }
              

           
            return bmp;
        }

        public static Bitmap extractImg(Bitmap bmp)
        {
           
            int boolindex = 0;
            Display d = new Display();
            int wh;
            wh = bmp.Width * bmp.Height;
            int[,] img;

            bool[] outarr = new bool[wh];

            // pass through the rows
             // pass through each row
            for (int i = 0; i < bmp.Width; i++)
            {
                // pass through each row
                for (int j = 0; j < bmp.Height; j++)
                {

                    Color pixel = bmp.GetPixel(i, j);
                    int lsb = pixel.R %2;

                    if (lsb == 1)
                        outarr[boolindex] = true;
                    else
                        outarr[boolindex] = false;
                    boolindex++;


                }
            }
            img = conversion.intarray(outarr);
            return extrctbmp.extract(img);



        }
    }
}
