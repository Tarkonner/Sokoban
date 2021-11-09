using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    public class Player : GameObject
    {
        protected Vector2 velocity;

        public Vector2 Velocity { get => velocity; set => velocity = value; }
        public float Speed { get => speed; set => speed = value; }

        private float speed = 200.101f;


        public Player(Vector2 position)
        {
            this.position = position;



        }


        protected void Move(GameTime gameTime)
        {
            float de = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((Velocity * Speed) * de);


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, rectangle, Color.White, rotaton, Origen, scale, effect, layerDepth);
        }

        public override void LoadContent(ContentManager content)
        {

            animations = new Texture2D[24];

            //for (int i = 1; i < animations.Length; i++)
            //{
            //    animations[i] = content.Load<Texture2D>("player_0" + i);
            //}


            animations[0] = content.Load<Texture2D>("player_01" );


            sprite = animations[0];

            this.position = new Vector2();
           

            rectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
        }

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
        }
    }
}
