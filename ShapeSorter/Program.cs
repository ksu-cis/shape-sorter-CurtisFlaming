using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");




            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4.0),
                new Rectangle(6, 7),
                new Square(5.0),
                new Circle(3.0),
                new Rectangle(2.0, 4.0),
                new Circle(3.5),
                new Square(20)
            };


            foreach(IShape shape in shapes)
            {
                Console.WriteLine($"Area is: {shape.Area}");
            }
            Console.WriteLine();

            IEnumerable<IShape> filterShapes = shapes.Where(shape => shape.Area > 50);
            Console.WriteLine("Shapes with an area > 50");
            foreach (IShape shape in filterShapes)
            {
                Console.WriteLine($"Area is: {shape.Area}");
            }

            Console.WriteLine();

            IEnumerable<Circle> circles;
            circles = shapes.OfType<Circle>();
            foreach (Circle circle in circles)
            {
                Console.WriteLine($"Circle Area is: {circle.Area}");
            }

            Console.WriteLine();

            Console.WriteLine("Circles with area < 30");
            foreach (Circle shape in circles.Where(circle => circle.Area < 30))
            {
                Console.WriteLine($"area: {shape.Area}");
            }


            Console.WriteLine();
            Console.WriteLine("Group by Area");
            var groupBY = shapes.GroupBy(shape => shape.Area % 2 == 0);
            foreach (var group in groupBY)
            {
                Console.WriteLine(group.Key ? "Evens" : "Odds");
                foreach (var shape in group)
                {
                    Console.WriteLine($"shape with are {shape.Area}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Group by type");
            var groupByType = shapes.GroupBy(shape => shape.GetType());
            foreach(var group in groupByType)
            {
                Console.WriteLine($"shapes of type {group.Key}");
                foreach(var shape in group)
                {
                    Console.WriteLine($"shape with area {shape.Area}");
                }
            }
        }
    }
}
