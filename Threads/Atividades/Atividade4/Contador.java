package Atividade4;

public class Contador {
    //Atributos
    private int valor;

    //Métodos
    public synchronized void incrementar(){
        valor++;
    }

    //Getter
    public int getValor() {
        return valor;
    }
}
