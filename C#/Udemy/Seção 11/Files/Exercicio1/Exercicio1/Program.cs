using System.Globalization;
using System.IO;

public class Program {
    public static void Main(string[] args) {
        string path = @"C:\Users\walte\OneDrive\Documentos\Projects\C#\Seção 11\Files\summary.csv";

        try
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] fields = line.Split(',');

                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        double total = price * quantity;

                        Console.WriteLine($"{name}, {total.ToString("F2", CultureInfo.InvariantCulture)}");
                    }
                }
            }
        }

        catch (IOException e) {
            Console.WriteLine(e.Message);
        }
    }
}
