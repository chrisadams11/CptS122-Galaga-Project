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
    class PlayerShip: Ship
    {
        int FiringCooldown;
        int HealingCooldown;

        public void InitializePlayerShip(int PlayerNumber)
        {
            this.Health = Constants.PlayerStats.PlayerHealth;
            this.Damage = Constants.PlayerStats.PlayerDamage;
            this.Speed = Constants.PlayerStats.PlayerSpeed;
            this.ProjectileSpeed = Constants.PlayerStats.PlayerProjectileSpeed;
            this.FiringCooldown = 0;
            this.HealingCooldown = 2;

            if (PlayerNumber == 1)
            {
                this.InitializeSprite("Player Ship", Globals.ViewPortWidth * .2f, (int)(Globals.ViewPortHeight * .85f));
                this.ViewportNumber = 1;
            }

            else if (PlayerNumber == 2)
            {
                this.InitializeSprite("Player Ship", Globals.ViewPortWidth * .8f, (int)(Globals.ViewPortHeight * .85f));
                this.ViewportNumber = 2;
            }
        }

        public void UpdatePlayerShip(KeyboardState KeyboardState, KeyboardState OldKeyboardState, GameTime gameTime)
        {
            this.UpdateShip(gameTime);

            if (this.IsAlive)
            {
                if (this.HealingCooldown > 0)
                    this.HealingCooldown--;

                if (this.HealingCooldown == 0 &&
                    this.Health < Constants.PlayerStats.PlayerHealth)
                {
                    this.Health++;
                    this.HealingCooldown = 2;
                }

                if (this.ViewportNumber == 1)
                {
                    if (KeyboardState.IsKeyDown(Keys.W))
                    {
                        this.Direction.Y = -1;
                    }

                    else if (KeyboardState.IsKeyDown(Keys.S))
                    {
                        this.Direction.Y = 1;
                    }

                    else
                    {
                        this.Direction.Y = 0;
                    }

                    if (KeyboardState.IsKeyDown(Keys.D))
                    {
                        this.Direction.X = 1;
                    }

                    else if (KeyboardState.IsKeyDown(Keys.A))
                    {
                        this.Direction.X = -1;
                    }

                    else
                    {
                        this.Direction.X = 0;
                    }

                    if (this.FiringCooldown == 0 &&
                        KeyboardState.IsKeyDown(Keys.Space))
                    {
                        Vector2 BulletPosition = this.SpritePosition;
                        BulletPosition.X += (this.SpriteSize.Width / 2);
                        Functions.Create_Projectile(BulletPosition, -Vector2.UnitY, this.ProjectileSpeed, this.Damage, "Player Shot", false);
                        Sounds.PlayerShootSound.Play(.5f, 0f, 0f); ;
                        this.FiringCooldown = 11;
                    }

                    else if (this.FiringCooldown != 0)
                    {
                        this.FiringCooldown--;
                    }

                    if (this.SpritePosition.X + this.SpriteSize.Width >= Globals.ViewPort1.Width)
                    {
                        this.SpritePosition.X = Globals.ViewPort1.Width - this.SpriteSize.Width;
                    }

                    else if (this.SpritePosition.X <= 0)
                    {
                        this.SpritePosition.X = 0;
                    }

                    if (this.SpritePosition.Y + this.SpriteSize.Height >= Globals.ViewPort1.Height)
                    {
                        this.SpritePosition.Y = Globals.ViewPort1.Height - this.SpriteSize.Height;
                    }

                    else if (this.SpritePosition.Y <= Globals.ViewPortHeight * .65f)
                    {
                        this.SpritePosition.Y = Globals.ViewPortHeight * .65f;
                    }
                }

                else if (this.ViewportNumber == 2)
                {
                    if (KeyboardState.IsKeyDown(Keys.Up))
                    {
                        this.Direction.Y = -1;
                    }

                    else if (KeyboardState.IsKeyDown(Keys.Down))
                    {
                        this.Direction.Y = 1;
                    }

                    else
                    {
                        this.Direction.Y = 0;
                    }

                    if (KeyboardState.IsKeyDown(Keys.Right))
                    {
                        this.Direction.X = 1;
                    }

                    else if (KeyboardState.IsKeyDown(Keys.Left))
                    {
                        this.Direction.X = -1;
                    }

                    else
                    {
                        this.Direction.X = 0;
                    }



                    if (this.FiringCooldown == 0 &&
                        KeyboardState.IsKeyDown(Keys.Enter))
                    {
                        Vector2 BulletPosition = this.SpritePosition;
                        BulletPosition.X += (this.SpriteSize.Width / 2);
                        Functions.Create_Projectile(BulletPosition, -Vector2.UnitY, this.ProjectileSpeed, this.Damage, "Player Shot", false);
                        Sounds.PlayerShootSound.Play(.5f, 0f, 0f); ;
                        this.FiringCooldown = 11;
                    }

                    else if (this.FiringCooldown != 0)
                    {
                        this.FiringCooldown--;
                    }



                    if (this.SpritePosition.X + this.SpriteSize.Width >= Globals.ViewPortWidth)
                    {
                        this.SpritePosition.X = Globals.ViewPortWidth - this.SpriteSize.Width;
                    }

                    else if (this.SpritePosition.X <= Globals.ViewPort2.X)
                    {
                        this.SpritePosition.X = Globals.ViewPort2.X;
                    }

                    if (this.SpritePosition.Y + this.SpriteSize.Height >= Globals.ViewPort2.Height)
                    {
                        this.SpritePosition.Y = Globals.ViewPort2.Height - this.SpriteSize.Height;
                    }

                    else if (this.SpritePosition.Y <= Globals.ViewPortHeight * .65f)
                    {
                        this.SpritePosition.Y = Globals.ViewPortHeight * .65f;
                    }
                }
            }
        }
    }
}
