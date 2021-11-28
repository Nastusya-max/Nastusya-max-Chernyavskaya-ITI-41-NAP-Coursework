using OpenTK;
using System;
using System.Collections.Generic;

namespace OpentTKGame
{
    /// <summary>
    /// Класс,объекты которго отрисовываются на игровом поле в качестве призов
    /// </summary>
    public class PresentsLauncher : GameObject
    {
        DateTime timer = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
        int delay;
        Random random = new Random();
        Factory factory = new Factory();
        List<GameObject> gameObjects;
        Player leftPlayer;
        Player rightPlayer;
        /// <summary>
        /// Конструктор создания объктов
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="scale"></param>
        /// <param name="position"></param>
        /// <param name="gameObjects"></param>
        /// <param name="leftPlayer"></param>
        /// <param name="rightPlayer"></param>
        public PresentsLauncher(Texture2D texture, Vector2 scale, Vector2 position, List <GameObject> gameObjects, Player leftPlayer, Player rightPlayer)
            :base(texture, scale, position)
        {
            this.gameObjects = gameObjects;
            delay = random.Next(10, 20);
            this.leftPlayer = leftPlayer;
            this.rightPlayer = rightPlayer;
        }
        /// <summary>
        /// Обновление и модификация кадров, применение метода рандомной гнерации призов из класса Factory
        /// </summary>
        public override void Update()
        {
            DateTime time = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            var tmp = time - timer; 
            if (tmp.TotalSeconds >= delay)
            {
                timer = time;
                delay = random.Next(10, 20);
                gameObjects.Add(factory.GetRandomPrize( new Vector2(GetRandomPossition(), -170), leftPlayer, rightPlayer, gameObjects));
            }
        }
        /// <summary>
        /// Метод для случайной позиции приза по X
        /// </summary>
        /// <returns></returns>
        public int GetRandomPossition()
        {
            var tmp = random.NextDouble();
            if (tmp <= 0.5f)
            {
                return random.Next(135, 640);
            }
            else
            {
                return random.Next(-480, 20);
            }   
        }
    }
}
