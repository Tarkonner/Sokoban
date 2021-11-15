using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    class Floor : GameObject
    {
        public Floor(float xPosition, float yPosition) : base(xPosition, yPosition)
        {
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("ground_06");

            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
