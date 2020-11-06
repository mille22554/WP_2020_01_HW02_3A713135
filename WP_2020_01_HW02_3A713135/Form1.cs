using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WP_2020_01_HW02_3A713135
{
    public partial class Form1 : Form
    {
        int x = 0;
        string a;
        int[] y = new int[53];
        Image[] pic = new Image[53];
        ResourceManager rm = new ResourceManager(typeof(WP_2020_01_HW02_3A713135.Properties.Resources));
        Array Faro(int[] yy)
        {
            Random rand = new Random();
            for (int i = 1; i < 53; i++)
            {
                yy[i] = rand.Next(1, 53);
                for (int j = 1; j < i; j++)
                {
                    while (yy[i] == yy[j])
                    {
                        j = 1;
                        yy[i] = rand.Next(1, 53);
                    }
                }
            }
            return yy;
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "抽過的卡:";
            label2.Text = "作者:Moro";
            this.Text = "抽卡";
            Faro(y);
            for (int i = 1; i < 53; i++)
            {
                pic[i] = rm.GetObject("_"+i) as Image;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (x > 51)
            {
                MessageBox.Show("已經沒有牌了!","錯誤", MessageBoxButtons.OK);
            }
            else { 
                x++;
                if (y[x] < 10)
                {
                    textBox1.Text = textBox1.Text +"0"+ y[x] + ",";
                }
                else
                {
                    textBox1.Text = textBox1.Text + y[x] + ",";
                }
                pictureBox1.Image = pic[y[x]];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            x = 0;
            textBox1.Text = "";
            Faro(y);
            pictureBox1.Image = null;
        }
    }
}
