using Eolnyss.Core.Helpers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eolnyss.Physics
{
    public class Box : IBox
    {
        public event EventHandler<CollisionArgs> OnCollision;

        private IWorld world;
        private float x;
        private float y;
        private float width;
        private float height;
        private object data;

        public Box(IWorld world, float x, float y, float width, float height, object data = null)
        {
            this.world = world;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.data = data;
        }

        public IWorld World => this.world;

        public Vector2 Position => new Vector2(x, y);

        public Vector2 Size => new Vector2(width, height);

        public Rectangle Bounds => new Rectangle((int)x, (int)y, (int)width, (int)height);

        public object Data
        {
            get => this.data;
            set => this.data = value;
        }

        public void Move(float x, float y)
        {
            this.x = (float)Math.Round(x);          
            this.y = (float)Math.Round(y);
        }

        public void Push(Vector2 movement)
        {
            this.x = (float)Math.Round(Position.X + movement.X);
            HandleCollisions(Axis.Horizontal);

            this.y = (float)Math.Round(Position.Y + movement.Y);
            HandleCollisions(Axis.Vertical);
        }

        public void HandleCollisions(Axis axis)
        {
            #region Lidl fix #32

            var top = Bounds.Top;
            var bottom = Bounds.Bottom;
            var left = Bounds.Left;
            var right = Bounds.Right;

            if (left < 0 || world.Width < right ||
                top < 0 || world.Height < bottom)
            {
                OnCollision?.Invoke(this, new CollisionArgs(null, Side.None));
                return;
            }

            #endregion

            foreach (var box in this.world.Boxes)
            {
                if (box.Equals(this))
                    continue;

                int offset = 0;

                var bounds = new Rectangle(box.Bounds.X + offset / 2, box.Bounds.Y + offset / 2, box.Bounds.Width - offset, box.Bounds.Height - offset);

                if (!Bounds.Intersects(bounds))
                    continue;

                var depth = Bounds.GetIntersectionDepth(box.Bounds);

                var side = Side.None;

                switch (axis)
                {
                    case Axis.Horizontal:
                        side = depth.X < 0 ? Side.Right : Side.Left;
                        this.x += depth.X;
                        break;
                    case Axis.Vertical:
                        side = depth.Y < 0 ? Side.Bottom : Side.Top;
                        this.y += depth.Y;
                        break;
                }

                OnCollision?.Invoke(this, new CollisionArgs(box, side));
            }
        }

        public void LidlFix()
        {
            OnCollision?.Invoke(null, new CollisionArgs(null, Side.None));
        }

        public enum Axis
        {
            Horizontal,
            Vertical
        }
    }
}
