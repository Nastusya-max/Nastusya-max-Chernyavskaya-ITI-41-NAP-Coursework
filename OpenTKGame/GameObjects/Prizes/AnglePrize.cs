using OpenTK;
using System.Collections.Generic;

namespace OpentTKGame
{
    /// <summary>
    /// Приз для угла отскока
    /// </summary>
    public class AnglePrize : Prize
    {
        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="position"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="gameObjects"></param>
        public AnglePrize(Vector2 position, Player left, Player right, List<GameObject> gameObjects)
            : base(ContentPipe.LoadTexture("Клевер.png"), new Vector2(0.3f, 0.3f), position, left, right, gameObjects)
        {

        }
        /// <summary>
        /// Переопределенный метод для декораций
        /// </summary>
        /// <param name="player"></param>
        public override void Decorate(Player player)
        {
            player.Property = new AngleDecorator(player.Property);
        }

        public override void Deserialize(byte[] data)
        {
            throw new System.NotImplementedException();
        }

        public override byte[] Serialize()
        {
            throw new System.NotImplementedException();
        }
    }
}
