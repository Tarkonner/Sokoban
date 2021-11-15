﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    class LevelData
    {
        /// <summary>
        /// Dataen for levles
        /// 0: gulv
        /// 1: vægge
        /// 2: boks
        /// 3: mål
        /// 4: spiller
        /// </summary>
        public int[,] level_0 = new int[7, 6]
        {
            {1, 1, 1, 1, 1, 1},
            {1, 0, 0, 0, 0, 1},
            {1, 0, 2, 0, 0, 1},
            {1, 0, 0, 4, 0, 1},
            {1, 0, 3, 0, 0, 1},
            {1, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1}
        };
        public int[,] level_1 = new int[7, 6]
        {
            {1, 1, 1, 1, 1, 1},
            {1, 1, 0, 0, 0, 1},
            {1, 1, 0, 3, 3, 1},
            {1, 0, 2, 0, 0, 1},
            {1, 4, 0, 0, 2, 1},
            {1, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1}
        };

        public List<int[,]> levelHolder = new List<int[,]>();

        public LevelData()
        {
            levelHolder.Add(level_0);
            levelHolder.Add(level_1);
        }

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
