using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{


    public abstract class GameObject
    {
        public Vector2 position;
        public float rotaton;
        public Vector2 scale = Vector2.One;

        // rendering
        public float layerDepth;
        protected SpriteEffects effect;
        protected Rectangle rectangle;

        // sprite
        protected Texture2D sprite;


        /// <summary>
        /// animations
        /// </summary>
        protected Texture2D[] animations;
        protected float animationSpeed;
        private float timeEapsed;
        private float fps = 0;
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


        public abstract void Draw(SpriteBatch spriteBatch);

        public void Animate(GameTime gameTime)
        {
            timeEapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            currenIndex = (int)(timeEapsed * fps);

            sprite = animations[currenIndex];

            if (currenIndex >= animations.Length - 1)
            {
                timeEapsed = 0;

                currenIndex = 0;

            }


        }


    }
}
