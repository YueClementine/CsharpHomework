using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        Pen CustomizePenColor = new Pen(Color.White);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int leng = trackBar1.Value ;
            this.th1 = trackBar2.Value * Math.PI / 180;
            this.th2 = trackBar3.Value * Math.PI / 180;
            this.per1 = double.Parse(comboBox2.Text);
            this.per2 = double.Parse(comboBox3.Text);
            int n = int.Parse(comboBox1.Text);
            if (graphics == null) graphics = this.panel1.CreateGraphics();
            drawCayleyTree(n, 200, 310, leng, -Math.PI / 2);
        }
   
        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th1);

        }
        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(
                CustomizePenColor,
                (int)x0, (int)y0, (int)x1, (int)y1
                );
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.CustomizePenColor.Color=colorDialog1.Color;
            }

        }
    }
}
