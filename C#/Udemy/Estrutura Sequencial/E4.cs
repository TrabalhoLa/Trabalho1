using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite seu número de funcionario: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite seu número de horas trabalhadas: ");
            int hours = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor que você recebe por hora: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double salary = value * hours;

            Console.WriteLine();
            Console.WriteLine("Número: " + id);
            Console.WriteLine("Salário: R$" + salary.ToString("F2", CultureInfo.InvariantCulture));
        }   
    }
}
