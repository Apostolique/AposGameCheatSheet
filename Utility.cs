using Microsoft.Xna.Framework;

namespace AposGameCheatSheet
{
    static class Utility
    {
        public static Core game;
        public static GameWindow Window;

        public static int WindowWidth => Window.ClientBounds.Width;
        public static int WindowHeight => Window.ClientBounds.Height;

        public static Input Input;

        public static bool showLine = false;
    }
}