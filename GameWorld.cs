﻿using Microsoft.Xna.Framework;
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
        List<GameObjectWithCollider> collisionList = new List<GameObjectWithCollider>();

        //Debug
        Texture2D collisionTexture;

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

            collisionTexture = Content.Load<Texture2D>("CollisionTexture");
            objectManeger.SetContentManeger(Content);

            //Load levels
            levels = new LevelData();
            //Uplow first level
            LoadLevel(0);
            objectManeger.UpdateLoop();

            //Load item
            foreach (GameObject item in objectManeger.GameObjects)
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


            float de = (float)gameTime.ElapsedGameTime.TotalSeconds;
            testClock -= de;
            if (testClock < 0 && !loadTestlevel)
            {
                loadTestlevel = true;

                LoadLevel(1);
                objectManeger.UpdateLoop();

                //Load item
                foreach (GameObject item in objectManeger.GameObjects)
                {
                    //Get GameObjects with collision
                    if (item is GameObjectWithCollider)
                        collisionList.Add((GameObjectWithCollider)item);
                }

                //Upload collision list to LookAround

                LookAround.objects = collisionList;
            }

            //Update all gameobjects
            foreach (GameObject item in objectManeger.GameObjects)
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

            objectManeger.UpdateLoop();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            foreach (var item in objectManeger.GameObjects)
            {
                item.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }


        public void LoadLevel(int targetLevel)
        {
            //Remove old level
            if (objectManeger.GameObjects.Count > 0)
            {
                foreach (var item in objectManeger.GameObjects)
                {
                    objectManeger.Remove(item);
                }
            }

            collisionList.Clear();

            //Inscert level
            for (int y = 0; y < levels.levelHolder[targetLevel].GetLength(1); y++)
            {
                for (int x = 0; x < levels.levelHolder[targetLevel].GetLength(0); x++)
                {
                    //Add floor if needed
                    if (levels.levelHolder[targetLevel][x, y] > 1)
                        objectManeger.AddToWorld(levels.Object(0, x, y));

                    //Spawn object
                    objectManeger.AddToWorld(levels.Object(levels.levelHolder[targetLevel][x, y], x, y));
                }
            }
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
