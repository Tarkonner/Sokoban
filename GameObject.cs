using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{


    public abstract class GameObject
    {
        public Vector2 position;
        public float rotaton;
        public Vector2 scale;

        // rendering
        public float layerDepth;
        protected SpriteEffects effect;
        protected Rectangle rectangle;
        protected Texture2D[] animations;
        protected Texture2D sprite;
        protected float animationSpeed;

        public Vector2 Origen { 
            get {
                if (sprite != null)
                {
                    return new Vector2(sprite.Width / 2, sprite.Height / 2 );
                }
                return Vector2.Zero;
            } 
        }

        public abstract void Update(GameTime gameTime);

        public abstract void LoadContent(ContentManager content);


        public abstract void Draw(SpriteBatch spriteBatch);
       

    }
}
