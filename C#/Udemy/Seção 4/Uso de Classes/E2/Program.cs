using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            //Instanciando a classe funcionario
            Funcionario f1 = new Funcionario();
            Funcionario f2 = new Funcionario();

            //Dados do primeiro funcionario
            Console.WriteLine("Digite os dados do primeiro funcionário");
            
            Console.Write("Nome: ");
            f1.nome = Console.ReadLine();
            Console.Write("Salário: ");
            f1.Salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine();
            
            //Dados do segundo funcionario
            Console.WriteLine("Digite os dados do segundo funcionário");
            
            Console.Write("Nome: ");
            f2.nome = Console.ReadLine();
            Console.Write("Salario: ");
            f2.Salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine();
            
            //Média entre os salários
            double media = (f1.Salario + f2.Salario) / 2;

            Console.WriteLine("Salário médio entre os dois funcionários é: " + media.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}