using Eolnyss.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Eolnyss.Prefabs
{
    public class Block : PhysicsObject, ICloneable
    {
        private BlockType type;

        public Block(IBox box, BlockType type) : base(box)
        {
            box.Data = this;
            this.type = type;
        }

        public BlockType Type => this.type;

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            switch (type)
            {
                case BlockType.Platform:
                    spriteBatch.Draw(Assets.PlatformTexture, Bounds, Color.White);
                    break;
                case BlockType.Spike:
                    spriteBatch.Draw(Assets.SpikeTexture, Bounds, Color.White);
                    break;
                case BlockType.Goal:
                    spriteBatch.Draw(Assets.GoalTexture, Bounds, Color.White);
                    break;
            }
        }

        public override void OnCollision(object sender, CollisionArgs collisionArgs)
        {
        }

        public object Clone()
        {
            var box = Box.World.Create(Position.X, Position.Y, Size.X, Size.Y);

            return new Block(box, Type);
        }
    }

    public enum BlockType
    {
        Platform,
        Spike,
        Goal
    }
}
