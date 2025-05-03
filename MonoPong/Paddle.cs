using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoPong
{
    public class Paddle : Sprite
    {
        public bool IsComputer { get; init; }       

        public override Vector4 HitBox => new Vector4(Location, Size);

        public Paddle(bool isComputer, Vector2 location, Vector2 size, Texture2D texture, int xSpeed, int ySpeed)
           : base(location, size, texture, xSpeed, ySpeed)
        {
            IsComputer = isComputer;
        }
        public override void Update(GameTime gameTime, KeyboardState KeyState, Viewport viewport)
        {
            if (IsComputer)
            {
                computerUpdate(gameTime, viewport);
            }
            else
            {
                userUpdate(gameTime, KeyState, viewport);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 HitboxPosition = new Vector2(HitBox.X, HitBox.Y);
            spriteBatch.Draw(Texture,HitboxPosition,Color.White);
        }
        private void userUpdate(GameTime gameTime, KeyboardState KeyState, Viewport viewport)
        {
            if (Location.Y > 0 && Location.Y + Size.Y < viewport.Height)
            {
                if (KeyState.IsKeyDown(Keys.Up))
                {
                    Location = new Vector2(Location.X, Location.Y - 5);
                }
                if (KeyState.IsKeyDown(Keys.Down))
                {
                    Location = new Vector2(Location.X, Location.Y + 5);
                }
            }
            if(Location.Y == 0)
            {
                if (KeyState.IsKeyDown(Keys.Down))
                {
                    Location = new Vector2(Location.X, Location.Y + 5);
                }
            }
            if(Location.Y + Size.Y == viewport.Height)
            {
                if (KeyState.IsKeyDown(Keys.Up))
                {
                    Location = new Vector2(Location.X, Location.Y - 5);
                }
            }

        }
        private void computerUpdate(GameTime gameTime, Viewport viewport)
        {
            Location = new Point(Location.X , Location.Y - YSpeed);
            if (Location.Y <= 0)
            {
                YSpeed = -YSpeed;
            }
            if (Location.Y + Size.Y >= viewport.Height)
            {
                YSpeed = -YSpeed;
            }
        }

    }
}
