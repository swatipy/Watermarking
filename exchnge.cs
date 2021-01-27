using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtermap
{
    class exchnge
    {


        public static Bitmap exchngeblocks(Bitmap b1, Bitmap b2)
        {
            int l1=32, l2 = 32;
            Display d = new Display();
            int[,] a1 = bitttoarr.change(b1);
            int[,] a2 = bitttoarr.change(b2);
            for (int i = l1 / 2; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {

               //  int temp = a1[i, j];
                    a1[i, j] = a2[i,j]; 
              // a2[i, j] = temp;

                }
            }
            
                Bitmap output = d.Displayimage(a1);
                //inarr[k, l] = output;

            

            return output;

        }
    }
}