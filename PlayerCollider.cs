using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    class PlayerCollider : Collider
    {
        public PlayerCollider(GameObject gameObject, bool isTriggerCollider = false) : base(gameObject, isTriggerCollider)
        {
        }

        public override void OnCollision(GameObject other)
        {
            base.OnCollision(other);
            
        }
    }
}
