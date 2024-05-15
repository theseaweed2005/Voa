using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Voa
{
    public class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private Vector2 velocity;
        private bool isJumping;
        private const float speed = 3f;
        private const float jumpStrength = 10f;
        private const float gravity = 0.4f;

        public Player(Texture2D texture, Vector2 initialPosition)
        {
            this.texture = texture;
            this.position = initialPosition;
            this.velocity = Vector2.Zero;
            this.isJumping = false;
        }

        public Vector2 Position => position;

        public void Update(GameTime gameTime, Level level)
        {
            KeyboardState state = Keyboard.GetState();

            // andar
            if (state.IsKeyDown(Keys.Left))
                position.X -= speed;
            if (state.IsKeyDown(Keys.Right))
                position.X += speed;

            // saltar
            if (state.IsKeyDown(Keys.Space) && !isJumping)
            {
                velocity.Y = -jumpStrength;
                isJumping = true;
            }

            // Gravity
            velocity.Y += gravity;
            position += velocity;

            // colider plataformas
            Rectangle playerRect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            if (level.CheckCollision(playerRect))
            {
                position.Y -= velocity.Y;  
                velocity.Y = 0;
                isJumping = false;
            }

            //colider chão
            if(position.Y > 400)
            {
                position.Y = 400;
                velocity.Y = 0;
                isJumping = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}