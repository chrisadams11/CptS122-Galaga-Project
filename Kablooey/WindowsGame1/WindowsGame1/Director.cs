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
    class Director
    {
        Random RNG;

        SoldierShip Soldier;
        TankShip Tank;
        SniperShip Sniper;
        ScoutShip Scout;

        public void InitializeDirector()
        {
            this.RNG = new Random();

            for (int jjj = 1; jjj < 3; jjj++)
            {
                for (int iii = 0; iii < 5; iii++)
                {
                    this.Soldier = new SoldierShip();
                    this.Soldier.InitializeSoldierShip(jjj);
                    this.Soldier.LoadContent();

                    if (jjj == 1)
                        Globals.EnemyShipList1.Add(this.Soldier);
                    else if (jjj == 2)
                        Globals.EnemyShipList2.Add(this.Soldier);
                }

                for (int iii = 0; iii < 3; iii++)
                {
                    this.Sniper = new SniperShip();
                    this.Sniper.InitializeSniperShip(jjj);
                    this.Sniper.LoadContent();

                    if (jjj == 1)
                        Globals.EnemyShipList1.Add(this.Sniper);
                    else if (jjj == 2)
                        Globals.EnemyShipList2.Add(this.Sniper);
                }

                for (int iii = 0; iii < 3; iii++)
                {
                    this.Tank = new TankShip();
                    this.Tank.InitializeTankShip(jjj);
                    this.Tank.LoadContent();

                    if (jjj == 1)
                        Globals.EnemyShipList1.Add(this.Tank);
                    else if (jjj == 2)
                        Globals.EnemyShipList2.Add(this.Tank);
                }

                for (int iii = 0; iii < 5; iii++)
                {
                    this.Scout = new ScoutShip();
                    this.Scout.InitializeScoutShip(jjj);
                    this.Scout.LoadContent();

                    if (jjj == 1)
                        Globals.EnemyShipList1.Add(this.Scout);
                    else if (jjj == 2)
                        Globals.EnemyShipList2.Add(this.Scout);
                }
            }

        }

        public void UpdateDirector(int Ticks)
        {
            if  (Ticks <= 4000 && (Ticks % 30 == 1) ||
                (Ticks > 4000 && Ticks <= 8000 && (Ticks % 20 == 1)) ||
                (Ticks > 8000 && Ticks <= 12000 && (Ticks % 15 == 1)) ||
                (Ticks > 12000 && Ticks <= 16000 && (Ticks % 10 == 1)) ||
                (Ticks > 16000 && Ticks <= 18000 && (Ticks % 7 == 1)) ||
                (Ticks > 18000 && Ticks <= 22000 && (Ticks % 4 == 1)) ||
                (Ticks > 22000 && (Ticks % 1 == 1)))
            {
                CreateRandomShip();
            }
        }

        void CreateRandomShip()
        {
            for (int iii = 1; iii < 3; iii++)
            {
                int RandomShip = this.RNG.Next(1, 5);

                if (RandomShip == 1)
                {
                    this.Soldier = new SoldierShip();
                    this.Soldier.InitializeSoldierShip(iii);
                    this.Soldier.LoadContent();

                    if (iii == 1)
                        Globals.EnemyShipList1.Add(this.Soldier);
                    else if (iii == 2)
                        Globals.EnemyShipList2.Add(this.Soldier);
                }

                else if (RandomShip == 2)
                {
                    this.Sniper = new SniperShip();
                    this.Sniper.InitializeSniperShip(iii);
                    this.Sniper.LoadContent();

                    if (iii == 1)
                        Globals.EnemyShipList1.Add(this.Sniper);
                    else if (iii == 2)
                        Globals.EnemyShipList2.Add(this.Sniper);
                }

                else if (RandomShip == 3)
                {
                    this.Tank = new TankShip();
                    this.Tank.InitializeTankShip(iii);
                    this.Tank.LoadContent();

                    if (iii == 1)
                        Globals.EnemyShipList1.Add(this.Tank);
                    else if (iii == 2)
                        Globals.EnemyShipList2.Add(this.Tank);
                }

                else if (RandomShip == 4)
                {
                    this.Scout = new ScoutShip();
                    this.Scout.InitializeScoutShip(iii);
                    this.Scout.LoadContent();

                    if (iii == 1)
                        Globals.EnemyShipList1.Add(this.Scout);
                    else if (iii == 2)
                        Globals.EnemyShipList2.Add(this.Scout);
                }
            }
        }

    }
}
