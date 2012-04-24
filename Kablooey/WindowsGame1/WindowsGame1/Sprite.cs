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
    class Sprite
    {
        public Texture2D SpriteTexture;
        public Vector2 SpritePosition = Vector2.Zero;
        public Rectangle SpriteSize;
        public string TheDrawnAssetName = null;
        public int ViewportNumber;

        public bool IsAlive = true;

        public void InitializeSprite(string theAssetName, float SpritePositionX, float SpritePositionY)
        {
            this.TheDrawnAssetName = theAssetName;
            this.SpritePosition.X = SpritePositionX;
            this.SpritePosition.Y = SpritePositionY;
        }

        public void InitializeSprite(string theAssetName, Vector2 SpritePosition)
        {
            this.TheDrawnAssetName = theAssetName;
            this.SpritePosition = SpritePosition;
        }

        public void LoadContent()
        {
            SpriteTexture = Globals.staticContentManager.Load<Texture2D>(this.TheDrawnAssetName);
            SpriteSize.Width = SpriteTexture.Width;
            SpriteSize.Height = SpriteTexture.Height;
        }

        public void DrawSprite()
        {
            if (IsAlive)
            {
                Globals.SpriteBatch.Draw(this.SpriteTexture, this.SpritePosition, Color.White);
            }
        }
    }
}
