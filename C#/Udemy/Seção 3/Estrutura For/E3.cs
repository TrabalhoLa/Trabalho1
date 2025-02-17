using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite a quantidade de números a serem digitados: ");
            int quantidade = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 0; i < quantidade; i++) {
                string[] valores = Console.ReadLine().Split(' ');
                
                double n1 = double.Parse(valores[0], CultureInfo.InvariantCulture);
                double n2 = double.Parse(valores[1], CultureInfo.InvariantCulture);
                double n3 = double.Parse(valores[2], CultureInfo.InvariantCulture);
                
                double ponderada = (n1 * 2 + n2 * 3 + n3 * 5) / 10;

                Console.WriteLine("Média ponderada do conjunto: " + ponderada.ToString("F1"), CultureInfo.InvariantCulture);
                Console.WriteLine();
            }
        }
    }
}
