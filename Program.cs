using System;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        using var jogo = new AsteroidesSketch();
        jogo.Run();
    }
}
