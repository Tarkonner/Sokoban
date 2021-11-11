﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    public static class LookAround
    {
        public static List<GameObjectWithCollider> rectangles = new List<GameObjectWithCollider>();

        public static bool LookAt(Vector2 position)
        {
            bool result = false;
            Rectangle rec = new Rectangle((int)position.X, (int)position.Y, 1, 1);

            foreach (GameObjectWithCollider item in rectangles)
            {
                result = rec.Intersects(item.rectangle);

                if (result)
                    break;
            }

            return result;
        }
    }
}
