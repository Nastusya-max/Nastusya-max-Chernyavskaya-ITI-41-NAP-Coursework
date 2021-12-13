using OpenTK;
using System.Collections.Generic;

namespace OpentTKGame
{
    /// <summary>
    /// Приз силы
    /// </summary>
    public class ForcePrize : Prize
    {
        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="position"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="gameObjects"></param>
        public ForcePrize(Vector2 position, Player left, Player right, List<GameObject> gameObjects)
            : base(ContentPipe.LoadTexture("Зелье.png"), new Vector2(0.3f, 0.3f), position, left, right, gameObjects)
        {

        }
        /// <summary>
        /// Переопределённый метод для декораций
        /// </summary>
        /// <param name="player"></param>
        public override void Decorate(Player player)
        {
            player.Property = new ForceDecorator(player.Property);
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
