using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtermap
{
    class zigzag
    {
     Bitmap block;
    Bitmap block2;
         

        public Bitmap[,] traverse(Bitmap[,] inarr, int l1, int l2)
        {
            int d = -1;

            int i = 0;
            int j = 0;
            int i_prev = 0;
            int j_prev = 0;

            for (int k = 0; k <= inarr.GetLength(0); k++)
            {

                for (int l = 0; l < inarr.GetLength(1); l++)
                {


                    /*   i = i + 1;
                       j = j + 1;

                    */

                    i += d;
                       j -= d;
                       if (i < 0)
                       {
                           i++;
                           d = -d;
                       }
                       else if (j < 0)
                       {
                           j++;
                           d = -d;

                       }
                    /* Console.WriteLine("i="+(i));
                     Console.WriteLine("j="+(j));
                     Console.WriteLine("i_prev=" + (i_prev));
                     Console.WriteLine("j_prev=" + (j_prev));*/
                    toexchange(inarr, i, j, i_prev, j_prev, l1, l2);
                    i_prev = i;
                    j_prev = j;




                }



            }
            return inarr;


        }

        public void toexchange(Bitmap[,] a, int k, int l, int k_prev, int l_prev, int l1, int l2)
        {

            //block[k,l] = a[k, l];

            try
            {
                block = a[k, l];
                block2 = a[k_prev, l_prev];
            }
            catch (Exception e)
            {
                e.ToString();
            }




          //  exchnge.exchngeblocks(block, block2, a, k_prev, l_prev, l1, l2);
        }
    }
}
