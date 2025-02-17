using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {

            Console.WriteLine("Digite um inteiro n1: ");
            int n1 = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite um inteiro n2: ");
            int n2 = int.Parse(Console.ReadLine());

            int n3 = n1 + n2;
            Console.WriteLine("O resultado da soma entre n1 e n2 é: " + n3);
        }   
    }
}
