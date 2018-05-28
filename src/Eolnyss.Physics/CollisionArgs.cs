using System;

namespace Eolnyss.Physics
{
    public class CollisionArgs : EventArgs
    {
        private readonly IBox box;
        private readonly Side side;

        public CollisionArgs(IBox box, Side side)
        {
            this.box = box;
            this.side = side;
        }

        public IBox Box => this.box;

        public Side Side => this.side;
    }
}
