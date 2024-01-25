using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testdll;

namespace WindowsFormsAppGame
{
    public class IntelligentCreature : Living
    {


        private int timePointCostPerReload;
        private Items.Weapon activeWeapon = null;

        public Items.Weapon ActiveWeapon
        {
            get { return activeWeapon; }
            set { activeWeapon = value; }
        }

        public int TimePointCostPerReload
        {
            get { return timePointCostPerReload; }
            set { timePointCostPerReload = value; }
        }

        public IntelligentCreature(int X, int Y, string Name, int Health, int MaxHealth, int CurrentTimePoints,
            int MaxTimePoints, int ViewRadius, int Accuracy, int TimePointCostPerReload, Items.Weapon Gun)
            : base(Y, X, Name, Health, MaxHealth, CurrentTimePoints, MaxTimePoints, ViewRadius, Accuracy)
        {
            if (TimePointCostPerReload <= 0)
            {
                throw new ArgumentException("Time points per reload cannot be less than zero.");
            }
            ActiveWeapon = Gun;
            TimePointCostPerStep = 1;
        }

        public void takeWeapon(Items.Weapon weapon)
        {
            if (1 > CurrentTimePoints)
            {
                throw new ArgumentException("Not enough move points");
            }
            if (ActiveWeapon != null)
            {
                throw new ArgumentException("You already have weapon");
            }
            CurrentTimePoints--;
            ActiveWeapon = weapon;

        }

        public void dropItem()
        {
            if (ActiveWeapon == null)
            {
                throw new ArgumentException("You don`t have weapon");
            }
            ActiveWeapon = null;
        }
        public void shoot(Random rnd)
        {
            if (ActiveWeapon == null)
            {
                throw new ArgumentException("There is no weapon equipped");
            }
            if (CurrentTimePoints < ActiveWeapon.FireTimeCost)
            {
                throw new ArgumentException("Not enough move points");
            }
            CurrentTimePoints -= ActiveWeapon.FireTimeCost;
            //Random rnd = new Random();//вынести наверх
            int value = rnd.Next(0, 100);
            if (value < Accuracy)
            {
                try
                {
                    ActiveWeapon.fire();
                    //target.Health -= ActiveWeapon.Damage;
                }
                catch
                {
                    throw new ArgumentException("Gun is out of ammo.");
                }
                //Shooting animation
                //target.Health -= ActiveWeapon.Damage;
            }
            else
            {
                throw new ArgumentException("Miss");
            }
        }

        public void shootEnemy(Living target, Random rnd)// вынести в одну функцию
        {
            try
            {
                shoot(rnd);
                target.Health -= ActiveWeapon.Damage;
            }
            catch
            {
                throw new ArgumentException("Shot wasn`t made.");
            }
        }
    }
}
