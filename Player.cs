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

        protected Texture2D[] animationsUp;
        protected Texture2D[] animationsLeft;
        protected Texture2D[] animationsDown;
        protected Texture2D[] animationsRight;
        protected Texture2D[] animationsIdle;

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
            animationsUp = new Texture2D[3];
            animationsIdle = new Texture2D[2];
            animationsLeft = new Texture2D[3];
            animationsDown = new Texture2D[2];
            animationsRight = new Texture2D[3];
            // Up animaton
            for (int i = 2; i <= 4; i++)
            {
                animationsUp[i - 2] = content.Load<Texture2D>("player_0" + i);
            }
            // D animaton
            for (int i = 11; i <= 13; i++)
            {
                animationsRight[i - 11] = content.Load<Texture2D>("player_" + i);
            }
            // Left animaton
            for (int i = 14; i <= 16; i++)
            {
                animationsLeft[i - 14] = content.Load<Texture2D>("player_" + i);
            }
            // Down animaton
            for (int i = 23; i <= 24; i++)
            {
                animationsDown[i - 23] = content.Load<Texture2D>("player_" + i);

            }
            // start
            for (int i = 1; i <= 2; i++)
            {
                animationsIdle[i - 1] = content.Load<Texture2D>("player_0" + i);

            }

            // Idle animation
            animations = animationsIdle;

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
                animations = animationsRight;

            }
            else if (keyboard.IsKeyDown(Keys.A))
            {

                playerInput = new Vector2(-1, 0);
                animations = animationsLeft;

            }
            else if (keyboard.IsKeyDown(Keys.W))
            {
                playerInput = new Vector2(0, -1);

                animations = animationsUp;

            }
            else if (keyboard.IsKeyDown(Keys.S))
            {
                playerInput = new Vector2(0, 1);
                animations = animationsDown;

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
