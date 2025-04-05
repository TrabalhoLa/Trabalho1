namespace Exercicio4.Payers;

public abstract class TaxPayer {
    //Atributos
    public String Name { get; set; }
    public double AnualIncome { get; set; }
    
    //Construtores
    public TaxPayer(String name, double anualIncome) {
        Name = name;
        AnualIncome = anualIncome;
    }
    
    //Métodos
    public abstract double Tax();
}