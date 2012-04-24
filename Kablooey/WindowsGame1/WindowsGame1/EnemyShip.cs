using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
namespace WindowsGame1
{
    abstract class EnemyShip: Ship
    {
        public abstract void UpdateEnemyShip(GameTime gameTime);

        public void InitializeEnemyShip(int ScreenNumber, int Health, int Damage, int Speed, int ProjectileSpeed, string assetName)
        {
            this.Health = Health;
            this.Damage = Damage;
            this.Speed = Speed;
            this.ProjectileSpeed = ProjectileSpeed;

            if (ScreenNumber == 1)
            {
                this.InitializeSprite(assetName, (Globals.ViewPort1.Width * ((float)Globals.RNG.Next(1,50) / 50)), 0);
                this.ViewportNumber = 1;
            }

            else if (ScreenNumber == 2)
            {
                this.InitializeSprite(assetName, Globals.ViewPort2.X + (Globals.ViewPort2.Width * ((float)Globals.RNG.Next(1, 50) / 50)), 0);
                this.ViewportNumber = 2;
            }
        }
    }
}
