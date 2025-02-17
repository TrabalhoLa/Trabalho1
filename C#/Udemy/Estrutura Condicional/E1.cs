using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite um número inteiro: ");
            int numero = int.Parse(Console.ReadLine());

            if (numero >= 0)
                Console.WriteLine("O número digitado é positivo!");

            else
                Console.WriteLine("O número digitado é negativo!");
        }   
    }
}
