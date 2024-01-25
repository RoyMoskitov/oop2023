using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testdll

{
    public class Items
    {
        public enum AmmoType { iron = 1, silver = 2, golden = 3, magical = 4 };
        public class Item
        {
            protected string name = "Undefined";
            protected int weight;
            protected int x;
            protected int y;
            /// <summary>
            /// Constructor with parameters and default one
            /// </summary> 
            /// <param name="Name"></param>
            /// <param name="Weight"></param>
            /// <param name="X"></param>
            /// <param name="Y"></param>
            /// <exception cref="ArgumentException"></exception>
            public Item(string Name = "Undefined", int Weight = 1000, int X = 0, int Y = 0)
            {
                if (Weight <= 0)
                {
                    throw new ArgumentException("Weight cannot be less than zero.", nameof(Weight));
                }
                weight = Weight;
                name = Name;
                x = X;
                y = Y;
            }
            /// <summary>
            /// Getter/Setter of X coordinate
            /// </summary>
            public int X { get { return x; } set { x = value; } }
            /// <summary>
            /// Getter/Setter of Y coordinate
            /// </summary>
            public int Y { get { return y; } set { y = value; } }
            /// <summary>
            ///  Getter/Setter of Name
            /// </summary>
            public string Name { get { return name; } set { name = value; } }
            /// <summary>
            /// Getter/Setter of weight
            /// </summary>
            public int Weight { get { return weight; } set { weight = value; } }
        };

        public class Bullet : Item
        {
            private AmmoType type;
            private int amount;
            public Bullet(string Name = "DefaultBullet", AmmoType ammoType = AmmoType.iron, int Amount = 20)
                : base(Name, Amount)
            {
                if (Amount <= 0)
                {
                    throw new ArgumentException("Amount cannot be less than zero.", nameof(Amount));
                }
                type = ammoType;
                amount = Amount;

            }
            /// <summary>
            /// Getter/Setter of amount of bullets
            /// </summary>
            public int Amount { get { return amount; } set { amount = value; } }
            /// <summary>
            /// Getter/Setter of bullet type
            /// </summary>
            public AmmoType Type { get { return type; } set { type = value; } }
        };

        public class Weapon : Item
        {
            protected int damage;
            protected int fireTimeCost;
            protected int reloadTimeCost;
            protected int curAmmo;
            protected int maxAmmo;
            /// <summary>
            /// Constructor with parameters and default one
            /// </summary>
            /// <param name="Name"></param>
            /// <param name="Weight"></param>
            /// <param name="Damage"></param>
            /// <param name="FireTimeCost"></param>
            /// <param name="ReloadTimeCost"></param>
            /// <param name="MaxAmmo"></param>
            /// <exception cref="ArgumentException"></exception>
            public Weapon(string Name = "Undefined", int Weight = 5000, int Damage = 2, int FireTimeCost = 1, int ReloadTimeCost = 2, int MaxAmmo = 10, int X = 0, int Y = 0)
                : base(Name, Weight, X, Y)
            {
                if (Damage <= 0)
                {
                    throw new ArgumentException("Damage cannot be less than zero.", nameof(Damage));
                }
                if (FireTimeCost <= 0)
                {
                    throw new ArgumentException("Fire time cost cannot be less than zero.", nameof(FireTimeCost));
                }
                if (ReloadTimeCost <= 0)
                {
                    throw new ArgumentException("Reload time cost cannot be less than zero.", nameof(ReloadTimeCost));
                }
                if (MaxAmmo <= 0)
                {
                    throw new ArgumentException("Max ammo cannot be less than zero.", nameof(MaxAmmo));
                }
                reloadTimeCost = ReloadTimeCost;
                maxAmmo = MaxAmmo;
                curAmmo = maxAmmo;
                fireTimeCost = FireTimeCost;
                damage = Damage;
            }
            /// <summary>
            /// Getter/Setter of weapon damage
            /// </summary>
            public int Damage
            {
                get { return damage; }
                set { damage = value; }
            }

            public int FireTimeCost
            {
                get => fireTimeCost;
                set { fireTimeCost = value; }
            }

            public int ReloadTimeCost
            {
                get { return reloadTimeCost; }
                set { reloadTimeCost = value; }
            }
            public int MaxAmmo { get { return maxAmmo; } set { maxAmmo = value; } }
            public int CurAmmo { get { return curAmmo; } set { curAmmo = value; } }
            public void fire()
            {
                if (curAmmo == 0)
                {
                    throw new ArgumentException("Gun is out of ammo.");
                }
                curAmmo--;
            }
            public void reload(int amount)
            {
                curAmmo += amount;
            }

        };

        public class AmmoContainer : Item
        {
            private Bullet bullets;
            public AmmoContainer(Bullet Bullets, int Weight = 20, string Name = "DefaultContainer", int X = 0, int Y = 0)
                : base(Name, Weight, X, Y)
            {
                bullets = Bullets;
            }

            public Bullet Bullets
            {
                get { return bullets; }
                set { bullets = value; }
            }
        };

        public class AidKit : Item
        {
            private int duration;
            private int restoringHealth;
            public AidKit(string Name = "DefaultAidKit", int Duration = 1, int RestoringHealth = 5, int Weight = 2000, int X = 0, int Y = 0)
                : base(Name, Weight)
            {
                if (Duration <= 0)
                {
                    throw new ArgumentException("Duration cannot be less than zero.", nameof(Duration));
                }
                if (RestoringHealth <= 0)
                {
                    throw new ArgumentException("Restoring health cannot be less than zero.", nameof(RestoringHealth));
                }
                restoringHealth = RestoringHealth;
                duration = Duration;

            }

            public int Duration
            {
                get { return duration; }
                set { duration = value; }
            }

            public int RestoringHealth
            {
                get { return restoringHealth; }
                set { restoringHealth = value; }
            }

        }
        public class Grenade : Item
        {
            private int damage { get; set; }
            private int duration { get; set; }

            private int radius { get; set; }

            public Grenade(string Name = "DefaultGrenade", int Damage = 5, int Duration = 5, int Radius = 3,
                int Weight = 2000, int X = 0, int Y = 0)
            : base(Name, Weight)
            {
                if (Duration <= 0)
                {
                    throw new ArgumentException("Duration cannot be less than zero.", nameof(Duration));
                }
                if (Damage <= 0)
                {
                    throw new ArgumentException("Damage cannot be less than zero.", nameof(Damage));
                }
                if (Radius <= 0)
                {
                    throw new ArgumentException("Radius cannot be less than zero.", nameof(Radius));
                }
                this.damage = Damage;
                this.duration = Duration;
                radius = Radius;
            }


        }



    }
}
