using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BackroomsProject
{
    public class Game1 : Game
    {
        Texture2D playerTexture;
        Rectangle playerRectangle;
        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

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

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W)) { 
                playerRectangle.Y -= 2;
            } else if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S)) {
                playerRectangle.Y += 2;
            } else if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A)) {
                playerRectangle.X -= 2;
            } else if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D)) {
                playerRectangle.X += 2;
            }

            base.Update(gameTime);
        }
        
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // Create a 50x50 yellow square texture
            playerTexture = new Texture2D(GraphicsDevice, 50, 50);
            Color[] data = new Color[50 * 50];

            // Fill the texture with yellow color
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Yellow;

            playerTexture.SetData(data);

            // Set the initial position of the player
            playerRectangle = new Rectangle(100, 100, 50, 50); // x, y, width, height
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // Draw the player (yellow square)
            spriteBatch.Draw(playerTexture, playerRectangle, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }    
    }
}
