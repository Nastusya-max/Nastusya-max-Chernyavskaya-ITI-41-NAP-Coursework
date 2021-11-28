using System.Collections.Generic;
using OpenTK;
using System.Windows.Controls;

namespace OpentTKGame
{
    /// <summary>
    /// Класс Game
    /// </summary>
    public class Game: GameWindow
    {
        List<GameObject> gameObjects;
        Player player1;
        Player player2;
        Ball ball;
        Score scorePlayer1;
        Score scorePlayer2;
        Colon colon;
        UI gameOver;
        /// <summary>
        /// Конструктор для создания объектов класса
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Game(int width, int height) : base(width, height)
        {
            gameObjects = new List<GameObject>();
        }
        /// <summary>
        /// Метод иниициализации объектов
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void Initialization(ProgressBar left, ProgressBar right)
        {
            
            player1 = new Player(ContentPipe.LoadTexture("cat1.png"), new Vector2(0.4f, 0.4f), new Vector2(200, -170), false, left);
            player2 = new Player(ContentPipe.LoadTexture("bird.png"), new Vector2(0.4f, 0.4f), new Vector2(-50, -170), true, right);
            ball = new Ball(ContentPipe.LoadTexture("pinkball.png"), new Vector2(0.22f, 0.22f), new Vector2(70, 30));
            gameObjects.Add(new Background(ContentPipe.LoadTexture("beach.png"), new Vector2(0.8f, 0.9f), new Vector2(600, 400)));
            gameObjects.Add(new Grid(ContentPipe.LoadTexture("GridLeft.png"), new Vector2(0.32f, 0.32f), new Vector2(150, -40)));
            gameObjects.Add(player1);
            gameObjects.Add(player2);
            gameObjects.Add(ball);
            gameObjects.Add(new Grid(ContentPipe.LoadTexture("GridRight.png"), new Vector2(0.32f, 0.32f), new Vector2(150, -40)));
            colon = new Colon(ContentPipe.LoadTexture("_.png"), new Vector2(1f, 1f), new Vector2(540, 370));
            scorePlayer1 = new Score(ContentPipe.LoadTexture("0.png"), new Vector2(1f, 1f), new Vector2(570, 370), new Texture2D[] {
                ContentPipe.LoadTexture("0.png"),
                ContentPipe.LoadTexture("1.png"),
                ContentPipe.LoadTexture("2.png"),
                ContentPipe.LoadTexture("3.png"),
                ContentPipe.LoadTexture("4.png"),
                ContentPipe.LoadTexture("5.png"),
                ContentPipe.LoadTexture("6.png"),
                ContentPipe.LoadTexture("7.png"),
                ContentPipe.LoadTexture("8.png"),
                ContentPipe.LoadTexture("9.png"),
                ContentPipe.LoadTexture("10.png")
                }, 0, true);
            scorePlayer2 = new Score(ContentPipe.LoadTexture("0.png"), new Vector2(1f, 1f), new Vector2(510, 370), new Texture2D[]
            {
                ContentPipe.LoadTexture("0.png"),
                ContentPipe.LoadTexture("1.png"),
                ContentPipe.LoadTexture("2.png"),
                ContentPipe.LoadTexture("3.png"),
                ContentPipe.LoadTexture("4.png"),
                ContentPipe.LoadTexture("5.png"),
                ContentPipe.LoadTexture("6.png"),
                ContentPipe.LoadTexture("7.png"),
                ContentPipe.LoadTexture("8.png"),
                ContentPipe.LoadTexture("9.png"),
                ContentPipe.LoadTexture("10.png")
            }, 1, true);
            gameObjects.Add(colon);
            gameObjects.Add(scorePlayer1);
            gameObjects.Add(scorePlayer2);
            gameOver = new UI(ContentPipe.LoadTexture("GameOver1.png"), new Vector2(0.3f, 0.35f), new Vector2(190, 390));
            gameObjects.Add(gameOver);
            gameObjects.Add( new PresentsLauncher(ContentPipe.LoadTexture("GameOver1.png"), new Vector2(0.3f, 0.35f), new Vector2(190, 390), gameObjects, player1, player2));
        }
        /// <summary>
        /// Метод отрисовки объектов
        /// </summary>
        public void Rendering()
        {
            foreach(var item in gameObjects)
            {
                SpriteBatch.Draw(item);
                if(item is Player)
                {
                    ((Player)item).UpdateKeys(OpenTK.Input.Keyboard.GetState());

                }
                if (item is Ball)
                {
                    ((Ball)item).CheckCollision(gameObjects);
                }                      
            }
            for (int i = 0; i < gameObjects.Count; i++)
            {
                SpriteBatch.Draw(gameObjects[i]);
                gameObjects[i].Update();   
            }
        }  
    }
}
