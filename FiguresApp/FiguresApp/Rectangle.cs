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
    public class Rectangle : Figure
    {
        public double SideA;
        public double SideB;
        public Rectangle(List<Point> points) : base(points)
        {
            SideA = Math.Sqrt(Math.Pow((points[3].X - points[0].X), 2) + Math.Pow((points[3].Y - points[0].Y), 2));
            SideB = Math.Sqrt(Math.Pow((points[1].X - points[0].X), 2) + Math.Pow((points[1].Y - points[0].Y), 2));
            CalculateArea();
            CalculatePerimeter();

        }
        public Rectangle() { }

        public override double CalculateArea()
        {
            Area = SideA * SideB;
            return Area;
        }

        public override double CalculatePerimeter()
        {
            Perimeter = 2 * (SideA + SideB);
            return Perimeter;
        }

        public override void FindCenter()
        {
            double sumX = 0, sumY = 0;
            foreach (var p in Points)
            {
                sumX += p.X;
                sumY += p.Y;
            }
            Center = new Point(sumX / 4, sumY / 4);
        }

        public override void RotateFigure(double degree)
        {
            foreach (var point in Points)
            {
                point.X = point.X + Math.Cos(degree) - point.Y + Math.Sin(degree);
                point.Y = point.Y + Math.Cos(degree) + point.X + Math.Sin(degree);
            }

        }

        public override void MoveFigure(int moveX, int moveY)
        {
            foreach (var p in Points)
            {
                p.X += moveX;
                p.Y += moveY;
            }
        }

        public override void Scale(double scale)
        {
            foreach (var point in Points)
            {
                point.X = Center.X - scale * (Center.X - point.X);
                point.Y = Center.Y - scale * (Center.Y - point.Y);
            }
            SideA = Math.Sqrt(Math.Pow((Points[3].X - Points[0].X), 2) + Math.Pow((Points[3].Y - Points[0].Y), 2));
            SideB = Math.Sqrt(Math.Pow((Points[1].X - Points[0].X), 2) + Math.Pow((Points[1].Y - Points[0].Y), 2));
            CalculatePerimeter();
            CalculateArea();
        }

        public override string ToString()
        {
            string points = "";

            foreach (var item in Points)
            {
                points += $"[{item.X},{item.Y}]";
            }
            return $"Parameters of Rectangle :Corner Points ->{points} Area -> {Area}, Perimeter -> {Perimeter}";
        }
    }
}
