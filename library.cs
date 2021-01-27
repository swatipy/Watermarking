﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtermap
{
    class library
    {
        public static byte[] DecodeHex(string hextext)
        {
            String[] arr = hextext.Split('-');
            byte[] array = new byte[arr.Length];
            try
            {
                for (int i = 0; i < arr.Length; i++)
                    array[i] = Convert.ToByte(arr[i], 16);
               
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return array;
        }

        public static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number % 2 == 0) return (number == 2);
            int root = (int)Math.Sqrt((double)number);
            for (int i = 3; i <= root; i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        public static Bitmap ConvertByteToImage(byte[] bytes)
        {
            
               Bitmap  b = new Bitmap(Image.FromStream(new MemoryStream(bytes)));
           
            return b;
        }

        public static byte[] ConvertImageToByte(Image My_Image)
        {
            MemoryStream m1 = new MemoryStream();
            new Bitmap(My_Image).Save(m1, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] header = new byte[] { 255, 216 };
            header = m1.ToArray();
            return (header);
        }
    }
}
