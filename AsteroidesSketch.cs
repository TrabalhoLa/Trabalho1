using Monogame.Processing;
using AsteroidesSingleplayer;
using System;
using System.Collections.Generic;
using System.Linq; // Usado para a função RemoveAll

public class AsteroidesSketch : Processing
{
    // --- Variáveis do Jogo ---
    Ship ship;
    bool esquerda, direita, cima;
    PImage barcoSprite;

    List<Bullet> tiros = new List<Bullet>();
    List<Asteroide> asteroides = new List<Asteroide>();

    int score = 0;
    int nivelOnda = 1;
    Random rng = new Random();

    public override void Setup()
    {
        size(1000, 500);
        barcoSprite = loadImage("Assets/barco1.png");
        ship = new Ship(new Vector2(width / 2f, height / 2f));

        // Gera a primeira onda de asteroides
        SpawnAsteroides(5);
    }

    public override void Draw()
    {
        background(10, 10, 25); // Um fundo espacial escuro

        // --- Atualização dos Objetos ---
        HandleInput();
        ship.Update();

        foreach (var asteroide in asteroides)
        {
            asteroide.Update(this);
        }

        foreach (var tiro in tiros)
        {
            tiro.Update();
        }

        // --- Lógica de Colisão e Gerenciamento ---
        HandleCollisions();

        // --- Lógica de Limpeza ---
        // Remove tiros que saíram da tela ou colidiram
        tiros.RemoveAll(t => !t.IsActive || t.Position.X < 0 || t.Position.X > width || t.Position.Y < 0 || t.Position.Y > height);

        // Remove asteroides que foram destruídos
        asteroides.RemoveAll(a => !a.IsActive);

        // --- Lógica de Fim de Onda ---
        if (asteroides.Count == 0)
        {
            nivelOnda++;
            SpawnAsteroides(4 + nivelOnda); // Gera uma nova onda, um pouco mais difícil

        }

        // --- Desenho dos Objetos ---
        ship.Draw(this, barcoSprite);

        foreach (var asteroide in asteroides)
        {
            asteroide.Draw(this);
        }

        foreach (var tiro in tiros)
        {
            tiro.Draw(this);
        }

        // --- Desenho da Interface (Score) ---
        DrawUI();
    }

    void HandleCollisions()
    {
        var novosFragmentos = new List<Asteroide>();

        foreach (var asteroide in asteroides)
        {
            if (!asteroide.IsActive) continue;

            foreach (var tiro in tiros)
            {
                if (!tiro.IsActive) continue;

                // Calcula a distância entre o centro do asteroide e o tiro
                float distancia = asteroide.Position.Distance(tiro.Position);

                // Se a distância for menor que a soma dos raios (raio do asteroide + raio do tiro)
                if (distancia < asteroide.Size + 8) // Raio do asteroide é 'Size', raio do tiro é ~8
                {
                    // Marca ambos para remoção
                    asteroide.IsActive = false;
                    tiro.IsActive = false;


                    score += asteroide.Tamanho;


                    if (asteroide.Tamanho > 1)
                    {
                        novosFragmentos.AddRange(asteroide.Quebrar(this));
                    }

                    break;
                }
            }
        }

        if (novosFragmentos.Any())
        {
            asteroides.AddRange(novosFragmentos);
        }
    }

    void SpawnAsteroides(int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {

            Vector2 pos;
            if (rng.Next(2) == 0)
            {
                pos = new Vector2(rng.Next(width), rng.Next(2) == 0 ? -50 : height + 50);
            }
            else
            {
                pos = new Vector2(rng.Next(2) == 0 ? -50 : width + 50, rng.Next(height));
            }

            asteroides.Add(new Asteroide(pos, 4, this));
        }
    }

    void DrawUI()
    {
        fill(255);
        textSize(40);
        textAlign(TextAlign.RIGHT);
        text($"Score: {score}", width - 30, 50);
    }


    void HandleInput()
    {
        esquerda = keyPressed && keyCode == Microsoft.Xna.Framework.Input.Keys.Left;
        direita = keyPressed && keyCode == Microsoft.Xna.Framework.Input.Keys.Right;
        cima = keyPressed && keyCode == Microsoft.Xna.Framework.Input.Keys.Up;

        if (keyPressed && keyCode == Microsoft.Xna.Framework.Input.Keys.Space)
        {
            tiros.Add(new Bullet(ship.Position, ship.Rotation));
        }

        ship.HandleInput(esquerda, direita, cima);
    }
}

