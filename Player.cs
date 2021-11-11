using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban
{
    public class Player : GameObjectWithCollider
    {
        public Vector2 playerInput = Vector2.Zero;
        private bool trueAnimationsW;
        private Vector2 gridPosition;

        private GraphicsDeviceManager graphicsPlayer;



        private float timeBetweenMovement = .3f;
        private float movementClock = 0;
        private int maxX = 12;
        private int maxY = 8;

        public Player(Vector2 position, GraphicsDeviceManager graphics)
        {
            gridPosition = position;
            this.position = GridPlacement.Placement(gridPosition);

            this.graphicsPlayer = graphics;

            animationSpeed = 12;
        }



        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, rectangle, Color.White, rotaton, Origen, scale, effect, layerDepth);
        }



        public override void LoadContent(ContentManager content)
        {

            //W
            animations = new Texture2D[3];
            //D
            animationsD = new Texture2D[3];
            //A
            animationsA = new Texture2D[3];
            //S
            animationsS = new Texture2D[3];



            //D
            for (int i = 11; i <= 13; i++)
            {

                animationsD[i - 1] = content.Load<Texture2D>("player_" + i);



            }
            //W
            for (int i = 2; i <= 4; i++)
            {
      animations[i - 2] = content.Load<Texture2D>("player_0" + i);
                    
              


            }

            sprite = animations[0];

            sprite = animationsD[0];







            rectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);





        }


        private void Movement(GameTime gameTime)
        {
            playerInput = Vector2.Zero;

            KeyboardState keyboard = Keyboard.GetState();
            float de = (float)gameTime.ElapsedGameTime.TotalSeconds;
            movementClock -= de;

            //Input
            if (keyboard.IsKeyDown(Keys.D))
            {
                playerInput = new Vector2(1, 0);

            }
            else if (keyboard.IsKeyDown(Keys.A))
            {
                playerInput = new Vector2(-1, 0);
            }
            else if (keyboard.IsKeyDown(Keys.W))
            {

                playerInput = new Vector2(0, -1);
                trueAnimationsW = true;

            }
            else if (keyboard.IsKeyDown(Keys.S))
            {
                playerInput = new Vector2(0, 1);
            }


            if (keyboard.IsKeyUp(Keys.W))
            {
                trueAnimationsW = false;
            }


            //Movement
            if (movementClock <= 0 && playerInput != Vector2.Zero)
            {

                //Bounds
                if (gridPosition.X + playerInput.X >= 0
                    && gridPosition.X + playerInput.X < maxX
                    && gridPosition.Y + playerInput.Y >= 0
                    && gridPosition.Y + playerInput.Y < maxY
                    )
                {
                    movementClock = timeBetweenMovement;

                    gridPosition += playerInput;

                    position = GridPlacement.Placement(gridPosition);
                }


            }

        }

        public override void Update(GameTime gameTime)
        {
            if (trueAnimationsW == true)
            {
                Animate(gameTime);
                
            }

            AnimateD(gameTime);
            Movement(gameTime);

            //Move(gameTime);
        }

        public override void OnCollision(GameObject other)
        {
            base.OnCollision(other);
        }
    }
}
