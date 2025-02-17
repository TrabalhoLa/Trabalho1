using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Dê as coordenadas x, y num plano cartesiano (o programa só encerra caso x ou y sejam 0): ");
            string[] valores = Console.ReadLine().Split(' ');
            
            int n1 = int.Parse(valores[0]);
            int n2 = int.Parse(valores[1]);

            string quadrante = null;

            while (n1 != 0 && n2 != 0) {
                //Canto superior direito
                if (n1 > 0 && n2 > 0)
                    quadrante = "Q1";
            
                //Canto superior esquerdo
                else if(n1 < 0 && n2 > 0)
                    quadrante = "Q2";
            
                //Canto inferior esquerdo
                else if(n1 < 0 && n2 < 0)
                    quadrante = "Q3";
            
                //Canto inferior direito
                else if(n1 > 0 && n2 < 0)
                    quadrante = "Q4";

                Console.WriteLine(quadrante);
                Console.WriteLine();
                
                valores = Console.ReadLine().Split(' ');
                n1 = int.Parse(valores[0]);
                n2 = int.Parse(valores[1]);
            }
        }   
    }
}
