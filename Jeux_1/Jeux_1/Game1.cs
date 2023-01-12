using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Jeux_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        public static int ScreenWidth;
        public static int ScreenHeight;
        public static Random Random;

        private Score _score;
        private List<Sprite> _sprites;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = "Test";

            ScreenWidth = _graphics.PreferredBackBufferWidth;
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            Random = new Random();

            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var batTexture = Content.Load<Texture2D>("rectangle");
            var ballTexture = Content.Load<Texture2D>("carré");

            _score = new Score(Content.Load<SpriteFont>("Font"));

            _sprites = new List<Sprite>();


            new Sprite(Content.Load<Texture2D>("Background"));
            new Bat(batTexture)
            {
                Position = new Vector2(20, (ScreenHeight / 2) - (batTexture.Height / 2)),
                Input = new Input()
                {
                    Up = Keys.W,
                    Down = Keys.S,
                }
            };
            new Bat(batTexture)
            {
                Position = new Vector2(ScreenWidth - 20 - batTexture.Width, (ScreenHeight / 2) - (batTexture.Height / 2)),
                Input = new Input()
                {
                    Up = Keys.Up,
                    Down = Keys.Down,
                }
            };
            new Ball(ballTexture)
            {
                Position = new Vector2((ScreenWidth / 2) - (ballTexture.Width / 2), (ScreenHeight / 2) - (ballTexture.Height / 2)),
                Score = _score,
            };
        }  

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            foreach (var sprite in _sprites)
                sprite.Draw(_spriteBatch);

            _score.Draw(_spriteBatch);

            _spriteBatch.End();
            //GraphicsDevice.Clear(Color.Red);
            base.Draw(gameTime);
        }
    }
}