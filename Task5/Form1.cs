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
    public partial class Form1 : Form
    {
        enum Mode
        {
            KochCurve,
            KochSnow,
            SerpGask,
            HilbertCurve,
            HosperCurve,
            Bush
        }

        const string inputPath = @".\..\Input\";

        Dictionary<Mode, string> files = new Dictionary<Mode, string>()
        {
            {Mode.KochCurve, inputPath+"koh.txt" },
            {Mode.KochSnow,  inputPath+"koh1.txt" },
            {Mode.SerpGask,  inputPath+"serpGask.txt" },
            {Mode.HilbertCurve,  inputPath+"hilbert.txt" },
            {Mode.HosperCurve,  inputPath+"hosper.txt" },
            {Mode.Bush, inputPath+"bush.txt" },
        };

        Dictionary<Mode, List<Point []>> fractals;

        Mode mode = Mode.KochCurve;
        int generation = 0;

        LSystem lSystem;
        

        public Form1()
        {     
            InitializeComponent();
            fractals = new Dictionary<Mode, List<Point[]>>();
            foreach(var m in Enum.GetValues(typeof(Mode)).Cast<Mode>())
            {
                fractals[m] = new List<Point[]>();
            }
            lSystem = new LSystem(files[mode]);
        }

       
        private void KochSnow_CheckedChanged(object sender, EventArgs e)
        {
            mode = Mode.KochSnow;
            Refresh();
        }

        private void HilbertButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = Mode.HilbertCurve;
            Refresh();

        }

        private void KochKurveButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = Mode.KochCurve;
            Refresh();
        }

        private void SierpinskiGasketButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = Mode.SerpGask;
            Refresh();
        }

        private void HosperCurveButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = Mode.HosperCurve;
            Refresh();
        }

        private void IncGenerationButton_Click(object sender, EventArgs e)
        {
            generation++;
            GenerationLabel.Text = generation.ToString();
            Refresh();
        }

        private void DecGenerationButton_Click(object sender, EventArgs e)
        {
            if (generation <= 0)
                return;
            generation--;
            GenerationLabel.Text = generation.ToString();
            Refresh();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void turnOverFractal(Point[] fractal)
        {
            var h = pictureBox1.Height;
            for (var i = 0; i < fractal.Length; i++)
            {
                fractal[i].Y = h - h / 20 - fractal[i].Y;
            }
        }

        private void drawFractal(Pen pen, Graphics graphics, Point[] fractal)
        {
            var h = pictureBox1.Height;
           
            for (var i = 0; i < fractal.Length-1; i++)
            {         
                graphics.DrawLine(pen, fractal[i], fractal[i + 1]);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);
            Graphics g = e.Graphics;
           // var h = pictureBox1.Height;
           // g.DrawLine(pen, new Point(0, h-10), new Point(426, h-10));
            var fractalsCount = fractals[mode].Count;
            if (fractalsCount - 1 < generation)
            {
                lSystem = new LSystem(inputPath + files[mode]);
                for(var i = 0; i <= generation; i++)
                {            
                    if (fractals[mode].Count-1 < i)
                    {
                        fractals[mode].Add(lSystem.Apply(pictureBox1.Width, pictureBox1.Height));
                        turnOverFractal(fractals[mode].Last());
                    }
                    lSystem.Step();
                }
            }
            drawFractal(pen, g, fractals[mode][generation]);
        }

        private void GenerationLabel_Click(object sender, EventArgs e)
        {

        }

        private void BushButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = Mode.Bush;
            Refresh();
        }
    }
}
