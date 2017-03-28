using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;//GDI
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_sharp_userpaint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "Draw Lines";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int i;
            Graphics g = this.CreateGraphics(); //创建画板
            Pen p = new Pen(Color.Black, 1);//定义了一个颜色,宽度的画笔
            p.EndCap = LineCap.ArrowAnchor;//定义线尾的样式为箭头
            SolidBrush b1 = new SolidBrush(Color.ForestGreen);//定义写字刷
            g.TranslateTransform(350, 250);
            g.DrawLine(p, -150, 0, 150, 0);
            g.DrawString("X", new Font("宋体", 10), b1, new PointF(160, 0));
            g.DrawLine(p, 0, 150, 0, -150);
            g.DrawString("Y", new Font("宋体", 10), b1, new PointF(0, -160));
            //画刻度
            p.EndCap = LineCap.Flat;
            for (i = -125; i <= 125; i = i + 25)
            { g.DrawLine(p, i, 0, i, -3);
            g.DrawString(Convert.ToString(i), new Font("Times New Roman", 8), b1, new PointF(i-10, 3));
            }
            for (i = -125; i <= 125; i = i + 25)
            {
                if (i != 0)
                {
                    g.DrawLine(p, 0, i, 3, i);
                    g.DrawString(Convert.ToString(-1 * i), new Font("Times New Roman", 8), b1, new PointF(-25, i - 6));
                }
            }
            g.ResetTransform();
            g.Dispose();
            p.Dispose();
            b1.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)||string.IsNullOrEmpty(textBox3.Text)||string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("You need to enter all the initial value.");
                return;//跳出事件
            }
            float x1 = Convert.ToSingle(this.textBox1.Text);
            float y1 = Convert.ToSingle(this.textBox3.Text) * (-1);
            float x2 = Convert.ToSingle(this.textBox2.Text);
            float y2 = Convert.ToSingle(this.textBox4.Text) * (-1);
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Red, 1);
            g.TranslateTransform(350, 250);
            g.DrawLine(p, x1, y1, x2, y2);
            g.ResetTransform();
        }

        //只允许输入数字
        private void keypressfunc(KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46 && e.KeyChar != 45)
            e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypressfunc(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypressfunc(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypressfunc(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypressfunc(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("You need to enter all the initial value.");
                return;//跳出事件
            }
            float a = Convert.ToSingle(this.textBox5.Text);
            float b = Convert.ToSingle(this.textBox6.Text);
            float x1= -5000;
            float y1 = (a * x1 + b)*(-1);
            float x2 = 5000;
            float y2 = (a * x2 + b) * (-1);
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.SteelBlue, 1);
            g.TranslateTransform(350, 250);
            g.DrawLine(p, x1, y1, x2, y2);
            g.ResetTransform();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypressfunc(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypressfunc(e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics(); //创建画板
            //Rectangle rect = new Rectangle(0, 0, 700, 500);//定义矩形,参数为起点横纵坐标以及其长和宽

            ////单色填充
            //SolidBrush b1 = new SolidBrush(Color.White);//定义单色画刷          
            //g.FillRectangle(b1, rect);//填充这个矩形
            g.Clear(this.BackColor);
        }
//画二次曲线
        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("You need to enter all the initial value.");
                return;//跳出事件
            }
            float a = Convert.ToSingle(this.textBox7.Text);
            float b = Convert.ToSingle(this.textBox8.Text);
            float c = Convert.ToSingle(this.textBox9.Text);
            int x,xl;
            float y,yl;

            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.DarkViolet, 1);
            g.TranslateTransform(350, 250);

            xl = -5000;
            yl = (a * xl * xl + b * xl + c) * (-1);
            for (x = -5000; x <= 5000; x++)
            { 
                y = (a * x*x + b* x + c) * (-1);
                g.DrawLine(p, xl, yl, x, y);
                xl = x;
                yl = y;
            }
            g.ResetTransform();
        }
//可以在事件中重复调用
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            keypressfunc(e);
        }
    }
}
