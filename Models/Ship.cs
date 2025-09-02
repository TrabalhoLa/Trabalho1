using System;
using Monogame.Processing;

namespace AsteroidesSingleplayer
{
    public class Ship : GameObject
    {
        //propiedades - nave
        public float Rotation { get; set; }
        public float RotationSpeed { get; set; }
        public float Acceleration { get; set; }
        public float MaxSpeed { get; set; }

        // constructor
        public Ship(Vector2 position) : base(position, 20f) // tamanho da nave = 20
        {
            Rotation = 0f;
            RotationSpeed = 0.06f; // radianos por frame
            Acceleration = 0.2f;
            MaxSpeed = 2f;
            Velocity = new Vector2(0, 0);
        }

        // METODOS ABSTRATOS
        public override void Update()
        {
            UpdatePosition();

            //limite para velocidade maxima
            float currentSpeed = (float)Math.Sqrt(Velocity.X * Velocity.X + Velocity.Y * Velocity.Y);
            if (currentSpeed > MaxSpeed)
            {
                float scale = MaxSpeed / currentSpeed;
                Velocity = Velocity.Multiply(scale);
            }
            //Uma especie de "atrito" faz a velocidade dimnuir em 2% por frame
            Velocity = Velocity.Multiply(0.98f); 
            
            if (Position.X > 1000 + 80 + 7) Position.X = -80 - 6;
            if (Position.X < -80 - 7) Position.X = 1000 + 80 + 6;
            if (Position.Y > 500 + 80 + 7) Position.Y = -80 - 6;
            if (Position.Y < -80 - 7) Position.Y = 500 + 80 + 6;
        }

        // Desenha a nave usando sprite com rotação
        public void Draw(Processing g, PImage barcoSprite)
        {
            /*
            g.pushMatrix();
            g.translate(Position.X - 40, Position.Y - 40);
            g.triangle(
             40 + (float)Math.Cos(Rotation + Math.PI * 43 / 90) * -55,
             40 + (float)Math.Sin(Rotation + Math.PI * 43 / 90) * -55,
             40 + (float)Math.Cos(Rotation + Math.PI * 47 / 90) * -55,
             40 + (float)Math.Sin(Rotation + Math.PI * 47 / 90) * -55,
             40 + (float)Math.Cos(Rotation + Math.PI / 2) * -70,
             40 + (float)Math.Sin(Rotation + Math.PI / 2) * -70
             );
            g.popMatrix(); 
            */
            g.pushMatrix();
            g.translate(Position.X, Position.Y);
            g.rotate(Rotation);
            g.image(barcoSprite, -40, -40, 80, 80);
            g.popMatrix();
            //Console.WriteLine($"({Position.X}), ({Position.Y})");
        }

        // Lê o teclado e atualiza rotação/velocidade usando flags booleanas
        public void HandleInput(bool esquerda, bool direita, bool cima, bool baixo)
        {
            //Console.WriteLine($"c: {cima}, d: {direita}, e: {esquerda}");
            if (esquerda)
                Rotation -= RotationSpeed;
            if (direita)
                Rotation += RotationSpeed;
            if (cima)
            {
                Velocity.X += (float)Math.Sin(Rotation) * Acceleration;
                Velocity.Y -= (float)Math.Cos(Rotation) * Acceleration;
            }
            if (baixo)
            {
                Velocity.X += (float)Math.Sin(Rotation) * -Acceleration;
                Velocity.Y -= (float)Math.Cos(Rotation) * -Acceleration;
            }
        }

    }
}