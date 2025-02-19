using System.Globalization;

namespace Course;

public class Funcionario {
    public string nome;
    public double SalarioBruto;
    public double Imposto;

    public double SalarioLiquido() {
        return SalarioBruto - Imposto;
    }

    public void AumentarSalario(double porcentagem) {
        SalarioBruto = SalarioBruto + (SalarioBruto * porcentagem / 100);
    }

    public override string ToString() {
        return nome 
               + ", $ " 
               + SalarioLiquido().ToString("F2", CultureInfo.InvariantCulture);
    }
}