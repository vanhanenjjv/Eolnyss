using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Eolnyss.Physics
{
    public abstract class PhysicsObject : IPhysicsObject
    {
        IBox box;

        public PhysicsObject(IBox box)
        {
            this.box = box;
        }

        public virtual Vector2 Position => this.box.Position;

        public virtual Vector2 Size => this.box.Size;

        public virtual Rectangle Bounds => this.box.Bounds;

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public void Push(Vector2 force)
        {
            var newPosition = Position + force;
            this.box.Move(newPosition.X, newPosition.Y);
        }
    }
}
