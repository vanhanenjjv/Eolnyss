using System.Collections.Generic;

namespace Eolnyss.Physics
{
    public class World : IWorld
    {
        private List<IBox> boxes;

        public World()
        {
            this.boxes = new List<IBox>();
        }

        public IEnumerable<IBox> Boxes => this.boxes;

        public IBox Create(float x, float y, float width, float height)
        {
            IBox box = new Box(this, x, y, width, height);
            this.boxes.Add(box);

            return box;
        }
    }
}
