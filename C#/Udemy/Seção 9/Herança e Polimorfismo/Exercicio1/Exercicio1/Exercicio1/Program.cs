using System.Globalization;

namespace Exercicio1;

public class Program {
    public static void Main(string[] args) {
        List<Employee> employees = new List<Employee>();
        
        Console.Write("Enter the number of employees: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("-------------------------------------------");

        for (int i = 0; i < n; i++) {
            Console.WriteLine($"Employee {i + 1} data: ");

            Console.Write("Outsorcered (y/n)? ");
            char ch = char.Parse(Console.ReadLine().ToLower());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Hours: ");
            int hours = int.Parse(Console.ReadLine());

            Console.Write("Value per hour: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (ch == 'y') {
                Console.Write("Additional charge: ");
                double charge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                employees.Add(new OutsourcedEmployee(name, hours, value, charge));
            }

            else
                employees.Add(new Employee(name, hours, value));

            Console.WriteLine();
        }

        Console.WriteLine("-------------------------------------------");
        
        Console.WriteLine("PAYMENTS");

        foreach (Employee emp in employees) {
            Console.WriteLine(emp.ToString());
        }
    }
}