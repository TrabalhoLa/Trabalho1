using System.Globalization;
using Exercicio3.Shapes.Enums;

namespace Exercicio3.Shapes;

public class Circle : Shape{
    //Atributos
    public double Radius { get; set; }
    
    //Construtores
    public Circle(Color color, double radius)
        : base(color) {
        Radius = radius;
    }
    
    //Métodos
    public override string ToString() {
        return Area().ToString("F2", CultureInfo.InvariantCulture);
    }

    public override double Area() {
        return Math.PI * Math.Pow(Radius, 2);
    }
}