namespace OpentTKGame
{
    /// <summary>
    /// Декорация угла отскока
    /// </summary>
    public class AngleDecorator : DecoratorBase
    {
        /// <summary>
        /// Конструктор объекта класса
        /// </summary>
        /// <param name="playerProperities"></param>
        public AngleDecorator(PlayerProperities playerProperities)
            : base(playerProperities)
        {

        }
        /// <summary>
        /// Декорирование миниммального угла
        /// </summary>
        public override float MinAngle { get => 0; set => base.MinAngle = value; }
        /// <summary>
        /// Декорирование максимального угла
        /// </summary>
        public override float MaxAngle { get => 89; set => base.MaxAngle = value; }
    }
}
