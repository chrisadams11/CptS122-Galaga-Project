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
    class SoldierShip : EnemyShip
    {
        float PatrolLine;
        public bool IsEntering;

        public void InitializeSoldierShip(int ScreenNumber)
        {
            this.InitializeEnemyShip(ScreenNumber,
                                     Constants.EnemyStats.Soldier.SoldierHealth,
                                     Constants.EnemyStats.Soldier.SoldierDamage,
                                     Constants.EnemyStats.Soldier.SoldierSpeed,
                                     Constants.EnemyStats.Soldier.SoldierProjectileSpeed,
                                     "Enemy Soldier");
            this.IsEntering = true;
            this.PatrolLine = (Globals.ViewPortHeight * .1f + (Globals.ViewPortHeight * (.045f * (float)Globals.RNG.Next(1, 10))));
        }
        public override void UpdateEnemyShip(GameTime gameTime)
        {
            this.UpdateShip(gameTime);

            if (this.IsAlive)
            {
                if (this.IsEntering)
                {
                    this.Direction = Vector2.UnitY;

                    if (this.SpritePosition.Y >= this.PatrolLine)
                    {
                        this.IsEntering = false;
                        this.Direction = Vector2.UnitX;
                    }
                }

                else
                {
                    if (Globals.RNG.Next(1, 80) == 1)
                    {
                        Vector2 BulletPosition = this.SpritePosition;
                        BulletPosition.X += (this.SpriteSize.Width / 2);
                        BulletPosition.Y += this.SpriteSize.Height;
                        Functions.Create_Projectile(BulletPosition, Vector2.UnitY, Constants.EnemyStats.Soldier.SoldierProjectileSpeed, this.Damage, "CannonballSprite", true);
                    }

                    if (this.ViewportNumber == 1)
                    {
                        if (this.SpritePosition.X + this.SpriteSize.Width >= Globals.ViewPort1.Width)
                        {
                            this.Direction = -Vector2.UnitX;
                        }

                        else if (this.SpritePosition.X <= 0)
                        {
                            this.Direction = Vector2.UnitX;
                        }
                    }

                    else if (this.ViewportNumber == 2)
                    {
                        if (this.SpritePosition.X + this.SpriteSize.Width >= Globals.ViewPortWidth)
                        {
                            this.Direction = -Vector2.UnitX;
                        }

                        else if (this.SpritePosition.X <= Globals.ViewPort2.X)
                        {
                            this.Direction = Vector2.UnitX;
                        }
                    }

                }
            }

        }
    }
}
