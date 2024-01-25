using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testdll;
using WindowsFormsAppGame.GameClasses;
//using GameClasses;

namespace WindowsFormsAppGame
{
    public class Character : Living
    {
        //private PictureBox picture;
        private int timePointCostPerReload;
        private int strength;
        private Inventory inventory;
        private Items.Bullet activeBullets = null;
        private bool isMoving { get; set; } = false;

        public Items.Weapon ActiveWeapon { get; set; } = null;

        

        public int TimePointCostPerReload
        {
            get { return timePointCostPerReload; }
            set { timePointCostPerReload = value; }
        }

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public Inventory Inventory { get { return inventory; } set { inventory = value; } }

        public Items.Bullet ActiveBullets
        {
            get { return activeBullets; }
            set { activeBullets = value; }
        }
        public Character(int Y = 0, int X = 0, string Name = "Undefined", int Health = 20, int MaxHealth = 20, int CurrentTimePoints = 10,
            int MaxTimePoints = 10, int ViewRadius = 2, int Accuracy = 100, int TimePointCostPerReload = 1, 
            int Strength = 10000, Inventory Inventory = null, Items.Bullet ActiveBullets = null)
            : base(Y, X, Name, Health, MaxHealth, CurrentTimePoints, MaxTimePoints, ViewRadius, Accuracy)
        {
            if (TimePointCostPerReload <= 0)
            {
                throw new ArgumentException("Time points per reload cannot be less than zero.");
            }
            if (Strength <= 0)
            {
                throw new ArgumentException("Strength cannot be less than zero.");
            }
            strength = Strength;

            inventory = Inventory;
            activeBullets = ActiveBullets;
        }

        public void heal(Items.AidKit aidKit)
        {
            if (aidKit.Duration > CurrentTimePoints)
            {
                throw new ArgumentException("Not enough move points");
            }
            CurrentTimePoints -= aidKit.Duration;
            if (aidKit.RestoringHealth >= maxHealth - health)
            {
                health = maxHealth;
            }
            else
            {
                health += aidKit.RestoringHealth;
            }
            inventory.Items.Remove(aidKit);
        }

        public void equipWeapon(Items.Weapon weapon)
        {
            ActiveWeapon = weapon;
        }
        public void takeItem(Items.Item item)
        {
            if (1 > CurrentTimePoints)
            {
                throw new ArgumentException("Not enough move points");
            }
            CurrentTimePoints--;
            int sum = 0;
            foreach (var thing in inventory.Items) sum += thing.Weight;
            if (item.Weight > strength - sum)
            {
                throw new ArgumentException("Weight is too big");
            }
            Inventory.Items.Add(item);
        }
        public void dropItem(Items.Item item)
        {
            if (item == ActiveWeapon)
            {
                throw new ArgumentException("You cannot throw active weapon");
            }
            if (item is Items.AmmoContainer)
            {
                Items.AmmoContainer container = (Items.AmmoContainer)item;
                if (container.Bullets == activeBullets)
                {
                    throw new ArgumentException("You cannot throw active weapon");
                }
            }
            Inventory.Items.Remove(item);
        }

        public void reloadWeapon()
        {
            if (ActiveWeapon == null)
            {
                throw new ArgumentException("Weapon is not equipped");
            }
            if (ActiveWeapon.ReloadTimeCost > CurrentTimePoints)
            {
                throw new ArgumentException("Not enough move points");
            }
            CurrentTimePoints -= ActiveWeapon.ReloadTimeCost;
            int diff = ActiveWeapon.MaxAmmo - ActiveWeapon.CurAmmo;
            if (diff > 0 && activeBullets != null)
            {
                if (activeBullets.Amount > diff)
                {
                    ActiveWeapon.reload(diff);
                    activeBullets.Weight -= diff;
                    activeBullets.Amount -= diff;
                }
                else
                {
                    ActiveWeapon.reload(activeBullets.Amount);
                    foreach (var item in inventory.Items)
                    {
                        if (item is Items.AmmoContainer)
                        {
                            Items.AmmoContainer container = (Items.AmmoContainer)item;
                            if (container.Bullets == activeBullets)
                            {
                                Inventory.Items.Remove(container);
                                break;
                            }
                        }
                    }
                    activeBullets = null;
                }
            }
        }
        public void equipBullets(Items.AmmoContainer container)
        {
            foreach (var item in inventory.Items)
            {
                if (item == container)
                {
                    Items.Bullet bullet = container.Bullets;
                    activeBullets = (Items.Bullet)bullet;
                    return;
                }
            }
            throw new ArgumentException("There is no such container");
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

        public void shootGlass(Cell cell, Random rnd)
        {
            try
            {
                shoot(rnd);
                cell.type = CellType.partition;

            }
            catch
            {
                throw new ArgumentException("Shot wasn`t made.");
            }
        }
    }
}
