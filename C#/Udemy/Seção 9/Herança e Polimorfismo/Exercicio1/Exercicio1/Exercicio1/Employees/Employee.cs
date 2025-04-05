using System.Globalization;

namespace Exercicio1;

public class Employee {
    //Objetos
    public String Name { get; protected set; }
    public int Hours { get; protected set; }
    public double ValuePerHour { get; protected set; }

    //Construtores
    public Employee() {
    }

    public Employee(String name, int hours, double valuePerHour) {
        Name = name;
        Hours = hours;
        ValuePerHour = valuePerHour;
    }
    
    //Métodos
    public override string ToString() {
        return $"{Name} - $ {payment().ToString("F2", CultureInfo.InvariantCulture)}";
    }

    public virtual double payment() {
        return Hours * ValuePerHour;
    }
}