using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite um numero: ");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i <= numero; i++) {
                int quadrado = (int)Math.Pow(i, 2);
                int cubo = (int)Math.Pow(i, 3);

                Console.WriteLine("{0} {1} {2}", i, quadrado, cubo);
            }
        }
    }
}
