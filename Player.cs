using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban
{
    public class Player : GameObjectWithCollider
    {
        private GraphicsDeviceManager graphicsPlayer;

        //Movement
        public Vector2 playerInput = Vector2.Zero;
        private Vector2 gridPosition;
        private float timeBetweenMovement = .3f;
        private float movementClock = 0;
        private int maxX = 12;
        private int maxY = 8;

        //Animation

        protected Texture2D[] animationsW;
        protected Texture2D[] animationsA;
        protected Texture2D[] animationsS;
        protected Texture2D[] animationsD;
        protected Texture2D[] animationsx;

        public Player(Vector2 position, GraphicsDeviceManager graphics)
        {
            gridPosition = position;
            this.position = GridPlacement.Placement(gridPosition);

            this.graphicsPlayer = graphics;

            animationSpeed = 3;
        }


        public override void LoadContent(ContentManager content)
        {
            //Load animations
            animationsW = new Texture2D[3];
            animationsx = new Texture2D[2];
            animationsA = new Texture2D[3];
            animationsS = new Texture2D[2];
            animationsD = new Texture2D[3];
            // W animaton
            for (int i = 2; i <= 4; i++)
            {
                animationsW[i - 2] = content.Load<Texture2D>("player_0" + i);
            }
            // D animaton
            for (int i = 11; i <= 13; i++)
            {
                animationsD[i - 11] = content.Load<Texture2D>("player_" + i);
            }
            // A animaton
            for (int i = 14; i <= 16; i++)
            {
                animationsA[i - 14] = content.Load<Texture2D>("player_" + i);
            }
            // S animaton
            for (int i = 23; i <= 24; i++)
            {
                animationsS[i - 23] = content.Load<Texture2D>("player_" + i);

            }
            // start
            for (int i = 1; i <= 2; i++)
            {
                animationsx[i - 1] = content.Load<Texture2D>("player_0" + i);

            }

            // Idle animation
            animations = animationsx;

            // setter sprite
            sprite = animations[0];


            //Rec
            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
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
                animations = animationsD;

            }
            else if (keyboard.IsKeyDown(Keys.A))
            {

                playerInput = new Vector2(-1, 0);
                animations = animationsA;

            }
            else if (keyboard.IsKeyDown(Keys.W))
            {
                playerInput = new Vector2(0, -1);

                animations = animationsW;

            }
            else if (keyboard.IsKeyDown(Keys.S))
            {
                playerInput = new Vector2(0, 1);
                animations = animationsS;

            }


            var placeTaken = LookAround.LookAt(GridPlacement.Placement(gridPosition + playerInput));


            //Movement
            if (movementClock <= 0 && playerInput != Vector2.Zero && !placeTaken.Item1)
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
                    rectangle.X = (int)position.X;
                    rectangle.Y = (int)position.Y;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            Animate(gameTime);
            Movement(gameTime);
        }

        public override void OnCollision(GameObject other)
        {
            base.OnCollision(other);
        }
    }
}
