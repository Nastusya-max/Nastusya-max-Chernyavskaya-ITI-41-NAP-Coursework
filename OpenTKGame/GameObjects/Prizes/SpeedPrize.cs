using OpenTK;
using System.Collections.Generic;

namespace OpentTKGame
{
    /// <summary>
    /// Класс для приза скорости
    /// </summary>
    public class SpeedPrize : Prize
    {
        /// <summary>
        /// Конструктор создания объекта
        /// </summary>
        /// <param name="position"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="gameObjects"></param>
        public SpeedPrize(Vector2 position, Player left, Player right, List<GameObject> gameObjects)
            : base(ContentPipe.LoadTexture("Яблоко.png"), new Vector2(0.3f, 0.3f), position,  left,  right, gameObjects)
        {

        }
        /// <summary>
        /// Переопределение декоратора
        /// </summary>
        /// <param name="player"></param>
        public override void Decorate(Player player)
        {
            player.Property = new SpeedDecorator(player.Property);
        }

    }
}
