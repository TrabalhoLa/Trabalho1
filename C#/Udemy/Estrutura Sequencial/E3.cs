using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            int[] valores = new int[4];

            Console.WriteLine("Digite quatro valores: ");

            for (int i = 0; i < 4; i++) 
                valores[i] = int.Parse(Console.ReadLine());
            
            int produto1 = valores[0] * valores[1];
            int produto2 = valores[2] * valores[3];
            
            int diferenca = produto1 - produto2;

            Console.WriteLine("Diferença entre o produto de A e B, pelo produto de C e D: " + diferenca);
        }   
    }
}
