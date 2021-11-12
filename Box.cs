using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
   public class Box : GameObjectWithCollider
    {

        private Vector2 gridPosition;

        public Box(Vector2 position)
        {
            gridPosition = position;

            this.position = GridPlacement.Placement(gridPosition);

        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("crate_01");            

            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);       
        }

        public override void Update(GameTime gameTime)
        {
           
        }

        public bool MoveInDirection(Vector2 direction)
        {
            GameObjectWithCollider targetObject = LookAround.LookAt(GridPlacement.Placement(gridPosition + direction));

            if(targetObject == null)
            {
                //Move           
                gridPosition += direction;
                position = GridPlacement.Placement(gridPosition);
                //Set rectangle position
                rectangle.X = (int)position.X;
                rectangle.Y = (int)position.Y;

                return true;
            }

            return false;
        }
    }
}
