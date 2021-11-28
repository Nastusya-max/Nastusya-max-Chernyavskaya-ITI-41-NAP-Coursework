using OpenTK;

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
        /// <summary>
        /// Обновление кадров
        /// </summary>
        public override void Update()
        {
            if (Score.CheckGameOver == false)
            {
                Texture = spriteGameOver;
            }
        }
    }
}