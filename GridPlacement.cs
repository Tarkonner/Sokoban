using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
   public static class GridPlacement
    {


        public static Vector2 Placement(Vector2 dir)
        {
            Vector2 result =  new Vector2(64 / 2 + dir.X * 64 ,64 / 2 + dir.Y * 64);

            return result;
        }


    }
}
