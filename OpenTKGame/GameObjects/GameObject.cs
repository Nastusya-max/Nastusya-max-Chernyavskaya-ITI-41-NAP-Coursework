using OpenTK;
namespace OpentTKGame
{
    /// <summary>
    /// Класс, представляющий игровой объект.
    /// </summary>
    public abstract class GameObject
    {
        public int Id { get; set; }

        /// <summary>
        /// Свойство, хранящее текстуру объекта
        /// </summary>
        public Texture2D Texture { get; protected set; }
        /// <summary>
        /// Свойство, хранящее позицию объекта
        /// </summary>
        public Vector2 Position { get; protected set; }
        /// <summary>
        /// Свойство, размер текстуру объекта
        /// </summary>
        public Vector2 Scale { get; protected set; }
        /// <summary>
        /// Свойство для определения нахождения игрока относительно сетки
        /// для игрока справа PositionOfGrid = true
        /// </summary>
        public bool IsRightPlayer { get; set; }
        /// <summary>
        /// Конструктор игрового объекта.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="scale"></param>
        /// <param name="position"></param>
        public GameObject (Texture2D texture, Vector2 scale, Vector2 position)
        {
            Texture = texture;
            Scale = scale;
            Position = position;
        }
        /// <summary>
        /// Абстрактный метод для модификации и обновления отрисовки кадров на игровом пространстве
        /// </summary>
        public abstract void Update();

        public abstract byte[] Serialize();

        public abstract void Deserialize(byte[] data);
    }
}
