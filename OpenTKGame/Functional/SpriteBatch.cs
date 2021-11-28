using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpentTKGame
{
    /// <summary>
    /// Класс для отрисовки тексуры
    /// </summary>
    class SpriteBatch
    {
        /// <summary>
        /// Метод для отрисовки текстуры
        /// </summary>
        /// <param name="gameObject"></param>
        public static void Draw(GameObject gameObject)
        {
            var texture = gameObject.Texture;
            var scale = gameObject.Scale;
            var position = gameObject.Position;
            Vector2[] vertices = new Vector2[4]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1),
            };

            GL.BindTexture(TextureTarget.Texture2D, texture.ID);
            GL.Begin(PrimitiveType.Quads);

            for (int i = 0; i < 4; i++)
            {
                GL.TexCoord2(vertices[i]);

                vertices[i].X *= texture.Width;
                vertices[i].Y *= texture.Height;
                vertices[i] *= scale;
                vertices[i] -= position;
                GL.Vertex2(vertices[i]);
            }
            GL.End();
        }

        public static void Begin(int screenWidth, int screenHeight)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-screenWidth / 2f, screenWidth / 2f, screenHeight / 2f, -screenHeight / 2f, 0f, 1f);
        }
    }
}
