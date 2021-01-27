using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtermap
{
    class conversion
    {
        public static bool[] boolarray(int[] txt)
        {
            bool[] arr = new bool[1024];
            int i = 0;

            for (int k = 0; k < 1024; k++)
            {


                if (txt[i] == 0)
                {
                    arr[k] = false;
                }

                else
                {
                    arr[k] = true;

                }

                i++;
            }
            return arr;
        }
        public static int[,] intarray(bool[] b)
        {
            int[] arr = new int[1024];
            int i = 0;
            for (int k = 0; k <1024; k++)
            {
                if (b[i] == false)
                    arr[k] =0 ;
                else
                    arr[k] =255;
                i++;
            }

            int j, m;
            int[,] img = new int[32, 32];
            int Height =32;
            for (int l = 0; l < arr.Length; l++)
            {
                j = l % Height;
                m = (int)(l / Height);
                img[m, j] = arr[l];

            }
            return img;
        }
        public static Bitmap[,] bmparray(Bitmap[] b)
        {
            

          
            Bitmap[,] img = new Bitmap[8,8];

            int k = 0;


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    img[i, j] = b[k];
                    k++;
                }
            }
            return img;
        }
    }
}