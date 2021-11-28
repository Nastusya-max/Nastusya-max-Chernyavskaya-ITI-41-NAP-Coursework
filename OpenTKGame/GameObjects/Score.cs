using OpenTK;

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
        public override void Update()
        {
            if (Player.Score[playerNum] == 0)
            {
                Texture = numbers[0];
            }
            if (Player.Score[playerNum] == 1)
            {
                Texture = numbers[1];
            }
            if (Player.Score[playerNum] == 2)
            {
                Texture = numbers[2];
            }
            if (Player.Score[playerNum] == 3)
            {
                Texture = numbers[3];
            }
            if (Player.Score[playerNum] == 4)
            {
                Texture = numbers[4];
            }
            if (Player.Score[playerNum] == 3)
            {
                Texture = numbers[3];
            }
            if (Player.Score[playerNum] == 4)
            {
                Texture = numbers[4];
            }
            if (Player.Score[playerNum] == 5)
            {
                Texture = numbers[5];
            }
            if (Player.Score[playerNum] == 6)
            {
                Texture = numbers[6];
            }
            if (Player.Score[playerNum] == 7)
            {
                Texture = numbers[7];
            }
            if (Player.Score[playerNum] == 8)
            {
                Texture = numbers[8];
            }
            if (Player.Score[playerNum] == 9)
            {
                Texture = numbers[9];
            }
            if (Player.Score[playerNum] == 10)
            {
                Texture = numbers[10];
                CheckGameOver = false;
            }
        }
    }
}

