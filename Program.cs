using Raylib_cs;
using System.Numerics;

static class Program
    {
        public static void Main()
        {
            
            var ScreenHeight = 480;
            var ScreenWidth = 800;
            var Random = new Random();
            var IsGameOver = false;
            var finalScore = 0;
            var scorey = 40;
            var instructionsy = 24;

            /// settings for the gunner
            var GunnerSize = 30;
            var GunnerHeight = 10;
            var Gunner = new Rectangle(ScreenWidth / 2, ScreenHeight - (GunnerSize * 2), GunnerSize, GunnerHeight);
            var MovementSpeed = 8;
            var Gunnerpt2 =  new Rectangle((ScreenWidth / 2) + 10, ScreenHeight - (GunnerSize * 2) - 10, 10, GunnerHeight);

            /// stettings for the bullet
            var BulletWidth = 5;
            var BulletLength = 10;
            var Bullet = new Rectangle(Gunner.x + 12, Gunner.y - 15, BulletWidth, BulletLength);

            /// settings for the reset barriers
            var FireRate = 8;
            var Firewall = new Rectangle(0, 3 , ScreenWidth, 2);
            var Score = 0;
            var LimitLine = new Rectangle(0, ScreenHeight - 100, ScreenWidth, 2);

            /// settings for the asteroids
            Texture2D texture;
            var image = Raylib.LoadImage("link.png");
            texture = Raylib.LoadTextureFromImage(image);
            Raylib.UnloadImage(image);
            var Evilx = 400;
            var Evily = 0;
            var Evil = new Rectangle(Evilx, Evily, 30, 30);
            var EvilFallSpeed = 1;
            
                


            Raylib.InitWindow(ScreenWidth, ScreenHeight, "GameObject");
            Raylib.SetTargetFPS(60);
            while (!Raylib.WindowShouldClose()){

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);



                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
                    Gunner.x += MovementSpeed;
                    Gunnerpt2.x += MovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
                    Gunner.x -= MovementSpeed;
                    Gunnerpt2.x -= MovementSpeed;
                }

                Raylib.DrawRectangleRec(Gunner, Color.GREEN);
                Raylib.DrawRectangleRec(Gunnerpt2, Color.GREEN);
                Raylib.DrawRectangleRec(Bullet, Color.WHITE);
                Raylib.DrawRectangleRec(Firewall, Color.BLACK);
                Raylib.DrawRectangleRec(LimitLine, Color.ORANGE);
                Raylib.DrawRectangleRec(Evil, Color.BROWN);
                Raylib.DrawTexture(texture, 400, 200, Color.WHITE);


                

                Evil.y += EvilFallSpeed;
                Bullet.y -= FireRate;

                if (Raylib.CheckCollisionRecs(Bullet, Evil)){
                    Evil.x = Raylib.GetRandomValue(10, ScreenWidth - 10);
                    Evil.y = 0;
                    Score += 1;
                    EvilFallSpeed = Raylib.GetRandomValue(1,3);
                }

                if (Raylib.CheckCollisionRecs(Evil, LimitLine)){
                    IsGameOver = true;
                
                }

                if (Raylib.CheckCollisionRecs(Bullet, Firewall)){
                    Bullet.y = Gunner.y;
                    Bullet.x = Gunner.x + 12;

                }
                if (IsGameOver == true){
                    Raylib.DrawText("GAME OVER!", 12, 24, 20, Color.WHITE);
                    instructionsy = -20;
                    scorey = -20;
                    finalScore = Score;
                    Raylib.DrawText($" Final Score: {finalScore}", 12, 40, 20, Color.WHITE);
                    Raylib.EndDrawing();
                }


                if (IsGameOver == false){
                Raylib.DrawText("Shoot the asteroids! Don't let them pass the line", 12, instructionsy, 20, Color.WHITE);
                Raylib.DrawText($"Score: {Score}", 12, scorey, 20, Color.WHITE);

                Raylib.EndDrawing();
                }




            }

            Raylib.CloseWindow();
        }
        }            