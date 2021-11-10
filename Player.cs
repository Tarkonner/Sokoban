using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban
{
    public class Player : GameObject
    {
        public Vector2 velocity;

        public float Speed { get => speed; set => speed = value; }

        private float speed = 200.101f;

        private GraphicsDeviceManager _graphics;
        private bool testc = false;

        public Player(Vector2 position, GraphicsDeviceManager graphics)
        {
            this.position = position;

            this._graphics = graphics;


        }


        protected void Move(GameTime gameTime)
        {
            float de = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((velocity * Speed) * de);


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


            animations[0] = content.Load<Texture2D>("player_01");


            sprite = animations[0];

            rectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
        }


        private void Movement()
        {
            velocity = Vector2.Zero;
            KeyboardState keyboard = Keyboard.GetState();


            if (testc == false)
            {
                if (keyboard.IsKeyDown(Keys.W))
                {

                    velocity += new Vector2(0, -1);

                    testc = true;


                }

            }

            if (testc == false)
            {
                if (keyboard.IsKeyDown(Keys.D))
                {
                    velocity += new Vector2(1, 0);
                    testc = true;
                }

            }
            if (testc == false)
            {
                if (keyboard.IsKeyDown(Keys.A))
                {
                    velocity += new Vector2(-1, 0);
                    testc = true;
                }

            }
            if (testc == false)
            {
                if (keyboard.IsKeyDown(Keys.S))
                {
                    velocity += new Vector2(0, 1);
                    testc = true;
                }
            }


            if (testc != false)
            {



                if (keyboard.IsKeyUp(Keys.D))
                {
                    testc = false;
                }
                if (keyboard.IsKeyUp(Keys.W))
                {
                    testc = false;
                }
                if (keyboard.IsKeyUp(Keys.A))
                {
                    testc = false;
                }
                if (keyboard.IsKeyUp(Keys.S))
                {
                    testc = false;
                }

            }

            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }



        }


        public override void Update(GameTime gameTime)
        {
            Movement();
            Move(gameTime);
        }
    }
}
