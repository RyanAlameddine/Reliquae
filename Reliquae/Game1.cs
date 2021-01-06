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
using Reliquae.Worlds;
using Reliquae.Worlds.Entities;
using Reliquae.Utilities.Physics;
using Reliquae.Utilities.Physics.Forces;

namespace Reliquae
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private ResourceManager resourceManager;
        private InputManager input;
        private World world;

        Player player;

        Texture2D rect;

        FrameCounter framecounter;

        SpriteFont spriteFont;

        Vector2 cameraOffset;

        const int zoom = 4;

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
            input = new InputManager(() => cameraOffset * zoom);
            framecounter = new FrameCounter();

            base.Initialize();

            rect = new Texture2D(graphics.GraphicsDevice, 16, 16);
            Color[] data = new Color[16 * 16];
            Color color = new Color(Color.Red, .2f);
            for (int i = 0; i < data.Length; ++i) data[i] = color;
            rect.SetData(data);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Window.AllowUserResizing = true;

            spriteFont = Content.Load<SpriteFont>("Font");

            // TODO: use this.Content to load your game content here

            resourceManager.LoadBlocks(Content);

            //Tilemap
            ushort[,] tiles = new ushort[50, 50];
            tiles = tiles.Select((x, y, block) => (ushort)1);
            TileMap tileMap = new TileMap(tiles, resourceManager.BlockManager.Patterns);


            //Player
            Texture2D rect = new Texture2D(graphics.GraphicsDevice, 16, 16);
            Color[] data = new Color[16 * 16];
            Color color = new Color(Color.Red, .2f);
            for (int i = 0; i < data.Length; ++i) data[i] = color;
            rect.SetData(data);
            List<IForce> forces = new List<IForce>();
            KineticComponent playerKinetics = new KineticComponent(forces, 60);
            forces.AddRange(new List<IForce>()
            {
                new ControlForce(() => input.VerticalAxis * 1000, () => playerKinetics.Velocity, new Vector2(0, 1)),
                new ControlForce(() => input.HorizontalAxis * 1000, () => playerKinetics.Velocity, new Vector2(1, 0)),
            }
            );
            player = new Player(rect, playerKinetics, new ColliderTransform(new Rectangle(0, 0, 16, 16), Vector2.Zero));

            //Entity Map
            EntityMap entityMap = new EntityMap(player);

            //World
            world = new World(new List<(TileMap, EntityMap)>() { (tileMap, entityMap) }, 0, () => default, () => default);
        }

        protected override void Update(GameTime gameTime)
        {
            input.Update(gameTime);

            if (input.LeftButtonDown)  world.Layers[0].tileMap.ChangeTile(new Point(input.MouseTilePosition.X, input.MouseTilePosition.Y), 2);
            if (input.RightButtonDown) world.Layers[0].tileMap.ChangeTile(new Point(input.MouseTilePosition.X, input.MouseTilePosition.Y), 1);

            world.Update(gameTime);

            float x = player.Transform.Position.X + player.Transform.Hitbox.Width/2;
            float y = player.Transform.Position.Y + player.Transform.Hitbox.Height/2;
            cameraOffset = new Vector2(x - graphics.GraphicsDevice.Viewport.Width/2/zoom, y - graphics.GraphicsDevice.Viewport.Height/2/zoom);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

            PainterContext painter = new PainterContext(spriteBatch, gameTime);
            painter.MultiplyZoom(zoom);
            painter.AddOffset(cameraOffset); //follow player

            world.Draw(painter);

            painter.Draw(rect, input.MouseTilePosition.ToVector2() * 16);

            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            framecounter.Update(deltaTime);


            spriteBatch.DrawString(spriteFont, framecounter.CurrentFramesPerSecond.ToString(), new Vector2(2, 2), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
