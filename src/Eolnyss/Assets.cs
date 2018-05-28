using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Eolnyss
{
    static class Assets
    {
        public static Texture2D PlayerTexture;
        public static Texture2D PlatformTexture;
        public static Texture2D SpikeTexture;

        public static void LoadContent(ContentManager content)
        {
            PlayerTexture = content.Load<Texture2D>("Sprites/forsen1337");
            PlatformTexture = content.Load<Texture2D>("Sprites/forsenW");
            SpikeTexture = content.Load<Texture2D>("Sprites/forsenC");
        }
    }
}
