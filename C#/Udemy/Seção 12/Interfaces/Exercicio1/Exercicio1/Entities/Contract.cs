namespace Exercicio1.Entities;

public class Contract {
    //Atributos
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public double TotalValue { get; set; }
    public List<Installment> Installments { get; set; } = new List<Installment>();
    
    //Construtores
    public Contract() {
    }

    public Contract(int number, DateTime date, double totalValue) {
        Number = number;
        Date = date;
        TotalValue = totalValue;
    }
}