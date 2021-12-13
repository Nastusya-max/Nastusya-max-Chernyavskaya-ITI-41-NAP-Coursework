using System;

namespace OpentTKGame
{
    /// <summary>
    /// Класс базовых декораций
    /// </summary>
    [Serializable]
    public class DecoratorBase: PlayerProperities
    {
        PlayerProperities playerProperities;
        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="playerProperities"></param>
        public DecoratorBase(PlayerProperities playerProperities)
        {
            this.playerProperities = playerProperities;
        }
        /// <summary>
        /// Переопредеоение угла
        /// </summary>
        public override float Angle { get => playerProperities.Angle; set => playerProperities.Angle = value; }
        /// <summary>
        /// Переопределение силы
        /// </summary>
        public override float Force { get => playerProperities.Force; set => playerProperities.Force = value; }
        /// <summary>
        /// Переопределение максимального угла
        /// </summary>
        public override float MaxAngle { get => playerProperities.MaxAngle; set => playerProperities.MaxAngle = value; }
        /// <summary>
        /// Переопределение минимального угла
        /// </summary>
        public override float MinAngle { get => playerProperities.MinAngle; set => playerProperities.MinAngle = value; }
        /// <summary>
        /// Переопределение максимальной силы
        /// </summary>
        public override float MaxForce { get => playerProperities.MaxForce; set => playerProperities.MaxForce = value; }
        /// <summary>
        /// Переопределение минимальной силы
        /// </summary>
        public override float MinForce { get => playerProperities.MinForce; set => playerProperities.MinForce = value; }
        /// <summary>
        /// Переопределение скорости
        /// </summary>
        public override float Speed { get => playerProperities.Speed; set => playerProperities.Speed = value; }
    }
}
