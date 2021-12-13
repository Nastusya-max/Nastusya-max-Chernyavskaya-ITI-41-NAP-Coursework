using OpenTK;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OpentTKGame
{
    /// <summary>
    /// Счёт игры
    /// </summary>
    public class Score : GameObject
    {
        Texture2D[] numbers;
        int playerNum;
        /// <summary>
        /// Переменная, равная true при 10 очках
        /// </summary>
        public static bool CheckGameOver = true;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="scale"></param>
        /// <param name="position"></param>
        /// <param name="numbers"></param>
        /// <param name="playerNum"></param>
        /// <param name="CheckGameOver"></param>
        public Score(Texture2D texture, Vector2 scale, Vector2 position, Texture2D[] numbers, int playerNum, bool CheckGameOver)
            : base(texture, scale, position)
        {
            this.numbers = numbers;
            this.playerNum = playerNum;
        }
        /// <summary>
        /// Обновление и модификация кадров
        /// </summary>
        public override void Update(TimeSpan obj)
        {
            if (Player.Score[playerNum] > 10)
            {
                return;
            }

            var score = Player.Score[playerNum];
            Texture = numbers[score];
            if (score == 10)
            {
                CheckGameOver = false;
            }
        }

        private BinaryFormatter _binaryFormatter = new BinaryFormatter();
        private MemoryStream _memoryStream = new MemoryStream();

        public override byte[] Serialize()
        {
            _binaryFormatter.Serialize(_memoryStream, Player.Score[playerNum]);

            var buffer = _memoryStream.ToArray();

            _memoryStream.Flush();
            _memoryStream.Seek(0, SeekOrigin.Begin);

            return buffer;
        }

        public override void Deserialize(byte[] data)
        {
            _memoryStream.Write(data, 0, data.Length);
            _memoryStream.Seek(0, SeekOrigin.Begin);

            var state = (int)_binaryFormatter.Deserialize(_memoryStream);

            _memoryStream.Flush();
            _memoryStream.Seek(0, SeekOrigin.Begin);

            Player.Score[playerNum] = state;
        }
    }
}

