using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eolnyss.Core
{
    public abstract class GameObject
    {
        public abstract Vector2 Position { get; }

        public abstract void Update(GameTime gameTime);
    }
}
