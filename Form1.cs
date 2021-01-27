using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Filtermap
{
    public partial class Form1 : Form
    {
        Bitmap embedimage;
        Bitmap outputimg;
        Bitmap[,] bmpimg;
        Bitmap[,] finalimg;
        private Bitmap bmp;
        bool[] extractbool = new bool[65536];
        public Bitmap outimg;
        public int[,] img;
        int[] txt;
        Bitmap[,] comboimg;
        Bitmap[,] eximage;
        Bitmap[,] extimage;
        Bitmap[,] blendimg;
        Bitmap[,] logimg;
        Bitmap inimg;
        Bitmap n_img;


        divide div = new divide();
        divide div1 = new divide();
        lsbpartition lp = new lsbpartition();
        retraverse rt = new retraverse();
        zigzag zig = new zigzag();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }





        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files (*.jpeg; *.png; *.bmp)|*.jpg; *.png; *.bmp";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                inimg = (Bitmap)Image.FromFile(open_dialog.FileName);
                pictureBox1.Image = (Bitmap)inimg;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            n_img=CreateNonIndexedImage(inimg);
            Bitmap msbimg = msb.embed((Bitmap)n_img);
            pictureBox2.Image = Extbitmap.Convolute((Bitmap)msbimg);


            MessageBox.Show("Convolution Done!");
        }

        public Bitmap CreateNonIndexedImage(Image src)
        {
        Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

        using (Graphics gfx = Graphics.FromImage(newBmp)) {
        gfx.DrawImage(src, 0, 0);
        }

        return newBmp;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            logimg = div.split((Bitmap)pictureBox2.Image);
            Bitmap[] zimg = new Bitmap[64];
            Bitmap[] zout = new Bitmap[64];
            int k = 0;
            // bmpimg = zig.traverse(logimg, 43, 43);
            for (int i = 0; i < logimg.GetLength(0); i++)
            {
                for (int j = 0; j < logimg.GetLength(0); j++)
                {
                    //bmpimg[Tables.ZigZag[i, j]] = logimg[i, j];
                    zimg[k] = logimg[i, j];
                    k++;
                }

            }
            /*  for (int l = 0; l < logimg.GetLength(0); l++)
              {

                  zout[Tables.ZigZag[l]] = zimg[l];
              }*/
            /*  int l = 0;
            
                  for (int z = 0; z < 36; z++)
                  {
                      if(z<35)*/
            //zout[l]= exchnge.exchngeblocks(zimg[Tables.ZigZag[z]], zimg[Tables.ZigZag[z + 1]]);
            // pictureBox3.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[1]], zimg[Tables.ZigZag[2]]);
            /*     else
                      pictureBox3.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[z]], zimg[Tables.ZigZag[0]]);

                  l++;
              }*/


            //   bmpimg=conversion.bmparray(zout);
            /* pictureBox3.Image = zimg[0];
             pictureBox6.Image = zimg[1];
             pictureBox7.Image = zimg[2];
             pictureBox8.Image = zimg[3];
             pictureBox9.Image = zimg[4];
             pictureBox10.Image = zimg[5];
             pictureBox11.Image = zimg[6];
             pictureBox12.Image = zimg[7];
             pictureBox13.Image = zimg[8];
             pictureBox14.Image = zimg[9];*/

            pictureBox3.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[0]], zimg[Tables.ZigZag[1]]);
            pictureBox6.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[1]], zimg[Tables.ZigZag[2]]);
            pictureBox13.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[2]], zimg[Tables.ZigZag[3]]);
            pictureBox21.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[3]], zimg[Tables.ZigZag[4]]);
            pictureBox14.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[4]], zimg[Tables.ZigZag[5]]);
            pictureBox7.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[5]], zimg[Tables.ZigZag[6]]);
            pictureBox8.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[6]], zimg[Tables.ZigZag[7]]);
            pictureBox15.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[7]], zimg[Tables.ZigZag[8]]);
            pictureBox22.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[8]], zimg[Tables.ZigZag[9]]);
            pictureBox29.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[9]], zimg[Tables.ZigZag[10]]);
            pictureBox37.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[10]], zimg[Tables.ZigZag[11]]);
            pictureBox30.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[11]], zimg[Tables.ZigZag[12]]);
            pictureBox23.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[12]], zimg[Tables.ZigZag[13]]);
            pictureBox16.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[13]], zimg[Tables.ZigZag[14]]);
            pictureBox9.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[14]], zimg[Tables.ZigZag[15]]);
            pictureBox10.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[15]], zimg[Tables.ZigZag[16]]);
            pictureBox17.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[16]], zimg[Tables.ZigZag[17]]);
            pictureBox24.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[17]], zimg[Tables.ZigZag[18]]);
            pictureBox31.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[18]], zimg[Tables.ZigZag[19]]);
            pictureBox38.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[19]], zimg[Tables.ZigZag[20]]);
            pictureBox45.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[20]], zimg[Tables.ZigZag[21]]);
            pictureBox53.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[21]], zimg[Tables.ZigZag[22]]);
            pictureBox46.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[22]], zimg[Tables.ZigZag[23]]);
            pictureBox39.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[23]], zimg[Tables.ZigZag[24]]);
            pictureBox32.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[24]], zimg[Tables.ZigZag[25]]);
            pictureBox25.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[25]], zimg[Tables.ZigZag[26]]);
            pictureBox18.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[26]], zimg[Tables.ZigZag[27]]);
            pictureBox11.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[27]], zimg[Tables.ZigZag[28]]);
            pictureBox12.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[28]], zimg[Tables.ZigZag[29]]);
            pictureBox19.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[29]], zimg[Tables.ZigZag[30]]);
            pictureBox26.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[30]], zimg[Tables.ZigZag[31]]);
            pictureBox33.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[31]], zimg[Tables.ZigZag[32]]);
            pictureBox40.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[32]], zimg[Tables.ZigZag[33]]);
            pictureBox47.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[33]], zimg[Tables.ZigZag[34]]);
            pictureBox54.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[34]], zimg[Tables.ZigZag[35]]);
            pictureBox61.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[35]], zimg[Tables.ZigZag[36]]);
            pictureBox62.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[36]], zimg[Tables.ZigZag[37]]);
            pictureBox55.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[37]], zimg[Tables.ZigZag[38]]);
            pictureBox48.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[38]], zimg[Tables.ZigZag[39]]);
            pictureBox41.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[39]], zimg[Tables.ZigZag[40]]);
            pictureBox34.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[40]], zimg[Tables.ZigZag[41]]);
            pictureBox27.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[41]], zimg[Tables.ZigZag[42]]);
            pictureBox20.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[42]], zimg[Tables.ZigZag[43]]);

            pictureBox28.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[43]], zimg[Tables.ZigZag[44]]);
            pictureBox35.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[44]], zimg[Tables.ZigZag[45]]);
            pictureBox42.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[45]], zimg[Tables.ZigZag[46]]);
            pictureBox49.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[46]], zimg[Tables.ZigZag[47]]);
            pictureBox56.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[47]], zimg[Tables.ZigZag[48]]);
            pictureBox63.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[48]], zimg[Tables.ZigZag[49]]);
            pictureBox64.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[49]], zimg[Tables.ZigZag[50]]);
            pictureBox57.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[50]], zimg[Tables.ZigZag[51]]);
            pictureBox50.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[51]], zimg[Tables.ZigZag[52]]);
            pictureBox43.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[52]], zimg[Tables.ZigZag[53]]);
            pictureBox36.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[53]], zimg[Tables.ZigZag[54]]);
            pictureBox44.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[54]], zimg[Tables.ZigZag[55]]);
            pictureBox51.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[55]], zimg[Tables.ZigZag[56]]);
            pictureBox58.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[56]], zimg[Tables.ZigZag[57]]);
            pictureBox65.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[57]], zimg[Tables.ZigZag[58]]);
            pictureBox66.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[58]], zimg[Tables.ZigZag[59]]);
            pictureBox59.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[59]], zimg[Tables.ZigZag[60]]);
            pictureBox52.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[60]], zimg[Tables.ZigZag[61]]);
            pictureBox60.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[61]], zimg[Tables.ZigZag[62]]);
            pictureBox68.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[62]], zimg[Tables.ZigZag[63]]);
            pictureBox67.Image = exchnge.exchngeblocks(zimg[Tables.ZigZag[63]], zimg[Tables.ZigZag[0]]);
        }







        private void button9_Click(object sender, EventArgs e)
        {
            //Decoded feature
            bmp = (Bitmap)pictureBox133.Image;
            Bitmap msbimg = msb.embed((Bitmap)bmp);
            pictureBox200.Image = Extbitmap.Convolute((Bitmap)msbimg);


        }






        private void button6_Click(object sender, EventArgs e)
        {

            //Embedding the watermark
            Read read = new Read((Bitmap)pictureBox3.Image);
            txt = read.straight();
            Read read1 = new Read((Bitmap)pictureBox6.Image);
            int[] txt1 = read1.straight();
            Read read2 = new Read((Bitmap)pictureBox7.Image);
            int[] txt2 = read2.straight();
            Read read3 = new Read((Bitmap)pictureBox8.Image);
            int[] txt3 = read3.straight();
            Read read4 = new Read((Bitmap)pictureBox9.Image);
            int[] txt4 = read4.straight();
            Read read5 = new Read((Bitmap)pictureBox10.Image);
            int[] txt5 = read5.straight();
            Read read6 = new Read((Bitmap)pictureBox11.Image);
            int[] txt6 = read6.straight();
            Read read7 = new Read((Bitmap)pictureBox12.Image);
            int[] txt7 = read7.straight();
            Read read8 = new Read((Bitmap)pictureBox13.Image);
            int[] txt8 = read8.straight();
            Read read9 = new Read((Bitmap)pictureBox14.Image);
            int[] txt9 = read9.straight();
            Read read10 = new Read((Bitmap)pictureBox15.Image);
            int[] txt10 = read10.straight();
            Read read11 = new Read((Bitmap)pictureBox16.Image);
            int[] txt11 = read11.straight();
            Read read12 = new Read((Bitmap)pictureBox17.Image);
            int[] txt12 = read12.straight();
            Read read13 = new Read((Bitmap)pictureBox18.Image);
            int[] txt13 = read13.straight();
            Read read14 = new Read((Bitmap)pictureBox19.Image);
            int[] txt14 = read14.straight();
            Read read15 = new Read((Bitmap)pictureBox20.Image);
            int[] txt15 = read15.straight();
            Read read16 = new Read((Bitmap)pictureBox21.Image);
            int[] txt16 = read16.straight();
            Read read17 = new Read((Bitmap)pictureBox22.Image);
            int[] txt17 = read17.straight();
            Read read18 = new Read((Bitmap)pictureBox23.Image);
            int[] txt18 = read18.straight();
            Read read19 = new Read((Bitmap)pictureBox24.Image);
            int[] txt19 = read19.straight();
            Read read20 = new Read((Bitmap)pictureBox25.Image);
            int[] txt20 = read20.straight();
            Read read21 = new Read((Bitmap)pictureBox26.Image);
            int[] txt21 = read21.straight();
            Read read22 = new Read((Bitmap)pictureBox27.Image);
            int[] txt22 = read22.straight();
            Read read23 = new Read((Bitmap)pictureBox28.Image);
            int[] txt23 = read23.straight();
            Read read24 = new Read((Bitmap)pictureBox29.Image);
            int[] txt24 = read24.straight();
            Read read25 = new Read((Bitmap)pictureBox30.Image);
            int[] txt25 = read25.straight();
            Read read26 = new Read((Bitmap)pictureBox31.Image);
            int[] txt26 = read26.straight();
            Read read27 = new Read((Bitmap)pictureBox32.Image);
            int[] txt27 = read27.straight();
            Read read28 = new Read((Bitmap)pictureBox33.Image);
            int[] txt28 = read28.straight();
            Read read29 = new Read((Bitmap)pictureBox34.Image);
            int[] txt29 = read29.straight();
            Read read30 = new Read((Bitmap)pictureBox35.Image);
            int[] txt30 = read30.straight();
            Read read31 = new Read((Bitmap)pictureBox36.Image);
            int[] txt31 = read31.straight();
            Read read32 = new Read((Bitmap)pictureBox37.Image);
            int[] txt32 = read32.straight();
            Read read33 = new Read((Bitmap)pictureBox38.Image);
            int[] txt33 = read33.straight();
            Read read34 = new Read((Bitmap)pictureBox39.Image);
            int[] txt34 = read34.straight();
            Read read35 = new Read((Bitmap)pictureBox40.Image);
            int[] txt35 = read35.straight();
            //Embedding the watermark
            Read read36 = new Read((Bitmap)pictureBox41.Image);
            int[] txt36 = read36.straight();
            Read read37 = new Read((Bitmap)pictureBox42.Image);
            int[] txt37 = read37.straight();
            Read read38 = new Read((Bitmap)pictureBox43.Image);
            int[] txt38 = read38.straight();
            Read read39 = new Read((Bitmap)pictureBox44.Image);
            int[] txt39 = read39.straight();
            Read read40 = new Read((Bitmap)pictureBox45.Image);
            int[] txt40 = read40.straight();
            Read read41 = new Read((Bitmap)pictureBox46.Image);
            int[] txt41 = read41.straight();
            Read read42 = new Read((Bitmap)pictureBox47.Image);
            int[] txt42 = read42.straight();
            Read read43 = new Read((Bitmap)pictureBox48.Image);
            int[] txt43 = read43.straight();
            Read read44 = new Read((Bitmap)pictureBox49.Image);
            int[] txt44 = read44.straight();
            Read read45 = new Read((Bitmap)pictureBox50.Image);
            int[] txt45 = read45.straight();
            Read read46 = new Read((Bitmap)pictureBox51.Image);
            int[] txt46 = read46.straight();
            Read read47 = new Read((Bitmap)pictureBox52.Image);
            int[] txt47 = read47.straight();
            Read read48 = new Read((Bitmap)pictureBox53.Image);
            int[] txt48 = read48.straight();
            Read read49 = new Read((Bitmap)pictureBox54.Image);
            int[] txt49 = read49.straight();
            Read read50 = new Read((Bitmap)pictureBox55.Image);
            int[] txt50 = read50.straight();
            Read read51 = new Read((Bitmap)pictureBox56.Image);
            int[] txt51 = read51.straight();
            Read read52 = new Read((Bitmap)pictureBox57.Image);
            int[] txt52 = read52.straight();
            Read read53 = new Read((Bitmap)pictureBox58.Image);
            int[] txt53 = read53.straight();
            Read read54 = new Read((Bitmap)pictureBox59.Image);
            int[] txt54 = read54.straight();
            Read read55 = new Read((Bitmap)pictureBox60.Image);
            int[] txt55 = read55.straight();
            Read read56 = new Read((Bitmap)pictureBox61.Image);
            int[] txt56 = read56.straight();
            Read read57 = new Read((Bitmap)pictureBox62.Image);
            int[] txt57 = read57.straight();
            Read read58 = new Read((Bitmap)pictureBox63.Image);
            int[] txt58 = read58.straight();
            Read read59 = new Read((Bitmap)pictureBox64.Image);
            int[] txt59 = read59.straight();
            Read read60 = new Read((Bitmap)pictureBox65.Image);
            int[] txt60 = read60.straight();
            Read read61 = new Read((Bitmap)pictureBox66.Image);
            int[] txt61 = read61.straight();
            Read read62 = new Read((Bitmap)pictureBox67.Image);
            int[] txt62 = read62.straight();
            Read read63 = new Read((Bitmap)pictureBox68.Image);
            int[] txt63 = read63.straight();

            List<bool[]> ll = new List<bool[]>();
            bool[] arr = conversion.boolarray(txt);
            bool[] arr1 = conversion.boolarray(txt1);
            bool[] arr2 = conversion.boolarray(txt2);
            bool[] arr3 = conversion.boolarray(txt3);
            bool[] arr4 = conversion.boolarray(txt4);
            bool[] arr5 = conversion.boolarray(txt5);
            bool[] arr6 = conversion.boolarray(txt6);
            bool[] arr7 = conversion.boolarray(txt7);
            bool[] arr8 = conversion.boolarray(txt8);
            bool[] arr9 = conversion.boolarray(txt9);
            bool[] arr10 = conversion.boolarray(txt10);
            bool[] arr11 = conversion.boolarray(txt11);
            bool[] arr12 = conversion.boolarray(txt12);
            bool[] arr13 = conversion.boolarray(txt13);
            bool[] arr14 = conversion.boolarray(txt14);
            bool[] arr15 = conversion.boolarray(txt15);
            bool[] arr16 = conversion.boolarray(txt16);
            bool[] arr17 = conversion.boolarray(txt17);
            bool[] arr18 = conversion.boolarray(txt18);
            bool[] arr19 = conversion.boolarray(txt19);
            bool[] arr20 = conversion.boolarray(txt20);
            bool[] arr21 = conversion.boolarray(txt21);
            bool[] arr22 = conversion.boolarray(txt22);
            bool[] arr23 = conversion.boolarray(txt23);
            bool[] arr24 = conversion.boolarray(txt24);
            bool[] arr25 = conversion.boolarray(txt25);
            bool[] arr26 = conversion.boolarray(txt26);
            bool[] arr27 = conversion.boolarray(txt27);
            bool[] arr28 = conversion.boolarray(txt28);
            bool[] arr29 = conversion.boolarray(txt29);
            bool[] arr30 = conversion.boolarray(txt30);
            bool[] arr31 = conversion.boolarray(txt31);
            bool[] arr32 = conversion.boolarray(txt32);
            bool[] arr33 = conversion.boolarray(txt33);
            bool[] arr34 = conversion.boolarray(txt34);
            bool[] arr35 = conversion.boolarray(txt35);
            bool[] arr36 = conversion.boolarray(txt36);
            bool[] arr37 = conversion.boolarray(txt37);
            bool[] arr38 = conversion.boolarray(txt38);
            bool[] arr39 = conversion.boolarray(txt39);
            bool[] arr40 = conversion.boolarray(txt40);
            bool[] arr41 = conversion.boolarray(txt41);
            bool[] arr42 = conversion.boolarray(txt42);
            bool[] arr43 = conversion.boolarray(txt43);
            bool[] arr44 = conversion.boolarray(txt44);
            bool[] arr45 = conversion.boolarray(txt45);
            bool[] arr46 = conversion.boolarray(txt46);
            bool[] arr47 = conversion.boolarray(txt47);
            bool[] arr48 = conversion.boolarray(txt48);
            bool[] arr49 = conversion.boolarray(txt49);
            bool[] arr50 = conversion.boolarray(txt50);
            bool[] arr51 = conversion.boolarray(txt51);
            bool[] arr52 = conversion.boolarray(txt52);
            bool[] arr53 = conversion.boolarray(txt53);
            bool[] arr54 = conversion.boolarray(txt54);
            bool[] arr55 = conversion.boolarray(txt55);
            bool[] arr56 = conversion.boolarray(txt56);
            bool[] arr57 = conversion.boolarray(txt57);
            bool[] arr58 = conversion.boolarray(txt58);
            bool[] arr59 = conversion.boolarray(txt59);
            bool[] arr60 = conversion.boolarray(txt60);
            bool[] arr61 = conversion.boolarray(txt61);
            bool[] arr62 = conversion.boolarray(txt62);
            bool[] arr63 = conversion.boolarray(txt63);




            ll.Add(arr);
            ll.Add(arr1);
            ll.Add(arr2);
            ll.Add(arr3);
            ll.Add(arr4);
            ll.Add(arr5);
            ll.Add(arr6);
            ll.Add(arr7);
            ll.Add(arr8);
            ll.Add(arr9);
            ll.Add(arr10);
            ll.Add(arr11);
            ll.Add(arr12);
            ll.Add(arr13);
            ll.Add(arr14);
            ll.Add(arr15);
            ll.Add(arr16);
            ll.Add(arr17);
            ll.Add(arr18);
            ll.Add(arr19);
            ll.Add(arr20);
            ll.Add(arr21);
            ll.Add(arr22);
            ll.Add(arr23);
            ll.Add(arr24);
            ll.Add(arr25);
            ll.Add(arr26);
            ll.Add(arr27);
            ll.Add(arr28);
            ll.Add(arr29);
            ll.Add(arr30);
            ll.Add(arr31);
            ll.Add(arr32);
            ll.Add(arr33);
            ll.Add(arr34);
            ll.Add(arr35);
            ll.Add(arr36);
            ll.Add(arr37);
            ll.Add(arr38);
            ll.Add(arr39);
            ll.Add(arr40);
            ll.Add(arr41);
            ll.Add(arr42);
            ll.Add(arr43);
            ll.Add(arr44);
            ll.Add(arr45);
            ll.Add(arr46);
            ll.Add(arr47);
            ll.Add(arr48);
            ll.Add(arr49);
            ll.Add(arr50);
            ll.Add(arr51);
            ll.Add(arr52);
            ll.Add(arr53);
            ll.Add(arr54);
            ll.Add(arr55);
            ll.Add(arr56);
            ll.Add(arr57);
            ll.Add(arr58);
            ll.Add(arr59);
            ll.Add(arr60);
            ll.Add(arr61);
            ll.Add(arr62);
            ll.Add(arr63);


            finalimg = lp.split((Bitmap)inimg);
            Bitmap[,] result = new Bitmap[8, 8];
            result[0, 0] = blockembed.hideblocks(ll.ElementAt(0), finalimg[0, 0]);
            result[0, 1] = blockembed.hideblocks(ll.ElementAt(1), finalimg[0, 1]);
            result[0, 2] = blockembed.hideblocks(ll.ElementAt(2), finalimg[0, 2]);
            result[0, 3] = blockembed.hideblocks(ll.ElementAt(3), finalimg[0, 3]);
            result[0, 4] = blockembed.hideblocks(ll.ElementAt(4), finalimg[0, 4]);
            result[0, 5] = blockembed.hideblocks(ll.ElementAt(5), finalimg[0, 5]);
            result[0, 6] = blockembed.hideblocks(ll.ElementAt(6), finalimg[0, 6]);
            result[0, 7] = blockembed.hideblocks(ll.ElementAt(7), finalimg[0, 7]);
            result[1, 0] = blockembed.hideblocks(ll.ElementAt(8), finalimg[1, 0]);
            result[1, 1] = blockembed.hideblocks(ll.ElementAt(9), finalimg[1, 1]);
            result[1, 2] = blockembed.hideblocks(ll.ElementAt(10), finalimg[1, 2]);
            result[1, 3] = blockembed.hideblocks(ll.ElementAt(11), finalimg[1, 3]);
            result[1, 4] = blockembed.hideblocks(ll.ElementAt(12), finalimg[1, 4]);
            result[1, 5] = blockembed.hideblocks(ll.ElementAt(13), finalimg[1, 5]);
            result[1, 6] = blockembed.hideblocks(ll.ElementAt(14), finalimg[1, 6]);
            result[1, 7] = blockembed.hideblocks(ll.ElementAt(15), finalimg[1, 7]);
            result[2, 0] = blockembed.hideblocks(ll.ElementAt(16), finalimg[2, 0]);
            result[2, 1] = blockembed.hideblocks(ll.ElementAt(17), finalimg[2, 1]);
            result[2, 2] = blockembed.hideblocks(ll.ElementAt(18), finalimg[2, 2]);
            result[2, 3] = blockembed.hideblocks(ll.ElementAt(19), finalimg[2, 3]);
            result[2, 4] = blockembed.hideblocks(ll.ElementAt(20), finalimg[2, 4]);
            result[2, 5] = blockembed.hideblocks(ll.ElementAt(21), finalimg[2, 5]);
            result[2, 6] = blockembed.hideblocks(ll.ElementAt(22), finalimg[2, 6]);
            result[2, 7] = blockembed.hideblocks(ll.ElementAt(23), finalimg[2, 7]);
            result[3, 0] = blockembed.hideblocks(ll.ElementAt(24), finalimg[3, 0]);
            result[3, 1] = blockembed.hideblocks(ll.ElementAt(25), finalimg[3, 1]);
            result[3, 2] = blockembed.hideblocks(ll.ElementAt(26), finalimg[3, 2]);
            result[3, 3] = blockembed.hideblocks(ll.ElementAt(27), finalimg[3, 3]);
            result[3, 4] = blockembed.hideblocks(ll.ElementAt(28), finalimg[3, 4]);
            result[3, 5] = blockembed.hideblocks(ll.ElementAt(29), finalimg[3, 5]);
            result[3, 6] = blockembed.hideblocks(ll.ElementAt(30), finalimg[3, 6]);
            result[3, 7] = blockembed.hideblocks(ll.ElementAt(31), finalimg[3, 7]);
            result[4, 0] = blockembed.hideblocks(ll.ElementAt(32), finalimg[4, 0]);
            result[4, 1] = blockembed.hideblocks(ll.ElementAt(33), finalimg[4, 1]);
            result[4, 2] = blockembed.hideblocks(ll.ElementAt(34), finalimg[4, 2]);
            result[4, 3] = blockembed.hideblocks(ll.ElementAt(35), finalimg[4, 3]);
            result[4, 4] = blockembed.hideblocks(ll.ElementAt(36), finalimg[4, 4]);
            result[4, 5] = blockembed.hideblocks(ll.ElementAt(37), finalimg[4, 5]);
            result[4, 6] = blockembed.hideblocks(ll.ElementAt(38), finalimg[4, 6]);
            result[4, 7] = blockembed.hideblocks(ll.ElementAt(39), finalimg[4, 7]);


            result[5, 0] = blockembed.hideblocks(ll.ElementAt(40), finalimg[5, 0]);
            result[5, 1] = blockembed.hideblocks(ll.ElementAt(41), finalimg[5, 1]);
            result[5, 2] = blockembed.hideblocks(ll.ElementAt(42), finalimg[5, 2]);
            result[5, 3] = blockembed.hideblocks(ll.ElementAt(43), finalimg[5, 3]);
            result[5, 4] = blockembed.hideblocks(ll.ElementAt(44), finalimg[5, 4]);
            result[5, 5] = blockembed.hideblocks(ll.ElementAt(45), finalimg[5, 5]);
            result[5, 6] = blockembed.hideblocks(ll.ElementAt(46), finalimg[5, 6]);
            result[5, 7] = blockembed.hideblocks(ll.ElementAt(47), finalimg[5, 7]);
            result[6, 0] = blockembed.hideblocks(ll.ElementAt(48), finalimg[6, 0]);
            result[6, 1] = blockembed.hideblocks(ll.ElementAt(49), finalimg[6, 1]);
            result[6, 2] = blockembed.hideblocks(ll.ElementAt(50), finalimg[6, 2]);
            result[6, 3] = blockembed.hideblocks(ll.ElementAt(51), finalimg[6, 3]);
            result[6, 4] = blockembed.hideblocks(ll.ElementAt(52), finalimg[6, 4]);
            result[6, 5] = blockembed.hideblocks(ll.ElementAt(53), finalimg[6, 5]);
            result[6, 6] = blockembed.hideblocks(ll.ElementAt(54), finalimg[6, 6]);
            result[6, 7] = blockembed.hideblocks(ll.ElementAt(55), finalimg[6, 7]);
            result[7, 0] = blockembed.hideblocks(ll.ElementAt(56), finalimg[7, 0]);
            result[7, 1] = blockembed.hideblocks(ll.ElementAt(57), finalimg[7, 1]);
            result[7, 2] = blockembed.hideblocks(ll.ElementAt(58), finalimg[7, 2]);
            result[7, 3] = blockembed.hideblocks(ll.ElementAt(59), finalimg[7, 3]);
            result[7, 4] = blockembed.hideblocks(ll.ElementAt(60), finalimg[7, 4]);
            result[7, 5] = blockembed.hideblocks(ll.ElementAt(61), finalimg[7, 5]);
            result[7, 6] = blockembed.hideblocks(ll.ElementAt(62), finalimg[7, 6]);
            result[7, 7] = blockembed.hideblocks(ll.ElementAt(63), finalimg[7, 7]);








            MessageBox.Show("Your image was hidden in the image successfully!", "Done");

            pictureBox69.Image = result[0, 0];
            pictureBox70.Image = result[0, 1];
            pictureBox71.Image = result[0, 2];
            pictureBox72.Image = result[0, 3];
            pictureBox73.Image = result[0, 4];
            pictureBox74.Image = result[0, 5];
            pictureBox75.Image = result[0, 6];
            pictureBox76.Image = result[0, 7];
            pictureBox77.Image = result[1, 0];
            pictureBox78.Image = result[1, 1];
            pictureBox79.Image = result[1, 2];
            pictureBox80.Image = result[1, 3];
            pictureBox81.Image = result[1, 4];
            pictureBox82.Image = result[1, 5];
            pictureBox83.Image = result[1, 6];
            pictureBox84.Image = result[1, 7];

            pictureBox85.Image = result[2, 0];
            pictureBox86.Image = result[2, 1];
            pictureBox87.Image = result[2, 2];
            pictureBox88.Image = result[2, 3];
            pictureBox89.Image = result[2, 4];
            pictureBox90.Image = result[2, 5];
            pictureBox91.Image = result[2, 6];
            pictureBox92.Image = result[2, 7];
            pictureBox93.Image = result[3, 0];
            pictureBox94.Image = result[3, 1];
            pictureBox95.Image = result[3, 2];
            pictureBox96.Image = result[3, 3];
            pictureBox97.Image = result[3, 4];
            pictureBox98.Image = result[3, 5];
            pictureBox99.Image = result[3, 6];
            pictureBox100.Image = result[3, 7];
            pictureBox101.Image = result[4, 0];
            pictureBox102.Image = result[4, 1];
            pictureBox103.Image = result[4, 2];
            pictureBox104.Image = result[4, 3];
            pictureBox105.Image = result[4, 4];
            pictureBox106.Image = result[4, 5];
            pictureBox107.Image = result[4, 6];
            pictureBox108.Image = result[4, 7];
            pictureBox109.Image = result[5, 0];
            pictureBox110.Image = result[5, 1];
            pictureBox111.Image = result[5, 2];
            pictureBox112.Image = result[5, 3];
            pictureBox113.Image = result[5, 4];
            pictureBox114.Image = result[5, 5];
            pictureBox115.Image = result[5, 6];
            pictureBox116.Image = result[5, 7];
            pictureBox117.Image = result[6, 0];
            pictureBox118.Image = result[6, 1];
            pictureBox119.Image = result[6, 2];
            pictureBox120.Image = result[6, 3];
            pictureBox121.Image = result[6, 4];
            pictureBox122.Image = result[6, 5];
            pictureBox123.Image = result[6, 6];
            pictureBox124.Image = result[6, 7];
            pictureBox125.Image = result[7, 0];
            pictureBox126.Image = result[7, 1];
            pictureBox127.Image = result[7, 2];
            pictureBox128.Image = result[7, 3];
            pictureBox129.Image = result[7, 4];
            pictureBox130.Image = result[7, 5];
            pictureBox131.Image = result[7, 6];
            pictureBox132.Image = result[7, 7];

            embedimage = Combo.combine(result);

            pictureBox133.Image = embedimage;

        }
        private void button5_Click(object sender, EventArgs e)
        {
            extimage = div1.split((Bitmap)pictureBox133.Image);


            List<Bitmap> ol = new List<Bitmap>();
            ol.Add(extimage[0, 0]);
            ol.Add(extimage[0, 1]);
            ol.Add(extimage[0, 2]);
            ol.Add(extimage[0, 3]);
            ol.Add(extimage[0, 4]);
            ol.Add(extimage[0, 5]);
            ol.Add(extimage[0, 6]);
            ol.Add(extimage[0, 7]);
            ol.Add(extimage[1, 0]);
            ol.Add(extimage[1, 1]);
            ol.Add(extimage[1, 2]);
            ol.Add(extimage[1, 3]);
            ol.Add(extimage[1, 4]);
            ol.Add(extimage[1, 5]);
            ol.Add(extimage[1, 6]);
            ol.Add(extimage[1, 7]);
            ol.Add(extimage[2, 0]);
            ol.Add(extimage[2, 1]);
            ol.Add(extimage[2, 2]);
            ol.Add(extimage[2, 3]);
            ol.Add(extimage[2, 4]);
            ol.Add(extimage[2, 5]);
            ol.Add(extimage[2, 6]);
            ol.Add(extimage[2, 7]);
            ol.Add(extimage[3, 0]);
            ol.Add(extimage[3, 1]);
            ol.Add(extimage[3, 2]);
            ol.Add(extimage[3, 3]);
            ol.Add(extimage[3, 4]);
            ol.Add(extimage[3, 5]);
            ol.Add(extimage[3, 6]);
            ol.Add(extimage[3, 7]);
            ol.Add(extimage[4, 0]);
            ol.Add(extimage[4, 1]);
            ol.Add(extimage[4, 2]);
            ol.Add(extimage[4, 3]);
            ol.Add(extimage[4, 4]);
            ol.Add(extimage[4, 5]);
            ol.Add(extimage[4, 6]);
            ol.Add(extimage[4, 7]);
            ol.Add(extimage[5, 0]);
            ol.Add(extimage[5, 1]);
            ol.Add(extimage[5, 2]);
            ol.Add(extimage[5, 3]);
            ol.Add(extimage[5, 4]);
            ol.Add(extimage[5, 5]);
            ol.Add(extimage[5, 6]);
            ol.Add(extimage[5, 7]);
            ol.Add(extimage[6, 0]);
            ol.Add(extimage[6, 1]);
            ol.Add(extimage[6, 2]);
            ol.Add(extimage[6, 3]);
            ol.Add(extimage[6, 4]);
            ol.Add(extimage[6, 5]);
            ol.Add(extimage[6, 6]);
            ol.Add(extimage[6, 7]);
            ol.Add(extimage[7, 0]);
            ol.Add(extimage[7, 1]);
            ol.Add(extimage[7, 2]);
            ol.Add(extimage[7, 3]);
            ol.Add(extimage[7, 4]);
            ol.Add(extimage[7, 5]);
            ol.Add(extimage[7, 6]);
            ol.Add(extimage[7, 7]);
            eximage = new Bitmap[8, 8];

            eximage[0, 0] = blockembed.extractImg(ol.ElementAt(0));
            eximage[0, 1] = blockembed.extractImg(ol.ElementAt(1));
            eximage[0, 2] = blockembed.extractImg(ol.ElementAt(2));
            eximage[0, 3] = blockembed.extractImg(ol.ElementAt(3));
            eximage[0, 4] = blockembed.extractImg(ol.ElementAt(4));
            eximage[0, 5] = blockembed.extractImg(ol.ElementAt(5));
            eximage[0, 6] = blockembed.extractImg(ol.ElementAt(6));
            eximage[0, 7] = blockembed.extractImg(ol.ElementAt(7));
            eximage[1, 0] = blockembed.extractImg(ol.ElementAt(8));
            eximage[1, 1] = blockembed.extractImg(ol.ElementAt(9));
            eximage[1, 2] = blockembed.extractImg(ol.ElementAt(10));
            eximage[1, 3] = blockembed.extractImg(ol.ElementAt(11));
            eximage[1, 4] = blockembed.extractImg(ol.ElementAt(12));
            eximage[1, 5] = blockembed.extractImg(ol.ElementAt(13));
            eximage[1, 6] = blockembed.extractImg(ol.ElementAt(14));
            eximage[1, 7] = blockembed.extractImg(ol.ElementAt(15));
            eximage[2, 0] = blockembed.extractImg(ol.ElementAt(16));
            eximage[2, 1] = blockembed.extractImg(ol.ElementAt(17));
            eximage[2, 2] = blockembed.extractImg(ol.ElementAt(18));
            eximage[2, 3] = blockembed.extractImg(ol.ElementAt(19));
            eximage[2, 4] = blockembed.extractImg(ol.ElementAt(20));
            eximage[2, 5] = blockembed.extractImg(ol.ElementAt(21));
            eximage[2, 6] = blockembed.extractImg(ol.ElementAt(22));
            eximage[2, 7] = blockembed.extractImg(ol.ElementAt(23));
            eximage[3, 0] = blockembed.extractImg(ol.ElementAt(24));
            eximage[3, 1] = blockembed.extractImg(ol.ElementAt(25));
            eximage[3, 2] = blockembed.extractImg(ol.ElementAt(26));
            eximage[3, 3] = blockembed.extractImg(ol.ElementAt(27));
            eximage[3, 4] = blockembed.extractImg(ol.ElementAt(28));
            eximage[3, 5] = blockembed.extractImg(ol.ElementAt(29));
            eximage[3, 6] = blockembed.extractImg(ol.ElementAt(30));
            eximage[3, 7] = blockembed.extractImg(ol.ElementAt(31));
            eximage[4, 0] = blockembed.extractImg(ol.ElementAt(32));
            eximage[4, 1] = blockembed.extractImg(ol.ElementAt(33));
            eximage[4, 2] = blockembed.extractImg(ol.ElementAt(34));
            eximage[4, 3] = blockembed.extractImg(ol.ElementAt(35));
            eximage[4, 4] = blockembed.extractImg(ol.ElementAt(36));
            eximage[4, 5] = blockembed.extractImg(ol.ElementAt(37));
            eximage[4, 6] = blockembed.extractImg(ol.ElementAt(38));
            eximage[4, 7] = blockembed.extractImg(ol.ElementAt(39));
            eximage[5, 0] = blockembed.extractImg(ol.ElementAt(40));
            eximage[5, 1] = blockembed.extractImg(ol.ElementAt(41));
            eximage[5, 2] = blockembed.extractImg(ol.ElementAt(42));
            eximage[5, 3] = blockembed.extractImg(ol.ElementAt(43));
            eximage[5, 4] = blockembed.extractImg(ol.ElementAt(44));
            eximage[5, 5] = blockembed.extractImg(ol.ElementAt(45));
            eximage[5, 6] = blockembed.extractImg(ol.ElementAt(46));
            eximage[5, 7] = blockembed.extractImg(ol.ElementAt(47));
            eximage[6, 0] = blockembed.extractImg(ol.ElementAt(48));
            eximage[6, 1] = blockembed.extractImg(ol.ElementAt(49));
            eximage[6, 2] = blockembed.extractImg(ol.ElementAt(50));
            eximage[6, 3] = blockembed.extractImg(ol.ElementAt(51));
            eximage[6, 4] = blockembed.extractImg(ol.ElementAt(52));
            eximage[6, 5] = blockembed.extractImg(ol.ElementAt(53));
            eximage[6, 6] = blockembed.extractImg(ol.ElementAt(54));
            eximage[6, 7] = blockembed.extractImg(ol.ElementAt(55));
            eximage[7, 0] = blockembed.extractImg(ol.ElementAt(56));
            eximage[7, 1] = blockembed.extractImg(ol.ElementAt(57));
            eximage[7, 2] = blockembed.extractImg(ol.ElementAt(58));
            eximage[7, 3] = blockembed.extractImg(ol.ElementAt(59));
            eximage[7, 4] = blockembed.extractImg(ol.ElementAt(60));
            eximage[7, 5] = blockembed.extractImg(ol.ElementAt(61));
            eximage[7, 6] = blockembed.extractImg(ol.ElementAt(62));
            eximage[7, 7] = blockembed.extractImg(ol.ElementAt(63));
            Bitmap[] exin = new Bitmap[64];
            // Bitmap[] exout = new Bitmap[36];
            blendimg = new Bitmap[8, 8];
            int k = 0;
            for (int i = 0; i < eximage.GetLength(0); i++)
            {
                for (int j = 0; j < eximage.GetLength(1); j++)
                {

                    exin[k] = eximage[i, j];
                    k++;
                }

            }
            /* int l = 0;
             try
             {
                 for (int z = 0; z < 36; z++)   
                 {
                     if (z < 35)
                         exout[l] = erexchange.exchngeblocks(exin[Tables.ZigZag[z]], exin[Tables.ZigZag[z + 1]]);
                     else
                         exout[l] = reexchange.exchngeblocks(exin[Tables.ZigZag[z]], exin[Tables.ZigZag[0]]);

                     l++;
                 }
             }
             */
            pictureBox134.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[63]], exin[Tables.ZigZag[0]]);
            pictureBox135.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[0]], exin[Tables.ZigZag[1]]);
            pictureBox142.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[1]], exin[Tables.ZigZag[2]]);
            pictureBox150.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[2]], exin[Tables.ZigZag[3]]);
            pictureBox143.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[3]], exin[Tables.ZigZag[4]]);
            pictureBox136.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[4]], exin[Tables.ZigZag[5]]);
            pictureBox137.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[5]], exin[Tables.ZigZag[6]]);
            pictureBox144.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[6]], exin[Tables.ZigZag[7]]);
            pictureBox151.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[7]], exin[Tables.ZigZag[8]]);
            pictureBox158.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[8]], exin[Tables.ZigZag[9]]);
            pictureBox166.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[9]], exin[Tables.ZigZag[10]]);
            pictureBox159.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[10]], exin[Tables.ZigZag[11]]);
            pictureBox152.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[11]], exin[Tables.ZigZag[12]]);
            pictureBox145.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[12]], exin[Tables.ZigZag[13]]);
            pictureBox138.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[13]], exin[Tables.ZigZag[14]]);
            pictureBox139.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[14]], exin[Tables.ZigZag[15]]);
            pictureBox146.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[15]], exin[Tables.ZigZag[16]]);
            pictureBox153.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[16]], exin[Tables.ZigZag[17]]);
            pictureBox160.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[17]], exin[Tables.ZigZag[18]]);
            pictureBox167.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[18]], exin[Tables.ZigZag[19]]);
            pictureBox174.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[19]], exin[Tables.ZigZag[20]]);
            pictureBox182.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[20]], exin[Tables.ZigZag[21]]);
            pictureBox175.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[21]], exin[Tables.ZigZag[22]]);
            pictureBox168.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[22]], exin[Tables.ZigZag[23]]);
            pictureBox161.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[23]], exin[Tables.ZigZag[24]]);
            pictureBox154.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[24]], exin[Tables.ZigZag[25]]);
            pictureBox147.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[25]], exin[Tables.ZigZag[26]]);
            pictureBox140.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[26]], exin[Tables.ZigZag[27]]);
            pictureBox141.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[27]], exin[Tables.ZigZag[28]]);
            pictureBox148.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[28]], exin[Tables.ZigZag[29]]);
            pictureBox155.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[29]], exin[Tables.ZigZag[30]]);
            pictureBox162.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[30]], exin[Tables.ZigZag[31]]);
            pictureBox169.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[31]], exin[Tables.ZigZag[32]]);
            pictureBox176.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[32]], exin[Tables.ZigZag[33]]);
            pictureBox183.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[33]], exin[Tables.ZigZag[34]]);
            pictureBox190.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[34]], exin[Tables.ZigZag[35]]);
            pictureBox191.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[35]], exin[Tables.ZigZag[36]]);
            pictureBox184.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[36]], exin[Tables.ZigZag[37]]);
            pictureBox177.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[37]], exin[Tables.ZigZag[38]]);
            pictureBox170.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[38]], exin[Tables.ZigZag[39]]);
            pictureBox163.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[39]], exin[Tables.ZigZag[40]]);
            pictureBox156.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[40]], exin[Tables.ZigZag[41]]);
            pictureBox149.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[41]], exin[Tables.ZigZag[42]]);
            pictureBox157.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[42]], exin[Tables.ZigZag[43]]);

            pictureBox164.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[43]], exin[Tables.ZigZag[44]]);
            pictureBox171.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[44]], exin[Tables.ZigZag[45]]);
            pictureBox178.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[45]], exin[Tables.ZigZag[46]]);
            pictureBox185.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[46]], exin[Tables.ZigZag[47]]);
            pictureBox192.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[47]], exin[Tables.ZigZag[48]]);
            pictureBox193.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[48]], exin[Tables.ZigZag[49]]);
            pictureBox186.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[49]], exin[Tables.ZigZag[50]]);
            pictureBox179.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[50]], exin[Tables.ZigZag[51]]);
            pictureBox172.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[51]], exin[Tables.ZigZag[52]]);
            pictureBox165.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[52]], exin[Tables.ZigZag[53]]);
            pictureBox173.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[53]], exin[Tables.ZigZag[54]]);
            pictureBox180.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[54]], exin[Tables.ZigZag[55]]);
            pictureBox187.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[55]], exin[Tables.ZigZag[56]]);
            pictureBox194.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[56]], exin[Tables.ZigZag[57]]);
            pictureBox195.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[57]], exin[Tables.ZigZag[58]]);
            pictureBox188.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[58]], exin[Tables.ZigZag[59]]);
            pictureBox181.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[59]], exin[Tables.ZigZag[60]]);
            pictureBox189.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[60]], exin[Tables.ZigZag[61]]);
            pictureBox197.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[61]], exin[Tables.ZigZag[62]]);
            pictureBox196.Image = reexchange.exchngeblocks(exin[Tables.ZigZag[62]], exin[Tables.ZigZag[63]]);


            blendimg[0, 0] = (Bitmap)pictureBox134.Image;
            blendimg[0, 1] = (Bitmap)pictureBox135.Image;
            blendimg[0, 2] = (Bitmap)pictureBox136.Image;
            blendimg[0, 3] = (Bitmap)pictureBox137.Image;
            blendimg[0, 4] = (Bitmap)pictureBox138.Image;
            blendimg[0, 5] = (Bitmap)pictureBox139.Image;
            blendimg[0, 6] = (Bitmap)pictureBox140.Image;
            blendimg[0, 7] = (Bitmap)pictureBox141.Image;
            blendimg[1, 0] = (Bitmap)pictureBox142.Image;
            blendimg[1, 1] = (Bitmap)pictureBox143.Image;
            blendimg[1, 2] = (Bitmap)pictureBox144.Image;
            blendimg[1, 3] = (Bitmap)pictureBox145.Image;
            blendimg[1, 4] = (Bitmap)pictureBox146.Image;
            blendimg[1, 5] = (Bitmap)pictureBox147.Image;
            blendimg[1, 6] = (Bitmap)pictureBox148.Image;
            blendimg[1, 7] = (Bitmap)pictureBox149.Image;
            blendimg[2, 0] = (Bitmap)pictureBox150.Image;
            blendimg[2, 1] = (Bitmap)pictureBox151.Image;
            blendimg[2, 2] = (Bitmap)pictureBox152.Image;
            blendimg[2, 3] = (Bitmap)pictureBox153.Image;
            blendimg[2, 4] = (Bitmap)pictureBox154.Image;
            blendimg[2, 5] = (Bitmap)pictureBox155.Image;
            blendimg[2, 6] = (Bitmap)pictureBox156.Image;
            blendimg[2, 7] = (Bitmap)pictureBox157.Image;
            blendimg[3, 0] = (Bitmap)pictureBox158.Image;
            blendimg[3, 1] = (Bitmap)pictureBox159.Image;
            blendimg[3, 2] = (Bitmap)pictureBox160.Image;
            blendimg[3, 3] = (Bitmap)pictureBox161.Image;
            blendimg[3, 4] = (Bitmap)pictureBox162.Image;
            blendimg[3, 5] = (Bitmap)pictureBox163.Image;
            blendimg[3, 6] = (Bitmap)pictureBox164.Image;
            blendimg[3, 7] = (Bitmap)pictureBox165.Image;
            blendimg[4, 0] = (Bitmap)pictureBox166.Image;
            blendimg[4, 1] = (Bitmap)pictureBox167.Image;
            blendimg[4, 2] = (Bitmap)pictureBox168.Image;
            blendimg[4, 3] = (Bitmap)pictureBox169.Image;
            blendimg[4, 4] = (Bitmap)pictureBox170.Image;
            blendimg[4, 5] = (Bitmap)pictureBox171.Image;
            blendimg[4, 6] = (Bitmap)pictureBox172.Image;
            blendimg[4, 7] = (Bitmap)pictureBox173.Image;
            blendimg[5, 0] = (Bitmap)pictureBox174.Image;
            blendimg[5, 1] = (Bitmap)pictureBox175.Image;
            blendimg[5, 2] = (Bitmap)pictureBox176.Image;
            blendimg[5, 3] = (Bitmap)pictureBox177.Image;
            blendimg[5, 4] = (Bitmap)pictureBox178.Image;
            blendimg[5, 5] = (Bitmap)pictureBox179.Image;
            blendimg[5, 6] = (Bitmap)pictureBox180.Image;
            blendimg[5, 7] = (Bitmap)pictureBox181.Image;
            blendimg[6, 0] = (Bitmap)pictureBox182.Image;
            blendimg[6, 1] = (Bitmap)pictureBox183.Image;
            blendimg[6, 2] = (Bitmap)pictureBox184.Image;
            blendimg[6, 3] = (Bitmap)pictureBox185.Image;
            blendimg[6, 4] = (Bitmap)pictureBox186.Image;
            blendimg[6, 5] = (Bitmap)pictureBox187.Image;
            blendimg[6, 6] = (Bitmap)pictureBox188.Image;
            blendimg[6, 7] = (Bitmap)pictureBox189.Image;
            blendimg[7, 0] = (Bitmap)pictureBox190.Image;
            blendimg[7, 1] = (Bitmap)pictureBox191.Image;
            blendimg[7, 2] = (Bitmap)pictureBox192.Image;
            blendimg[7, 3] = (Bitmap)pictureBox193.Image;
            blendimg[7, 4] = (Bitmap)pictureBox194.Image;
            blendimg[7, 5] = (Bitmap)pictureBox195.Image;
            blendimg[7, 6] = (Bitmap)pictureBox196.Image;
            blendimg[7, 7] = (Bitmap)pictureBox197.Image;
            outputimg = Combo.combine(blendimg);
            pictureBox198.Image = outputimg;

            /*      pictureBox78.Image = eximage[0, 0];
                               pictureBox79.Image = eximage[0, 1];
                               pictureBox80.Image = eximage[0, 2];
                               pictureBox81.Image = eximage[0, 3];
                               pictureBox82.Image = eximage[0, 4];
                               pictureBox83.Image = eximage[0, 5];
                               pictureBox84.Image = eximage[1, 0];
                               pictureBox85.Image = eximage[1, 1];
                               pictureBox86.Image = eximage[1, 2];
                               pictureBox87.Image = eximage[1, 3];
                               pictureBox88.Image = eximage[1, 4];
                               pictureBox89.Image = eximage[1, 5];
                               pictureBox90.Image = eximage[2, 0];
                               pictureBox91.Image = eximage[2, 1];
                               pictureBox92.Image = eximage[2, 2];
                               pictureBox93.Image = eximage[2, 3];
                               pictureBox94.Image = eximage[2, 4];
                               pictureBox95.Image = eximage[2, 5];
                               pictureBox96.Image = eximage[3, 0];
                               pictureBox97.Image = eximage[3, 1];
                               pictureBox98.Image = eximage[3, 2];
                               pictureBox99.Image = eximage[3, 3];
                               pictureBox100.Image = eximage[3, 4];
                               pictureBox101.Image = eximage[3, 5];
                               pictureBox102.Image = eximage[4, 0];
                               pictureBox103.Image = eximage[4, 1];
                               pictureBox104.Image = eximage[4, 2];
                               pictureBox105.Image = eximage[4, 3];
                               pictureBox106.Image = eximage[4, 4];
                               pictureBox107.Image = eximage[4, 5];
                               pictureBox108.Image = eximage[5, 0];
                               pictureBox109.Image = eximage[5, 1];
                               pictureBox110.Image = eximage[5, 2];
                               pictureBox111.Image = eximage[5, 3];
                               pictureBox112.Image = eximage[5, 4];
                               pictureBox113.Image = eximage[5, 5];
                               outputimg = Combo.combine(eximage);
                               pictureBox114.Image = outputimg; */


        }




        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap diffmap = Result.difference((Bitmap)pictureBox198.Image, (Bitmap)pictureBox200.Image);
            pictureBox199.Image = diffmap;

        }

        







    }
}

     
       

        

     



