using OpenTK;

namespace OpentTKGame
{
    /// <summary>
    /// Двоеточие
    /// </summary>
    public class Colon : GameObject
    {
        /// <summary>
        /// Конструктор создания
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="scale"></param>
        /// <param name="position"></param>
        public Colon(Texture2D texture, Vector2 scale, Vector2 position)
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