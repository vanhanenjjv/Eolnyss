using Eolnyss.Core;
using Microsoft.Xna.Framework;
using System;

namespace Eolnyss.Physics
{
    public interface IPhysicsObject : IGameObject
    {
        void Push(Vector2 movement);
    }
}