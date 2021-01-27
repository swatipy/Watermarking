using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;

namespace Filtermap
{
    class divide
    {

        
        
        Bitmap[,] bmps;
        public Bitmap[,] split(Bitmap source)
        {
           int widthsix = (int)((double)source.Width /8.0);
            int heightsix = (int)((double)source.Height / 8.0 );
            bmps = new Bitmap[8,8];
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
       //zig.traverse(bmps, widthsix, heightsix);//Exchanging 
            return bmps;
            }
        }



       
           
        }
    

