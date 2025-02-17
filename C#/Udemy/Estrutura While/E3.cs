using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Informe o código do combustível desejado: ");
            Console.WriteLine("1-Álcool; 2-Gasolina; 3-Diesel; 4-Fim");
            
            int opcao = int.Parse(Console.ReadLine());
            
            int alcool = 0;
            int gasolina = 0;
            int diesel = 0;

            while (opcao != 4) {
                if (opcao < 1 || opcao > 4) {
                    Console.WriteLine("Digite uma opção válida!");
                    Console.WriteLine();
                }
                
                else if(opcao == 1)
                    alcool++;
                
                else if(opcao == 2)
                    gasolina++;
                
                else if(opcao == 3)
                    diesel++;
                
                opcao = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            
            Console.WriteLine("Muito obrigado por abastecer!");
            Console.WriteLine("Álcool: " + alcool);
            Console.WriteLine("Gasolina: " + gasolina);
            Console.WriteLine("Diesel: " + diesel);
        }
    }
}
