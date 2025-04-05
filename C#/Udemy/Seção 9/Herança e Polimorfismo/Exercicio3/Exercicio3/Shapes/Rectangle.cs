using System.Globalization;
using Exercicio3.Shapes.Enums;

namespace Exercicio3.Shapes;

public class Rectangle : Shape{
    //Atributos
    public double Width { get; set; }
    public double Height { get; set; }
    
    //Construtores
    public Rectangle(Color color, double width, double height)
        : base(color){
        Width = width;
        Height = height;
    }
    
    //Métodos
    public override string ToString() {
        return Area().ToString("F2", CultureInfo.InvariantCulture);
    }

    public override double Area() {
        return Width * Height;
    }
}