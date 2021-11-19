//using Microsoft.Xna.Framework;
//using MonoGame.UI.Forms;
//using System;

//namespace Sokoban.UI
//{
//    class Ui : ControlManager
//    {
//        LevelManeger level = new LevelManeger();




//        public Ui(Game game) : base(game)
//        {

//        }
//        public override void InitializeComponent()
//        {

//            var btn1 = new Button()
//            {
//                Text = "Start",
//                Size = new Vector2(200, 43),
//                BackgroundColor = Color.White,
//                Location = new Vector2(270, 100),
//                TextColor = Color.Black,
//            };

//            btn1.Clicked += Btn1_Clicked;

//            Controls.Add(btn1);

//            var level1 = new Button()
//            {
//                Text = "Level 1",
//                Size = new Vector2(200, 43),
//                BackgroundColor = Color.White,
//                Location = new Vector2(270, 155),
//                TextColor = Color.Black,
//            };

//            var level2 = new Button()
//            {
//                Text = "Level 2",
//                Size = new Vector2(200, 43),
//                BackgroundColor = Color.White,
//                Location = new Vector2(270, 210),
//                TextColor = Color.Black,
//            };

//            var level3 = new Button()
//            {
//                Text = "Level 3",
//                Size = new Vector2(200, 43),
//                BackgroundColor = Color.White,
//                Location = new Vector2(270, 265),
//                TextColor = Color.Black,
//            };

//            var level4 = new Button()
//            {
//                Text = "Level 4",
//                Size = new Vector2(200, 43),
//                BackgroundColor = Color.White,
//                Location = new Vector2(270, 320),
//                TextColor = Color.Black,
//            };

//            var level5 = new Button()
//            {
//                Text = "Level 5",
//                Size = new Vector2(200, 43),
//                BackgroundColor = Color.White,
//                Location = new Vector2(270, 375),
//                TextColor = Color.Black,
//            };



//            Controls.Add(level1);
//            Controls.Add(level2);
//            Controls.Add(level3);
//            Controls.Add(level4);
//            Controls.Add(level5);

//        }



//        private void Btn1_Clicked(object sender, EventArgs e)
//        {

//            Button btn = sender as Button;

            
//            Controls.Clear();

//            var btn2 = new Button()
//            {
//                Text = "Restart",
//                Size = new Vector2(90, 35),
//                BackgroundColor = Color.White,
//                Location = new Vector2(20, 15),
//                TextColor = Color.Black,

//            };


//            btn2.Clicked += Btn2_Clicked;
//            Controls.Add(btn2);

//            level.LoadLevel(0);
//        }



//        private void Btn2_Clicked(object sender, EventArgs e)
//        {
//            level.LoadLevel(0);
//        }
//    }
//}
