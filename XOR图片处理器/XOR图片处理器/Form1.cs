using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOR图片处理器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap srcBitmap = null;

        private Bitmap showBitmap = null;


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "bmp文件(*.bmp)|*.bmp|gif文件(*.gif)|*.gif|jpg文件(*.jpg)|*.jpg|png文件(*.png)|*.png|tif文件(*.tif)|*.tif|wmf文件(*.wmf)|*.wmf";
            openFileDialog.Filter = "jpg文件(*.jpg)|*.jpg|png文件(*.png)|*.png|tif文件(*.tif)|*.tif|wmf文件(*.wmf)|*.wmf";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                //this.openFileDialog.FileName是图片的绝对路径

                Image pic = Image.FromFile(openFileDialog.FileName);
                this.pictureBox1.Width = pic.Width;//显示图片的控件的长度
                this.pictureBox1.Height = pic.Height;//显示图片的控件的宽度

                //显示图片
                this.pictureBox1.Image = System.Drawing.Bitmap.FromFile(openFileDialog.FileName);
                srcBitmap = (Bitmap)System.Drawing.Bitmap.FromFile(openFileDialog.FileName);
            }

        }

        private void ui_button_change_Click(object sender, EventArgs e)
        {
            //MessageBox.Show( Convert.ToString( srcBitmap.Height ) );
            //MessageBox.Show( Convert.ToString( srcBitmap.Width ) );

            this.showBitmap = this.srcBitmap;
            
            for (int i = 0; i < showBitmap.Width; i++ )
            {
                for (int j = 0; j < showBitmap.Height; j++)
                {
                    Color color = showBitmap.GetPixel(i, j);
                    // ---- MessageBox.Show(Convert.ToString(value.A));
                    int value = color.ToArgb();
                    value = value ^ -1;
                    // ---- Color new_color = new Color(255,1,1,1);
                    Color test = Color.FromArgb(value);
                    showBitmap.SetPixel(i,j,test);
                }
            }
            
            /*
            for (int i = 20; i < 40; i++ )
            {
                for (int j = 20; j < 40; j++ )
                {
                    showBitmap.SetPixel(i, j, Color.Blue);
                }
            }
            */
            this.pictureBox1.Image = showBitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ---- 载入直接写文件
        }
    }
}

