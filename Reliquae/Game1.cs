using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Reliquae.Drawing;
using Reliquae.Memory;
using Reliquae.Worlds.TileMaps;
using Reliquae.Worlds.TileMaps.Generation;
using System.Collections.Generic;

namespace Reliquae
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private ResourceManager resourceManager;
        private TileMap tileMap;

        Vector2 mousePos;

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

            Window.AllowUserResizing = true;

            // TODO: use this.Content to load your game content here

            resourceManager.LoadBlocks(Content);

            ushort[,] tiles = new ushort[,] {
                { 2, 2, 2, 2, 2, 2, 2, 2 },
                { 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1 },
                { 2, 2, 2, 2, 2, 1, 1, 2 },
                { 2, 2, 2, 2, 2, 1, 1, 2 },
                { 2, 2, 2, 2, 2, 1, 1, 2 },
                { 2, 2, 2, 2, 2, 1, 1, 2 },
                { 2, 2, 2, 2, 2, 1, 1, 2 },
                };
            tileMap = new TileMap(tiles, resourceManager.BlockManager.Patterns);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var ms = Mouse.GetState();


            mousePos = new Vector2(ms.X / 16 / 5, ms.Y / 16 / 5);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp);

            PainterContext painter = new PainterContext(spriteBatch);
            painter.MultiplyPositionScalar(16);
            painter.MultiplyZoom(5);

            tileMap.Draw(painter, gameTime);

            Texture2D rect = new Texture2D(graphics.GraphicsDevice, 16, 16);
            Color[] data = new Color[16 * 16];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            rect.SetData(data);
            painter.Draw(rect, mousePos);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
