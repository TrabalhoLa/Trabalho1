using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Aluno aluno = new Aluno();
            
            Console.Write("Digite o nome do aluno: ");
            aluno.nome = Console.ReadLine();

            Console.WriteLine("Digite as três notas dos alunos: ");
            
            string[] notas = Console.ReadLine().Split(' ');
            aluno.nota[0] = double.Parse(notas[0], CultureInfo.InvariantCulture);
            aluno.nota[1] = double.Parse(notas[1], CultureInfo.InvariantCulture);
            aluno.nota[2] = double.Parse(notas[2], CultureInfo.InvariantCulture);

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