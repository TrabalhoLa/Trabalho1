using System.Globalization;

namespace Course;

public class Retangulo {
    public double altura, largura;
    
    public double Area() {
        return altura * largura;
    }

    public double Perimetro() {
        return 2 * (altura + largura);
    }

    public double Diagonal() {
        return Math.Sqrt(Math.Pow(altura, 2) + Math.Pow(largura, 2));
    }

    public override string ToString() {
        return "Área: " + Area().ToString("F2", CultureInfo.InvariantCulture)
            +  "\nPerímetro: " + Perimetro().ToString("F2", CultureInfo.InvariantCulture)
            +  "\nDiagonal: " + Diagonal().ToString("F2", CultureInfo.InvariantCulture);
    }
}