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
    
    public partial class Form2 : Form
    {
        private Graphics g;
        List<Segment> segments;
        double R;
        Point startPoint1 = new Point(0,0);
        Point startPoint2 = new Point(0,0);

        public Form2()
        {
            segments = new List<Segment>();
            R = 1.0;
            InitializeComponent();
            roughness_box.Text = R.ToString();
            g = CreateGraphics();
        }

       
        private void next_step_btn_Click(object sender, EventArgs e)
        {
            next_step_btn.Enabled = false;
            List<Segment> worked = new List<Segment>();
            var random = new Random();
            foreach(var s in segments)
            {
                var height = (s.begin.Y + s.end.Y) / 2 + (random.NextDouble() - 0.5) * R * s.GetLength();
                var centerX = (s.begin.X + s.end.X) / 2;
                var centerPoint = new Point(centerX, (int)height);
                worked.Add(new Segment(s.begin, centerPoint));
                worked.Add(new Segment(centerPoint, s.end));
            }
            segments = worked;
            g.Clear(BackColor);
            foreach (var s in segments)
            {
                g.DrawLine(Pens.Black, s.begin, s.end);
            }
            next_step_btn.Enabled = true;
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            startPoint1 = new Point(0, 0);
            startPoint2 = new Point(0, 0);
            segments.Clear();
            g.Clear(BackColor);
            next_step_btn.Enabled = false;
        }

        private void minus_btn_Click(object sender, EventArgs e)
        {
            if (Math.Abs(R - 4) <= 0.0001)
            {
                plus_btn.Enabled = true;
            }
            R -= 0.1;
            roughness_box.Text = R.ToString();
            if (Math.Abs(R - 0.1) <= 0.0001)
            {
                minus_btn.Enabled = false;
                return;
            }
        }

        private void plus_btn_Click(object sender, EventArgs e)
        {
            if (Math.Abs(R - 0.1) <= 0.0001)
            {
                minus_btn.Enabled = true;
            }
            R += 0.1;
            roughness_box.Text = R.ToString();
            if (Math.Abs(R - 4) <= 0.0001)
            {
                plus_btn.Enabled = false;
                return;
            }
        }

        private void Form2_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (startPoint1.X == 0)
            {
                startPoint1 = new Point(e.X, e.Y);
                return;
            }

            if(startPoint2.X == 0)
            {
                startPoint2 = new Point(e.X, e.Y);
                g.DrawLine(Pens.Black, startPoint1.X, startPoint1.Y, startPoint2.X, startPoint2.Y);
                next_step_btn.Enabled = true;
                segments.Add(new Segment(startPoint1, startPoint2));
            }
            
        }

        private void roughness_box_TextChanged(object sender, EventArgs e)
        {
            var value = roughness_box.Text;
            double val;
            if (double.TryParse(value, out val))
            {
                if(val > 4 || val < 0.1)
                {
                    MessageBox.Show("Значение должно быть от 0,1 до 4");
                    return;
                }
                R = val;
            }

        }
    }

    public class Segment
    {
        public Point begin;
        public Point end;
        public Segment(Point beg, Point end)
        {
            begin = beg;
            this.end = end;
        }
        public double GetLength()
        {
            return Math.Sqrt(Math.Pow((end.X - begin.X), 2) + Math.Pow((end.Y - begin.Y), 2));
        }
    }
}
