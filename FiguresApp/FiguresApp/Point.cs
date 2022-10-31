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
    public class Point
    {
        public double X;
        public double Y;
        public Point() { }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }


    }
}
