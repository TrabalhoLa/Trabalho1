package Entidades;

import java.util.ArrayList;
import java.util.List;

class Conta {
    //Atributos
    private String numero;
    private Agencia agencia;
    private final List<Cliente> clientes;

    //Construtora
    public Conta(String numero, Agencia agencia) {
        this.numero = numero;
        this.agencia = agencia;
        this.clientes = new ArrayList<>();
        agencia.adicionarConta(this);
    }

    //Getters e Setters
    public String getNumero() {
        return numero;
    }

    public Agencia getAgencia() {
        return agencia;
    }

    public List<Cliente> getClientes() {
        return clientes;
    }

    public void setNumero(String numero) {
        this.numero = numero;
    }

    public void setAgencia(Agencia agencia) {
        this.agencia = agencia;
    }

    //Métodos
    public void adicionarCliente(Cliente cliente) {
        if (!clientes.contains(cliente)) {
            clientes.add(cliente);
            cliente.adicionarConta(this);
        }
    }

    public void removerCliente(Cliente cliente) {
        if (clientes.contains(cliente)) {
            clientes.remove(cliente);
            cliente.removerConta(this);
        }
    }
}