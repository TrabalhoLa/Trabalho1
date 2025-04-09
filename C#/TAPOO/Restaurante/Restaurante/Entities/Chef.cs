using Restaurante.Entities.Enum;

namespace Restaurante.Entities;

public class Chef {
    //Atributos
    public int arroz = 0;
    public int carne = 0;
    public int macarrao = 0;
    public int molho = 0;
    
    //Métodos
    public void PrepararPedido(Pedido pedido, int numero) {
        switch (pedido.Tipo) {
            case TipoPrato.Executivo:
                Program.ConsoleLock("[Chef] Inicio da Preparação do Pedido {numero}", ConsoleColor.Red);
                
                VerificiarEPreparar(ref arroz, 1, "arroz", 3);
                VerificiarEPreparar(ref carne, 1, "carne", 2);
                arroz--;
                carne--;
                Thread.Sleep(2000);
                
                Program.ConsoleLock("[Chef] Fim da Preparação do Pedido {numero}", ConsoleColor.Red);
                break;
            
            case TipoPrato.Italiano:
                Program.ConsoleLock("[Chef] Inicio da Preparação do Pedido {numero}", ConsoleColor.Red);
                
                VerificiarEPreparar(ref macarrao, 1, "macarrao", 4);
                VerificiarEPreparar(ref molho, 1, "molho", 2);
                macarrao--;
                molho--;
                Thread.Sleep(2000);
                
                Program.ConsoleLock("[Chef] Fim da Preparação do Pedido {numero}", ConsoleColor.Red);
                break;
                
            case TipoPrato.Especial: 
                Program.ConsoleLock("[Chef] Inicio da Preparação do Pedido {numero}", ConsoleColor.Red);
                
                VerificiarEPreparar(ref arroz, 1, "arroz", 3);
                VerificiarEPreparar(ref carne, 1, "carne", 2);
                VerificiarEPreparar(ref molho, 1, "molho", 2);
                arroz--;
                carne--;
                molho--;
                Thread.Sleep(3000);
                
                Program.ConsoleLock("[Chef] Fim da Preparação do Pedido {numero}", ConsoleColor.Red);
                break;
        }
    }

    public void VerificiarEPreparar(ref int ingrediente, int quantidadeNecessaria, string nome, int quantidade) {
        Program.ConsoleLock("[Chef] Iniciando produção de {nome}", ConsoleColor.Green);
        
        while (ingrediente < quantidadeNecessaria) {
            Thread.Sleep(2000);
            ingrediente += quantidade;
            Program.ConsoleLock("[Chef] Finalizou produção de {nome}. Estoque atualizado: {ingrediente} unidades", ConsoleColor.Green);
        }
    }
}