using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{


    public abstract class GameObject
    {
        //Transform
        public Vector2 position;
        public float rotaton;
        public Vector2 scale = Vector2.One;

        //Rendering
        public float layerDepth;
        protected SpriteEffects effect;
        public Rectangle rectangle;

        //Animation
        protected Texture2D sprite;
        protected Texture2D[] animations;
        protected float animationSpeed;
        private float timeEapsed;
        private int currenIndex;



        public Vector2 Origen
        {
            get
            {
                if (sprite != null)
                {
                    return new Vector2(sprite.Width / 2, sprite.Height / 2);
                }
                return Vector2.Zero;
            }
        }
        public Texture2D Sprite { get => sprite; set => sprite = value; }


        public abstract void Update(GameTime gameTime);

        public abstract void LoadContent(ContentManager content);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, rectangle, null, Color.White, rotaton, Origen, effect, layerDepth);
        }

        public virtual void Animate(GameTime gameTime)
        {
            timeEapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            currenIndex = (int)(timeEapsed * animationSpeed);

            if (currenIndex >= animations.Length)
            {
                timeEapsed = 0;

                currenIndex = 0;
            }
            sprite = animations[currenIndex];
        }
    }
}
