using System.Globalization;
using Exercicio1.Entities;
using Exercicio1.Services;

namespace Exercicio1;

public class Program {
    public static void Main(string[] args) {
        Console.WriteLine("Enter contract data");

        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Date (dd/MM/yyyy): ");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Console.Write("Contract value: ");
        double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Enter number of installments: ");
        int numberOfInstallments = int.Parse(Console.ReadLine());
        
        Contract contract = new Contract(number, date, contractValue);
        
        ContractService contractService = new ContractService(new PaypalService());
        contractService.ProcessContract(contract, numberOfInstallments);

        Console.WriteLine("Installments: ");
        foreach (Installment installment in contract.Installments) {
            Console.WriteLine(installment);
        }
    }
}