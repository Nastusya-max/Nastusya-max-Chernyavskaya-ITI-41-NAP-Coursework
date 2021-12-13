using OpenTK;
using System;

namespace OpentTKGame
{
    /// <summary>
    /// Класс фона
    /// </summary>
    public class Background : GameObject
    {
        /// <summary>
        /// Конструктор создания объекта
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="scale"></param>
        /// <param name="position"></param>
        public Background(Texture2D texture, Vector2 scale, Vector2 position)
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
        /// Обновление и модификация кадров
        /// </summary>
        public override void Update(TimeSpan obj)
        {

        }
    }
}