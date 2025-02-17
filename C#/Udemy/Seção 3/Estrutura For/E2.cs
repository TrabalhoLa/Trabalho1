using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite a quantidade de números a serem digitados: ");
            int quantidade = int.Parse(Console.ReadLine());
            Console.WriteLine();
            
            int dentro = 0;
            int fora = 0;

            for (int i = 0; i < quantidade; i++) {
                int numero = int.Parse(Console.ReadLine());

                if (numero >= 10 && numero <= 20)
                    dentro++;

                else
                    fora++;
            }
            
            Console.WriteLine();
            Console.WriteLine(dentro + " in");
            Console.WriteLine(fora + " out");
        }
    }
}
