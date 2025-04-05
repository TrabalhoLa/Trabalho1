using Exercicio3.Shapes.Enums;

namespace Exercicio3.Shapes;

public abstract class Shape {
    //Atributos
    public Color Color { get; set; }

    //Construtores
    public Shape(Color color) {
        Color = color;
    }
    
    //Métodos
    public abstract double Area();
}