using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;


namespace Filtermap
{
    class extract
    {
        public static  int[,] extractimg(Bitmap img)
        {
            int[,] output;
            int wh;
            wh = img.Width;
            int he=img.Height;
            output = new int[wh,he];
            int pixvalue = 0;
            
            for (int i = 0; i < img.Height; i++)
            {
                // pass through each row
                for (int j = 0; j < img.Width; j++)
                {
                    Color pixel = img.GetPixel(j, i);
                   

                    pixvalue = pixvalue + pixel.R;
                    output[j,i] = pixvalue;
                    pixvalue = 0;
                   
                }
            }
            return output;
        }
    }
}