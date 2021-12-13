using System;

namespace OpentTKGame
{
    /// <summary>
    /// Декоратор скорости
    /// </summary>
    [Serializable]
    public class SpeedDecorator : DecoratorBase
    {
        /// <summary>
        /// Конструктор создания объекта
        /// </summary>
        /// <param name="playerProperities"></param>
        public SpeedDecorator(PlayerProperities playerProperities)
            : base(playerProperities)
        {

        }
        /// <summary>
        /// Декорирование скорости
        /// </summary>
        public override float Speed { get => base.Speed + 0.2f; set => base.Speed = value; }
    }
}
