using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    class Wall : GameObjectWithCollider
    {
        public Wall(float xPosition, float yPosition, bool isTriggerCollider = false) : base(xPosition, yPosition, isTriggerCollider)
        {
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("block_05");

            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
