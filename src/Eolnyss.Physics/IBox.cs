using Microsoft.Xna.Framework;

namespace Eolnyss.Physics
{
    public interface IBox
    {
        Vector2 Position { get; }

        Vector2 Size { get; }

        Rectangle Bounds { get; }

        void Move(float x, float y);
    }
}