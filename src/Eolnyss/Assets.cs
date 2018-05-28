using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Eolnyss
{
    static class Assets
    {
        public static Texture2D PlayerTexture;
        public static Texture2D PlatformTexture;
        public static Texture2D SpikeTexture;
        public static Texture2D GoalTexture;

        public static Song Song;

        public static void LoadContent(ContentManager content)
        {
            PlayerTexture = content.Load<Texture2D>("Sprites/forsenBee");
            PlatformTexture = content.Load<Texture2D>("Sprites/forsenE");
            SpikeTexture = content.Load<Texture2D>("Sprites/forsenD");
            GoalTexture = content.Load<Texture2D>("Sprites/Honey");

            Song = content.Load<Song>("Audio/BumbleBee");
        }
    }
}
