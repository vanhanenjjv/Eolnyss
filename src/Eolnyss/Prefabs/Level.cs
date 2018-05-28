﻿using Eolnyss.Core;
using Eolnyss.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.world = new World();

            blocks = new List<Block>();

            LoadLevel("");

            var box = world.Create(start.X, start.Y, 40, 40);
            this.player = new Player(box, start);
        }

        public override Vector2 Position => new Vector2(0, 0);

        public IEnumerable<IBox> Boxes => throw new NotImplementedException();

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
                    var box1 = world.Create(x * 40, x * 40, 40, 40);
                    return new Block(box1, BlockType.Goal);
                case 'v':
                    var box2 = world.Create(x * 40, x * 40, 40, 40);
                    return new Block(box2, BlockType.Goal);
                case 'x':
                    var box3 = world.Create(x * 40, x * 40, 40, 40);
                    return new Block(box3, BlockType.Goal);
                default:
                    throw new Exception();
            }
        }

    }
}
