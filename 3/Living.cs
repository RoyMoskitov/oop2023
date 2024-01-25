using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppGame
{
    public class Living
    {
        protected int y;
        protected int x;
        protected string name = "Undefined";
        protected int health;
        protected int maxHealth;
        protected int currentTimePoints;
        protected int maxTimePoints;
        protected int timePointCostPerStep = 1;
        protected int viewRadius;
        protected int accuracy;

        public PictureBox pictureBox { get; set; }
        public string Name { get { return name; } }
        public int MaxTimePoints
        {
            get { return maxTimePoints; }
            set { maxTimePoints = value; }
        }

        public int TimePointCostPerStep
        {
            get { return timePointCostPerStep; }
            set { timePointCostPerStep = value; }
        }
        public int CurrentTimePoints
        {
            set { currentTimePoints = value; }
            get { return currentTimePoints; }
        }

        public int Health
        {
            set { health = value; }
            get { return health; }
        }

        public int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }
        public int ViewRadius
        {
            get { return viewRadius; }
            set { viewRadius = value; }
        }
        public int Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public Living(int Y, int X, string Name, int Health, int MaxHealth, int CurrentTimePoints, int MaxTimePoints,
            int ViewRadius, int Accuracy)
        {
            if (Health <= 0)
            {
                throw new ArgumentException("Health cannot be less than zero.", nameof(Health));
            }
            if (MaxHealth <= 0)
            {
                throw new ArgumentException("Max health cannot be less than zero.", nameof(MaxHealth));
            }
            if (CurrentTimePoints < 0)
            {
                throw new ArgumentException("Current Time Points cannot be less than zero.", nameof(CurrentTimePoints));
            }
            if (MaxTimePoints <= 0)
            {
                throw new ArgumentException("Max Time Points cannot be less than zero.", nameof(MaxTimePoints));
            }
            if (ViewRadius <= 0)
            {
                throw new ArgumentException("View radius cannot be less than zero.", nameof(ViewRadius));
            }
            if (Accuracy <= 0)
            {
                throw new ArgumentException("Accuracy cannot be less than zero.", nameof(Accuracy));
            }
            name = Name;
            health = Health;
            maxHealth = MaxHealth;
            currentTimePoints = CurrentTimePoints;
            accuracy = Accuracy;
            maxTimePoints = MaxTimePoints;
            viewRadius = ViewRadius;
            //pictureBox = new PictureBox();
            x = X; y = Y;
        }

        public void takeStep(int X, int Y)
        {
            if (currentTimePoints < timePointCostPerStep)
            {
                throw new ArgumentException("You don`t have enough time points.");
            }
            x = X; y = Y;
            currentTimePoints -= timePointCostPerStep;
        }

    };
}
