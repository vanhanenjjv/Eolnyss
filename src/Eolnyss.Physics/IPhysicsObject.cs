using Eolnyss.Core;
using Microsoft.Xna.Framework;
using System;

namespace Eolnyss.Physics
{
    public interface IPhysicsObject : IGameObject, IBox
    {
        void Push(Vector2 movement);
    }
}