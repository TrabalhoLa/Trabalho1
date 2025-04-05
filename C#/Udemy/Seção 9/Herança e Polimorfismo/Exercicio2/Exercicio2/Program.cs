using System.Globalization;
using Exercicio2.Products;

namespace Exercicio2;

public class Program {
    public static void Main(string[] args){
        List<Product> Products = new List<Product>();
        
        Console.Write("Enter the number of products: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("-----------------------------------");

        for (int i = 0; i < n; i++) {
            Console.WriteLine($"Product {i+1} data: ");

            Console.Write("Common, used or imported (c/u/i)? ");
            char ch = char.Parse(Console.ReadLine().ToLower());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (ch == 'i') {
                Console.Write("Customs fee: ");
                double fee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                Products.Add(new ImportedProduct(name, price, fee));
            }
            
            else if (ch == 'u') {
                Console.Write("Manufacture date (DD/MM/YYYY): ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                
                Products.Add(new UsedProduct(name, price, date));
            }

            else 
                Products.Add(new Product(name, price));

            Console.WriteLine();
        }
        
        Console.WriteLine("-----------------------------------");

        Console.WriteLine("PRICE TAGS: ");

        foreach (Product product in Products) {
            Console.WriteLine(product);
        }
    }
}