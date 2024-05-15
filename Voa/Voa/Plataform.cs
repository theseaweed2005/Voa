using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Voa
{
    public class Platform
    {
        private Texture2D texture;
        private Vector2 position;

        public Platform(Texture2D texture, Vector2 position) 
        { 
            this.texture = texture;
            this.position = position;
        }
        public Rectangle BoundingBox => new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
