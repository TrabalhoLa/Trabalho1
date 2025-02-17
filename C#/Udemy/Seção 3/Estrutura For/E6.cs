using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite um numero: ");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Os divisores deste número são: ");

            for (int i = 1; i <= numero; i++) {
                if (numero % i == 0)
                    Console.WriteLine(i);
            }
        }
    }
}
