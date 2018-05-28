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

        public Box(IWorld world, float x, float y, float width, float height)
        {
            this.world = world;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public Vector2 Position => new Vector2(x, y);

        public Vector2 Size => new Vector2(width, height);

        public Rectangle Bounds => new Rectangle((int)x, (int)y, (int)width, (int)height);

        public void Move(float x, float y)
        {
            this.x = x;          
            HandleCollisions(Axis.Horizontal);

            this.y = y;
            HandleCollisions(Axis.Vertical);
        }

        public void HandleCollisions(Axis axis)
        {
            foreach (var box in this.world.Boxes)
            {
                if (box.Equals(this))
                    continue;

                if (!Bounds.Intersects(box.Bounds))
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

        public enum Axis
        {
            Horizontal,
            Vertical
        }
    }
}
