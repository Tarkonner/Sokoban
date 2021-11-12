using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    class Goal : GameObjectWithCollider
    {
        private bool boxOnGoal = false;
        public bool BoxOnGoal { get => boxOnGoal; set => boxOnGoal = value; }

        public Goal(float xPosition, float yPosition, bool isTriggerCollider = false) : base(xPosition, yPosition, isTriggerCollider)
        {
        }




        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("environment_03");

            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Box)
                boxOnGoal = true;
        }
    }
}
