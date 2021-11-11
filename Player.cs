using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban
{
    public class Player : GameObjectWithCollider
    {
        public Vector2 playerInput = Vector2.Zero;

        private Vector2 gridPosition;

        private GraphicsDeviceManager graphicsPlayer;
        private bool placeTaken = false;

        private float timeBetweenMovement = .3f;
        private float movementClock = 0;
        private int maxX = 12;
        private int maxY = 8;

        public Player(Vector2 position, GraphicsDeviceManager graphics)
        {
            gridPosition = position;
            this.position = GridPlacement.Placement(gridPosition);

            this.graphicsPlayer = graphics;

            animationSpeed = 2;
        }


        public override void LoadContent(ContentManager content)
        {

            animations = new Texture2D[3];
            //animations = new Texture2D[24];
            //animations = new Texture2D[24];

            for (int i = 2; i <= 4; i++)
            {
                animations[i - 2] = content.Load<Texture2D>("player_0" + i);
            }


            //animations[0] = content.Load<Texture2D>("player_01");


            sprite = animations[0];

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
                
            }
            else if (keyboard.IsKeyDown(Keys.A))
            {
                playerInput = new Vector2(-1, 0);
            }
            else if (keyboard.IsKeyDown(Keys.W))
            {
                playerInput = new Vector2(0, -1);
            }
            else if (keyboard.IsKeyDown(Keys.S))
            {
                playerInput = new Vector2(0, 1);
            }

            placeTaken = LookAround.LookAt(GridPlacement.Placement(gridPosition + playerInput));

            //Movement
            if (movementClock <= 0 && playerInput != Vector2.Zero && !placeTaken)
            {
                //Bounds
                if(gridPosition.X + playerInput.X >= 0
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
