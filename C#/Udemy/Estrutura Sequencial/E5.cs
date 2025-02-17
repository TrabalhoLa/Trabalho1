using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            int[] id = new int[2];
            int[] quantidade = new int[2];
            double[] valor = new double[2];

            double total = 0;

            for (int i = 0; i < 2; i++) {
                int aux = i + 1;
                
                Console.WriteLine("Digite o código de uma peça " + aux + ":");
                id[i] = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o código de peças " + aux + ":");
                quantidade[i] = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o valor unitário de cada peça " + aux + ":");
                valor[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine();
                
                total += valor[i] * quantidade[i];
            }

            Console.WriteLine("O valor total a se pagar é: R$" + total.ToString("F2", CultureInfo.InvariantCulture));
        }   
    }
}
