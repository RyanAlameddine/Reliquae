using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Reliquae.Memory;
using Reliquae.TileMaps;
using Reliquae.TileMaps.Generation;
using System.Collections.Generic;

namespace Reliquae
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private ResourceManager resourceManager;
        private TileMap tileMap;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            resourceManager = new ResourceManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            resourceManager.LoadBlocks(Content);

            ushort[,] tiles = new ushort[,] {
                { 2, 2, 2, 2, 2 },
                { 2, 2, 2, 2, 2 },
                { 2, 2, 2, 2, 2 },
                { 2, 2, 2, 2, 2 },
                { 2, 2, 2, 2, 2 },
                };
            tileMap = new TileMap(tiles, resourceManager.BlockManager.Patterns);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin(SpriteSortMode.BackToFront);

            tileMap.Draw(spriteBatch, gameTime);

            base.Draw(gameTime);
        }
    }
}
