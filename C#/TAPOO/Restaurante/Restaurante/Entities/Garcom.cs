using Restaurante.Entities.Enum;

namespace Restaurante.Entities;

public class Garcom {
    //Atributos
    public Random random = new Random();
    
    //Métodos
    public Pedido CriarPedido(TipoPrato tipo, int numero) {
        Thread.Sleep(random.Next(1000, 10000));
        
        Program.ConsoleLock("[Garçom] - Envio de Pedido {numero}: Prato {tipo}", ConsoleColor.Blue);
        return new Pedido(tipo);
    }
}