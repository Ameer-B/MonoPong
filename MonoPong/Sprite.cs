using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoPong
{
    public abstract class Sprite
    {
        public Vector2 Location { get; set; }
        public Vector2 Size { get; set; }
        public abstract Vector4 HitBox { get; }
        public Texture2D Texture { get; set; }
        public int XSpeed;
        public int YSpeed;
     

        protected Sprite(Vector2 location, Vector2 size, Texture2D texture, int xSpeed, int ySpeed)
        {
            Location = location;
            Size = size;
            Texture = texture;
            XSpeed = xSpeed;
            YSpeed = ySpeed;
        }

        public abstract void Update(GameTime gameTime, KeyboardState KeyState, Viewport Viewport);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}