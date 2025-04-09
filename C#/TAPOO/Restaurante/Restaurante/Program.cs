using Restaurante.Entities;
using Restaurante.Entities.Enum;

namespace Restaurante;

public class Program {
    //Atributos
    static Queue<Pedido> filaPedidos = new Queue<Pedido>();
    
    static object lockConsole = new();
    
    //Método para mudar cor de print no console
    public static void ConsoleLock(string msg, ConsoleColor color)
    {
        lock(lockConsole)
        {
            var aux = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine($"{msg}");
            Console.ForegroundColor = aux;
        }
    }
    
    public static void Main(string[] args) {
        Chef chef = new Chef();
        Garcom garcom = new Garcom();
        Random random = new Random();
        int numeroPedido = 0;

        Thread threadGarcom = new Thread(() =>
        {
            while (true)
            {
                TipoPrato tipo = (TipoPrato)random.Next(0, 3);
                Pedido pedido = garcom.CriarPedido(tipo, numeroPedido++);

                lock (lockConsole)
                {
                    filaPedidos.Enqueue(pedido);
                }
            }
        });

        Thread threadChef = new Thread(() =>
        {
            int numeroAtendido = 0;
            while (true)
            {
                Pedido? pedido = null;

                lock (lockConsole)
                {
                    if (filaPedidos.Count > 0)
                    {
                        pedido = filaPedidos.Dequeue();
                    }
                }

                if (pedido != null)
                {
                    chef.PrepararPedido(pedido, numeroAtendido++);
                }
                else
                {
                    Thread.Sleep(500); // Espera um pouco se não tem pedidos
                }
            }
        });
        
        threadGarcom.Start();
        threadChef.Start();

        threadGarcom.Join();
        threadChef.Join();
    }
}