package Entidades;

import java.util.ArrayList;
import java.util.List;

class Agencia {
    //Atributos
    private String codigo;
    private Banco banco;
    private final List<Conta> contas;

    //Construtora
    public Agencia(String codigo, Banco banco) {
        this.codigo = codigo;
        this.banco = banco;
        this.contas = new ArrayList<>();
        banco.adicionarAgencia(this);
    }

    //Getters e Setters
    public String getCodigo() {
        return codigo;
    }

    public Banco getBanco() {
        return banco;
    }

    public List<Conta> getContas() {
        return contas;
    }

    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    public void setBanco(Banco banco) {
        this.banco = banco;
    }

    //Métodos
    public void adicionarConta(Conta conta) {
        contas.add(conta);
    }

    public void removerConta(Conta conta) {
        contas.remove(conta);
    }
}