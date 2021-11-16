using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    class GameObjectManeger
    {
        //Singelton
        private static GameObjectManeger instance = null;
        private ContentManager content;

        private GameObjectManeger()
        {
        }

        public static GameObjectManeger Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameObjectManeger();

                return instance;
            }
        }

        //Game object adding & removeing
        List<GameObject> addedGameObjects = new List<GameObject>(); //For gameobjectets der skal komme i gameObjevt listen
        List<GameObject> gameObjects = new List<GameObject>(); //For main loop
        List<GameObject> removingGameObjects = new List<GameObject>(); //For ting der skal fjernes

        #region Properties
        public List<GameObject> AddedGameObjects { get => addedGameObjects; set => addedGameObjects = value; }
        public List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }
        public List<GameObject> RemovingGameObjects { get => removingGameObjects; set => removingGameObjects = value; }
        #endregion


        public void UpdateLoop(GameTime gameTime)
        {
            //Add if new gameobjects is added
            CallAdd();

            //Remove gameobjebts from the list
            CallRemove();
        }

        public void AddToWorld(GameObject target)
        {
            addedGameObjects.Add(target);
        }

        public void Remove(GameObject target)
        {
            removingGameObjects.Add(target);
        }

        public void Clear(List<GameObject> input)
        {
            foreach (var item in input)
            {
                removingGameObjects.Add(item);
            }
        }

        private void CallAdd()
        {
            if (addedGameObjects.Count > 0)
            {
                for (int i = 0; i < addedGameObjects.Count; i++)
                {
                    addedGameObjects[i].LoadContent(content);
                    gameObjects.Add(addedGameObjects[i]);
                }
                addedGameObjects.Clear();
            }
        }

        private void CallRemove()
        {
            if (removingGameObjects.Count > 0)
            {
                for (int i = 0; i < removingGameObjects.Count; i++)
                {
                    gameObjects.Remove(removingGameObjects[i]);
                }
                removingGameObjects.Clear();
            }
        }

        public void SetContentManeger(ContentManager content)
        {
            this.content = content;
        }
    }
}
