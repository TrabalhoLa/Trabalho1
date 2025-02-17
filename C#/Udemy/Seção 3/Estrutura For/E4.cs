using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite a quantidade de pares a serem digitados: ");
            int quantidade = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 0; i < quantidade; i++) {
                string[] valores = Console.ReadLine().Split(' ');
                
                int n1 = int.Parse(valores[0]);
                int n2 = int.Parse(valores[1]);

                if (n2 == 0) {
                    Console.WriteLine("Divisão impossível");
                    Console.WriteLine();
                }

                else {
                    double divisao = (double)n1 / n2;

                    Console.WriteLine("Resultado da divisão entre n1 e n2: " + divisao.ToString("F1", CultureInfo.InvariantCulture));
                    Console.WriteLine();
                }
            }
        }
    }
}
