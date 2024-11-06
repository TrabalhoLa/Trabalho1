package Entidades;

import java.util.ArrayList;
import java.util.List;

class Banco {
    //Atributos
    private int id;
    private String nome;
    private final List<Agencia> agencias;

    //Construtora
    public Banco(int id, String nome) {
        this.id = id;
        this.nome = nome;
        this.agencias = new ArrayList<>();
    }

    //Getters e Setters
    public int getId() {
        return id;
    }

    public String getNome() {
        return nome;
    }

    public List<Agencia> getAgencias() {
        return agencias;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    //Métodos
    public void adicionarAgencia(Agencia agencia) {
        agencias.add(agencia);
    }

    public void removerAgencia(Agencia agencia) {
        agencias.remove(agencia);
    }
}