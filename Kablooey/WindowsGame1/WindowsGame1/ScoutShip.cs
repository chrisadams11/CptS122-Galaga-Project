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
    class ScoutShip : EnemyShip
    {
        public bool IsEntering;
        public bool IsCharging;

        public void InitializeScoutShip(int ScreenNumber)
        {
            this.InitializeEnemyShip(ScreenNumber,
                                     Constants.EnemyStats.Scout.ScoutHealth,
                                     Constants.EnemyStats.Scout.ScoutDamage,
                                     Constants.EnemyStats.Scout.ScoutSpeed,
                                     0,
                                     "Enemy Sniper");
            this.IsEntering = true;
        }
        public override void UpdateEnemyShip(GameTime gameTime)
        {
            this.UpdateShip(gameTime);

            if (this.IsAlive)
            {
                if (this.IsEntering)
                {
                    this.Direction = Vector2.UnitY;

                    if (this.SpritePosition.Y >= Globals.ViewPortHeight * .50)
                    {
                        this.IsEntering = false;
                        this.Direction = Vector2.UnitX;
                    }
                }

                else if (!this.IsCharging)
                {
                    if (Globals.RNG.Next(1, 250) == 1)
                    {
                        this.IsCharging = true;
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

                else
                {
                    this.Speed = Constants.EnemyStats.Scout.ScoutChargingSpeed;

                    this.Direction.Y = 1;

                    if (this.ViewportNumber == 1)
                    {
                        if (Globals.player1.SpritePosition.X > this.SpritePosition.X)
                        {
                            this.Direction.X = .4f;
                        }

                        else if (Globals.player1.SpritePosition.X < this.SpritePosition.X)
                        {
                            this.Direction.X = -.4f;
                        }

                        if (Globals.player1.IsAlive &&
                            this.SpritePosition.Y + this.SpriteSize.Height >= Globals.player1.SpritePosition.Y && (

                             (this.SpritePosition.X >= Globals.player1.SpritePosition.X &&
                              this.SpritePosition.X <= Globals.player1.SpritePosition.X + Globals.player1.SpriteSize.Width) ||
                             (this.SpritePosition.X + this.SpriteSize.Width >= Globals.player1.SpritePosition.X &&
                              this.SpritePosition.X + this.SpriteSize.Width <= Globals.player1.SpritePosition.X + Globals.player1.SpriteSize.Width)))
                        {
                            Globals.player1.Health -= this.Damage;
                            this.IsAlive = false;
                            this.Speed = 0;
                        }
                    }

                    else if (this.ViewportNumber == 2)
                    {
                        if (Globals.player2.SpritePosition.X > this.SpritePosition.X)
                        {
                            this.Direction.X = .3f;
                        }

                        else if (Globals.player2.SpritePosition.X < this.SpritePosition.X)
                        {
                            this.Direction.X = -.3f;
                        }

                        if (Globals.player2.IsAlive &&
                            this.SpritePosition.Y + this.SpriteSize.Height >= Globals.player2.SpritePosition.Y && (

                             (this.SpritePosition.X >= Globals.player2.SpritePosition.X && 
                              this.SpritePosition.X <= Globals.player2.SpritePosition.X + Globals.player2.SpriteSize.Width) ||
                             (this.SpritePosition.X + this.SpriteSize.Width >= Globals.player2.SpritePosition.X && 
                              this.SpritePosition.X + this.SpriteSize.Width <= Globals.player2.SpritePosition.X + Globals.player2.SpriteSize.Width)) )
                        {
                            Globals.player2.Health -= this.Damage;
                            this.IsAlive = false;
                            this.IsCharging = false;
                            this.Speed = 0;
                        }
                    }

                    if (this.SpritePosition.Y > Globals.ViewPortHeight)
                    {
                        this.Speed = Constants.EnemyStats.Scout.ScoutSpeed;
                        this.IsCharging = false;
                        this.IsEntering = true;
                        this.SpritePosition.Y = -this.SpriteSize.Height;
                    }
                }
            }

        }
    }
}