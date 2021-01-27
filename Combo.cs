using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtermap
{
    class Combo
    {
        public static Bitmap combine(Bitmap[,] bmps)
        {

            int widthsix = 32;
          int heightsix = 32;
            int width=256;
            int height=256;
            Bitmap bmp = new Bitmap(width, height);
            for (int i = 0; i <8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                   
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(bmps[i,j],  new Rectangle(j * widthsix, i * heightsix, widthsix, heightsix),new Rectangle(0, 0, widthsix, heightsix), GraphicsUnit.Pixel);
                    g.Dispose();
                }
            }
            







            return bmp;




        }
    }
}
