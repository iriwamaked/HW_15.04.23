using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_15._04._23
{
    public class Point2D<T>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Point2D(T x, T y) { X = x; Y = y; }

        public override string ToString()
        {
            return $"X:{X}, Y:{Y}";
        }
    }

    public class Point3D:Point2D<int>
    {
        public int Z { get; set; }

        public Point3D(int x, int y, int z):base(x,y)
        {
            Z = z;  
        }

        public override string ToString()
        {
            return $"X:{X}, Y:{Y}, Z:{Z}";
        }
    }

    public class Line<T>
    {
        public Point2D<T> firstPoint { get; set; }
        public Point2D<T> secondPoint { get; set; }

        public Line(Point2D<T> firstPoint, Point2D<T> secondPoint)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
        }

        public Line(T x1, T y1, T x2, T y2)
        {
            firstPoint = new Point2D<T>(x1, y1);
            secondPoint = new Point2D<T>(x2, y2);
        }

        public override string ToString()
        {
            return $"The line between first point with coordinates {firstPoint.X}, {firstPoint.Y} and second point " +
                $"with coordinates {secondPoint.X}, {secondPoint.Y}.";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            do
            {
                Console.WriteLine("\n\tВыберите задание для проверки:");
                Console.WriteLine("\n\t1-Необобщенный класс точки Point3D, которые наследуется от" +
                    "\n\tgeneric-класса Point2D<T>");
                Console.WriteLine("\n\t2-Обобщенный класс прямой в плоскости с двумя полями" +
                    "\n\tтипа обобщенной точки");
                Console.WriteLine("\n\t3-Посчитать сколько раз каждое слово встречается в заданном" +
                    "\n\tтексте, результат записать в коллекцию Dictionary");
                Console.Write("\n\tВаш выбор: ");
                choice=int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Point3D p1 = new Point3D(5, 6, 9);
                        Console.WriteLine("\n\t"+p1);
                        break;
                    case 2:
                        Line<int> line = new Line<int>(2, 4, 6, 8);
                        Console.WriteLine("\n\t"+line);
                        break;
                    case 3:
                        Console.Write("\n\tВведите текст: ");
                        string text= Console.ReadLine();
                        string[] words = text.Split(new[] {' ', ',', '.', ';', ':', '?'}, StringSplitOptions.RemoveEmptyEntries);
                        Dictionary<string, int> count= new Dictionary<string, int>();
                        foreach (string word in words)
                        {
                            if (count.ContainsKey(word))
                            {
                                count[word]++;
                            }
                            else
                            {
                                count[word] = 1;
                            }
                        }
                        foreach(KeyValuePair<string, int> pair in count)
                        {
                            Console.WriteLine($"\n\tCлово \"{pair.Key}\" встречается {pair.Value}");
                        }
                        break;
                    default: Console.WriteLine("\n\tНеверный номер задания."); break;
                }
            } 
            while(choice >=1 || choice <=3);
            

        }
    }
}
