using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite o seu salário: ");
            double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double imposto = 0;

            if (salario >= 0 && salario <= 2000)
                imposto = 0;

            else if (salario >= 2000.1 && salario <= 3000)
                imposto = (salario - 2000) * 0.08;
            
            else if (salario >= 3000.1 && salario <= 4500)
                imposto = (salario - 3000) * 0.18 + 1000 * 0.08;
            
            else if (salario >= 4500.1)
                imposto = (salario - 4500) * 0.28 + 1500 * 0.18 + 1000 * 0.08;
            
            if(imposto == 0)
                Console.WriteLine("Baseado no seu salário, você é isento do imposto de renda!");

            else
                Console.WriteLine("Baseado no seu salário, o imposto de renda a ser pago é de: R$" + imposto.ToString("F2", CultureInfo.InvariantCulture));
        }   
    }
}
