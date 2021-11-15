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
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;


        List<GameObject> gameObject = new List<GameObject>();
        List<GameObjectWithCollider> collisionList = new List<GameObjectWithCollider>();

        //Debug
        Texture2D collisionTexture;


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

            collisionTexture = Content.Load<Texture2D>("CollisionTexture");

            LevelData levelData = new LevelData();

            for (int y = 0; y < levelData.Level_0.GetLength(1); y++)
            {
                for (int x = 0; x < levelData.Level_0.GetLength(0); x++)
                {
                    //Add floor if needed
                    if (levelData.Level_0[x, y] == 2 
                        || levelData.Level_0[x, y] == 3 
                        || levelData.Level_0[x, y] == 4)
                        gameObject.Add(levelData.Object(0, x, y));

                    //Spawn object
                    gameObject.Add(levelData.Object(levelData.Level_0[x, y], x, y));
                }
            }

            //Load item
            foreach (GameObject item in gameObject)
            {
                item.LoadContent(Content);

                //Get GameObjects with collision
                if (item is GameObjectWithCollider)
                    collisionList.Add((GameObjectWithCollider)item);
            }

            //Upload collision list to LookAround
            LookAround.objects = collisionList;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Update all gameobjects
            foreach (GameObject item in gameObject)
            {
                item.Update(gameTime);
            }

            //Collision
            foreach (GameObjectWithCollider item in collisionList)
            {
                foreach (GameObjectWithCollider other in collisionList)
                {
                    if (item != other)
                        item.CheckCollision(other);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            foreach (var item in gameObject)
            {
                item.Draw(spriteBatch);

                if (item is GameObjectWithCollider)
                    DrawCollisionBox((GameObjectWithCollider)item);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawCollisionBox(GameObjectWithCollider go)
        {

            Rectangle collisionBox = go.GetCollisionBox();
            Rectangle topline = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

            spriteBatch.Draw(collisionTexture, topline, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }
    }
}
