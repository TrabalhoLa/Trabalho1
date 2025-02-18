using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Retangulo retangulo = new Retangulo();

            Console.WriteLine("Entre a largura e altura do retângulo: ");
            
            retangulo.altura = double.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            retangulo.largura = double.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);

            Console.WriteLine();
            Console.WriteLine(retangulo);
        }
    }
}
