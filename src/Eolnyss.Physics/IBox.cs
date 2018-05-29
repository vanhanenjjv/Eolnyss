using Microsoft.Xna.Framework;
using System;

namespace Eolnyss.Physics
{
    public interface IBox
    {
        event EventHandler<CollisionArgs> OnCollision;

        Vector2 Position { get; }

        Vector2 Size { get; }

        Rectangle Bounds { get; }

        void Move(float x, float y);

        void Push(Vector2 movement);

        void LidlFix();

        object Data { get; set; }
    }
}