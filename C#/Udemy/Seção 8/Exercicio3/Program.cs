using System;
using System.Globalization;

namespace Exercicio3;

class Program{
    static void Main(string[] args){
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Enter client data");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Birth Date (DD/MM/YYYY): ");
        DateTime birth = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("-----------------------------------------");

        Console.WriteLine("Enter order data");
        Console.Write("Status: ");
        OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

        //Criando instância do cliente e da ordem
        Client client = new Client(name, email, birth);
        Order order = new Order(DateTime.Now, status, client);

        Console.Write("How many items to this order? ");
        int n = int.Parse(Console.ReadLine());
        
        Console.WriteLine("-----------------------------------------");
        
        //Instanciando todos os produtos e salvando em OrderItem
        for(int i = 0; i < n; i++){
            Console.WriteLine($"Enter #{i + 1} item data");

            Console.Write("Product name: ");
            string productName = Console.ReadLine();

            Console.Write("Product price: ");
            double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Product product = new Product(productName, productPrice);

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            OrderItem orderItem = new OrderItem(quantity, productPrice, product);

            order.addItem(orderItem);

            Console.WriteLine();
        }

        Console.WriteLine("-----------------------------------------");

        Console.WriteLine("ORDER SUMMARY");
        Console.WriteLine(order.ToString());
    }
}