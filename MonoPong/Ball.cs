using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoPong
{
    public class Ball : Sprite
    {
        public override Vector4 HitBox => new Vector4(Location.X - Size.X/2, Location.Y - Size.Y/2, Size.X, Size.Y);

        TimeSpan timePassed;

        public Ball(Vector2 location, Vector2 size, Texture2D texture, int xSpeed, int ySpeed)
            : base( location, size, texture, xSpeed, ySpeed)
        {

        }
        public override void Update(GameTime gameTime, KeyboardState KeyState, Viewport viewport)
        {
            timePassed += gameTime.ElapsedGameTime;
            Location = new Vector2(Location.X - XSpeed, Location.Y - YSpeed);

            if (Location.Y <= 0)
            {
                YSpeed = -YSpeed;
                Console.WriteLine("Hit the Top");
            }
            if (Location.Y >= viewport.Height)
            {
                YSpeed = -YSpeed;
                Console.WriteLine("Hit the Bottom");

            }
        }
        public void RealUpdate(Paddle userPaddle, Paddle computerPaddle, int userPts, int compPts)
        {
            //Fix bounce logic, something broke it

           // Update(gameTime, KeyState, viewport);

            if (Location.X  <= userPaddle.Location.X + userPaddle.Size.X && Location.Y > userPaddle.Location.Y 
                && Location.Y < userPaddle.Location.Y + userPaddle.Size.Y)
            {
                XSpeed = -5;
                Console.WriteLine("Hit User Paddle");

            }
            if (Location.X + Size.X >= computerPaddle.Location.X && Location.Y > computerPaddle.Location.Y 
                && Location.Y < computerPaddle.Location.Y + computerPaddle.Size.Y)
            {
                XSpeed = 5;
                Console.WriteLine("Hit Computer Paddle");

            }
            /*
            if (Location.X + Size.X < 0)
            {
                compPts++;
                XSpeed = 0;
                YSpeed = 0;
                Location = new Vector2(400,250);
                timePassed = TimeSpan.Zero;
                Console.WriteLine("Right Paddle Scored");

            }
            */
            if (timePassed >= TimeSpan.FromSeconds(3))
            {
                XSpeed = 5;
                YSpeed = 5;
            }
            /*
            if (Location.X > viewport.Width)
            {
                userPts++;
                XSpeed = 0;
                YSpeed = 0;
                Location = new Vector2(400, 250);
                timePassed = TimeSpan.Zero;
                Console.WriteLine("Left Paddle Scored");

            }
            */
            if (timePassed >= TimeSpan.FromSeconds(3))
            {
                XSpeed = 5;
                YSpeed = 5;
            }

        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 HitboxPosition = new Vector2(HitBox.X, HitBox.Y);
            spriteBatch.Draw(Texture, HitboxPosition, Color.White);
        }

    }
}
