using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
   public class Box : GameObjectWithMovement
    {
        public Box(Vector2 position, bool isTriggerCollider = false) : base(position, isTriggerCollider)
        {
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("crate_01");            

            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);       
        }

        public override void Update(GameTime gameTime)
        {
           
        }

        public bool BoxMovement(Vector2 direction)
        {
            GameObjectWithCollider targetObject = LookAround.LookAt(GridPlacement.Placement(gridPosition + direction));

            if(targetObject == null)
            {
                MoveInDirection(direction);

                return true;
            }

            return false;
        }
    }
}
