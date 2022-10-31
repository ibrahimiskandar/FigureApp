using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace FiguresApp
{
    [Serializable]
    public abstract class Figure
    {

        public double Area;
        public double Perimeter;
        public List<Point> Points;
        public Point Center { get; set; }

        public Figure()
        {
        }

        public Figure(List<Point> points)
        {
            Points = points;
            FindCenter();
            CalculateArea();
            CalculatePerimeter();
        }

        public abstract void FindCenter();
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
        public abstract void MoveFigure(int moveX, int moveY);
        public abstract void RotateFigure(double angle);
        public abstract void Scale(double scale);
    }

}
