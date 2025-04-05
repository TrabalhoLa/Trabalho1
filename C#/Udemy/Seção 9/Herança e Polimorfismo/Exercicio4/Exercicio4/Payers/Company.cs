using System.Globalization;

namespace Exercicio4.Payers;

public class Company : TaxPayer {
    //Atributos
    public int NumberOfEmployees { get; set; }
    
    //Construtores
    public Company(String name, double anualIncome, int numberOfEmployees) 
        : base(name, anualIncome) {
        NumberOfEmployees = numberOfEmployees;
    }
    
    //Métodos
    public override string ToString() {
        return $"{Name}: $ {Tax().ToString("F2", CultureInfo.InvariantCulture)}";
    }

    public override double Tax() {
        if (NumberOfEmployees <= 10)
            return AnualIncome * 0.16;
        
        else
            return AnualIncome * 0.14;
    }
}