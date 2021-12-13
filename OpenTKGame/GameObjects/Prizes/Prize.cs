using OpenTK;
using System;
using System.Collections.Generic;

namespace OpentTKGame
{
    /// <summary>
    /// Клас приза
    /// </summary>
    public abstract class Prize : GameObject
    {
        Player left;
        Player right;
        List<GameObject> gameObjects;
        /// <summary>
        /// Конструктор создания объекта
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="scale"></param>
        /// <param name="position"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="gameObjects"></param>
        public Prize(Texture2D texture, Vector2 scale, Vector2 position, Player left, Player right, List<GameObject> gameObjects) : base(texture, scale, position)
        {
            Position = position;
            Texture = texture;
            this.gameObjects = gameObjects;
            this.left = left;
            this.right = right;
        }
        /// <summary>
        /// Обновление кадров
        /// </summary>
        public override void Update(TimeSpan obj)
        {
            if(Math.Abs(left.Position.Y - Position.Y) <= 30 && Math.Abs(left.Position.X - Position.X) <= 30)
            {
                Decorate(left);
                gameObjects.Remove(this);
            }
            else if(Math.Abs(right.Position.Y - Position.Y) <= 30 && Math.Abs(right.Position.X - Position.X) <= 30)
            {
                Decorate(right);
                gameObjects.Remove(this);
            }
        }
        /// <summary>
        /// Абстрактный сетод для декорирования
        /// </summary>
        /// <param name="player"></param>
        public abstract void Decorate(Player player);

    }
}
