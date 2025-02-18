using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Pessoa p1 = new Pessoa();
            Pessoa p2 = new Pessoa();

            Console.WriteLine("Digite os dados da primeira pessoa");
            
            Console.Write("Nome: ");
            p1.nome = Console.ReadLine();
            Console.Write("Idade: ");
            p1.idade = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite os dados da segunda pessoa");
            
            Console.Write("Nome: ");
            p2.nome = Console.ReadLine();
            Console.Write("Idade: ");
            p2.idade = int.Parse(Console.ReadLine());

            Console.WriteLine();
            
            if(p1.idade > p2.idade)
                Console.WriteLine("Pessoa mais velha: " + p1.nome);

            else
                Console.WriteLine("Pessoa mais velha: " + p2.nome);
        }
    }
}
