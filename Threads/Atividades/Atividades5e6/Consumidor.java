package Atividades5e6;
import java.util.concurrent.BlockingQueue;

public class Consumidor implements Runnable{
    //Atributos
    private final BlockingQueue<Integer> fila;

    //Construtora
    public Consumidor(BlockingQueue<Integer> fila){
        this.fila = fila;
    }

    //Métodos
    @Override
    public void run() {
        try {
            //Enquanto puder retirar o elemento da fila, ele retirará
            while (true) {
                int elemento = fila.take();
                System.out.println("Consumidor retirou " + elemento + " da fila");
                Thread.sleep(1000);
            }
        }catch(InterruptedException e){
            System.out.println(e.getMessage());
            Thread.currentThread().interrupt();
        }
    }
}
