using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace FiguresApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Figures.bin";

            List<Figure> figures = new List<Figure>();
            if (File.Exists(path))
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    figures = (List<Figure>)bformatter.Deserialize(stream);
                }
            }
            while (true)
            {
                Console.WriteLine("1.Show all figures \n2.Create a figure \n3.Change figure \n4.Save to file \n0.Exit");
                bool parsed = int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        if (FiguresCount())
                        {
                            Console.WriteLine("\t\t\t\t\t\tAll Figures\n");
                            foreach (var figure in figures)
                            {
                                Console.WriteLine(figure);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no Figure");
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\t\t\t\t\t\tWhat figure do you want to create?");
                        Console.WriteLine("1.Rectangle \n2.Circle");
                        int choiceForFigure = IntIsValid();
                        Console.Clear();

                        switch (choiceForFigure)
                        {
                            case 1:
                                List<Point> pointsOfRectangle = new List<Point>();
                                Console.WriteLine("\t\t\t\t\t\tAdd points of rectangle!");
                                for (int i = 1; i < 5; i++)
                                {
                                    Console.WriteLine($"Enter Point {i}'s Cordinates :");
                                    Console.Write("X :");
                                    int X = IntIsValid();
                                    Console.Write("Y :");
                                    int Y = IntIsValid();
                                    pointsOfRectangle.Add(new Point(X, Y));
                                    Console.WriteLine();
                                }
                                Rectangle rectangle1 = new Rectangle(pointsOfRectangle);
                                figures.Add(rectangle1);
                                Console.Clear();
                                Console.WriteLine("\t\t\t\t\t\tRectangle created!\n");
                                break;
                            case 2:
                                List<Point> pointsOfCircle = new List<Point>();
                                Console.WriteLine("\t\t\t\t\t\tAdd points of circle!");
                                for (int i = 0; i < 2; i++)
                                {
                                    Console.WriteLine($"Enter Point {i}'s Cordinates :");
                                    Console.Write("X :");
                                    int X = IntIsValid();
                                    Console.Write("Y :");
                                    int Y = IntIsValid();
                                    pointsOfCircle.Add(new Point(X, Y));
                                    Console.WriteLine();
                                }
                                Circle circle = new Circle(pointsOfCircle);
                                figures.Add(circle);
                                Console.Clear();
                                Console.WriteLine("\t\t\t\t\t\tCircle created!\n");
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Wrong Option!\n");
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        if (FiguresCount())
                        {
                            Console.WriteLine("\t\t\t\tChoose by ID which figure do you want to change\n");
                            DisplayFigures();
                            bool figureIsEqual = false;
                            while (figureIsEqual == false)
                            {
                                Console.Write("Enter ID: ");
                                int inputID = IntIsValid();
                                for (int i = 0; i < figures.Count; i++)
                                {
                                    if (i == inputID)
                                    {
                                        Console.WriteLine("\t\t\t\t\tChoose action for Figure");
                                        Console.WriteLine("1.Move figure \n2.Rotate figure \n3.Scale figure");
                                        int chooseForChange = IntIsValid();
                                        switch (chooseForChange)
                                        {
                                            case 1:
                                                Console.Clear();
                                                Console.WriteLine("Type new X:");
                                                int X = IntIsValid();
                                                Console.WriteLine("Type new Y:");
                                                int Y = IntIsValid();
                                                figures[i].MoveFigure(X, Y);
                                                break;
                                            case 2:
                                                Console.Clear();
                                                Console.WriteLine("Type angle:");
                                                double angle = Convert.ToDouble(Console.ReadLine());
                                                figures[i].RotateFigure(angle);
                                                break;
                                            case 3:
                                                Console.Clear();
                                                Console.WriteLine("Type scale:");
                                                double scale = Convert.ToDouble(Console.ReadLine());
                                                figures[i].Scale(scale);
                                                break;
                                            default:
                                                Console.Clear();
                                                Console.WriteLine("Wrong Option!\n");
                                                break;
                                        }
                                        figureIsEqual = true;
                                    }

                                }
                                if (figureIsEqual == false)
                                {
                                    Console.Clear();
                                    Console.WriteLine("There is no figure with such ID! Try again: ");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\t\t\t\t\t\tThere is no Figure\n");
                        }
                        break;
                    case 4:
                        Console.Clear();
                        WriteBinary(path, figures);
                        Console.WriteLine("\t\t\t\t\t\tFile Saved!\n");
                        break;
                    default:
                        if (parsed)
                        {
                            if (choice == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("\t\t\t\t\t\tProgram finished!\n");
                                Environment.Exit(1);
                                return;
                            }
                            Console.Clear();
                            Console.WriteLine("Enter numbers according to menu!\n");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Enter digits only!\n");
                        }
                        break;
                }
            }

            int IntIsValid()
            {
                int n = 0;
                bool isValid = true;
                while (isValid)
                {
                    bool intIsParsed = int.TryParse(Console.ReadLine(), out n);
                    if (intIsParsed)
                    {
                        isValid = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input:");
                    }
                }
                return n;
            }
            void DisplayFigures()
            {
                for (int i = 0; i < figures.Count; i++)
                {
                    Console.WriteLine($"{i}.{figures[i]}");
                }
            }

            void WriteBinary(string filePath, List<Figure> list)
            {
                using (Stream stream = File.Open(filePath, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, list);
                }
            }
            bool FiguresCount()
            {
                if (figures.Count() > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
