  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;

namespace Filtermap
{
    class Filtermapp
    {

        public static Bitmap embedImg(int[] text, Bitmap bmp)
        {
            
            int pixIndex = 0;

            // holds the value of the pixel 
            int pixValue = 0;

            // holds the index of the color element (R or G or B) that is currently being processed
            long pixelElementIndex = 0;

            // holds the number of trailing zeros that have been added when finishing the process
            int zeros = 0;

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
                    G = pixel.G - pixel.G % 2;
                    B = pixel.B - pixel.B % 2;
                    for (int n = 0; n < 3; n++)
                    {
                        // check if new 8 bits has been processed
                        if (pixelElementIndex % 8 == 0)
                        {



                            if (pixIndex < text.Length)
                            {
                                pixValue = text[pixIndex++];
                            }

                        }

                        // check which pixel element has the turn to hide a bit in its LSB
                        switch (pixelElementIndex % 3)
                        {
                            case 0:
                                {

                                    // the rightmost bit in the character will be (charValue % 2)
                                    // to put this value instead of the LSB of the pixel element
                                    // just add it to it
                                    // recall that the LSB of the pixel element had been cleared
                                    // before this operation
                                    R += pixValue % 2;

                                    // removes the added rightmost bit of the character
                                    // such that next time we can reach the next one
                                    pixValue /= 2;

                                } break;
                            case 1:
                                {

                                    G += pixValue % 2;

                                    pixValue /= 2;

                                } break;
                            case 2:
                                {

                                    B += pixValue % 2;

                                    pixValue /= 2;


                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                } break;
                        }

                        pixelElementIndex++;


                    }
                }
            }

            return bmp;
        }

        public static int[] extractImg(Bitmap bmp, int width, int height)
        {
            int colorUnitIndex = 0;
            int pixValue = 0;
            int[] output;
            int wh;
            wh = width * height;
            output = new int[wh];
            int inx = 0;


            // pass through the rows
            for (int i = 0; i < bmp.Height; i++)
            {
                // pass through each row
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);

                    // for each pixel, pass through its elements (RGB)
                    for (int n = 0; n < 3; n++)
                    {
                        switch (colorUnitIndex % 3)
                        {
                            case 0:
                                {
                                    // get the LSB from the pixel element (will be pixel.R % 2)
                                    // then add one bit to the right of the current character
                                    // this can be done by (charValue = charValue * 2)
                                    // replace the added bit (which value is by default 0) with
                                    // the LSB of the pixel element, simply by addition
                                    pixValue = pixValue * 2 + pixel.R % 2;
                                } break;
                            case 1:
                                {
                                    pixValue = pixValue * 2 + pixel.G % 2;
                                } break;
                            case 2:
                                {
                                    pixValue = pixValue * 2 + pixel.B % 2;
                                } break;
                        }

                        colorUnitIndex++;

                        // if 8 bits has been added, then add the current character to the result text
                        if (colorUnitIndex % 8 == 0)
                        {
                            // reverse? of course, since each time the process happens on the right (for simplicity)
                            pixValue = reverseBits(pixValue);

                            // can only be 0 if it is the stop character (the 8 zeros)
                            if (inx == wh)
                            {
                                return output;
                            }

                            // convert the character value from int to char
                            output[inx] = pixValue;
                            inx++;
                            // add the current character to the result text
                            //extractedText += c.ToString();
                        }
                    }
                    // pixValue = 0;
                }
            }

            return output;
        }

        public static int reverseBits(int n)
        {
            int result = 0;

            for (int i = 0; i < 8; i++)
            {
                result = result * 2 + n % 2;

                n /= 2;
            }

            return result;
        }
    }
}
