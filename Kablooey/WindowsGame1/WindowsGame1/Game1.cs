using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace WindowsGame1
{
    static class Globals    // A collection of global variables, most of which pertain to the game's grid system.
    {
        public static ContentManager staticContentManager;
        public static SpriteBatch SpriteBatch;
        public static int ViewPortWidth;
        public static int ViewPortHeight;
        public static Viewport ViewPort1;
        public static Viewport ViewPort2;
        public static List<Projectile> ProjectileList = new List<Projectile>();
        public static List<Ship> EnemyShipList1 = new List<Ship>();
        public static List<Ship> EnemyShipList2 = new List<Ship>();
        public static PlayerShip player1;
        public static PlayerShip player2;
        public static Random RNG;

    }

    static class Sounds
    {
        public static SoundEffect PlayerHitSound;
        public static SoundEffect PlayerShootSound;
        public static SoundEffect EnemyHitSound;
        public static SoundEffect ShipExplosion;
    }

    static class Constants
    {
        public static class PlayerStats
        {
            public static int PlayerHealth = 500;
            public static int PlayerSpeed = 200;
            public static int PlayerDamage = 10;
            public static int PlayerProjectileSpeed = 550;
        }

        public static class EnemyStats
        {
            public static class Tank
            {
                public static int TankHealth = 40;
                public static int TankSpeed = 80;
                public static int TankDamage = 10;
                public static int TankProjectileSpeed = 200;
            }

            public static class Sniper
            {
                public static int SniperHealth = 10;
                public static int SniperSpeed = 80;
                public static int SniperDamage = 30;
                public static int SniperProjectileSpeed = 400;
            }

            public static class Scout
            {
                public static int ScoutHealth = 30;
                public static int ScoutSpeed = 80;
                public static int ScoutChargingSpeed = 260;
                public static int ScoutDamage = 40;
            }

            public static class Soldier
            {
                public static int SoldierHealth = 30;
                public static int SoldierSpeed = 100;
                public static int SoldierProjectileSpeed = 300;
                public static int SoldierDamage = 10;
            }
        }
    }

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager Graphics;

        KeyboardState KeyboardState;
        KeyboardState OldKeyboardState;
        Director theDirector;
        Song CataclysmicComets;
        SpriteFont VictoryFont;

        Sprite HUDLower1;
        Sprite HUDLower2;
        Sprite HUDSide1;
        StatusBar HealthBar1;
        StatusBar HealthBar2;

        Texture2D Background;

        int VictoryCondition;
        int Timer = 1;

        public Game1()
        {
            Globals.staticContentManager = new ContentManager(Services);
            Graphics = new GraphicsDeviceManager(this);
            Globals.staticContentManager.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary> 

        protected override void Initialize()
        {

            CataclysmicComets = Globals.staticContentManager.Load<Song>("CataclysmicComets");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(CataclysmicComets);

            VictoryFont = Globals.staticContentManager.Load<SpriteFont>("VictoryFont");
            VictoryCondition = 0;

            Sounds.PlayerHitSound = Globals.staticContentManager.Load<SoundEffect>("Quick Bass 001");
            Sounds.PlayerShootSound = Globals.staticContentManager.Load<SoundEffect>("Zap FX 007");
            Sounds.EnemyHitSound = Globals.staticContentManager.Load<SoundEffect>("Blip 007");
            Sounds.ShipExplosion = Globals.staticContentManager.Load<SoundEffect>("Kick 005");
            Globals.RNG = new Random(DateTime.Now.Millisecond);
            Globals.player1 = new PlayerShip();
            Globals.player2 = new PlayerShip();

            theDirector = new Director();

            this.IsMouseVisible = true;
            Globals.ViewPortHeight = (int)((Graphics.GraphicsDevice.Viewport.Height));
            Globals.ViewPortWidth = (int)((Graphics.GraphicsDevice.Viewport.Width));

            HUDLower1 = new Sprite();
            HUDLower1.InitializeSprite("HUD Lower", Vector2.Zero);
            HUDLower2 = new Sprite();
            HUDLower2.InitializeSprite("HUD Lower", Vector2.Zero);

            HUDSide1 = new Sprite();
            HUDSide1.InitializeSprite("HUD Side", Vector2.Zero);

            HealthBar1 = new StatusBar();
            HealthBar1.InitializeStatusBar(new string[7] { "Health Bar 0", "Health Bar 1", "Health Bar 2", "Health Bar 3", "Health Bar 4", "Health Bar 5", "Health Bar 6" }, 7, Vector2.Zero, Constants.PlayerStats.PlayerHealth);

            HealthBar2 = new StatusBar();
            HealthBar2.InitializeStatusBar(new string[7] { "Health Bar 0", "Health Bar 1", "Health Bar 2", "Health Bar 3", "Health Bar 4", "Health Bar 5", "Health Bar 6" }, 7, Vector2.Zero, Constants.PlayerStats.PlayerHealth);

            theDirector.InitializeDirector();

            Globals.player1.InitializePlayerShip(1);
            Globals.player2.InitializePlayerShip(2);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.player1.LoadContent();
            Globals.player2.LoadContent();

            HUDLower1.LoadContent();
            HUDLower2.LoadContent();
            HUDSide1.LoadContent();
            HealthBar1.LoadContent();
            HealthBar2.LoadContent();

            Background = Globals.staticContentManager.Load<Texture2D>("Background");

            Globals.ViewPort1.Height = Globals.ViewPortHeight - HUDLower1.SpriteSize.Height;
            Globals.ViewPort1.Width = (Globals.ViewPortWidth - HUDSide1.SpriteSize.Width) / 2;

            Globals.ViewPort2.X = (Globals.ViewPortWidth + HUDSide1.SpriteSize.Width) / 2;
            Globals.ViewPort2.Width = Globals.ViewPortWidth - Globals.ViewPort2.X;
            Globals.ViewPort2.Height = Globals.ViewPort1.Height;

            HUDLower1.SpritePosition = new Vector2(0, Globals.ViewPortHeight - HUDLower1.SpriteSize.Height);
            HUDLower2.SpritePosition = new Vector2(Globals.ViewPort2.X, Globals.ViewPortHeight - HUDLower1.SpriteSize.Height);
            HUDSide1.SpritePosition = new Vector2(Globals.ViewPort2.X - HUDSide1.SpriteSize.Width, 0);
            HealthBar1.SpritePosition = HUDSide1.SpritePosition;
            HealthBar2.SpritePosition.X = HealthBar1.SpritePosition.X;
            HealthBar2.SpritePosition.Y = HealthBar1.SpritePosition.Y + HealthBar1.SpriteSize.Height;
            
            
            foreach (EnemyShip Enemy in Globals.EnemyShipList1)
            {
                Enemy.LoadContent();
            }

            foreach (EnemyShip Enemy in Globals.EnemyShipList2)
            {
                Enemy.LoadContent();
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState = Keyboard.GetState();

            if (Globals.player1.IsAlive && Globals.player2.IsAlive)
            {
                theDirector.UpdateDirector(Timer);

                Globals.player1.UpdatePlayerShip(KeyboardState, OldKeyboardState, gameTime);
                Globals.player2.UpdatePlayerShip(KeyboardState, OldKeyboardState, gameTime);

                foreach (Projectile Bullet in Globals.ProjectileList)
                {
                    Bullet.UpdateProjectile(gameTime);
                }

                foreach (EnemyShip Enemy in Globals.EnemyShipList1)
                {
                    Enemy.UpdateEnemyShip(gameTime);
                }

                foreach (EnemyShip Enemy in Globals.EnemyShipList2)
                {
                    Enemy.UpdateEnemyShip(gameTime);
                }

                HealthBar1.UpdateStatusBar(Globals.player1.Health);
                HealthBar2.UpdateStatusBar(Globals.player2.Health);
                OldKeyboardState = KeyboardState;
                Timer++;
                base.Update(gameTime);
            }

            else
            {
                if (Globals.player1.IsAlive)
                {
                    VictoryCondition = 1;
                }

                else if (Globals.player2.IsAlive)
                {
                    VictoryCondition = 2;
                }

                if (KeyboardState.IsKeyDown(Keys.F5))
                {
                    foreach (Projectile Bullet in Globals.ProjectileList)
                    {
                        Bullet.IsAlive = false;
                    }

                    foreach (EnemyShip Enemy in Globals.EnemyShipList1)
                    {
                        Enemy.IsAlive = false;
                    }

                    foreach (EnemyShip Enemy in Globals.EnemyShipList2)
                    {
                        Enemy.IsAlive = false;
                    }

                    Globals.player1.IsAlive = false;
                    Globals.player2.IsAlive = false;
                    

                    Initialize();
                    LoadContent();
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Globals.SpriteBatch.Begin(SpriteBlendMode.AlphaBlend);

            Globals.SpriteBatch.Draw(Background, Vector2.Zero, Color.White);

            Globals.player1.DrawSprite();
            Globals.player2.DrawSprite();

            foreach (Projectile Bullet in Globals.ProjectileList)
            {
                Bullet.DrawSprite();
            }

            foreach (EnemyShip Enemy in Globals.EnemyShipList1)
            {
                Enemy.DrawSprite();
            }

            foreach (EnemyShip Enemy in Globals.EnemyShipList2)
            {
                Enemy.DrawSprite();
            }

            HUDLower1.DrawSprite();
            HUDLower2.DrawSprite();
            HUDSide1.DrawSprite();
            HealthBar1.DrawSprite();
            HealthBar2.DrawSprite();

            if (VictoryCondition != 0)
            {
                if (VictoryCondition == 1)
                    Globals.SpriteBatch.DrawString(VictoryFont, "Player 1 Victory! \r\nF5 To Restart", new Vector2(Globals.ViewPortWidth / 10f, Globals.ViewPortHeight / 3f), Color.Green);
            
                else if (VictoryCondition == 2)
                    Globals.SpriteBatch.DrawString(VictoryFont, "Player 2 Victory! \r\nF5 To Restart", new Vector2(Globals.ViewPortWidth / 10f, Globals.ViewPortHeight / 3f), Color.Green);
            }

            Globals.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
