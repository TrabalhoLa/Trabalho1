using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Funcionario f1 = new Funcionario();
            
            Console.Write("Digite seu nome: ");
            f1.nome = Console.ReadLine();

            Console.Write("Digite seu salário bruto: ");
            f1.SalarioBruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Digite o valor em impostos pagos: ");
            f1.Imposto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine();
            Console.WriteLine("Funcionário: " + f1);
            Console.WriteLine();
            
            Console.Write("Digite a porcentagem para aumentar o salário: ");
            f1.AumentarSalario(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));

            Console.WriteLine();
            Console.WriteLine("Dados atualizados: " + f1);
        }   
    }
}