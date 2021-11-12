using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    public abstract class GameObjectWithMovement : GameObjectWithCollider
    {
        protected GameObjectWithMovement(Vector2 position, bool isTriggerCollider) : base(position, isTriggerCollider)
        {
        }

        protected void MoveInDirection(Vector2 direction)
        {
            //Move           
            gridPosition += direction;
            position = GridPlacement.Placement(gridPosition);
            //Set rectangle position
            rectangle.X = (int)position.X;
            rectangle.Y = (int)position.Y;
        }
    }
}
