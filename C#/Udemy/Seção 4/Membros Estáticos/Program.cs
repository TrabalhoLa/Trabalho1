using System.Globalization;

namespace Course;

public class Program {
    public static void Main(string[] args) {
        Console.Write("Cotação do dólar: ");
        double cotacao = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Quantos dólares vai comprar: ");
        double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.WriteLine();
        Console.WriteLine("Valor a ser pago em reais: " + ConversorDeMoeda.Total(cotacao, valor).ToString("F2", CultureInfo.InvariantCulture));
    }
}
