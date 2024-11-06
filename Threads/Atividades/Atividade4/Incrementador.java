package Atividade4;

public class Incrementador implements Runnable{
    //Atributos
    private Contador contador;
    private int numeroThread;

    //Construtora
    public Incrementador(Contador contador, int numeroThread){
        this.contador = contador;
        this.numeroThread = numeroThread;
    }

    //Métodos
    @Override
    public void run() {
        //For para que cada thread incremente 100000 vezes
        for(int i=0; i<100000; i++){
            contador.incrementar();
        }
        System.out.println("Thread " + numeroThread + " terminou de incrementar");
    }
}
