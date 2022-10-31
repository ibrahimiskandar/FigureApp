using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace FiguresApp
{
    [Serializable]
    class Circle : Figure
    {
        public double Radius;
        public Circle() { }

        public Circle(List<Point> points) : base(points)
        {
            Radius = Math.Sqrt(Math.Pow((points[1].X - points[0].X), 2) + Math.Pow((points[1].Y - points[0].Y), 2));
            FindCenter();
            CalculateArea();
            CalculatePerimeter();
        }

        public override void FindCenter()
        {
            Center = Points[0];
        }

        public override double CalculateArea()
        {
            Area = Math.PI * Math.Pow(Radius, 2);
            return Area;
        }

        public override double CalculatePerimeter()
        {
            Perimeter = 2 * Math.PI * Radius;
            return Perimeter;
        }

        public override void MoveFigure(int moveX, int moveY)
        {
            foreach (var point in Points)
            {
                point.X += moveX;
                point.Y += moveY;
            }
        }

        public override void RotateFigure(double angle)
        {
            Console.WriteLine("Rotated!");
        }

        public override void Scale(double scale)
        {
            Radius *= scale;
            CalculateArea();
            CalculatePerimeter();
        }

        public override string ToString()
        {
            return $"Parameters of Circle :Center Points -> [{Center.X},{Center.Y}] ,Radius -> {Radius}, Area -> {Area}, Perimeter -> {Perimeter}";
        }

    }
}
