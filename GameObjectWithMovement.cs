using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    public abstract class GameObjectWithMovement : GameObjectWithCollider
    {
        protected GameObjectWithMovement(float xPosition, float yPosition, bool isTriggerCollider = false) : base(xPosition, yPosition, isTriggerCollider)
        {
            Undo.Instance.AddPosition(gridPosition, this);
        }

        protected virtual void MoveInDirection(Vector2 direction)
        {
            Undo.Instance.AddPosition(gridPosition, this);

            //Move           
            gridPosition += direction;
            position = GridPlacement.Placement(gridPosition);
            //Set rectangle position
            rectangle.X = (int)position.X;
            rectangle.Y = (int)position.Y;
        }

        public void SetPosition(Vector2 targetPosition)
        {
            position = GridPlacement.Placement(targetPosition);
            gridPosition = targetPosition;

            rectangle.X = (int)position.X;
            rectangle.Y = (int)position.Y;
        }
    }
}
