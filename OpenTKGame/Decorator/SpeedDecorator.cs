namespace OpentTKGame
{
    /// <summary>
    /// Декоратор скорости
    /// </summary>
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
        public override float Speed { get => base.Speed + 2; set => base.Speed = value; }
    }
}
