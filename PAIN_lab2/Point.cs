using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAIN_lab2
{
    public class Point
    {
        private string label;
        private double x, y;
        private ColorDef color;

        public Point() { }

        public Point(string label, double x, double y)
        {
            this.label = label;
            this.x = x;
            this.y = y;
        }

        public void changeX(double x)
        {
            this.x = x;
        }

        public void changeY(double y)
        {
            this.y = y;
        }

        public void changeLabel(string label)
        {
            this.label = label;
        }

        public void changeColor(ColorDef color) { this.color = color; }

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        public string getLabel() { return label; }

        public ColorDef getColor() { return color; }

    }
}
