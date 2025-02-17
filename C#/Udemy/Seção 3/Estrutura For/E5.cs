using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite um numero: ");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int fatorial = 1;
            
            for(int i = 1; i <= numero; i++)
                fatorial *= i;

            Console.WriteLine("O fatorial deste número é: " + fatorial);
        }
    }
}
