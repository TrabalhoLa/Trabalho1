using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            //Especificações
            Console.WriteLine("Código: 1; Especificação: Cachorro Quente; Preço: R$4.00");
            Console.WriteLine("Código: 2; Especificação: X-Salada; Preço: R$4.50");
            Console.WriteLine("Código: 3; Especificação: X-Bacon; Preço: R$5.00");
            Console.WriteLine("Código: 4; Especificação: Torrada Simples; Preço: R$2.00");
            Console.WriteLine("Código: 5; Especificação: Refrigerante; Preço: R$1.50");
            Console.WriteLine();
            
            Console.WriteLine("Digite o código do item e a quantidade do mesmo de 1-5: ");
            string[] item = Console.ReadLine().Split(' ');
            
            int id = int.Parse(item[0]);
            int quantidade = int.Parse(item[1]);
            
            double total = 0;

            //Verificações
            if (id == 1)
                total = quantidade * 4.00;
            
            else if (id == 2)
                total = quantidade * 4.50;
            
            else if (id == 3)
                total = quantidade * 5.00;
            
            else if (id == 4)
                total = quantidade * 2.00;
            
            else if (id == 5)
                total = quantidade * 1.50;

            Console.WriteLine("Total a se pagar: R$" + total.ToString("F2", CultureInfo.InvariantCulture));
        }   
    }
}
