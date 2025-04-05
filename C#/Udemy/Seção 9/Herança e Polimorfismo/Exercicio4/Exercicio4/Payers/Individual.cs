using System.Globalization;

namespace Exercicio4.Payers;

public class Individual : TaxPayer {
    //Atributos
    public double HealthExpenditures { get; set; }
    
    //Construtores
    public Individual(String name, double anualIncome, double healthExpenditures) 
        : base(name, anualIncome) {
        HealthExpenditures = healthExpenditures;
    }
    
    //Métodos
    public override string ToString() {
        return $"{Name}: $ {Tax().ToString("F2", CultureInfo.InvariantCulture)}";
    }

    public override double Tax() {
        if (AnualIncome < 20000.00) 
            return (AnualIncome * 0.15) - (HealthExpenditures * 0.5);
        
        else
            return (AnualIncome * 0.25) - (HealthExpenditures * 0.5);
    }
}