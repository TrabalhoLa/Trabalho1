using System.Globalization;
using Exercicio2.Accounts;
using Exercicio2.Accounts.Exceptions;

namespace Exercicio2;

public class Program {
    public static void Main(string[] args) {
        try
        {
            Console.WriteLine("Enter account data");

            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Holder: ");
            string holder = Console.ReadLine();

            Console.Write("Initial balance: ");
            double initialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Withdraw limit: ");
            double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Account account = new Account(number, holder, initialBalance, withdrawLimit);

            Console.WriteLine("-------------------------------------------");

            Console.Write("Enter ammount for withdraw: ");
            double withdrawAmmount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            account.Withdraw(withdrawAmmount);

            Console.WriteLine($"New balance: {account.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine("-------------------------------------------");
        }

        catch (DomainException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (FormatException e) {
            Console.WriteLine("Input string was not in a correct format.");
        }
    }
}