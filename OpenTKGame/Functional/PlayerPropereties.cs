using System;

namespace OpentTKGame
{
    /// <summary>
    /// Класс с характеристиками игрока
    /// </summary>
    [Serializable]
    public class PlayerProperities
    {
        /// <summary>
        /// Угол отскока
        /// </summary>
        public virtual float Angle { get; set; }
        /// <summary>
        /// Сила удара
        /// </summary>
        public virtual float Force { get; set; }
        /// <summary>
        /// Скорость
        /// </summary>
        public virtual float Speed { get; set; }
        /// <summary>
        /// Минимальный угл отскока
        /// </summary>
        public virtual float MinAngle { get; set; }
        /// <summary>
        /// Максимальный угл отскока
        /// </summary>
        public virtual float MaxAngle { get; set; }
        /// <summary>
        /// Минимальная сила
        /// </summary>
        public virtual float MinForce { get; set; }
        /// <summary>
        /// Максимальная сила
        /// </summary>
        public virtual float MaxForce { get; set; }
    }
}
