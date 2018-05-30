using Eolnyss.Core;
using Eolnyss.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Eolnyss.Prefabs
{
    class Level : GameObject
    {
        private IWorld world;

        private Player player;
        private List<Block> blocks;

        public Player Player => this.player;
        public List<Block> Blocks => this.blocks;

        private Vector2 start;
        private Vector2 goal;

        public Level()
        {
            blocks = new List<Block>();

            LoadLevel("");

            var box = this.world.Create(start.X, start.Y, 40, 40);
            this.player = new Player(box, this);
        }

        public Vector2 Start => this.start;

        public override Vector2 Position => new Vector2(0, 0);

        public override void Update(GameTime gameTime)
        {   
            this.player.Update(gameTime);

            foreach (var block in this.blocks)
                block.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            this.player.Draw(gameTime, spriteBatch);

            foreach (var block in this.blocks)
                block.Draw(gameTime, spriteBatch);
        }

        public void LoadLevel(string name)
        {
            var file = TitleContainer.OpenStream("Content/Levels/level1.txt");
            LoadLevel(file);
        }

        private void LoadLevel(Stream file)
        {
            int width;
            List<string> lines = new List<string>();

            using (StreamReader reader = new StreamReader(file))
            {
                string line = reader.ReadLine();
                width = line.Length;

                while (line != null)
                {
                    if (line.Length != width)
                        throw new InvalidOperationException();

                    lines.Add(line);
                    line = reader.ReadLine();
                }

                int height = lines.Count;

                world = new World(width * 40, height * 40);

                for (int y = 0; y < height; ++y)
                    for (int x = 0; x < width; ++x)
                    {
                        char type = lines[y][x];
                        var block = LoadBlock(type, x, y);

                        if (block != null)
                            this.blocks.Add(block);
                    }
            }
        }

        private Block LoadBlock(char type, int x, int y)
        {
            switch (type)
            {
                case '.':
                    return null;
                case 'p':
                    start = new Vector2(x * 40, y * 40);
                    return null;
                case 'g':
                    return new Block(this.world.Create(x * 40, y * 40, 40, 40), BlockType.Goal);
                case 'v':
                    return new Block(this.world.Create(x * 40, y * 40, 40, 40), BlockType.Spike);
                case 'x':
                    return new Block(this.world.Create(x * 40, y * 40, 40, 40), BlockType.Platform);
                default:
                    throw new Exception();
            }
        }

    }
}
