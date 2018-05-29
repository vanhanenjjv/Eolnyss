using System.Collections.Generic;

namespace Eolnyss.Physics
{
    public class World : IWorld
    {
        private List<IBox> boxes;

        private float width;
        private float height;

        public World(float width, float height)
        {
            this.width = width;
            this.height = height;

            this.boxes = new List<IBox>();
        }

        public float Width => width;

        public float Height => height;

        public IEnumerable<IBox> Boxes => this.boxes;

        public IBox Create(float x, float y, float width, float height)
        {
            IBox box = new Box(this, x, y, width, height);
            this.boxes.Add(box);

            return box;
        }

    }
}
