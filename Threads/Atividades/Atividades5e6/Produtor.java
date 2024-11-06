package Atividades5e6;
import java.util.concurrent.BlockingQueue;
import java.util.Random;

public class Produtor implements Runnable{
    //Atributos
    private final BlockingQueue<Integer> fila;
    private final Random random = new Random();

    //Construtora
    public Produtor(BlockingQueue<Integer> fila){
        this.fila = fila;
    }

    //Métodos
    @Override
    public void run() {
        try {
            //Enquanto puder colocar o elemento na fila, ele colocará
            while (true) {
                int elemento = random.nextInt(50);
                fila.put(elemento);
                System.out.println("Produtor colocou " + elemento + " na fila");
                Thread.sleep(1000);
            }
        }catch(InterruptedException e){
            System.out.println(e.getMessage());
            Thread.currentThread().interrupt();
        }
    }
}
