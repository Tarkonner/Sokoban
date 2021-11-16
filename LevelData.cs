using System;
using System.Collections.Generic;

namespace Sokoban
{
    class LevelData
    {
        #region Levels
        /// <summary>
        /// Dataen for levles
        /// 0: gulv
        /// 1: vægge
        /// 2: boks
        /// 3: mål
        /// 4: spiller
        /// </summary>
        public int[,] level_0 = new int[12, 7]
        {
            {1, 1, 1, 1,1, 1 ,1},
            {1, 4, 2, 0, 0, 3,1},
            {1, 0, 2, 0, 0, 0,1},
            {1, 0, 0, 0, 0, 1,1},
            {1, 3, 0, 0, 0, 3,1},
            {1, 0, 0, 2, 0, 0,1},
            {1, 0, 0, 1, 0, 1,1},
            {1, 1, 2, 1, 1, 1,1},
            {1, 0, 0, 1, 0, 0,1},
            {1, 0, 0, 0, 0, 0,1},
            {1, 0, 1, 0, 1, 3,1},
            {1, 1, 1, 1, 1, 1,1}
        };
        public int[,] level_1 = new int[12, 7]
{
            {1, 1, 1, 1,1, 1 ,1},
            {1, 4, 2, 0, 0, 3,1},
            {1, 0, 2, 0, 0, 0,1},
            {1, 1, 1, 1, 0, 1,1},
            {1, 3, 0, 0, 0, 3,1},
            {1, 0, 0, 2, 0, 0,1},
            {1, 0, 0, 1, 0, 1,1},
            {1, 1, 2, 0, 0, 1,1},
            {1, 0, 0, 1, 0, 0,1},
            {1, 0, 0, 0, 0, 0,1},
            {1, 0, 1, 0, 1, 3,1},
            {1, 1, 1, 1, 1, 1,1}
};
        public int[,] level_2 = new int[12, 7]
{
            {1, 1, 1, 1,1, 1 ,1},
            {1, 4, 2, 0, 0, 3,1},
            {1, 0, 2, 0, 0, 0,1},
            {1, 1, 1, 1, 0, 1,1},
            {1, 3, 0, 0, 0, 3,1},
            {1, 0, 0, 2, 0, 0,1},
            {1, 0, 0, 1, 0, 1,1},
            {1, 1, 2, 1, 0, 0,1},
            {1, 0, 0, 1, 0, 0,1},
            {1, 0, 0, 0, 0, 0,1},
            {1, 0, 1, 0, 1, 3,1},
            {1, 1, 1, 1, 1, 1,1}
};
        public int[,] level_3 = new int[12, 7]
{
            {1, 1, 1, 1,1, 1 ,1},
            {1, 4, 2, 0, 0, 3,1},
            {1, 0, 2, 0, 0, 0,1},
            {1, 1, 1, 1, 0, 1,1},
            {1, 3, 0, 0, 0, 3,1},
            {1, 0, 0, 2, 0, 0,1},
            {1, 0, 0, 0, 0, 1,1},
            {1, 0, 2, 0, 1, 1,1},
            {1, 0, 0, 1, 0, 0,1},
            {1, 0, 0, 0, 0, 0,1},
            {1, 0, 1, 0, 1, 3,1},
            {1, 1, 1, 1, 1, 1,1}
};
        public int[,] level_4 = new int[12, 7]
{
            {1, 1, 1, 1,1, 1 ,1},
            {1, 4, 2, 0, 0, 3,1},
            {1, 0, 2, 0, 0, 0,1},
            {1, 1, 1, 1, 0, 1,1},
            {1, 3, 0, 0, 0, 3,1},
            {1, 0, 0, 2, 0, 0,1},
            {1, 0, 0, 1, 0, 1,1},
            {1, 1, 2, 1, 1, 1,1},
            {1, 0, 0, 1, 0, 0,1},
            {1, 0, 0, 0, 0, 0,1},
            {1, 0, 1, 0, 1, 3,1},
            {1, 1, 1, 1, 1, 1,1}
};
        #endregion
        GameObjectManeger objectManeger = GameObjectManeger.Instance;

        public List<int[,]> levelHolder = new List<int[,]>();

        public LevelData()
        {
            levelHolder.Add(level_0);
            levelHolder.Add(level_1);
            levelHolder.Add(level_2);
            levelHolder.Add(level_3);
            levelHolder.Add(level_4);
        }

        public GameObject Object(int whatObjects, float xPos, float yPos)
        {
            switch (whatObjects)
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

        public void LoadLevel(int targetLevel)
        {
            int[,] spawnLevel = new int[0, 0];

            try
            {
                spawnLevel = levelHolder[targetLevel];

                //Remove old level
                if (objectManeger.GameObjects.Count > 0)
                {
                    foreach (var item in objectManeger.GameObjects)
                    {
                        objectManeger.Destory(item);
                    }
                }

                //Inscert level
                for (int y = 0; y < spawnLevel.GetLength(1); y++)
                {
                    for (int x = 0; x < spawnLevel.GetLength(0); x++)
                    {
                        //Add floor if needed
                        if (spawnLevel[x, y] > 1)
                            objectManeger.Instantiate(Object(0, x, y));

                        //Spawn object
                        objectManeger.Instantiate(Object(spawnLevel[x, y], x, y));
                    }
                }
            }
            catch(Exception e)
            {
                
            }
        }
    }
}
