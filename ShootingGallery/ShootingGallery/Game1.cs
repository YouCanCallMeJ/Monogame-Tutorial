using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShootingGallery
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D targetSprite;
        Texture2D crosshairsSprite;
        Texture2D backgroundSprite;
        
        // Printing Text Font Sprite
        SpriteFont gameFont;

        // Variables
        Vector2 targetPosition = new Vector2(300, 300);
        const int targetRadius = 45;

        // Mouse Input
        MouseState mState;
        bool mRealeased = true;
        int score = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Assign Imported assets(.xnb files = stream target) to targetSprite
            targetSprite = Content.Load<Texture2D>("target");
            crosshairsSprite = Content.Load<Texture2D>("crosshairs");
            backgroundSprite = Content.Load<Texture2D>("sky");

            gameFont = Content.Load<SpriteFont>("galleryFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Assign Mouse State every frame
            mState = Mouse.GetState();

            // Compare Mouse State
            if (mState.LeftButton == ButtonState.Pressed && mRealeased == true)
            {
                score++;
                mRealeased = false;
            }

            if (mState.LeftButton == ButtonState.Released)
            {
                mRealeased = true;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // We are about to draw something
            _spriteBatch.Begin();
            // Set 
            // Object Order is related to the coding sequence
            _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);

            // Printing Score
            _spriteBatch.DrawString(gameFont, score.ToString(), new Vector2(100, 100), Color.White);

            // targetPosition can be changed using update method
            _spriteBatch.Draw(targetSprite, targetPosition, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
