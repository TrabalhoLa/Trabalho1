using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite a senha: ");
            int senha = int.Parse(Console.ReadLine());

            while (senha != 2002) {
                Console.WriteLine("Senha incorreta!");
                Console.WriteLine();

                Console.WriteLine("Digite a senha: ");
                senha = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Acesso permitido!");
        }   
    }
}
