using Eolnyss.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Eolnyss.Prefabs
{
    public class Block : PhysicsObject
    {
        private BlockType type;

        public Block(IWorld world, float x, float y, float width, float height, BlockType type)
            : base(world, x, y, width, height)
        {
            this.type = type;
            OnCollision += Collision;
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

        public void Collision(object sender, CollisionArgs collisionArgs)
        {

        }   
    }

    public enum BlockType
    {
        Platform,
        Spike,
        Goal
    }
}
