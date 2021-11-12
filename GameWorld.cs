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
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            collisionTexture = Content.Load<Texture2D>("CollisionTexture");

            //Setup sceen
            gameObject.Add(new Box(2, 2));
            gameObject.Add(new Box(4, 4));
            gameObject.Add(new Player(3, 3));
            gameObject.Add(new Goal(6, 6));

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
            spriteBatch.Begin();
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
