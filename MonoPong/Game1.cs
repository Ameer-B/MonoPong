using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics.Metrics;

namespace MonoPong;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    //It's the round moving thing
    Ball ball;
    Paddle userPaddle;
    Paddle computerPaddle;
    int userPts;
    int compPts;

    KeyboardState ks;
    SpriteFont spriteFont;
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        graphics.PreferredBackBufferWidth = 750;
        graphics.PreferredBackBufferHeight = 500;
        graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        Vector2 ballLocation = new Vector2(400, 250);
        Vector2 ballSize = new Vector2(40, 40);

        Vector2 userPaddleLocation = new Vector2(50, 40); //OG Location: (50,300)
        Vector2 userPaddleSize = new Vector2(20, 100);

        Vector2 computerPaddleLocation = new Vector2(670, 0);
        Vector2 computerPaddleSize = new Vector2(20, 100);

        ball = new Ball(ballLocation, ballSize, Content.Load<Texture2D>("wonkyPope"), 5, 5);
        userPaddle = new Paddle(false, userPaddleLocation, userPaddleSize, Content.Load<Texture2D>("Paddle"), 7, 7);
        computerPaddle = new Paddle(true, computerPaddleLocation, computerPaddleSize, Content.Load<Texture2D>("Paddle"), 7, -7);
        spriteFont= Content.Load<SpriteFont>("Font");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        ks = Keyboard.GetState();
        // TODO: Add your update logic here        

        ball.RealUpdate(gameTime,ks, GraphicsDevice.Viewport,userPaddle,computerPaddle,userPts,compPts);
        userPaddle.Update(gameTime,ks, GraphicsDevice.Viewport);
        computerPaddle.Update(gameTime,ks, GraphicsDevice.Viewport);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();


        ball.Draw(gameTime, spriteBatch);
        userPaddle.Draw(gameTime, spriteBatch);
        computerPaddle.Draw(gameTime, spriteBatch);

        //spriteBatch.DrawString(spriteFont, "Score Here", new Vector2(350, 50), Color.Black);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
