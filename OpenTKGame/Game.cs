using System.Collections.Generic;
using OpenTK;
using System.Windows.Controls;
using System.Net.Sockets;
using OpenTK.Input;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System;

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
        UdpClient udpClient;
        bool isHost;
        List<Key> pressedKeys = new List<Key>();

        private BinaryFormatter _binaryFormatter = new BinaryFormatter();
        private MemoryStream _memoryStream = new MemoryStream();

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
        public void Initialization(ProgressBar left, ProgressBar right, UdpClient udpClient, bool isHost)
        {
            this.udpClient = udpClient;
            this.isHost = isHost;

            // host-controlled
            player1 = new Player(ContentPipe.LoadTexture("cat1.png"), new Vector2(0.4f, 0.4f), new Vector2(200, -170), false,
                left, isHost)
            {
                Id = 1,
            };

            // player-controlled
            player2 = new Player(ContentPipe.LoadTexture("bird.png"), new Vector2(0.4f, 0.4f), new Vector2(-50, -170), true,
                right, isHost)
            {
                Id = 2,
            };

            ball = new Ball(ContentPipe.LoadTexture("pinkball.png"), new Vector2(0.22f, 0.22f), new Vector2(70, 30))
            {
                Id = 3,
            };

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

        Task<UdpReceiveResult> receiveResult;

        [Serializable]
        struct GameObjectData
        {
            public byte[] data1;
            public byte[] data2;
            public byte[] dataBall;
            public byte[] score1;
            public byte[] score2;
        }

        /// <summary>
        /// Метод отрисовки объектов
        /// </summary>
        public void Rendering()
        {
            foreach (var item in gameObjects)
            {
                SpriteBatch.Draw(item);
                if (item is Player)
                {
                    ((Player)item).UpdateKeys(OpenTK.Input.Keyboard.GetState(), pressedKeys);

                }
                if (item is Ball)
                {
                    ((Ball)item).CheckCollision(gameObjects);
                }                      
            }

            if (receiveResult == null)
            {
                receiveResult = udpClient.ReceiveAsync();
            }

            if (isHost)
            {
                pressedKeys.Clear();
                if (receiveResult.IsCompleted)
                {
                    var data = receiveResult.Result.Buffer;
                    receiveResult = udpClient.ReceiveAsync();

                    _memoryStream.Write(data, 0, data.Length);
                    _memoryStream.Seek(0, SeekOrigin.Begin);

                    pressedKeys = (List<Key>)_binaryFormatter.Deserialize(_memoryStream);

                    _memoryStream.Flush();
                    _memoryStream.Seek(0, SeekOrigin.Begin);
                }

                var player1Data = player1.Serialize();
                var player2Data = player2.Serialize();
                var ballData = ball.Serialize();
                var sore1 = scorePlayer1.Serialize();
                var sore2 = scorePlayer2.Serialize();

                var ballDataStruct = new GameObjectData
                {
                    data1 = player1Data,
                    data2 = player2Data,
                    dataBall = ballData,
                    score1 = sore1,
                    score2 = sore2,
                };

                _binaryFormatter.Serialize(_memoryStream, ballDataStruct);
                var buffer = _memoryStream.ToArray();

                _memoryStream.Flush();
                _memoryStream.Seek(0, SeekOrigin.Begin);

                udpClient.Send(buffer, buffer.Length);
            }
            else
            {
                if (pressedKeys.Any())
                {
                    _binaryFormatter.Serialize(_memoryStream, pressedKeys);
                    var buffer = _memoryStream.ToArray();

                    _memoryStream.Flush();
                    _memoryStream.Seek(0, SeekOrigin.Begin);

                    udpClient.Send(buffer, buffer.Length);
                    pressedKeys.Clear();
                }

                while (receiveResult.IsCompleted)
                {
                    var data = receiveResult.Result.Buffer;

                    _memoryStream.Write(data, 0, data.Length);
                    _memoryStream.Seek(0, SeekOrigin.Begin);

                    var goData = (GameObjectData)_binaryFormatter.Deserialize(_memoryStream);

                    _memoryStream.Flush();
                    _memoryStream.Seek(0, SeekOrigin.Begin);

                    player1.Deserialize(goData.data1);
                    player2.Deserialize(goData.data2);
                    ball.Deserialize(goData.dataBall);
                    scorePlayer1.Deserialize(goData.score1);
                    scorePlayer2.Deserialize(goData.score2);

                    receiveResult = udpClient.ReceiveAsync();
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
