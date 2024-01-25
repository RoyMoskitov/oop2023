using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testdll;
using WindowsFormsAppGame.GameClasses;
//using static GameClasses.Items;
//using GameDynamicLibrary.GameClasses;

namespace WindowsFormsAppGame
{
    public class Level
    {
        private Matrix<Cell> field;
        private List<Living> characters;
        public Random r = new Random(32);
        private int[,] connection;
        private int[,] next;
        private int[,] moveNum;

        public int[,] Connection
        {
            get { return connection; }
            set { connection = value; }
        }
        public int[,] Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
        public Random Rand { get { return r; } }
        public Matrix<Cell> Field { get { return field; } }

        public List<Living> Characters
        {
            get { return characters; }
            set { characters = value; }
        }
        public Level(List<Living> Characters, Matrix<Cell> Field)
        {
            Connection = new int[Field.Width * Field.Height, Field.Width * Field.Height];
            Next = new int[Field.Width * Field.Height, Field.Width * Field.Height];
            this.field = Field;
            this.characters = Characters;
            InitMatrixes();

        }

        public int[,] MoveNum
        {
            get { return moveNum; }
            set { moveNum = value; }
        }

        public int getMoveNum(int x, int y)
        {
            return moveNum[x, y];
        }

        public int getNext(int x, int y)
        {
            return next[x, y];
        }

        public Cell this[int x, int y]
        {
            set { field[x, y] = value; }
            get { return field[x, y]; }
        }

        public int getConnection(int X, int Y)
        {
            return connection[X, Y];
        }

        public void InitMatrixes()
        {
            for (int i = 0; i < field.Height * field.Width; ++i)
            {
                for (int j = 0; j < field.Width * field.Height; ++j)
                {
                    Connection[i, j] = 99999;
                    Next[i, j] = j;
                }
            }

            for (int i = 0; i < field.Height; ++i)
            {
                for (int j = 0; j < field.Width; ++j)
                {
                    if (field[i, j].type == CellType.floor || field[i, j].type == CellType.warehouse)
                    {
                        if (i > 0)
                        {
                            if (field[i - 1, j].type == CellType.floor || field[i - 1, j].type == CellType.warehouse)
                            {
                                Connection[i * field.Width + j, (i - 1) * field.Width + j] = 1;
                            }
                        }
                        if (j % field.Width != 0 && (field[i, j - 1].type == CellType.floor || field[i, j - 1].type == CellType.warehouse))
                        {
                            Connection[i * field.Width + j, i * field.Width + j - 1] = 1;
                        }
                        if (((j + 1) % field.Width) != 0 && (field[i, j + 1].type == CellType.floor || field[i, j + 1].type == CellType.warehouse))
                        {
                            Connection[i * field.Width + j, ((i * field.Width) + j + 1)] = 1;
                        }
                        if ((i < (field.Height - 1)) && (field[i + 1, j].type == CellType.floor || field[i + 1, j].type == CellType.warehouse))
                        {
                            Connection[i * field.Width + j, (i + 1) * field.Width + j] = 1;
                        }
                    }
                }
            }

            for (int i = 0; i < field.Width * field.Height; ++i)
            {
                for (int j = 0; j < field.Height * field.Width; ++j)
                {
                    for (int k = 0; k < field.Width * field.Height; ++k)
                    {
                        if ((i != j) && (i != k) && (j != k) && (Connection[j, i] + Connection[i, k] < Connection[j, k]))
                        {
                            Connection[j, k] = Connection[j, i] + Connection[i, k];
                            Next[j, k] = Next[j, i];
                        }
                    }
                }
            }
        }


        public void DropItemCharacter(Character living, Items.Item item)
        {
            this[living.X, living.Y].items.Add(item);
            living.dropItem(item);
            item.X = living.X;
            item.Y = living.Y;
        }

        public void TakeItemCharacter(Character living, Items.Item item)
        {
            if (living.X != item.X || living.Y != item.Y)
            {
                throw new ArgumentException("Item is not close enough");
            }
            try
            {
                living.takeItem(item);
                this[living.X, living.Y].items.Remove(item);
            }
            catch
            {
                throw new ArgumentException("Item wasn't taken");
            }

        }

        public void FireEnemyCharacter(Character living, Living target)
        {
            if ((Math.Abs(living.X - target.X) <= living.ViewRadius && Math.Abs(living.Y - target.Y) <= living.ViewRadius))
            {
                try
                {
                    living.shootEnemy(target, Rand);
                }
                catch
                {
                    throw new ArgumentException("Shot wasn`t made");
                }
                if (target.Health <= 0)
                {
                    //DeathAnimation(target); 
                    //Death Animation
                    if (target is IntelligentCreature)
                    {
                        IntelligentCreature intelligentCreature = (IntelligentCreature)target;
                        if (intelligentCreature.ActiveWeapon != null)
                        {
                            this[intelligentCreature.X, intelligentCreature.Y].items.Add(intelligentCreature.ActiveWeapon);
                        }
                    }
                    else if (target is Forager)
                    {
                        Forager forager = (Forager)target;
                        foreach (Items.Item item in forager.Inventory.Items)
                        {
                            this[forager.X, forager.Y].items.Add(item);
                        }
                    }
                    characters.Remove(target);
                }
            }
            else
            {
                throw new ArgumentException("Character is out of your view radius");
            }
        }

        public void TakeStep(Living living, int X, int Y)
        {
            int x = living.X;
            int y = living.Y;
            if ((Math.Abs(x - X) == 1 && Y == y) || (Math.Abs(y - Y) == 1 && X == x))
            {
                if (X < 0 || X >= Field.Height)
                {
                    throw new IndexOutOfRangeException("X coordinate is out of field bounds.");
                }
                else if (Y < 0 || Y >= Field.Width)
                {
                    throw new IndexOutOfRangeException("Y coordinate is out of field bounds.");
                }
                else if (this[X, Y].type != CellType.floor && this[X, Y].type != CellType.warehouse)
                {
                    throw new ArgumentException("This cell is occupied");
                }
                else
                {
                    try
                    {
                        living.takeStep(X, Y);
                    }
                    catch
                    {
                        throw new ArgumentException("You dont have enough time points");
                    }
                }
            }
        }

        public void BeatEnemyWildCreature(WildCreature living, Character target)
        {
            if (Math.Abs(living.X - target.X) <= living.ViewRadius && Math.Abs(living.Y - target.Y) <= living.ViewRadius)
            {
                living.calculateDamage(target);
                if (target.Health <= 0)
                {
                    //Death Animation
                    foreach (Items.Item item in target.Inventory.Items)
                    {
                        this[target.X, target.Y].items.Add(item);
                    }
                    characters.Remove(target);
                    //living.CurrentTimePoints = 0;//для проверки
                }
            }
            else
            {
                throw new ArgumentException("Character is out of your view radius");
            }
        }

        public int FindClosestCharacter(int[,] Connection, int x, int y, ref Character target)
        {
            int curEnemy = x * field.Width + y;
            int min = int.MaxValue;
            for (int i = 0; i < characters.Count; ++i)
            {
                if (characters[i] is Character)
                {
                    int curCharacter = characters[i].X * field.Width + characters[i].Y;
                    if (Connection[curEnemy, curCharacter] < min)
                    {
                        target = (Character)characters[i];
                        min = Connection[curEnemy, curCharacter];
                    }
                }
            }
            return target.X * field.Width + target.Y;
        }
    }

}
