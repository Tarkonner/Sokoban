using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    public static class LookAround
    {
        public static List<GameObjectWithCollider> objects = new List<GameObjectWithCollider>();

        public static GameObjectWithCollider LookAt(Vector2 position)
        {
            GameObjectWithCollider targetObject = null;

            //Look
            Rectangle rec = new Rectangle((int)position.X, (int)position.Y, 1, 1);

            foreach (GameObjectWithCollider item in objects)
            {
                if (item.Trigger)
                    continue;

                bool colliding = rec.Intersects(item.rectangle);

                if (colliding)
                {
                    targetObject = item;
                    break;
                }
            }

            return targetObject;
        }
    }
}
