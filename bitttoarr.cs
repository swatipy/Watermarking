using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtermap
{
    class bitttoarr
    {
        public static int[,] change(Bitmap inimg)
        {

            Bitmap Obj = inimg; ;
            int Width = Obj.Width;
            int Height = Obj.Height;
            int i, j;
            int[,] arr1 = new int[Width, Height];  //[Row,Column]
            int[,] arr2 = new int[Width, Height];  //[Row,Column]

            Bitmap image = Obj;
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                     ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* imagePointer1 = (byte*)bitmapData1.Scan0;

                for (i = 0; i < bitmapData1.Height; i++)
                {
                    for (j = 0; j < bitmapData1.Width; j++)
                    {
                        arr1[j, i] = (int)((imagePointer1[0] + imagePointer1[1] + imagePointer1[2]) / 3.0);
                        arr2[j, i] = (int)arr1[j, i];
                        //4 bytes per pixel
                        imagePointer1 += 4;
                    }//end for j
                    //4 bytes per pixel
                    imagePointer1 += bitmapData1.Stride - (bitmapData1.Width * 4);
                }//end for i
            }//end unsafe
            image.UnlockBits(bitmapData1);

            return arr2;
        }
    }
}
