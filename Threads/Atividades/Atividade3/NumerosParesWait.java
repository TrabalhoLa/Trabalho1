package Atividade3;
import java.util.Random;

public class NumerosParesWait implements Runnable{
    //Atributos
    private int limite;
    private Controle controle;  //Objeto de Controle

    //Construtora
    public NumerosParesWait(int limite, Controle controle){
        if (limite < 0) {
            throw new IllegalArgumentException("O limite deve ser um valor positivo");
        }
        this.limite = limite;
        this.controle = controle;
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
            if(i % 2 == 0) {
                try {
                    controle.imprimePar(i);
                    Thread.sleep(500);
                } catch (InterruptedException e) {
                    System.out.println(e.getMessage());
                    Thread.currentThread().interrupt();
                }
            }
        }
    }
}
