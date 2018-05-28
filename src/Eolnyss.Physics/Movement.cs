namespace Eolnyss.Physics
{
    public class Movement
    {
        IBox box;
        Side side;

        public Movement(IBox box, Side side)
        {
            this.box = box;
            this.side = side;
        }

        public IBox Box => this.box;

        public Side Side => this.side;
    }
}
