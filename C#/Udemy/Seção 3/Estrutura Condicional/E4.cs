using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Digite a hora inicial e a hora final do jogo: ");
            string[] horas = Console.ReadLine().Split(' ');
            
            int horaInicio = int.Parse(horas[0]);
            int horaFim = int.Parse(horas[1]);

            int duracao;
            
            if(horaInicio < horaFim)
                duracao = horaFim - horaInicio;

            else if (horaInicio > horaFim)
                duracao = 24 - horaInicio + horaFim;

            else
                duracao = 24;

            Console.WriteLine("O jogo durou " + duracao + " horas");
        }   
    }
}
