using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    public abstract class GameObjectWithCollider : GameObject
    {
        private bool trigger;

        public GameObjectWithCollider(bool isTriggerCollider = false)
        {
            trigger = isTriggerCollider;
        }

        public virtual Rectangle GetCollisionBox(float sizeX = 0, float sizeY = 0)
        {
            Vector2 recSize = new Vector2((int)(sprite.Width * scale.X), (int)(sprite.Height * scale.Y));
            if (sizeX != 0 && sizeY != 0)
                recSize = new Vector2(sizeX * scale.X, sizeY * scale.Y);

            Rectangle result = new Rectangle((int)(position.X - Origen.X),
                (int)(position.Y - Origen.Y), (int)recSize.X, (int)recSize.Y);
            return result;
        }

        public virtual void OnCollision(GameObject other)
        {

        }

        public void CheckCollision(GameObjectWithCollider other)
        {
            if (other != this)
            {
                if (GetCollisionBox().Intersects(other.GetCollisionBox()))
                {
                    OnCollision(other);
                }
            }
        }
    }
}
