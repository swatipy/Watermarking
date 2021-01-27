using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtermap
{
    class lsbpartition
    {
        //retraverse re = new retraverse();
        public Bitmap[,] split(Bitmap source)
        {
             Bitmap[,] bmps;
           int widthsix = (int)((double)source.Width / 8);
            int heightsix = (int)((double)source.Height / 8);
            bmps = new Bitmap[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    bmps[i, j] = new Bitmap(widthsix, heightsix);
                    Graphics g = Graphics.FromImage(bmps[i, j]);
                    g.DrawImage(source, new Rectangle(0, 0, widthsix, heightsix), new Rectangle(j * widthsix, i * heightsix, widthsix, heightsix), GraphicsUnit.Pixel);
                    g.Dispose();
                }
            }
         //re.traverse(bmps, widthsix, heightsix);
            return bmps;
            }
        }


    }
