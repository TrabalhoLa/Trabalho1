import Atividade1.*;
import Atividade2.*;
import Atividade3.*;
import Atividade4.*;
import Atividades5e6.*;

import java.util.Scanner;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.BlockingQueue;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int escolha;

        do {
            System.out.println();
            System.out.println("Escolha uma atividade: 1, 2, 3, 4, 5, 6 ou 0 para sair");
            escolha = scanner.nextInt();

            switch (escolha) {
                case 1:
                    Atividade1();
                    break;

                case 2:
                    Atividade2();
                    break;

                case 3:
                    Atividade3();
                    break;

                case 4:
                    Atividade4();
                    break;

                case 5:
                    Atividade5();
                    break;

                case 6:
                    Atividade6();
                    break;

                default:
                    System.out.println("Escolha uma opção válida");
                    break;
            }
        } while(escolha != 0);
    }

    public static void Atividade1(){
        //Threads
        Thread thread = new Thread(new ClasseRunnable());

        //Inicia a thread
        thread.start();

        try{
            //Espera a thread terminar
            thread.join();
        } catch (InterruptedException e) {
            System.out.println(e.getMessage());
        }
    }

    public static void Atividade2(){
        //Threads
        Thread pares = new Thread(new NumerosPares(20));
        Thread impares = new Thread(new NumerosImpares(20));

        //Inicia todas as threads
        pares.start();
        impares.start();

        try{
            //Aguarda todas terminarem
            pares.join();
            impares.join();
        } catch (InterruptedException e) {
            System.out.println(e.getMessage());
        }
    }

    public static void Atividade3(){
        //Variável de controle
        Controle controle = new Controle();

        //Threads
        Thread threadPares = new Thread(new NumerosParesWait(20, controle));
        Thread threadImpares = new Thread(new NumerosImparesWait(20, controle));

        //Inicia todas as threads
        threadPares.start();
        threadImpares.start();

        try {
            //Aguarda todas terminarem
            threadPares.join();
            threadImpares.join();
        } catch (InterruptedException e) {
            System.out.println(e.getMessage());
        }
    }

    public static void Atividade4(){
        //Contador
        Contador contador = new Contador();

        //Threads
        Thread thread1 = new Thread(new Incrementador(contador, 1));
        Thread thread2 = new Thread(new Incrementador(contador, 2));
        Thread thread3 = new Thread(new Incrementador(contador, 3));
        Thread thread4 = new Thread(new Incrementador(contador, 4));
        Thread thread5 = new Thread(new Incrementador(contador, 5));

        //Inicia todas as threads
        thread1.start();
        thread2.start();
        thread3.start();
        thread4.start();
        thread5.start();

        try {
            //Espera todas as threads terminarem a execução
            thread1.join();
            thread2.join();
            thread3.join();
            thread4.join();
            thread5.join();

            //Imprime o valor total no contador(tem que ser 500000)
            System.out.println("Valor total no contador: " + contador.getValor());
        } catch (InterruptedException e) {
            System.out.println(e.getMessage());
        }
    }

    public static void Atividade5(){
        //Fila de capacidade 10
        BlockingQueue<Integer> fila = new ArrayBlockingQueue<>(10);

        //Threads
        Thread threadProdutor = new Thread(new Produtor(fila));
        Thread threadConsumidor = new Thread(new Consumidor(fila));

        //Iniciando as threads
        threadProdutor.start();
        threadConsumidor.start();

        try{
            //Esperando as threads terminarem
            threadProdutor.join();
            threadConsumidor.join();
        } catch (InterruptedException e) {
            System.out.println(e.getMessage());
        }
    }

    public static void Atividade6(){
        //Fila de capacidade 10
        BlockingQueue<Integer> fila = new ArrayBlockingQueue<>(10);

        //Quantidade de threads
        int quantProdutores = 3;
        int quantConsumidores = 2;

        //Threads de Produtor sendo criadas e iniciadas
        for(int i=0; i < quantProdutores; i++){
            Thread threadProdutor = new Thread(new Produtor(fila));
            threadProdutor.start();
        }

        //Threads de Consumidor sendo criadas e iniciadas
        for(int i=0; i < quantConsumidores; i++){
            Thread threadConsumidor = new Thread(new Consumidor(fila));
            threadConsumidor.start();
        }
    }

}
