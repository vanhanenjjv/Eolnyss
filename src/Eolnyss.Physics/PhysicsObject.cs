﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Eolnyss.Physics
{
    public abstract class PhysicsObject : IPhysicsObject
    {
        private IBox box;

        public PhysicsObject(IBox box)
        {
            this.box = box;
            this.box.OnCollision += OnCollision;
        }

        public IBox Box => this.box;

        public virtual Vector2 Position => this.box.Position;

        public virtual Vector2 Size => this.box.Size;

        public virtual Rectangle Bounds => this.box.Bounds;

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void OnCollision(object sender, CollisionArgs collisionArgs);

        public void Push(Vector2 movement)
        {
            float x = (float)Math.Round(Position.X + movement.X);
            float y = (float)Math.Round(Position.Y + movement.Y);

            this.box.Move(x, y);
        }
    }
}
