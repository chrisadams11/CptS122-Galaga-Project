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
    static class Functions
    {
        public static void Create_Projectile(Vector2 StartPosition, Vector2 Direction, int Speed, int Damage, string AssetName, bool IsEnemyProjectile)
        {
            bool NeedNew = true;

            foreach (Projectile newBullet in Globals.ProjectileList)
            {
                if (!newBullet.IsAlive)
                {
                    newBullet.InitializeProjectile(Damage, Direction, Speed, AssetName, StartPosition, IsEnemyProjectile);
                    NeedNew = false;
                    break;
                }
            }

            if (NeedNew)
            {
                Projectile newBullet = new Projectile();
                newBullet.InitializeProjectile(Damage, Direction, Speed, AssetName, StartPosition, IsEnemyProjectile);
                newBullet.LoadContent();
                Globals.ProjectileList.Add(newBullet);
            }
        }
    }
}
