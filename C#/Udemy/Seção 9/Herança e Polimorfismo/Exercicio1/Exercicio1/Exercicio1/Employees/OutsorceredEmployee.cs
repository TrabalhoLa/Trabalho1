namespace Exercicio1;

public class OutsourcedEmployee : Employee {
    //Objetos
    public double AdditionalCharge { get; set; }
    
    //Construtores
    public OutsourcedEmployee() {
    }
    
    public OutsourcedEmployee(String name, int hours, double valuePerHour, double additionalCharge) : base(name, hours, valuePerHour) {
        AdditionalCharge = additionalCharge;
    }
    
    //Métodos
    public sealed override double payment() {
        return (AdditionalCharge * 1.1) + base.payment();
    }
}