using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtermap
{
    class Result
    {
        
       
            public static Bitmap difference(Bitmap b1, Bitmap b2)
        {
            Bitmap final = new Bitmap(b1.Width, b1.Height);
            int G = 0;
            int B = 0;
            int R = 0;
            for (int i = 0; i < b1.Width; i++)
            {
                for (int j = 0; j < b1.Height; j++)
                {

                    Color finalpixel = final.GetPixel(i, j);

                    try
                    {
                        Color pixel = b1.GetPixel(i, j);
                        Color pixel1 = b2.GetPixel(i, j);

                        G =finalpixel.G; ;
                        B = finalpixel.B;

                        if (pixel1.R == pixel.R)
                            R = 0;
                        else
                            R = 255;
                            

                            final.SetPixel(i, j, Color.FromArgb(R, G, B));

                    }
                    catch (Exception e)
                    {
                        e.ToString();
                    }
                     
                }
            }
            return final;
}
        }
    }
