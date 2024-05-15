using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Voa
{
    public class Level
    {
        private List<Platform> platforms;

        public Level()
        {
            platforms = new List<Platform>();
        }

        public void AddPlatform(Texture2D texture, Vector2 position)
        {
            platforms.Add(new Platform(texture, position));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var platform in platforms)
            {
                platform.Draw(spriteBatch);
            }
        }

        public bool CheckCollision(Rectangle playerRect)
        {
            foreach (var platform in platforms)
            {
                if (playerRect.Intersects(platform.BoundingBox))
                    return true;
            }
            return false;
        }
    }
}
