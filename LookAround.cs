using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    public static class LookAround
    {
        public static List<GameObjectWithCollider> objects = new List<GameObjectWithCollider>();

        public static Tuple<bool, GameObjectWithCollider> LookAt(Vector2 position)
        {
            //Variabler
            bool result = false;
            GameObjectWithCollider targetObject = null;

            //Look
            Rectangle rec = new Rectangle((int)position.X, (int)position.Y, 1, 1);

            foreach (GameObjectWithCollider item in objects)
            {
                result = rec.Intersects(item.rectangle);

                if (result)
                {
                    targetObject = item;
                    break;
                }
            }

            return Tuple.Create(result, targetObject);
        }
    }
}
