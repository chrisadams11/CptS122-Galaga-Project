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
    class StatusBar: Sprite
    {
        string[] AssetNames;
        int Assets;
        int Status;
        int MaxStatus;

        public void InitializeStatusBar(string[] theAssetNames, int Assets, Vector2 SpritePosition, int MaxStatus)
        {
            this.TheDrawnAssetName = theAssetNames[0];

            AssetNames = theAssetNames;
            this.Assets = Assets;

            this.SpritePosition.X = SpritePosition.X;
            this.SpritePosition.Y = SpritePosition.Y;

            this.MaxStatus = MaxStatus;
            this.Status = this.MaxStatus;
        }

        public void UpdateStatusBar(int Status)
        {
            if (!(Status > this.MaxStatus))
            {
                string NewAssetName = AssetNames[(int)((float)Status / (float)MaxStatus * (Assets - 1) )];

                if (NewAssetName != this.TheDrawnAssetName)
                {
                    this.TheDrawnAssetName = NewAssetName;
                    this.LoadContent();
                }
            }
        }

    }
}
