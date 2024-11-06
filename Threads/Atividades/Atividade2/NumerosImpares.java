package Atividade2;
import java.util.Random;

public class NumerosImpares implements Runnable{
    //Atributos
    private int limite;

    //Construtora
    public NumerosImpares(int limite){
        if (limite < 0) {
            throw new IllegalArgumentException("O limite deve ser um valor positivo");
        }
        this.limite = limite;
    }

    //Getters e Setters
    public int getLimite() {
        return limite;
    }

    public void setLimite(int limite){
        if (limite < 0) {
            throw new IllegalArgumentException("O limite deve ser um valor positivo");
        }
        this.limite = limite;
    }

    @Override
    public void run(){
        Random random = new Random();

        for(int i=0; i <= this.limite; i++){
            if(i % 2 != 0) {
                try {
                    int intervaloAleatorio = random.nextInt(1000);

                    System.out.println(i + " || Tempo: " + intervaloAleatorio + "ms");
                    Thread.sleep(intervaloAleatorio);
                } catch (InterruptedException e) {
                    System.out.println(e.getMessage());
                }
            }
        }
    }

}
