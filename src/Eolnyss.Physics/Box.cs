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
            this.y = y;
        }
    }
}
