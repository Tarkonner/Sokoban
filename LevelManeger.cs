using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    class LevelManeger
    {
        GameObjectManeger objectManeger = GameObjectManeger.Instance;

        public List<int[,]> levelHolder = new List<int[,]>();


        public LevelManeger()
        {
            levelHolder.Add(LevelData.level_0);
            levelHolder.Add(LevelData.level_1);
            levelHolder.Add(LevelData.level_2);
            levelHolder.Add(LevelData.level_3);
            levelHolder.Add(LevelData.level_4);
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
            catch (Exception e)
            {

            }
        }
    }
}
