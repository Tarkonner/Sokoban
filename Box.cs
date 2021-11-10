using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    class Box : GameObject
    {        
        public Box(Vector2 position)
        {
            this.position = position;

            

        }
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("crate_01");

            rectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
       
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, rectangle, Color.White, rotaton, Origen, scale, effect, layerDepth);
        }



        public override void Update(GameTime gameTime)
        {
           
        }
    }
}
