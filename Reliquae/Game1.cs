using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Reliquae.Drawing;
using Reliquae.Memory;
using Reliquae.Worlds.TileMaps;
using Reliquae.Worlds.TileMaps.Generation;
using System.Collections.Generic;
using Reliquae.Utilities;
using Reliquae.Input;

namespace Reliquae
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private ResourceManager resourceManager;
        private TileMap tileMap;
        private InputManager input;

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
            input = new InputManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Window.AllowUserResizing = true;

            // TODO: use this.Content to load your game content here

            resourceManager.LoadBlocks(Content);

            ushort[,] tiles = new ushort[30,30];
            tiles = tiles.Select((x, y, block) => (ushort) 2);
            tileMap = new TileMap(tiles, resourceManager.BlockManager.Patterns);
        }

        protected override void Update(GameTime gameTime)
        {
            input.Update();

            if (input.LeftButtonDown)  tileMap.ChangeTile(new Point((int)input.MousePosition.X, (int) input.MousePosition.Y), 2);
            if (input.RightButtonDown) tileMap.ChangeTile(new Point((int)input.MousePosition.X, (int) input.MousePosition.Y), 1);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp);

            PainterContext painter = new PainterContext(spriteBatch, gameTime);
            painter.MultiplyZoom(5);

            tileMap.Draw(painter);

            Texture2D rect = new Texture2D(graphics.GraphicsDevice, 16, 16);
            Color[] data = new Color[16 * 16];
            Color color = new Color(Color.Red, .2f);
            for (int i = 0; i < data.Length; ++i) data[i] = color;
            rect.SetData(data);
            painter.Draw(rect, input.MousePosition.ToVector2());

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
