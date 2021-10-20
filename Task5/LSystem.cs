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
  
    public class LSystem
    {
        string axiom;
        Dictionary<char, string> rules;
        int rotateAngle;
        int initialAngle;
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

        double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public Point[] Apply(int width, int height)
        {
            int lineLength = 1000;
            List<Point> result = new List<Point>();
            double x = 0;
            double y = 0;
            int maxX = 0;
            int minX = 0;
            int maxY = 0;
            int minY = 0;
            result.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
            var angle = initialAngle;
            foreach(var c in currentState)
            {
                if (c == '+')
                {
                    angle += 60;
                    if (angle > 360)
                    {
                        angle %= 360;
                    }
                }
                if (c == '-')
                {
                    angle -= 60;
                    if (angle <0)
                    {
                        angle+= 360;
                    }
                }
                if(c == 'F')
                {
                    x += lineLength * Math.Cos(ConvertToRadians(angle));
                    y += lineLength * Math.Sin(ConvertToRadians(angle));
                    result.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
                    if (x > maxX){
                        maxX = (int)Math.Ceiling(x);
                    } else if(x < minX)
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
                }
            }
            Matrix matrix = new Matrix();
            var w = (float)(maxX - minX);
            var h = (float)(maxY - minY);
            var scaleX = w>0?(float)width /w : 1;
            var scaleY = h>0?(float)height / h  : 1 ;
            var arr = result.ToArray();
            //matrix.Translate(-minX,- minY);
            //matrix.TransformPoints(arr);
            //matrix = new Matrix();
            //matrix.Scale(scaleX,scaleY);
            matrix.Translate(-minX, -minY);
            matrix.TransformPoints(arr);
            matrix.Translate(minX, minY);
            matrix.Scale(scaleX, scaleY);   
            matrix.TransformPoints(arr);
            return arr;
        }

    }
}
