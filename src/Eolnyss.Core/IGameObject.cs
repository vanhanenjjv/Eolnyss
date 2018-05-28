using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Eolnyss.Core
{
    public interface IGameObject
    {
        Vector2 Position { get; }

        Vector2 Size { get; }

        Rectangle Bounds { get; }

        void Update(GameTime gameTime);

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
