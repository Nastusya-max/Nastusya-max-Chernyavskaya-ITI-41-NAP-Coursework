using OpenTK;
using System;

namespace OpentTKGame
{
    /// <summary>
    /// класс UI
    /// </summary>
    public class UI : GameObject
    {
        Texture2D spriteGameOver = ContentPipe.LoadTexture("GameOver2.png");
        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="scale"></param>
        /// <param name="position"></param>
        public UI(Texture2D texture, Vector2 scale, Vector2 position)
            : base(texture, scale, position)
        {

        }

        public override void Deserialize(byte[] data)
        {
            throw new System.NotImplementedException();
        }

        public override byte[] Serialize()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Обновление кадров
        /// </summary>
        public override void Update(TimeSpan obj)
        {
            if (Score.CheckGameOver == false)
            {
                Texture = spriteGameOver;
            }
        }
    }
}