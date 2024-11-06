package Atividade3;

public class Controle {
    //Atributos
    private boolean turnoPar = true;

    //Métodos
    public synchronized void imprimePar(int numero) throws InterruptedException{
        while(!turnoPar)  //Caso seja a vez de um impar, ele espera para ser imprimido
            wait();

        System.out.println(numero);
        turnoPar = false;  //Muda a vez após imprimir um par
        notify();
    }

    public synchronized void imprimeImpar(int numero) throws InterruptedException{
        while(turnoPar)  //Caso seja a vez de um impar, ele espera para ser imprimido
            wait();

        System.out.println(numero);
        turnoPar = true;  //Muda a vez após imprimir um ímpar
        notify();
    }
}
