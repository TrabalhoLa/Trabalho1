using System.Globalization;

namespace Exercicio1.Entities;

public class Installment {
    //Atributos
    public DateTime DueDate { get; set; }
    public double Amount { get; set; }
    
    //Construtores
    public Installment() {
    }

    public Installment(DateTime dueDate, double amount) {
        DueDate = dueDate;
        Amount = amount;
    }
    
    //Métodos
    public override string ToString() {
        return $"{DueDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} - " +
               $"{Amount.ToString("F2", CultureInfo.InvariantCulture)}";
    }
}