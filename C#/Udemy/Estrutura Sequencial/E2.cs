using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite o valor do raio do círculo: ");
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            double area = Math.PI * Math.Pow(raio, 2);

            Console.WriteLine("A área do círculo é: " + area.ToString("F4", CultureInfo.InvariantCulture));
        }   
    }
}
