using Restaurante.Entities.Enum;

namespace Restaurante.Entities;

public class Pedido {
    //Atributos
    public TipoPrato Tipo { get; private set; }
    
    //Construtores
    public Pedido() {
    }

    public Pedido(TipoPrato tipo) {
        Tipo = tipo;
    }
    
    //Métodos
    public override string ToString() {
        return $"Pedido: {Tipo}";
    }
}