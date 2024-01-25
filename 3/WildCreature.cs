using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppGame
{
    public class WildCreature : Living
    {
        private int damage;
        private const int TimePointsPerAttack = 1;
        public WildCreature(int X = 0, int Y = 0, string Name = "UNdefined", int MaxHealth = 20, int Health = 20, int MaxTimePoints = 5,
            int timePointCostPerStep = 1, int Accuracy = 60, int Damage = 5, int ViewRadius = 5, int CurrentTimePoints = 5)
            : base(Y, X, Name, Health, MaxHealth, CurrentTimePoints, MaxTimePoints, ViewRadius, Accuracy)
        {
            if (Damage <= 0)
            {
                throw new ArgumentException("Damage cannot be less than zero.", nameof(Damage));
            }
            damage = Damage;
        }

        public void calculateDamage(Living target)
        {
            if (target.CurrentTimePoints < TimePointsPerAttack)
            {
                throw new ArgumentException("Don't have enoigh points");
            }
            target.Health -= damage;
            CurrentTimePoints -= TimePointsPerAttack;
        }
    }
}
