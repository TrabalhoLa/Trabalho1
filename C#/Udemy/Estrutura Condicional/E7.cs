using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite dois valores: ");
            string[] valores = Console.ReadLine().Split(' ');
            
            double n1 = double.Parse(valores[0], CultureInfo.InvariantCulture);
            double n2 = double.Parse(valores[1], CultureInfo.InvariantCulture);

            string quadrante = null;

            //Centro
            if (n1 == 0 && n2 == 0)
                quadrante = "Origem";
            
            //Eixo X
            else if ((n1 > 0 && n2 == 0) || (n1 < 0 && n2 == 0))
                quadrante = "Eixo X";
            
            //Eixo Y
            else if ((n2 > 0 && n1 == 0) || (n2 < 0 && n1 == 0))
                quadrante = "Eixo Y";
            
            //Canto superior direito
            else if(n1 > 0 && n2 > 0)
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
        }   
    }
}
