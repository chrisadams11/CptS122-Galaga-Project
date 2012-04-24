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
            public static int PlayerHealth = 1000;
            public static int PlayerSpeed = 200;
            public static int PlayerDamage = 10;
            public static int PlayerProjectileSpeed = 500;
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
                public static int SniperHealth = 20;
                public static int SniperSpeed = 80;
                public static int SniperDamage = 30;
                public static int SniperProjectileSpeed = 400;
            }

            public static class Scout
            {
                public static int ScoutHealth = 20;
                public static int ScoutSpeed = 80;
                public static int ScoutChargingSpeed = 160;
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

            Globals.ViewPort1 = Graphics.GraphicsDevice.Viewport;
            Globals.ViewPort2 = Globals.ViewPort1;
            Globals.ViewPort1.Width = Globals.ViewPort1.Width / 2;
            Globals.ViewPort2.Width = Globals.ViewPort2.Width / 2;
            Globals.ViewPort2.X = Globals.ViewPort1.Width + 1;

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
            if (Globals.player1.IsAlive && Globals.player2.IsAlive)
            {
                KeyboardState = Keyboard.GetState();

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

            if (VictoryCondition != 0)
            {
                if (VictoryCondition == 1)
                    Globals.SpriteBatch.DrawString(VictoryFont, "Player 1 Victory!", new Vector2(Globals.ViewPortWidth / 10f, Globals.ViewPortHeight / 3f), Color.Green);
            
                else if (VictoryCondition == 2)
                    Globals.SpriteBatch.DrawString(VictoryFont, "Player 2 Victory!", new Vector2(Globals.ViewPortWidth / 10f, Globals.ViewPortHeight / 3f), Color.Green);
            }

            Globals.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
