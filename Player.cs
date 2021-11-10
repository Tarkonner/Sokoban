using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban
{
    public class Player : GameObject
    {
        public Vector2 playerInput = Vector2.Zero;

        private Vector2 gridPosition;

        private GraphicsDeviceManager graphicsPlayer;

        private float timeBetweenMovement = .9f;
        private float movementClock = 0;

        public Player(Vector2 position, GraphicsDeviceManager graphics)
        {
            this.position = position;

            this.graphicsPlayer = graphics;


        }


        //protected void Move(GameTime gameTime)
        //{
        //    float de = (float)gameTime.ElapsedGameTime.TotalSeconds;

        //    position += ((playerInput * Speed) * de);


        //}

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


        private void Movement(GameTime gameTime)
        {
            playerInput = Vector2.Zero;
            KeyboardState keyboard = Keyboard.GetState();

            int de = (int)gameTime.ElapsedGameTime.TotalSeconds;
            movementClock -= de ;

            //Input
            if (keyboard.IsKeyDown(Keys.D))
            {
                playerInput = new Vector2(1, 0);

            }


            //Movement
            if(movementClock <= 0)
            {
            
                movementClock = timeBetweenMovement;

                gridPosition += playerInput;

                position = GridPlacement.Placement(gridPosition);


                
            }

           





        }


        public override void Update(GameTime gameTime)
        {
            Movement(gameTime);
            //Move(gameTime);
        }
    }
}
