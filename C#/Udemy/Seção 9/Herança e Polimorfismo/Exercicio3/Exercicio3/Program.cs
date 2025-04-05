using System.Globalization;
using Exercicio3.Shapes;
using Exercicio3.Shapes.Enums;

namespace Exercicio3;

public class Program {
    public static void Main(string[] args) {
        List<Shape> Shapes = new List<Shape>();

        Console.Write("Enter the number of shapes: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("-------------------------------");

        for (int i = 0; i < n; i++) {
            Console.WriteLine($"Shape #{i+1} data: ");

            Console.Write("Rectangle or Circle (r/c)? ");
            char shape = char.Parse(Console.ReadLine().ToLower());

            Console.Write("Color (Black/Blue/Red): ");
            Color color = Enum.Parse<Color>(Console.ReadLine().ToUpper());

            if (shape == 'r') {
                Console.Write("Width: ");
                double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                Console.Write("Height: ");
                double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                Shapes.Add(new Rectangle(color, width, height));
            }

            else {
                Console.Write("Radius: ");
                double radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                Shapes.Add(new Circle(color, radius));
            }

            Console.WriteLine();
        }

        Console.WriteLine("-------------------------------");

        Console.WriteLine("SHAPE AREAS: ");

        foreach (Shape shape in Shapes) {
            Console.WriteLine(shape);
        }
    }
}