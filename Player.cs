using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        private SoundEffect walkSound;

        public Player(Vector2 position, GraphicsDeviceManager graphics)
        {
            gridPosition = position;
            this.position = GridPlacement.Placement(gridPosition);

            this.graphicsPlayer = graphics;

            animationSpeed = .5f;
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

            walkSound = content.Load<SoundEffect>("326543__sqeeeek__wetfootsteps");
            SoundEffect.MasterVolume = .4f;

            //Rec
            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }


        private void Input(GameTime gameTime)
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
                walkSound.Play();
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


            


            //Movement
            if (movementClock <= 0 && playerInput != Vector2.Zero)
            {
                Movement(playerInput);
                movementClock = timeBetweenMovement;
            }
        }

        public override void Update(GameTime gameTime)
        {
            Animate(gameTime);
            Input(gameTime);
        }

        private void Movement(Vector2 direction)
        {
            //Bounds
            if (gridPosition.X + direction.X <= 0
                && gridPosition.X + direction.X > maxX
                && gridPosition.Y + direction.Y <= 0
                && gridPosition.Y + direction.Y > maxY)
                return;
                
            //Look
            GameObjectWithCollider targetObject = LookAround.LookAt(GridPlacement.Placement(gridPosition + playerInput));

            if(targetObject == null)
                MoveInDirection(direction);
            else if (targetObject is Box)
            {
                Box targetBox = (Box)targetObject;
                bool result = targetBox.MoveInDirection(direction);

                if (result)
                    MoveInDirection(direction);
            }


        }

        private void MoveInDirection(Vector2 direction)
        {
            //Move           
            gridPosition += direction;
            position = GridPlacement.Placement(gridPosition);
            //Set rectangle position
            rectangle.X = (int)position.X;
            rectangle.Y = (int)position.Y;
        }

        public override void OnCollision(GameObject other)
        {
            base.OnCollision(other);
        }
    }
}
