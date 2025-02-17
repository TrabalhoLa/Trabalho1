using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite um numero: ");
            int numero = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Números ímpares de 1 até o número:");

            for (int i = 1; i <= numero; i++) {
                if(i % 2 != 0)
                    Console.WriteLine(i);
            }
        }
    }
}
