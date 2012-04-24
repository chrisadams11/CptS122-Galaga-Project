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
    class Projectile : Sprite
    {
        int Damage;
        Vector2 Direction;
        int Speed;
        bool IsEnemyProjectile;

        public void InitializeProjectile(int Damage, Vector2 Direction, int Speed, string AssetName, Vector2 Position, bool IsEnemyProjectile)
        {
            this.TheDrawnAssetName = AssetName;
            this.SpritePosition = Position;
            this.Damage = Damage;
            this.Direction = Direction;
            this.Speed = Speed;
            this.IsAlive = true;
            this.IsEnemyProjectile = IsEnemyProjectile;

            if (Position.X < Globals.ViewPortWidth / 2)
            {
                this.ViewportNumber = 1;
            }

            else
            {
                this.ViewportNumber = 2;
            }
        }

        public void UpdateProjectile(GameTime gameTime)
        {
            if (this.IsAlive)
            {
                if (this.ViewportNumber == 1)
                {
                    if (IsEnemyProjectile)
                    {
                        if (Globals.player1.IsAlive &&
                            this.SpritePosition.Y + this.SpriteSize.Height >= Globals.player1.SpritePosition.Y && (

                             (this.SpritePosition.X >= Globals.player1.SpritePosition.X &&
                              this.SpritePosition.X <= Globals.player1.SpritePosition.X + Globals.player1.SpriteSize.Width) ||
                             (this.SpritePosition.X + this.SpriteSize.Width >= Globals.player1.SpritePosition.X &&
                              this.SpritePosition.X + this.SpriteSize.Width <= Globals.player1.SpritePosition.X + Globals.player1.SpriteSize.Width)))
                        {
                            Sounds.PlayerHitSound.Play(.25f, 0f, 0f); ;
                            this.IsAlive = false;
                            this.Speed = 0;
                            Globals.player1.Health -= this.Damage;
                        }
                    }

                    else
                    {
                        foreach (Ship Ship in Globals.EnemyShipList1)
                        {
                            if (Ship.IsAlive &&
                                this.SpritePosition.Y + this.SpriteSize.Height <= Ship.SpritePosition.Y + Ship.SpriteSize.Height && (

                                 (this.SpritePosition.X >= Ship.SpritePosition.X &&
                                  this.SpritePosition.X <= Ship.SpritePosition.X + Ship.SpriteSize.Width) ||
                                 (this.SpritePosition.X + this.SpriteSize.Width >= Ship.SpritePosition.X &&
                                  this.SpritePosition.X + this.SpriteSize.Width <= Ship.SpritePosition.X + Ship.SpriteSize.Width)))
                            {
                                Sounds.EnemyHitSound.Play(.1f, 0f, 0f); ;
                                this.IsAlive = false;
                                this.Speed = 0;
                                Ship.Health -= this.Damage;
                            }
                        }
                    }
                }

                if (this.ViewportNumber == 2)
                {
                    if (IsEnemyProjectile)
                    {
                        if (Globals.player2.IsAlive &&
                            this.SpritePosition.Y + this.SpriteSize.Height >= Globals.player2.SpritePosition.Y && (

                             (this.SpritePosition.X >= Globals.player2.SpritePosition.X &&
                              this.SpritePosition.X <= Globals.player2.SpritePosition.X + Globals.player2.SpriteSize.Width) ||
                             (this.SpritePosition.X + this.SpriteSize.Width >= Globals.player2.SpritePosition.X &&
                              this.SpritePosition.X + this.SpriteSize.Width <= Globals.player2.SpritePosition.X + Globals.player2.SpriteSize.Width)))
                        {
                            Sounds.PlayerHitSound.Play(.25f, 0f, 0f); ;
                            this.IsAlive = false;
                            this.Speed = 0;
                            Globals.player2.Health -= this.Damage;
                        }
                    }
                    else
                    {
                        foreach (Ship Ship in Globals.EnemyShipList2)
                        {
                            if (Ship.IsAlive &&
                                this.SpritePosition.Y + this.SpriteSize.Height <= Ship.SpritePosition.Y + Ship.SpriteSize.Height && (

                                 (this.SpritePosition.X >= Ship.SpritePosition.X &&
                                  this.SpritePosition.X <= Ship.SpritePosition.X + Ship.SpriteSize.Width) ||
                                 (this.SpritePosition.X + this.SpriteSize.Width >= Ship.SpritePosition.X &&
                                  this.SpritePosition.X + this.SpriteSize.Width <= Ship.SpritePosition.X + Ship.SpriteSize.Width)))
                            {
                                Sounds.EnemyHitSound.Play(.1f, 0f, 0f); ;
                                this.IsAlive = false;
                                this.Speed = 0;
                                Ship.Health -= this.Damage;
                            }
                        }
                    }
                }
            }

            this.SpritePosition += this.Speed * this.Direction * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (this.SpritePosition.Y >= Globals.ViewPortHeight)
            {
                IsAlive = false;
                Speed = 0;
            }

            else if (SpritePosition.Y < 0)
            {
                IsAlive = false;
                Speed = 0;
            }

        }
    }
}

