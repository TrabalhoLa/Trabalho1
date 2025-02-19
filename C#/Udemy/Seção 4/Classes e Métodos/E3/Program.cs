using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Aluno aluno = new Aluno();
            
            Console.Write("Digite o nome do aluno: ");
            aluno.nome = Console.ReadLine();

            Console.WriteLine("Digite as três notas dos alunos separadas por espaço:");
            string[] notas = Console.ReadLine().Split(' ');

            for (int i = 0; i < 3; i++)
                aluno.nota[i] = double.Parse(notas[i], CultureInfo.InvariantCulture);
            
            Console.WriteLine();
            
            if(aluno.Aprovado()){
                Console.WriteLine("Nota final: " + aluno.NotaFinal().ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Aprovado!");
            }

            else {
                Console.WriteLine("Nota final: " + aluno.NotaFinal().ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Reprovado!");
                Console.WriteLine("Faltaram " + aluno.NotaRestante().ToString("F2", CultureInfo.InvariantCulture) + " pontos");
            }
        }   
    }
}
