using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    public class Collider
    {
        /*
        private GameObject parent;
        private bool trigger;

        public Collider(GameObject gameObject, bool isTriggerCollider = false)
        {
            parent = gameObject;
            trigger = isTriggerCollider;
        }

        public virtual Rectangle GetCollisionBox(GameObject gameObject, float sizeX = 0, float sizeY = 0)
        {
            Vector2 recSize = new Vector2((int)(gameObject.Sprite.Width * gameObject.scale.X), (int)(gameObject.Sprite.Height * gameObject.scale.Y));
            if (sizeX != 0 && sizeY != 0)
                recSize = new Vector2(sizeX * gameObject.scale.X, sizeY * gameObject.scale.Y);

            Rectangle result = new Rectangle((int)(gameObject.position.X - gameObject.Origen.X), 
                (int)(gameObject.position.Y - gameObject.Origen.Y), (int)recSize.X, (int)recSize.Y);
            return result;
        }

        public virtual void OnCollision(GameObject other)
        {

        }

        public void CheckCollision(GameObject other)
        {
            Collider otherCol = other.Collider;
            if (otherCol == null || otherCol.trigger)
                return;

            if (GetCollisionBox(other).Intersects(otherCol.GetCollisionBox(parent)))
            {
                OnCollision(other);
            }
        }
        */
    }
}
