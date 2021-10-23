using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Task5
{
    public struct Line
    {
       public Point[] points;
       public int level;
       public Line(Point[] pts, int lvl)
       {
            points = pts;
            level = lvl;
       }
    }


    public class LSystem
    {
        public struct LSystemState
        {
            public double X;
            public double Y;
            public int Rotate;
            public int level;
            public LSystemState(double x, double y, int rotate, int lvl)
            {
                X = x;
                Y = y;
                Rotate = rotate;
                level = lvl;
            }
        }


        string axiom;
        Dictionary<char, string> rules;
        int rotateAngle;
        int initialAngle;
        double p = -1;
        int rotateDiviation = 0;
        int stepNum = 0;
        string currentState;

        public LSystem(string axiom, Dictionary<char, string> rules, int rotateAngle, int initialAngle)
        {
            this.axiom = axiom;
            this.rules = new Dictionary<char, string>(rules);
            this.rotateAngle = rotateAngle;
            this.initialAngle = initialAngle;
        }

        public LSystem(string filepath)
        {
            var lines = File.ReadLines(filepath).ToArray();
            var firstLine = lines[0].Split();
            axiom = firstLine[0];
            currentState = axiom;
            rotateAngle = int.Parse(firstLine[1]);
            initialAngle = int.Parse(firstLine[2]);
            if (firstLine.Length >= 5)
            {
                p = double.Parse(firstLine[3]);
                rotateDiviation = int.Parse(firstLine[4]);
            }
            //if (firstLine.Length >= 6)
            //{
            //    withTreeLevels = firstLine[5] == "1";
            //}
           
            rules = new Dictionary<char, string>();
            for (var i = 1; i < lines.Length; i++)
            {
                var line = lines[i].Split();
                rules[line[0][0]] = line[1].Trim();
            }
        }

        public string Axiom => axiom;

        public string CurrentState => currentState;
        public int RotateAngle => rotateAngle;
        public int InitailAngle => initialAngle;

        public int StepNum => stepNum;
        public Dictionary<char, string> Rules => new Dictionary<char, string>(rules);

        public void Step()
        {
            var stringBuilder = new StringBuilder();
            foreach (char c in currentState)
            {
                if (rules.ContainsKey(c))
                {
                    stringBuilder.Append(rules[c]);
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }
            currentState = stringBuilder.ToString().Trim();
            ++stepNum;
        }

        static double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public List<Line> Apply(int width, int height)
        {
            int lineLength = 1000;
            width -= width / 10;
            height -= height/10;
            List<Line> result = new List<Line>();
            double x = 0;
            double y = 0;
            int maxX = 0;
            int minX = 0;
            int maxY = 0;
            int minY = 0;
            var angle = initialAngle;
            Stack<LSystemState> stack = new Stack<LSystemState>();
            int level = 0;
            foreach (var c in currentState)
            {
                if (c == '+')
                {
                    Random random = new Random();
                    var dAngle = 0;
                    if (random.NextDouble() < p)
                    {
                        dAngle = ((random.Next() % 2) * 2 - 1) *(random.Next()% rotateDiviation);
                    }
                    angle += rotateAngle+dAngle;
                    if (angle > 360)
                    {
                        angle %= 360;
                    }
                }
                else if (c == '-')
                {
                    angle -= rotateAngle;
                    if (angle < 0)
                    {
                        angle += 360;
                    }
                }
                else if (c == 'F')
                {                
                    var p1 = new Point((int)Math.Round(x), (int)Math.Round(y));
                    x += lineLength * Math.Cos(ConvertToRadians(angle));
                    y += lineLength * Math.Sin(ConvertToRadians(angle));
                    var p2 = new Point((int)Math.Round(x), (int)Math.Round(y));

                    result.Add( new Line(new Point[] { p1, p2 }, level));

                    if (x > maxX)
                    {
                        maxX = (int)Math.Ceiling(x);
                    }
                    else if (x < minX)
                    {
                        minX = (int)Math.Floor(x);
                    }
                    if (y > maxY)
                    {
                        maxY = (int)Math.Ceiling(y);
                    }
                    else if (y < minY)
                    {
                        minY = (int)Math.Floor(y);
                    }
                    level++;
                }
                else if (c == '[')
                {
                    stack.Push(new LSystemState(x, y,  angle, level));
                }
                else if (c == ']')
                {
                    var state = stack.Pop();
                    angle = state.Rotate;
                    x = state.X;
                    y = state.Y;
                    level = state.level;
                }     
            }
            var w = (float)(maxX - minX);
            var h = (float)(maxY - minY);
            var scaleX = w > 0 ? (float)width / w : 1;
            var scaleY = h > 0 ? (float)height / h : 1;
            var scale = Math.Min(scaleX, scaleY);
            Matrix translateMatrix = new Matrix();
            var scaleMatrix = new Matrix();
            scaleMatrix.Scale(scale, scale);
            translateMatrix.Translate(-minX, -minY);
            foreach (var line in result)
            {
                translateMatrix.TransformPoints(line.points);
                scaleMatrix.TransformPoints(line.points);
                line.points[0].Y = height - line.points[0].Y;
                line.points[1].Y = height - line.points[1].Y;
            }
            return result;
        }
    } 
}
