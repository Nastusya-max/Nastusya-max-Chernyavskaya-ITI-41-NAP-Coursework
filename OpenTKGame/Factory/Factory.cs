using OpenTK;
using System;
using System.Collections.Generic;

namespace OpentTKGame
{
    /// <summary>
    /// Класс, реализующий паттерн "фабричный метод"
    /// </summary>
    public class Factory
    {
        Random random = new Random(1);
        /// <summary>
        /// Метод реализующий гибкую генерацию призов случайных типов
        /// </summary>
        /// <param name="position"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="gameObjects"></param>
        /// <returns></returns>
        public Prize GetRandomPrize(Vector2 position, Player left, Player right, List<GameObject> gameObjects)
        {
            switch (random.Next(1, 4))
            {
                case 1:
                    return new SpeedPrize(position, left, right, gameObjects);
                case 2:
                    return new ForcePrize(position, left, right, gameObjects);
                case 3:
                    return new AnglePrize(position, left, right, gameObjects);
            }
            return null;
        }
    }
}
