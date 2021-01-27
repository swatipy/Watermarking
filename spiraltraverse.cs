using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtermap
{
    class spiraltraverse
    {
        Bitmap block;
        Bitmap block2;
        public  void traverse(Bitmap[,] inarr, int l1, int l2)
        {
            int k = 0;
            int i = 0;
            int k_prev = 0;
            int i_prev = 0;
            int m = inarr.GetLength(0);
            int n = inarr.GetLength(1);
            int l = 0;
            while (k < m && l < n)
            {
                for (i = l; i < n; ++i)
                {
                    toexchange(inarr, k, i, k_prev, i_prev, l1, l2);
                    k_prev = k;
                    i_prev = i;

                }
                k++;
                for (i = k; i < m; ++i)
                {
                    toexchange(inarr, i, n-1, k_prev, i_prev, l1, l2);
                }
                n--;
                if (k < m)
                {
                    for (i = n - 1; i >= 1; ++i)
                    {
                        toexchange(inarr,m-1,i ,k_prev, i_prev, l1, l2);
                    }
                    m--;
                }
                m--;
                if (l < n)
                {
                    for (i = m- 1; i >= k; --i)
                    {
                        toexchange(inarr,  i,l, k_prev, i_prev, l1, l2);
                    }
                    l++;
                }
            }
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




           // exchnge.exchngeblocks(block, block2, a, k, l, l1, l2);
        }
    }
}