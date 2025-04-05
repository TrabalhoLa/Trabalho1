using Exercicio4.Payers;
using System.Globalization;

namespace Exercicio4;

public class Program {
    public static void Main(string[] args) {
        List<TaxPayer> TaxPayers = new List<TaxPayer>();

        Console.Write("Enter the number of tax payers: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("---------------------------------");

        for (int i = 0; i < n; i++) {
            Console.WriteLine($"Tax payer {i+1} data:");

            Console.Write("Individual or company (i/c)? ");
            char choice = char.Parse(Console.ReadLine().ToLower());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Anual income: ");
            double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (choice == 'i') {
                Console.Write("Health expenditures: ");
                double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                TaxPayers.Add(new Individual(name, anualIncome, healthExpenditures));
            }

            else {
                Console.Write("Number of employees: ");
                int nEmployees = int.Parse(Console.ReadLine());
                
                TaxPayers.Add(new Company(name, anualIncome, nEmployees));
            }

            Console.WriteLine();
        }
        
        Console.WriteLine("---------------------------------");

        Console.WriteLine("TAXES PAID: ");

        double sum = 0;

        foreach (TaxPayer taxPayer in TaxPayers) {
            Console.WriteLine(taxPayer);

            sum += taxPayer.Tax();
        }

        Console.WriteLine();
        
        Console.WriteLine($"TOTAL TAXES: $ {sum.ToString("F2", CultureInfo.InvariantCulture)}");
    }
}