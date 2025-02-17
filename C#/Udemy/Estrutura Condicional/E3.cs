using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite dois números inteiros: ");
            string[] numeros = Console.ReadLine().Split(' ');
            
            int n1 = int.Parse(numeros[0]);
            int n2 = int.Parse(numeros[1]);

            if(n1 % n2 == 0 || n2 % n1 == 0)
                Console.WriteLine("Os números são múltiplos!");

            else
                Console.WriteLine("Os números não são múltiplos!");
        }   
    }
}
