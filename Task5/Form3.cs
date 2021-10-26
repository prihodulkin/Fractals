using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form3 : Form
    {
        int mode = 0;
        List<Button> points = new List<Button>();
        float t = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            t = ((float)trackBar1.Value) / 100;
            pictureBox1.Refresh();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private PointF getPoint(List<PointF> points)
        {
            if (t == 0)
                return (points[0]);
            var res = new PointF();
            for (int i = 0; i < points.Count; i++)
            {
                var l = bernstein(points.Count - 1, i, t);
                res.X += points[i].X * l;
                res.Y += points[i].Y * l;
            }
            return res;
        }

        private PointF getPoint(List<PointF> points, float T)
        {
            if (T == 0)
                return (points[0]);
            var res = new PointF(0,0);
            for (int i = 0; i < points.Count; i++)
            {
                var l = bernstein(points.Count - 1, i, T);
                res.X += points[i].X * l;
                res.Y += points[i].Y * l;
            }
            return res;
        }

        private List<PointF>GetPoints(float interval=0.01f)
        {
            var pts = new List<PointF>();
            foreach (var i in points)
            {
                pts.Add(i.Location);
            }
            List<PointF> res = new List<PointF>();
            for (float tt = 0;tt<=1;tt+=interval)
            {
                res.Add(getPoint(pts, tt));
            }
            return res;
        }


        private float fact(int i)
        {
            float res = 1;
            for (float j = 1; j <= i; j++)
                res *= j;
            return res;
        }

        float binominal(int n, int i)
        {
            return fact(n) / (fact(i) * fact(n-i));
        }

        float bernstein(int n, int i, float T)
        {
            float a = (float)Math.Pow(T, i);
            float b = (float)Math.Pow((1 - T), (n - i));
            return binominal(n, i) * a * b;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            mode = 0;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            mode = 1;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                Button but = new Button();
                but.FlatStyle = FlatStyle.Flat;
                but.Size = new Size(6, 6);

                but.BackColor = Color.Green;
                but.Click += Deleter;
                but.MouseMove += Ref;
                pictureBox1.Controls.Add(but);
                but.Location = new Point(e.X-3, e.Y-3);
                ControlExtension.Draggable(but, true);
                points.Add(but);
            }
            pictureBox1.Refresh();
        }


        private void Deleter(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                pictureBox1.Controls.Remove((Button)sender);
                points.Remove((Button)sender);
            }
            pictureBox1.Refresh();
        }

        private void Ref(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            /*
            if (points.Count > 0)
            {
                var a = new SolidBrush(Color.Red);
                e.Graphics.FillRectangle(a, getPoint(points).X, getPoint(points).Y, 5, 5);
            }
            */
            if (points.Count > 0)
            {
                var a = new SolidBrush(Color.Red);
                var b = GetPoints((float)1/(points.Count*500));
                foreach (var i in b)
                {
                    e.Graphics.FillRectangle(a, i.X, i.Y, 2, 2);
                }
            }
        }
    }
}
