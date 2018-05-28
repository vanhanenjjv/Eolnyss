using Eolnyss.Core;
using Microsoft.Xna.Framework;

namespace Eolnyss.Physics
{
    public interface IPhysicsObject : IGameObject
    {
        void Push(Vector2 force);
    }
}