using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;



namespace Sokoban
{
    public class GameWorld : Game
    {
        //Tech
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //Level
        private LevelData levels;

        //Gameobjcts
        private GameObjectManeger objectManeger = GameObjectManeger.Instance;

        private float testClock = 5;
        private bool loadTestlevel = false;


        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            // klar til fullscreen
            //IsMouseVisible = false;
#if (!DEBUG)
            graphics.IsFullScreen = true;
#endif  
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
           
            base.Initialize();

#if (!DEBUG)
            graphics.ApplyChanges();
#endif
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            objectManeger.SetContentManeger(Content);

            //Load levels
            levels = new LevelData();
            //Uplow first level
            levels.LoadLevel(0);
            objectManeger.UpdateLoop();

            //Load item
            foreach (GameObject item in objectManeger.GameObjects)
            {
                item.LoadContent(Content);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

#if(DEBUG)
            float de = (float)gameTime.ElapsedGameTime.TotalSeconds;
            testClock -= de;
            if (testClock < 0 && !loadTestlevel)
            {
                loadTestlevel = true;

                levels.LoadLevel(1);
                objectManeger.UpdateLoop();
            }
#endif

            //Update all gameobjects
            foreach (GameObject item in objectManeger.GameObjects)
            {
                item.Update(gameTime);
            }

            //Collision
            foreach (GameObjectWithCollider item in objectManeger.CollisionList)
            {
                foreach (GameObjectWithCollider other in objectManeger.CollisionList)
                {
                    if (item != other)
                        item.CheckCollision(other);
                }
            }
                       
         
            
            base.Update(gameTime);

            objectManeger.UpdateLoop();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            foreach (var item in objectManeger.GameObjects)
            {
                item.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
