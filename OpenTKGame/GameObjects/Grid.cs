using OpenTK;

namespace OpentTKGame
{
    /// <summary>
    /// Сетка 
    /// </summary>
    public class Grid : GameObject
    {
        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="scale"></param>
        /// <param name="position"></param>
        public Grid(Texture2D texture, Vector2 scale, Vector2 position)
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
        public override void Update()
        {
           
        }
    }
}