using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtermap
{
    class msb
    {
        public static Bitmap embed(Bitmap bmp)
        {
           

            // hold pixel elements
            int R = 0, G = 0, B = 0;


            // pass through the rows
            for (int i = 0; i < bmp.Height; i++)
            {
                // pass through each row
                for (int j = 0; j < bmp.Width; j++)
                {
                    // holds the pixel that is currently being processed
                    Color pixel = bmp.GetPixel(j, i);

                    // now, clear the least significant bit (LSB) from each pixel element
                    R = pixel.R - pixel.R % 2;
                    G = pixel.G;
                    B = pixel.B;
                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            return bmp;
        } 
    }
}