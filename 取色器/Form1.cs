using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 取色器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Bitmap bmp;
        Bitmap bmpZoom;
        private void Form1_Load(object sender, EventArgs e)
        {

            bmp = new Bitmap(pictureBox1.BackgroundImage.GetThumbnailImage(pictureBox1.Width,pictureBox1.Height,null,IntPtr.Zero));
            
            bmpZoom = new Bitmap(20, 20);

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            Color c = bmp.GetPixel(e.X, e.Y);
            label1.Text = c.ToString();

            for(int i = -10; i < 10; i++)
            {
                for( int j = -10; j < 10; j++)
                {
                    Color cOrig;
                    if (e.X + i <= 0 || e.X + i >= bmp.Width || e.Y + j <= 0 || e.Y + j >= bmp.Height)
                    {
                        cOrig = Color.Black;
                    }
                    else
                    {
                        //取原来的
                        cOrig = bmp.GetPixel(e.X + i, e.Y + j);
                    }
                    //把取到的RGB值放入小的bmp中
                    bmpZoom.SetPixel(i + 10, j + 10, cOrig);
                }
            }

            pictureBox2.BackgroundImage = bmpZoom;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "hello world";
        }
    }
}
