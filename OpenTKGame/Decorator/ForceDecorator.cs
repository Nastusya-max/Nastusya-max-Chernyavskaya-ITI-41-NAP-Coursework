using System;

namespace OpentTKGame
{
    /// <summary>
    /// Декоратор силы удара
    /// </summary>
    [Serializable]
    public class ForceDecorator : DecoratorBase
    {
        /// <summary>
        /// Конструктор создания объектов
        /// </summary>
        /// <param name="playerProperities"></param>
        public ForceDecorator(PlayerProperities playerProperities)
            : base(playerProperities)
        {

        }
        /// <summary>
        /// Декорирование минимальной силы удара
        /// </summary>
        public override float MinForce { get => 5; set => base.MinForce = value; }
        /// <summary>
        /// Декорирование максимальной силы удара
        /// </summary>
        public override float MaxForce { get => 20; set => base.MaxForce = value; }
    }
}
