using OpenTK;

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
        /// <summary>
        /// Обновление и модификация кадров
        /// </summary>
        public override void Update()
        {

        }
    }
}