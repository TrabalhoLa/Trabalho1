using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite os valores A, B e C: ");
            
            string[] valores = Console.ReadLine().Split(' ');
            
            //Valores
            double v1 = double.Parse(valores[0], CultureInfo.InvariantCulture);
            double v2 = double.Parse(valores[1], CultureInfo.InvariantCulture);
            double v3 = double.Parse(valores[2], CultureInfo.InvariantCulture);
    
            //Fórmulas de cada figura geométrica
            double triangulo = (v1 * v3) / 2;
            double circulo = Math.PI * Math.Pow(v2, 2);
            double trapezio = ((v1 + v2) * v3) / 2;
            double quadrado = Math.Pow(v2, 2);
            double retangulo = v1 * v2;
            
            Console.WriteLine("A área do triângulo que tem A por base e altura C é: " + triangulo.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("A área do círculo de raio C é: " + circulo.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("A área do trapézio que tem A e B por bases e C por altura é: " + trapezio.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("A área do quadrado que tem lado B é: " + quadrado.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("A área do retângulo que tem lados A e B é: " + retangulo.ToString("F3", CultureInfo.InvariantCulture));
        }   
    }
}
