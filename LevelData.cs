using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    class LevelData
    {
        public int[,] Level_0 = new int[7, 6]
        {
            {1, 1, 1, 1, 1, 1},
            {1, 0, 0, 0, 0, 1},
            {1, 0, 2, 0, 0, 1},
            {1, 0, 0, 4, 0, 1},
            {1, 0, 3, 0, 0, 1},
            {1, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1}
        };

        public GameObject Object(int whatObjects, float xPos, float yPos)
        {
            switch(whatObjects)
            {
                case 0:
                    return new Floor(xPos, yPos);
                case 1:
                    return new Wall(xPos, yPos);
                case 2:
                    return new Box(xPos, yPos);
                case 3:
                    return new Goal(xPos, yPos);
                case 4:
                    return new Player(xPos, yPos);
            }

            return null;
        }
    }
}
