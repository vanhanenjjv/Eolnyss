using System;
using System.Collections.Generic;
using System.IO;

namespace Eolnyss.Prefabs
{
    static class LevelManager
    {
        private const int AmountOfLevels = 2;

        private static int levelNumber;

        private static Level currentLevel;

        static LevelManager()
        {
            levelNumber = 1;

            RestartLevel();
        }

        public static Level CurrentLevel => currentLevel;

        public static void NextLevel()
        {
            if (levelNumber + 1 > -1 && levelNumber + 1 < AmountOfLevels)
                ++levelNumber;
            else
                levelNumber = 0;

            currentLevel = new Level($"level{levelNumber}");
        }

        public static void RestartLevel() => currentLevel = new Level($"level{levelNumber}");

        public static void PreviousLevel()
        {
            if (levelNumber - 1 > -1 && levelNumber - 1 < AmountOfLevels)
                --levelNumber;
            else
                levelNumber = AmountOfLevels - 1;

            currentLevel = new Level($"level{levelNumber}");
        }
    }
}
