using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BackroomsProject
{
    public class Game1 : Game
    {
        Texture2D playerTexture;
        Rectangle playerRectangle;
        World world;
        Client client;
        int KeysPressed = 0;
        bool left = false;
        bool up = false;
        bool right = false;
        bool down = false;
        int speed = 2;
        int seed = 58349;
        int worldX, worldY = 0;

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
            client = new Client();
            world = new World(spriteBatch, seed, worldX, worldY);
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W)) {
                if (left || right & !(left & right))
                {
                    playerRectangle.Y -= speed / 2;
                }
                else
                {
                    playerRectangle.Y -= speed;
                }

                up = true;
                
            } else
            {
                up = false;
            }
            if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S)) {
                if (left || right & !(left & right))
                {
                    playerRectangle.Y += speed / 2;
                }
                else
                {
                    playerRectangle.Y += speed;
                }

                down = true;
                
            }
            else
            {
                down = false;
            }
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A)) {
                if (up || down & !(up & down))
                {
                    playerRectangle.X -= speed / 2;
                }
                else
                {
                    playerRectangle.X -= speed;
                }

                left = true;
                
            }
            else
            {
                left = false;
            }
            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D)) {

                if (up || down & !(up & down)) 
                {
                    playerRectangle.X += speed / 2;
                }
                else
                {
                    playerRectangle.X += speed;
                }

                
                right = true;
                
            }
            else
            {
                right = false;
            }

            base.Update(gameTime);
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // Create a 50x50 yellow square texture
            playerTexture = new Texture2D(GraphicsDevice, 10, 10);
            Color[] data = new Color[10 * 10];

            // Fill the texture with yellow color
            for (int i = 0; i < data.Length; ++i) data[i] = Color.CornflowerBlue;

            playerTexture.SetData(data);

            // Set the initial position of the player
            playerRectangle = new Rectangle(100, 100, 10, 10); // x, y, width, height
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PaleGoldenrod);

            spriteBatch.Begin();

            world.Draw();

            // Draw the player (yellow square)
            spriteBatch.Draw(playerTexture, playerRectangle, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }    
    }
}
