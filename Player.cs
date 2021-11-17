using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban
{
    public class Player : GameObjectWithMovement
    {
        //Movement
        private KeyboardState keyboard;
        public Vector2 playerInput = Vector2.Zero;
        private float timeBetweenMovement = .3f;
        private float movementClock = 0;
        //Animation
        protected Texture2D[] animationsUp;
        protected Texture2D[] animationsLeft;
        protected Texture2D[] animationsDown;
        protected Texture2D[] animationsRight;
        protected Texture2D[] animationsIdle;
        private SoundEffect walkSound;
        private SoundEffectInstance soundEffectInstance;

        public Player(float xPosition, float yPosition, bool isTriggerCollider = false) : base(xPosition, yPosition, isTriggerCollider)
        {
            animationSpeed = 2;

            layerDepth = 0.2f;
        }

        public override void LoadContent(ContentManager content)
        {
            //Load animations

            animationsIdle = new Texture2D[4];
            

            
            
            Texture2D[] loadetAnimationsUp;
            Texture2D[] loadetAnimationsRight;
            Texture2D[] loadetAnimationsLeft;
            Texture2D[] loadetAnimationsDown;
            
            // Up animaton
            animationsUp = new Texture2D[4];
            loadetAnimationsUp = new Texture2D[3];
            for (int i = 2; i <= 4; i++)
            {
                loadetAnimationsUp[i - 2] = content.Load<Texture2D>("player_0" + i);
            }
            animationsUp[0] = loadetAnimationsUp[0];
            animationsUp[1] = loadetAnimationsUp[1];
            animationsUp[2] = loadetAnimationsUp[0];
            animationsUp[3] = loadetAnimationsUp[2];


            // D animaton
            animationsRight = new Texture2D[4];
            loadetAnimationsRight = new Texture2D[3];
            for (int i = 11; i <= 13; i++)
            {
                loadetAnimationsRight[i - 11] = content.Load<Texture2D>("player_" + i);
            }
            animationsRight[0] = loadetAnimationsRight[0];
            animationsRight[1] = loadetAnimationsRight[1];
            animationsRight[2] = loadetAnimationsRight[0];
            animationsRight[3] = loadetAnimationsRight[2];

            // Left animaton
            animationsLeft = new Texture2D[4];
            loadetAnimationsLeft = new Texture2D[3];
            for (int i = 14; i <= 16; i++)
            {
                loadetAnimationsLeft[i - 14] = content.Load<Texture2D>("player_" + i);
            }
            animationsLeft[0] = loadetAnimationsLeft[0];
            animationsLeft[1] = loadetAnimationsLeft[1];
            animationsLeft[2] = loadetAnimationsLeft[0];
            animationsLeft[3] = loadetAnimationsLeft[2];


            // Down animaton
            animationsDown = new Texture2D[4];
            loadetAnimationsDown = new Texture2D[4];
            for (int i = 23; i <= 26; i++)
            {
                loadetAnimationsDown[i - 23] = content.Load<Texture2D>("player_" + i);

            }

            animationsDown[0] = loadetAnimationsDown[0];
            animationsDown[1] = loadetAnimationsDown[1];
            animationsDown[2] = loadetAnimationsDown[0];
            animationsDown[3] = loadetAnimationsDown[2];

            // start
            for (int i = 23; i <= 26; i++)
            {
                animationsIdle[i - 23] = content.Load<Texture2D>("player_" + i);
            }

            // Idle animation
            animations = animationsIdle;

            // setter sprite
            sprite = animations[0];

            walkSound = content.Load<SoundEffect>("326543__sqeeeek__wetfootsteps");



            soundEffectInstance = walkSound.CreateInstance();
            soundEffectInstance.IsLooped = false;

            soundEffectInstance.Pitch = 0.1f;
            soundEffectInstance.Pan = 0.1f;
            SoundEffect.MasterVolume = 0.3f;



            // Set some properties




            //Rec
            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        public override void Update(GameTime gameTime)
        {
            Animate(gameTime);
            Input(gameTime);
        }

        private void Input(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            playerInput = Vector2.Zero;

            //Timer for time between movement
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

            //Movement
            if (movementClock <= 0 && playerInput != Vector2.Zero)
            {               
                Movement(playerInput);
                movementClock = timeBetweenMovement;
                soundEffectInstance.Stop();
                soundEffectInstance.Play();
            }

            //Undo movement
            PressedKey pressedKey = new PressedKey();
            if (PressedKey.HasBeenPressed(Keys.Z))
            {
                Undo.Instance.PutOnStack();
                Undo.Instance.MoveBack();
            }
        }

        private void Movement(Vector2 direction)
        {
            //Look
            GameObjectWithCollider targetObject = LookAround.LookAt(GridPlacement.Placement(gridPosition + playerInput));

            if (targetObject == null)
                MoveInDirection(direction);
            else if (targetObject is Box)
            {
                Box targetBox = (Box)targetObject;
                bool result = targetBox.BoxMovement(direction);

                if (result)
                    MoveInDirection(direction);
            }
        }

        protected override void MoveInDirection(Vector2 direction)
        {

            base.MoveInDirection(direction);
            Undo.Instance.PutOnStack();
        }

        public override void OnCollision(GameObject other)
        {
            base.OnCollision(other);
        }
    }
}
