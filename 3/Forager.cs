using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testdll;

namespace WindowsFormsAppGame
{
    public class Forager : Living
    {
        private Inventory inventory;
        private int strength;

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public Inventory Inventory { get { return inventory; } set { inventory = value; } }

        public Forager(int X, int Y, string Name, int Health, int MaxHealth, int CurrentTimePoints,
            int MaxTimePoints, int ViewRadius, int Accuracy, int Strength, Inventory Inventory)
            : base(Y, X, Name, Health, MaxHealth, CurrentTimePoints, MaxTimePoints, ViewRadius, Accuracy)
        {
            if (Strength <= 0)
            {
                throw new ArgumentException("Strength cannot be less than zero.");
            }
            inventory = Inventory;
        }
        public void takeItem(Items.Item item)
        {
            if (1 > CurrentTimePoints)
            {
                throw new ArgumentException("Not enough move points");
            }
            //CurrentTimePoints--;
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
            Inventory.Items.Remove(item);
        }
    }
}
