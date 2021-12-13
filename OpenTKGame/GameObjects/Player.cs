using System;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Windows.Controls;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace OpentTKGame
{
    /// <summary>
    /// Класс игрока
    /// </summary>
    public class Player : GameObject
    {
        bool isFall;
        bool isGround;
        bool isHost;

        /// <summary>
        /// Массив для счёто очков
        /// </summary>
        public static int[] Score = new int[] {0,0};
        Texture2D spritePlayer1_1 = ContentPipe.LoadTexture("cat1.png");
        Texture2D spritePlayer1_2 = ContentPipe.LoadTexture("cat2.png");
        Texture2D spritePlayer2_1 = ContentPipe.LoadTexture("bird.png");
        Texture2D spritePlayer2_2 = ContentPipe.LoadTexture("bird2.png");

        /// <summary>
        /// Индикатор силы удара
        /// </summary>
        public ProgressBar progressBar;
        /// <summary>
        /// Свойства игрока
        /// </summary>
        public PlayerProperities Property { get; set; }
        /// <summary>
        /// Вектор движения
        /// </summary>
        public Vector2 dir = new Vector2();
        /// <summary>
        /// Конструктор объекта класса
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="scale"></param>
        /// <param name="position"></param>
        /// <param name="isRightPlayer"></param>
        /// <param name="progressBar"></param>
        public Player(Texture2D texture, Vector2 scale, Vector2 position, bool isRightPlayer,
            ProgressBar progressBar, bool isHost)
            :base(texture, scale, position)
        {
            this.isHost = isHost;

            Position = position;
            IsRightPlayer = isRightPlayer;
            Texture = texture;
            this.progressBar = progressBar;

            Property = new PlayerProperities()
            {
                Speed = 5,
                Force = 10,
                Angle = 45,
                MinAngle =20,
                MaxAngle = 45,
                MinForce = 10,
                MaxForce = 15
            };
        }
        /// <summary>
        /// Метод управления игроком
        /// </summary>
        /// <param name="keystate"></param>
        public void UpdateKeys(KeyboardState keystate, List<Key> clientKeys)
        {
            dir = Vector2.Zero;
            if (IsRightPlayer)
            {
                MoveRightPlayer(keystate, clientKeys);
                return;
            }

            MoveLeftPlayer(keystate);
        }

        private void MoveLeftPlayer(KeyboardState keystate)
        {
            if (!isHost)
            {
                return;
            }

            if (keystate.IsKeyDown(Key.ShiftLeft))
            {
                Property.Force += 0.3f;
            }

            if (keystate.IsKeyDown(Key.ControlLeft))
            {
                Property.Force -= 0.3f;
            }

            if (Property.Force > Property.MaxForce)
            {
                Property.Force = Property.MaxForce;
            }

            if (Property.Force < Property.MinForce)
            {
                Property.Force = Property.MinForce;
            }

            if (keystate.IsKeyDown(Key.E))
            {
                Property.Angle += 1;
            }

            if (keystate.IsKeyDown(Key.Q))
            {
                Property.Angle -= 1;
            }

            if (Property.Angle > Property.MaxAngle)
            {
                Property.Angle = Property.MaxAngle;
            }

            if (Property.Angle < Property.MinAngle)
            {
                Property.Angle = Property.MinAngle;
            }

            if (keystate.IsKeyDown(Key.A))
            {
                dir.X = 1;
            }

            if (keystate.IsKeyDown(Key.D))
            {
                dir.X = -1;
            }

            if (keystate.IsKeyDown(Key.W) && !isFall && isGround)
            {
                dir.Y = 1;
            }

            else
            {
                isFall = true;
            }
        }

        private void MoveRightPlayer(KeyboardState keystate, List<Key> clientKeys)
        {
            if (isHost)
            {
                if (clientKeys.Contains(Key.ShiftLeft))
                {
                    Property.Force += 0.3f;
                }

                if (clientKeys.Contains(Key.ControlLeft))
                {
                    Property.Force -= 0.3f;
                }

                if (Property.Force > Property.MaxForce)
                {
                    Property.Force = Property.MaxForce;
                }

                if (Property.Force < Property.MinForce)
                {
                    Property.Force = Property.MinForce;
                }

                if (clientKeys.Contains(Key.E))
                {
                    Property.Angle += 1;
                }


                if (clientKeys.Contains(Key.Q))
                {
                    Property.Angle -= 1;

                }

                if (Property.Angle > Property.MaxAngle)
                {
                    Property.Angle = Property.MaxAngle;
                }

                if (Property.Angle < Property.MinAngle)
                {
                    Property.Angle = Property.MinAngle;
                }

                if (clientKeys.Contains(Key.A))
                {
                    dir.X = 1;
                }

                if (clientKeys.Contains(Key.D))
                {
                    dir.X = -1;
                }

                if (clientKeys.Contains(Key.W) && !isFall && isGround)
                {
                    dir.Y = 1;
                }
                else
                {
                    isFall = true;
                }
            }
            else
            {
                if (keystate.IsKeyDown(Key.ShiftLeft))
                {
                    clientKeys.Add(Key.ShiftLeft);
                }

                if (keystate.IsKeyDown(Key.ControlLeft))
                {
                    clientKeys.Add(Key.ControlLeft);
                }

                if (keystate.IsKeyDown(Key.E))
                {
                    clientKeys.Add(Key.E);
                }

                if (keystate.IsKeyDown(Key.Q))
                {
                    clientKeys.Add(Key.Q);
                }

                if (keystate.IsKeyDown(Key.A))
                {
                    clientKeys.Add(Key.A);
                }

                if (keystate.IsKeyDown(Key.D))
                {
                    clientKeys.Add(Key.D);
                }

                if (keystate.IsKeyDown(Key.W))
                {
                    clientKeys.Add(Key.W);
                }
            }
        }

        /// <summary>
        /// Метод обновления кадров
        /// </summary>
        public override void Update()
        {
            Position += dir * Property.Speed;
            
            CheckPosition();

            if (Position.Y <= -170)
            {
                isGround = true;
                isFall = false;
            }
            if (Position.Y > 0)
            {
                isFall = true;
            }
            if (isFall)
            {
                Position -= new Vector2(0, 5);
            }
            Animation();
            Angle();
            Force();
        }
        /// <summary>
        /// Метод проверки столкновения с сеткой
        /// </summary>
        public void CheckPosition()
        {
           if (IsRightPlayer)
           {
                if (Position.X < -480)
                {
                    Position = new Vector2(-485, Position.Y);
                }
                if (Position.X > 20)
                {
                    Position = new Vector2(20, Position.Y);
                }
            }
           else
           {
                if (Position.X > 640)
                {
                    Position = new Vector2(640, Position.Y);
                }
                if (Position.X < 135)
                {
                    Position = new Vector2(135, Position.Y);
                }
           }
        }
        /// <summary>
        /// Метод анимации игрока
        /// </summary>
        public void Animation()
        {
            DateTime timer = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            DateTime timer1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timerInterval = timer.Subtract(timer1970);
            Int32 iSeconds = Convert.ToInt32(timerInterval.TotalSeconds);
            if (IsRightPlayer == false)
            {
                Texture = spritePlayer1_1;
                if (iSeconds % 2 == 0)
                {
                    Texture = spritePlayer1_2;
                }
            }
            else
            {
                Texture = spritePlayer2_1;
                if (iSeconds % 2 == 0)
                {
                    Texture = spritePlayer2_2;
                }
            }         
        }

        private void Angle()
        {
            GL.Disable(EnableCap.Blend);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.LineWidth(3);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.LightSeaGreen);
            if (IsRightPlayer)
            {
                GL.Vertex2(450, 350);
                GL.Vertex2(400, 350);
                GL.Vertex2(450, 350);
                GL.Vertex2(450 - 50f * Math.Cos(MathHelper.DegreesToRadians(Property.Angle)), 350 - 50f * Math.Sin(MathHelper.DegreesToRadians(Property.Angle)));
            }
            else
            {
                GL.Vertex2(-450, 350);
                GL.Vertex2(-400, 350);
                GL.Vertex2(-450, 350);
                GL.Vertex2(-450 + 50f * Math.Cos(MathHelper.DegreesToRadians(Property.Angle)), 350 - 50f * Math.Sin(MathHelper.DegreesToRadians(Property.Angle)));
            }
            GL.End();
            GL.PopMatrix();
            GL.Enable(EnableCap.Blend);
            GL.Color3(Color.White);
        }

        private void Force()
        {
            progressBar.Value = (Property.Force - 5) / 0.15f;
        }

        private BinaryFormatter _binaryFormatter = new BinaryFormatter();
        private MemoryStream _memoryStream = new MemoryStream();

        [Serializable]
        struct State
        {
            public PlayerProperities playerProperities;
            public Vector2 pos;
            public Vector2 dir;
        }

        public override byte[] Serialize()
        {
            var state = new State
            {
                playerProperities = Property,
                dir = dir,
                pos = Position,
            };

            _binaryFormatter.Serialize(_memoryStream, state);

            var buffer = _memoryStream.ToArray();

            _memoryStream.Flush();
            _memoryStream.Seek(0, SeekOrigin.Begin);

            return buffer;
        }

        public override void Deserialize(byte[] data)
        {
            _memoryStream.Write(data, 0, data.Length);
            _memoryStream.Seek(0, SeekOrigin.Begin);

            var state = (State)_binaryFormatter.Deserialize(_memoryStream);

            _memoryStream.Flush();
            _memoryStream.Seek(0, SeekOrigin.Begin);

            Property = state.playerProperities;
            dir = state.dir;
            Position = state.pos;
        }
    }
}