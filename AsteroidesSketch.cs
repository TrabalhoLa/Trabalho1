using Monogame.Processing;
using AsteroidesSingleplayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.VisualBasic;
//using Microsoft.Xna.Framework; // Usado para a função RemoveAll

public class AsteroidesSketch : Processing
{
    // --- Variáveis do Jogo ---
    Ship ship;
    bool esquerda, direita, cima, baixo;
    PImage barcoSprite;
    PImage[] tiroSprite = new PImage[6];

    List<Bullet> tiros = new List<Bullet>();
    List<Asteroide> asteroides = new List<Asteroide>();

    int score = 0;
    int nivelOnda = 1;
    Random rng = new Random();

    int municao = 0;
    int counTimer = 0;

    public override void Setup()
    {
        size(1000, 500);
        FrameRate(100);
        barcoSprite = loadImage("Assets/barco1.png");
        tiroSprite[0] = loadImage("Assets/nota1.png");
        tiroSprite[1] = loadImage("Assets/nota2.png");
        tiroSprite[2] = loadImage("Assets/nota3.png");
        tiroSprite[3] = loadImage("Assets/nota4.png");
        tiroSprite[4] = loadImage("Assets/nota5.png");
        tiroSprite[5] = loadImage("Assets/nota6.png");

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
        esquerda = false;
        direita = false;
        if (mousePressed && (mouseButton == LEFT))
        {
            esquerda = true;
        }
        else if (mousePressed && (mouseButton == RIGHT))
        {
            direita = true;
        }
        cima = (keyCode == Microsoft.Xna.Framework.Input.Keys.Up || key == 'w' && keyPressed) ? true : false;
        baixo = (keyCode == Microsoft.Xna.Framework.Input.Keys.Down || key == 's' && keyPressed) ? true : false;


        if (keyPressed && key == 'q' && counTimer > 1)
        {
            municao = 5;
        }
        handleTiro();
        ship.HandleInput(esquerda, direita, cima, baixo);
    }

    void handleTiro()
    {
        counTimer++;
        if (counTimer > 1 && municao > 0)
        {
            counTimer = 0;
            municao--;
            float pinagem = (float)Math.PI / 180 * (10 - rng.Next(20));
            tiros.Add(new Bullet(ship.Position.Add(
                    new Vector2((float)Math.Cos(ship.Rotation + Math.PI / 2) * -35 - 20,
                    ((float)Math.Sin(ship.Rotation + Math.PI / 2) * -35 - 20))),
                ship.Rotation + pinagem,
                tiroSprite[municao]
            ));

            ship.Position = ship.Position.Add(new Vector2(
                (float)Math.Sin(-ship.Rotation) - pinagem,
                (float)Math.Cos(-ship.Rotation) - pinagem
            ));
        }

    }
}
/*


    tiros.Add(new Bullet(ship.Position.Add(new Vector2(
                20 + (float)Math.Cos(ship.Rotation + Math.PI / 2) * -35,
                20 + (float)Math.Sin(ship.Rotation + Math.PI / 2) * -35)),
                ship.Rotation + pinagem,
                tiroSprite[municao]
            ));

    void HandleInput()
    { 
        if (keyPressed)
        {
            HandleInput(true);
        }
    }

    void HandleInput(bool type)
    {

        //esse ()? : é nescessario pra não deixar todos os não recem pressionados false quando a função é chamada
        cima = (keyCode == Microsoft.Xna.Framework.Input.Keys.Up) ? type : cima;
        esquerda = false;
        direita = false;
        esquerda = (keyCode == Microsoft.Xna.Framework.Input.Keys.Left) ? type : esquerda;
        direita = (keyCode == Microsoft.Xna.Framework.Input.Keys.Right) ? type : direita;

        if (keyCode == Microsoft.Xna.Framework.Input.Keys.Space)
        {
            tiros.Add(new Bullet(ship.Position.Add(new Vector2(40, 40)), ship.Rotation));
        }

        ship.HandleInput(esquerda, direita, cima);
    }
    
    /* 
    if (mousePressed && (mouseButton == LEFT))
        {
            Console.WriteLine("Left");
        }
        else if (mousePressed && (mouseButton == RIGHT))
        {
            Console.WriteLine("Right");
        }
    */


