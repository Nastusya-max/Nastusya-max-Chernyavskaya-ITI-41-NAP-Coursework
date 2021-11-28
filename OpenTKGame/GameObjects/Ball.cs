using System;
using System.Collections.Generic;
using OpenTK;

namespace OpentTKGame
{
    /// <summary>
    /// Класс мяча
    /// </summary>
    public class Ball : GameObject
    {
        float directionX;
        float directionY;
        float RandX = 4;
        float RandY = -2;
        Random random = new Random();
        /// <summary>
        /// Счёт первого игрока
        /// </summary>
        public string scorePlayer1;
        /// <summary>
        /// Счёт второго игрока
        /// </summary>
        public string scorePlayer2;

        /// <summary>
        /// Конструктор мяча
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="scale"></param>
        /// <param name="position"></param>
        public Ball(Texture2D texture, Vector2 scale, Vector2 position)
            : base(texture, scale, position)
        {
            Position = position;
            directionX = 1.4f;
            directionY = 2;
        }
        /// <summary>
        /// Метод обновления кадров
        /// </summary>
        public override void Update()
        {
            directionY  += 0.6f;
            Position += new Vector2(RandX*directionX, RandY*directionY) * 0.3f;
         
            if (Position.Y < -210)
            {
                if (Position.X > 150)
                {
                    Player.Score[1]++;
                }
                else if (Position.X < 150)
                {
                    Player.Score[0]++;
                }
                Position = new Vector2(65, 60);
                directionY = -15;
                directionX /= 2;
            }
            if (Position.X > 640)
            {
                Player.Score[0]++;
                Position = new Vector2(65, 60);
                directionY = -15;
                directionX /= 2;
            }
            if (Position.X < -480)
            {
                Player.Score[1]++;
                Position = new Vector2(65, 60);
                directionY = -15;
                directionX /= 2;
            }
            if (Position.X > 50 && Position.X < 80 && Position.Y < -4)
            {
                Position = new Vector2(65, 30);
                directionY = -15;
                directionX /= 2;
                directionX += random.Next(-3, 4);
            }
            if (Score.CheckGameOver == false)
            {
                Position = new Vector2(65, 30);
            }
        }
        /// <summary>
        /// Проверка столкновений с игроком
        /// </summary>
        /// <param name="gameObjects"></param>
        public void CheckCollision(List<GameObject> gameObjects)
        {
            foreach(var item in gameObjects)
            {
                if(item is Player)
                {
                    if ((Position - item.Position).Length < 80)
                    {
                        Vector2 dir = new Vector2();

                        if(((Player)item).PositionOfGrid)
                        {
                            dir.Y = -1;
                            dir.X = 1 / (float)Math.Tan(MathHelper.DegreesToRadians(((Player)item).Property.Angle));
                        }
                        else
                        {
                            dir.Y = -1;
                            dir.X = -1 / (float)Math.Tan(MathHelper.DegreesToRadians(((Player)item).Property.Angle));
                        }
                        dir.Normalize();
                        dir *= ((Player)item).Property.Force;
                        directionX = dir.X;
                        directionY = dir.Y - 10;
                    } 
                }
            }
        }
    }
}
