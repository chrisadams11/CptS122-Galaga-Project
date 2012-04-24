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
    class Ship : Sprite
    {
        public int Health;
        public int Damage;
        public int Speed;
        public int ProjectileSpeed;
        public Vector2 Direction;


        public void UpdateShip(GameTime gameTime)
        {
            if (this.IsAlive)
            {
                if (this.Health <= 0)
                {
                    Sounds.ShipExplosion.Play(.25f, 0f, 0f);
                    this.IsAlive = false;
                }

                else
                {
                    this.SpritePosition += this.Speed * this.Direction * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
        }
    }
}
