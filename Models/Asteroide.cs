using Monogame.Processing;
using System;
using System.Collections.Generic;
using AsteroidesSingleplayer;

public class Asteroide
{
    public Vector2 Position;
    public Vector2 Velocity;
    public int Tamanho; // 4 = grande, 3 = médio, 2 = pequeno, 1 = mínimo
    public float Size;
    public bool IsActive = true;
    private Random random = new Random();

    public Asteroide(Vector2 pos, int tamanho, Processing sketch)
    {
        Position = pos;
        Tamanho = tamanho;
        Size = 30 * tamanho; // Exemplo: tamanho 4 = 120, 3 = 90, etc.
        // Velocidade aleatória
        float angle = (float)(random.NextDouble() * Math.PI * 2);
        float speed = 1.5f + (float)random.NextDouble() * 1.5f;
        // Velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * speed;
        Velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)).Multiply(speed);
    }

    public void Update(Processing sketch)
    {
        Position.Add(Velocity);
        // Faz o asteroide "sair" de um lado e aparecer do outro (efeito wrap)
        if (Position.X < -Size) Position.X = sketch.width + Size;
        if (Position.X > sketch.width + Size) Position.X = -Size;
        if (Position.Y < -Size) Position.Y = sketch.height + Size;
        if (Position.Y > sketch.height + Size) Position.Y = -Size;
    }

    public void Draw(Processing sketch)
    {
        sketch.pushMatrix();
        sketch.translate(Position.X, Position.Y);
        sketch.stroke(200);
        sketch.noFill();
        sketch.ellipse(0, 0, Size * 2, Size * 2);
        sketch.popMatrix();
    }

    // Fragmentação: retorna lista de novos asteroides menores
    public List<Asteroide> Quebrar(Processing sketch)
    {
        var fragmentos = new List<Asteroide>();
        if (Tamanho > 1)
        {
            int quantidade = 2 + random.Next(2); // 2 ou 3 fragmentos
            for (int i = 0; i < quantidade; i++)
            {
                fragmentos.Add(new Asteroide(Position, Tamanho - 1, sketch));
            }
        }
        return fragmentos;
    }
}