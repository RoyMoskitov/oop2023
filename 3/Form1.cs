
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppGame.GameClasses;
using Testdll;

namespace WindowsFormsAppGame
{
    public partial class Form1 : Form
    {
        public Image AidKitSprite;
        public Image RifleSprite;
        public Image AllAsserts;
        public Image CharacterSprite1;
        public Image CharacterSprite2;
        public Image CharacterSprite3;
        public Image CharacterSprite4;
        public Image GroundSprite;
        public Image AllowedGroundSprite;
        public Image WallSprite;
        public Image Terrorist;
        public Image TerrWeapon;
        public Image AmmoContainerSprite;
        public Image CanShootSprite;
        public List<Button> buttons = new List<Button>();
        public List<PictureBox> CharacterBoxes = new List<PictureBox>();
        public Level level;
        public Living ActiveCharacter;
        public List<Button> prevButtons = new List<Button>();
        public PictureBox prevBox;
        public List<Button> InventoryButtons = new List<Button>();
        public List<Button> InventoryActionButtons = new List<Button>();

        //public Button popUp;
        public bool ActiveInventory = false;
        public Form1()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10; // интервал таймера в миллисекундах
            timer.Tick += new EventHandler(timer_Tick);
            //this.Controls.Add(timer);

            //MartinSprite = new Bitmap("C:\\Sprites\\Terr");
            CanShootSprite = new Bitmap("C:\\Sprites\\ground_03.png");
            AmmoContainerSprite = new Bitmap("C:\\Sprites\\AmmoContainer.jpg");
            Terrorist = new Bitmap("C:\\Sprites\\Wild2.png");
            TerrWeapon = new Bitmap("C:\\Sprites\\TerrWeapon.jpg");
            AidKitSprite = new Bitmap("C:\\Sprites\\AidKit.jpg");
            RifleSprite = new Bitmap("C:\\Sprites\\Rifle2.jpg");
            AllAsserts = new Bitmap("C:\\Sprites\\crate_07.png");
            CharacterSprite1 = new Bitmap("C:\\Sprites\\player_05.png");
            CharacterSprite2 = new Bitmap("C:\\Sprites\\player_02.png");
            CharacterSprite3 = new Bitmap("C:\\Sprites\\player_11.png");
            CharacterSprite4 = new Bitmap("C:\\Sprites\\player_14.png");
            GroundSprite = new Bitmap("C:\\Sprites\\ground_06.png");
            AllowedGroundSprite = new Bitmap("C:\\Sprites\\ground_03.png");
            WallSprite = new Bitmap("C:\\Sprites\\crate_03.png");


            pictureBox2.Image = Terrorist;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = GroundSprite;
            CharacterBoxes.Add(pictureBox2);
            pictureBox2.MouseClick += new MouseEventHandler(OnBobPress);

            pictureBox1.Image = CharacterSprite1;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = GroundSprite;
            CharacterBoxes.Add(pictureBox1);
            pictureBox1.MouseClick += new MouseEventHandler(OnBobPress);


            Items.Weapon Pistol = new Items.Weapon("Rifle", 1000, 5, 1, 1, 10);
            Items.AidKit aidKit = new Items.AidKit("AidKit", 1, 100, 2000, 0, 0);
            List<Items.Item> list = new List<Items.Item>();
            list.Add(Pistol);
            list.Add(aidKit);
            Inventory inventory = new Inventory(list);
            Items.Bullet bullet = new Items.Bullet();
            Items.AmmoContainer container = new Items.AmmoContainer(bullet);
            list.Add(container);
            Character Bob = new Character(2, 2, "Bob", 20, 20, 10, 10, 3, 105, 1, 20000, inventory, null);
            //new character creation
            List<Items.Item> list1 = new List<Items.Item>();
            Inventory inventory1 = new Inventory(list);
            WildCreature Fool = new WildCreature(4, 4, "Fool", 30, 30, 5, 1, 100, 5, 1, 5);
            //Character Martin = new Character(4, 4, "Martin", 10, 10, 5, 5, 2, 100, 1, 100000, inventory1, null);
            //end of new character
            Bob.equipBullets(container);
            List<Living> living = new List<Living>();
            living.Add(Bob);
            living.Add(Fool);
            //living.Add(Martin);
            Matrix<Cell> cells = new Matrix<Cell>(8, 8);
            for (int i = 0; i < cells.Height; i++)
            {
                for (int j = 0; j < cells.Width; j++)
                {
                    cells[i, j] = new Cell(CellType.floor);
                }
            }
            cells[2, 3].type = CellType.wall;
            cells[4, 5].type = CellType.wall;
            cells[7, 0].type = CellType.wall;
            cells[6, 6].type = CellType.wall;
            Level level1 = new Level(living, cells);
            level = level1;
            ActiveCharacter = Bob;
            Bob.pictureBox = pictureBox1;
            Fool.pictureBox = pictureBox2;
            progressBar1.Maximum = Fool.MaxHealth;
            progressBar1.Value = Fool.MaxHealth;
            progressBar2.Maximum = Bob.MaxHealth;
            progressBar2.Value = Bob.MaxHealth;
            //progressBar1.

            for (int i = 0; i < level.Field.Height; ++i)
            {
                for (int j = 0; j < level.Field.Width; ++j)
                {

                    Button butt = new Button();
                    butt.Size = new Size(64, 64);
                    butt.Location = new Point(j * 64, i * 64);
                    butt.FlatAppearance.BorderSize = 0;
                    butt.FlatStyle = FlatStyle.Flat;
                    butt.BackColor = Color.DarkGray;

                    switch (level.Field[i, j].type)
                    {
                        case CellType.floor:

                            Image part = new Bitmap(64, 64);
                            Graphics g = Graphics.FromImage(part);
                            g.DrawImage(GroundSprite, new Rectangle(0, 0, 64, 64), 0, 0, 64, 64, GraphicsUnit.Pixel);
                            butt.BackgroundImage = part;
                            break;
                        case CellType.wall:
                            Image part1 = new Bitmap(100, 100);
                            Graphics g1 = Graphics.FromImage(part1);
                            g1.DrawImage(WallSprite, new Rectangle(0, 0, 64, 64), 0, 0, 64, 64, GraphicsUnit.Pixel);
                            butt.BackgroundImage = part1;
                            break;
                    }
                    butt.Click += new EventHandler(OnFigurePress);
                    this.Controls.Add(butt);
                    buttons.Add(butt);

                }
            }
            pictureBox2.Location = new Point(4 * 64, 4 * 64);
            pictureBox1.Location = new Point(pictureBox1.Location.X + (2 * 64), pictureBox1.Location.Y + (2 * 64));
            UpdateAmmoLabel();
            UpdateMovePointsLabel();
        }

        public bool isInActiveList(Button button)
        {
            if (button == null) return false;
            foreach (var butt in prevButtons)
            {
                if (butt == button) return true;
            }
            return false;
        }

        public bool isOnCharacter(Button button)
        {
            foreach (var character in level.Characters)
            {
                if (((button.Location.X) / 64 == ActiveCharacter.Y) && ((button.Location.Y) / 64 == ActiveCharacter.X))
                {
                    return true;
                }
            }
            return false;
        }

        public int AliveCharacters()
        {
            int enemy = 0, character = 0;
            foreach (var alive in level.Characters)
            {
                if (alive is Character) character = 1;
                else if (alive is Forager || alive is WildCreature || alive is IntelligentCreature) enemy = 1;
            }
            return enemy + character;
        }

        public void OnFigurePress(object sender, EventArgs e)
        {
            //Character character = (Character)ActiveCharacter;
            Button pressedButton = sender as Button;
            if (isInActiveList(pressedButton) == true)
            {
                Image part = new Bitmap(64, 64);
                Graphics g = Graphics.FromImage(part);
                g.DrawImage(GroundSprite, new Rectangle(0, 0, 64, 64), 0, 0, 64, 64, GraphicsUnit.Pixel);
                prevBox.BackgroundImage = part;
                try
                {
                    level.TakeStep(ActiveCharacter, (pressedButton.Location.Y) / 64, (pressedButton.Location.X) / 64);
                    UpdateAmmoLabel();
                    UpdateMovePointsLabel();
                    if (ActiveCharacter.CurrentTimePoints == 0) EndTurnButton_Click(EndTurnButton, e);
                    int align = 0;
                    if (ActiveCharacter.Name == "Martin") align = 19;
                    prevBox.Location = new Point(pressedButton.Location.X + align, pressedButton.Location.Y);    
                } catch
                {
                    EndTurnButton_Click(EndTurnButton, e);
                }
                foreach (var button in prevButtons)
                {
                    button.BackgroundImage = part;
                }
                prevButtons.Clear();
            }
        }

        public void OnBobPress(object sender, EventArgs e)
        {
            if (!(ActiveCharacter is Character)) return;
            Character character = (Character)ActiveCharacter;
            PictureBox pressedBox = sender as PictureBox;
            if (ActiveCharacter.pictureBox != pressedBox)
            {
                Living living = new Living(0, 0, "sd", 1, 1, 1, 1, 1, 100);
                foreach (Living alive in level.Characters)
                {
                    if (alive.pictureBox == pressedBox)
                    {
                        living = alive;
                        break;
                    }
                }
                if (ShootPressed == true && !(living is Character))
                {
                    try
                    {
                        level.FireEnemyCharacter(character, living);
                        //if (ActiveCharacter.CurrentTimePoints == 0) EndTurnButton_Click(EndTurnButton, e);
                        UpdateAmmoLabel();
                        UpdateMovePointsLabel();
                        if (living.Health >= 0) progressBar1.Value = living.Health;
                        //progressBar1.ForeColor = Color.Brown;
                        if (!level.Characters.Contains(living))
                        {
                            this.Controls.Remove((PictureBox)pressedBox);
                            if (AliveCharacters() == 1)
                            {
                                MessageBox.Show("The game is over, you Won", "Congratulations", MessageBoxButtons.OK);
                                this.Close();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("You couldn`t make a shot", "Warning", MessageBoxButtons.OK);
                    }
                    ShootEnemyButton_Click(ShootEnemyButton, e);
                }
                //return;
            }
            else if (ActiveCharacter.pictureBox == pressedBox)
            {
                if (ActiveCharacter.CurrentTimePoints < ActiveCharacter.TimePointCostPerStep)
                {
                    MessageBox.Show("You couldn`t reload weapon", "Warning", MessageBoxButtons.OK);
                    return;
                }
                Image part2 = new Bitmap(64, 64);
                Graphics g2 = Graphics.FromImage(part2);
                g2.DrawImage(AllowedGroundSprite, new Rectangle(0, 0, 64, 64), 0, 0, 64, 64, GraphicsUnit.Pixel);
                pressedBox.BackgroundImage = part2;
                int y = pressedBox.Location.X / 64, x = pressedBox.Location.Y / 64, cur = x * level.Field.Width + y;
                if (x > 0 && (level.Field[x - 1, y].type == CellType.floor || level.Field[x - 1, y].type == CellType.floor))
                {
                    buttons[cur - (1 * level.Field.Width)].BackgroundImage = part2;
                    prevButtons.Add(buttons[cur - (1 * level.Field.Width)]);
                }
                if (y % level.Field.Width != 0 && (level.Field[x, y - 1].type == CellType.floor || level.Field[x, y - 1].type == CellType.warehouse))
                {
                    buttons[cur - 1].BackgroundImage = part2;
                    prevButtons.Add(buttons[cur - 1]);
                }
                if (((y + 1) % level.Field.Width) != 0 && (level.Field[x, y + 1].type == CellType.floor || level.Field[x, y + 1].type == CellType.warehouse))
                {
                    buttons[cur + 1].BackgroundImage = part2;
                    prevButtons.Add(buttons[cur + 1]);
                }
                if ((x < (level.Field.Height - 1)) && (level.Field[x + 1, y].type == CellType.floor || level.Field[x + 1, y].type == CellType.warehouse))
                {
                    buttons[cur + (1 * level.Field.Width)].BackgroundImage = part2;
                    prevButtons.Add(buttons[cur + (1 * level.Field.Width)]);
                }
                prevBox = pressedBox;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (ActiveCharacter is Character)
            {
                Character character = (Character)ActiveCharacter;
                if (ActiveInventory == false)
                {
                    for (int i = 0; i < 4; ++i)
                    {
                        for (int j = 0; j < 4; ++j)
                        {
                            Button butt = new Button();
                            butt.Size = new Size(64, 64);
                            butt.Location = new Point(700 + (j * 64), 30 + (i * 64));
                            butt.BackColor = Color.White;

                            butt.Click += new EventHandler(OnInventoryTilePress);
                            butt.MouseHover += new EventHandler(InventoryTile_MouseHover);
                            //butt.MouseLeave += new EventHandler(TimerTick);
                            this.Controls.Add(butt);
                            butt.BringToFront();
                            InventoryButtons.Add(butt);
                        }
                    }
                    ActiveInventory = true;
                    int count = 0;
                    foreach (var item in character.Inventory.Items)
                    {
                        if (item is Items.Weapon && item.Name == "Rifle")
                        {
                            Image partW = new Bitmap(64, 64);
                            Graphics gW = Graphics.FromImage(partW);
                            gW.DrawImage(RifleSprite, new Rectangle(0, 0, 64, 64), 0, 0, 64, 64, GraphicsUnit.Pixel);
                            InventoryButtons[count].BackgroundImage = partW;
                        }
                        else if (item is Items.AidKit && item.Name == "AidKit")
                        {
                            Image partW = new Bitmap(64, 64);
                            Graphics gW = Graphics.FromImage(partW);
                            gW.DrawImage(AidKitSprite, new Rectangle(0, 0, 64, 64), 0, 0, 64, 64, GraphicsUnit.Pixel);
                            InventoryButtons[count].BackgroundImage = partW;
                        }
                        else if (item is Items.AmmoContainer)
                        {
                            Image partW = new Bitmap(64, 64);
                            Graphics gW = Graphics.FromImage(partW);
                            gW.DrawImage(AmmoContainerSprite, new Rectangle(0, 0, 64, 64), 0, 0, 64, 64, GraphicsUnit.Pixel);
                            InventoryButtons[count].BackgroundImage = partW;
                        }
                        ++count;
                    }


                }
                else if (ActiveInventory == true)
                {
                    Control control  = (Control) sender;
                    //RemoveControls(control);
                    for (int i = 0; i < 16; ++i)
                    {
                        this.Controls.Remove((Button)InventoryButtons[i]);
                    }
                    for (int i = 0; i < InventoryActionButtons.Count; ++i)
                    {
                        this.Controls.Remove((Button)InventoryActionButtons[i]);
                    }
                    InventoryActionButtons.Clear();
                    InventoryButtons.Clear();
                    ActiveInventory = false;
                }

            }
        }

        public void OnWeaponPress(object sender, MouseEventArgs e)
        {
            PictureBox pressedBox = sender as PictureBox;
            Button butt = new Button();
            butt.Size = new Size(64, 64);
            butt.Location = new Point(pressedBox.Location.X + 80, pressedBox.Location.Y);
            butt.BackColor = Color.DarkGray;
            butt.Text = "Graci";
        }

        public void DropButtonCreation(Button butt)
        {
            Button DropButton = new Button();
            DropButton.Text = "Drop Item";
            DropButton.BackColor = Color.LightBlue;
            DropButton.Size = new Size(64, 64);
            Point location = new Point(butt.Location.X + 60, butt.Location.Y + 64);
            DropButton.Location = location;
            DropButton.MouseLeave += new EventHandler(popupHeal_MouseLeave);
            DropButton.Click += new EventHandler(DropItemPress);
            //butt.Controls.Add(DropButton);
            this.Controls.Add(DropButton);
            DropButton.BringToFront();
            InventoryActionButtons.Add(DropButton);
        }

        public void OnInventoryTilePress(object sender, EventArgs e)
        {

        }
        public void InventoryTile_MouseHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int index = InventoryButtons.IndexOf((Button)sender);
            Character character = (Character)ActiveCharacter;
            Items.Item item = new Items.Item();
            Button butt = sender as Button;
            if (index >= 0 && index < character.Inventory.Items.Count) item = character.Inventory.Items[index];
            if (index >= 0 && index < character.Inventory.Items.Count
                && !(character.Inventory.Items[index] is Items.Weapon &&
                    character.Inventory.Items[index] == character.ActiveWeapon))
            {
                if (character.Inventory.Items[index] is Items.AmmoContainer)
                {
                    Items.AmmoContainer ammo = (Items.AmmoContainer)character.Inventory.Items[index];
                    if (ammo.Bullets != character.ActiveBullets)
                    {
                        DropButtonCreation(butt);
                    }
                }
                else
                {
                    DropButtonCreation(butt);
                }
            }
            if (item is Items.Weapon && index >= 0 && index < character.Inventory.Items.Count)
            {
                Button popupButton = new Button();
                if (item == character.ActiveWeapon) popupButton.Text = "Unequip weapon";
                else popupButton.Text = "Equip weapon";
                popupButton.BackColor = Color.LightBlue;
                popupButton.Size = new Size(64, 64);
                //Point location = new Point(940, 30);
                Point location = new Point(butt.Location.X + 60, butt.Location.Y);
                popupButton.Location = location;
                //button.Controls.Add(popupButton);
                this.Controls.Add(popupButton);
                popupButton.BringToFront();
                popupButton.MouseLeave += new EventHandler(popupWeapon_MouseLeave);
                popupButton.Click += new EventHandler(EquipWeaponPress);
                InventoryActionButtons.Add(popupButton);
            }
            else if (item is Items.AidKit && index >= 0 && index < character.Inventory.Items.Count)
            {

                Button popupButton = new Button();
                popupButton.Text = "Heal";
                popupButton.BackColor = Color.LightBlue;
                popupButton.Size = new Size(64, 64);
                Point location = new Point(butt.Location.X + 60, butt.Location.Y);
                popupButton.Location = location;
                //button.Controls.Add(popupButton);
                this.Controls.Add(popupButton);
                popupButton.BringToFront();
                popupButton.MouseLeave += new EventHandler(popupHeal_MouseLeave);
                popupButton.Click += new EventHandler(HealPress);
                InventoryActionButtons.Add(popupButton);
            }
            else if (item is Items.AmmoContainer && index >= 0 && index < character.Inventory.Items.Count)
            {
                Items.AmmoContainer container = (Items.AmmoContainer)item;
                Button popupButton = new Button();
                if (container.Bullets == character.ActiveBullets) popupButton.Text = "Unequip bullets";
                else popupButton.Text = "Equip bullets";
                popupButton.BackColor = Color.LightBlue;
                popupButton.Size = new Size(64, 64);
                Point location = new Point(butt.Location.X + 60, butt.Location.Y);
                popupButton.Location = location;
                //button.Controls.Add(popupButton);
                this.Controls.Add(popupButton);
                popupButton.BringToFront();
                popupButton.MouseLeave += new EventHandler(popupHeal_MouseLeave);//все эти функции одинаковые для разных типов предметов
                popupButton.Click += new EventHandler(EquipAmmoPress);
                InventoryActionButtons.Add(popupButton);
            }
        }

        private void DropItemPress(object sender, EventArgs e)
        {
            Character character = (Character)ActiveCharacter;
            Button butt = sender as Button;
            int index = -1;
            foreach (Button button in InventoryButtons)
            {
                if (butt.Location.X == button.Location.X + 60 && butt.Location.Y == button.Location.Y + 64)
                {
                    index = InventoryButtons.IndexOf(button);
                    break;
                }
            }
            level.DropItemCharacter(character, character.Inventory.Items[index]);
            UpdateAmmoLabel();
            UpdateMovePointsLabel();
            InventoryButton_Click(InventoryButton, e);
            InventoryButton_Click(InventoryButton, e);
            //if (ActiveCharacter.CurrentTimePoints == 0) EndTurnButton_Click(EndTurnButton, e);
            butt.Hide();
        }

        private void EquipAmmoPress(object sender, EventArgs e)
        {
            Character character = (Character)ActiveCharacter;
            Button butt = sender as Button;
            int index = -1;
            foreach (Button button in InventoryButtons)
            {
                if (butt.Location.X == button.Location.X + 60 && butt.Location.Y == button.Location.Y)
                {
                    index = InventoryButtons.IndexOf(button);
                    break;
                }
            }
            if (butt.Text == "Equip bullets") character.equipBullets((Items.AmmoContainer)character.Inventory.Items[index]);
            else character.ActiveBullets = null;
            UpdateAmmoLabel();
            UpdateMovePointsLabel();
            butt.Hide();
        }

        private void EquipWeaponPress(object sender, EventArgs e)
        {
            Character character = (Character)ActiveCharacter;
            Button butt = sender as Button;
            int index = -1;
            foreach (Button button in InventoryButtons)
            {
                if (butt.Location.X == button.Location.X + 60 && butt.Location.Y == button.Location.Y)
                {
                    index = InventoryButtons.IndexOf(button);
                    break;
                }
            }
            if (butt.Text == "Equip weapon") character.equipWeapon((Items.Weapon)character.Inventory.Items[index]);
            else character.ActiveWeapon = null;
            UpdateAmmoLabel();
            UpdateMovePointsLabel();
            butt.Hide();
        }

        private void HealPress(object sender, EventArgs e)
        {
            Character character = (Character)ActiveCharacter;
            Button butt = sender as Button;
            int index = -1;
            foreach (Button button in InventoryButtons)
            {
                if (butt.Location.X == button.Location.X + 60 && butt.Location.Y == button.Location.Y)
                {
                    index = InventoryButtons.IndexOf(button);
                    break;
                }
            }
            try
            {
                character.heal((Items.AidKit)character.Inventory.Items[index]);
            }
            catch
            {
                MessageBox.Show("You couldn`t use heal", "Warning", MessageBoxButtons.OK);
            }
            InventoryButton_Click(InventoryButton, e);
            InventoryButton_Click(InventoryButton, e);
            if (ActiveCharacter.Health >= 0) progressBar2.Value = ActiveCharacter.Health;
            UpdateAmmoLabel();
            UpdateMovePointsLabel();
            //if (ActiveCharacter.CurrentTimePoints == 0) EndTurnButton_Click(EndTurnButton, e);
            butt.Hide();
        }

        private void popupHeal_MouseLeave(object sender, EventArgs e)
        {
            Button butt = sender as Button;
            butt.Dispose();
        }

        private void EndTurnButton_MouseHover(object sender, EventArgs e)
        {

        }
        private void popupWeapon_MouseLeave(object sender, EventArgs e)
        {
            Button butt = sender as Button;
            butt.Dispose();
            //InventoryButtons.Controls.Remove(popUp);
        }

        //начало работы с предметами с земли, take item button

        bool ActiveGroundItems = false;
        public List<Button> GroundItemsButtons = new List<Button>();
        private void TakeItemButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (ActiveCharacter is Character)
            {
                Character character = (Character)ActiveCharacter;
                if (ActiveGroundItems == false)
                {
                    for (int i = 0; i < 4; ++i)
                    {
                        Button butt = new Button();
                        butt.Size = new Size(64, 64);
                        butt.Location = new Point(button.Location.X + 170 + (i * 64), button.Location.Y);
                        butt.BackColor = Color.White;

                        //butt.Click += new EventHandler(OnGroundItemPress);
                        butt.MouseHover += new EventHandler(OnGroundItemPress);
                        //butt.MouseLeave += new EventHandler(TimerTick);
                        this.Controls.Add(butt);
                        butt.BringToFront();
                        GroundItemsButtons.Add(butt);
                    }
                    ActiveGroundItems = true;
                    int count = 0;
                    foreach (var item in level[character.X, character.Y].items)
                    {
                        if (item is Items.Weapon && item.Name == "Rifle")
                        {
                            Image partW = new Bitmap(64, 64);
                            Graphics gW = Graphics.FromImage(partW);
                            gW.DrawImage(RifleSprite, new Rectangle(0, 0, 64, 64), 0, 0, 64, 64, GraphicsUnit.Pixel);
                            GroundItemsButtons[count].BackgroundImage = partW;
                        }
                        else if (item is Items.AidKit && item.Name == "AidKit")
                        {
                            Image partW = new Bitmap(64, 64);
                            Graphics gW = Graphics.FromImage(partW);
                            gW.DrawImage(AidKitSprite, new Rectangle(0, 0, 64, 64), 0, 0, 64, 64, GraphicsUnit.Pixel);
                            GroundItemsButtons[count].BackgroundImage = partW;
                        }
                        else if (item is Items.AmmoContainer)
                        {
                            Image partW = new Bitmap(64, 64);
                            Graphics gW = Graphics.FromImage(partW);
                            gW.DrawImage(AmmoContainerSprite, new Rectangle(0, 0, 64, 64), 0, 0, 64, 64, GraphicsUnit.Pixel);
                            GroundItemsButtons[count].BackgroundImage = partW;
                        }
                        ++count;
                    }
                }
                else if (ActiveGroundItems == true)
                {
                    for (int i = 0; i < 4; ++i)
                    {
                        this.Controls.Remove((Button)GroundItemsButtons[i]);
                    }
                    GroundItemsButtons.Clear();
                    ActiveGroundItems = false;
                }
            }
        }


        private void OnGroundItemPress(object sender, EventArgs e)
        {
            int index = GroundItemsButtons.IndexOf((Button)sender);
            Character character = (Character)ActiveCharacter;
            Items.Item item = new Items.Item();
            Button butt = sender as Button;
            int weight = 0;
            foreach (var thing in character.Inventory.Items) weight += thing.Weight;
            if (index >= 0 && index < level[character.X, character.Y].items.Count) item = level[character.X, character.Y].items[index];
            if (index >= 0 && index < level[character.X, character.Y].items.Count &&
                item.Weight <= character.Strength + weight)
            {
                Button DropButton = new Button();
                DropButton.Text = "Take item";
                DropButton.BackColor = Color.LightBlue;
                DropButton.Size = new Size(64, 64);
                Point location = new Point(butt.Location.X + 60, butt.Location.Y);
                DropButton.Location = location;
                this.Controls.Add(DropButton);
                DropButton.BringToFront();
                DropButton.MouseLeave += new EventHandler(popupHeal_MouseLeave);
                DropButton.Click += new EventHandler(TakeItemPress);
            }
        }

        private void TakeItemPress(object sender, EventArgs e)
        {
            Character character = (Character)ActiveCharacter;
            Button butt = sender as Button;
            int index = -1;
            foreach (Button button in GroundItemsButtons)
            {
                if (butt.Location.X == button.Location.X + 60 && butt.Location.Y == button.Location.Y)
                {
                    index = GroundItemsButtons.IndexOf(button);
                    break;
                }
            }
            try
            {
                level.TakeItemCharacter(character, level[character.X, character.Y].Items[index]);
                TakeItemButton_Click(TakeItemButton, e);
                TakeItemButton_Click(TakeItemButton, e);
            } catch {
                MessageBox.Show("You couldn`t use AidKit", "Warning", MessageBoxButtons.OK);
            }
            UpdateAmmoLabel();
            UpdateMovePointsLabel();
            //if (ActiveCharacter.CurrentTimePoints == 0) EndTurnButton_Click(EndTurnButton, e);
            butt.Hide();
        }

    // Начало работы с кнопкой перезарядки, reload weapon
        private void ReloadButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Character character = (Character)ActiveCharacter;
            try
            {
                character.reloadWeapon();
            }
            catch
            {
                //Button DropButton = new Button();
                MessageBox.Show("You couldn`t reload weapon", "Warning", MessageBoxButtons.OK);
                
            }
            UpdateAmmoLabel();
            UpdateMovePointsLabel();
            //if (ActiveCharacter.CurrentTimePoints == 0) EndTurnButton_Click(EndTurnButton, e);
        }

        // Начало работы с кнопкой стрельбы, shoot enemy 

        bool ShootPressed = false;
        private void ShootEnemyButton_Click(object sender, EventArgs e)
        {
            if (!(ActiveCharacter is Character)) return;
            Character character = (Character)ActiveCharacter; 
            if (ShootPressed == false)
            {
                foreach (var enemy in level.Characters)
                {
                    if (!(enemy is Character) && Math.Abs(enemy.X - ActiveCharacter.X) <= character.ViewRadius
                        && Math.Abs(enemy.Y - ActiveCharacter.Y) <= character.ViewRadius)
                    {
                        enemy.pictureBox.BackgroundImage = CanShootSprite;
                    }
                }
                ShootPressed = true;
            }
            else
            {
                foreach (var enemy in level.Characters)
                {
                    if (!(enemy is Character) && Math.Abs(enemy.X - ActiveCharacter.X) <= character.ViewRadius
                        && Math.Abs(enemy.Y - ActiveCharacter.Y) <= character.ViewRadius)
                    {
                        enemy.pictureBox.BackgroundImage = GroundSprite;
                    }
                }
                ShootPressed = false;
            }
        }

        private void EndTurnButton_Click(object sender, EventArgs e)
        {
            if (AliveCharacters() == 1)
            {
                MessageBox.Show("The game is over, you lost this one", "End", MessageBoxButtons.OK);
                this.Close();
            }
            //int index = level.Characters.IndexOf(ActiveCharacter);
            //if (index == level.Characters.Count - 1) ActiveCharacter = level.Characters[0];
            //else ActiveCharacter = level.Characters[index+1];
            UpdateAmmoLabel();
            UpdateMovePointsLabel();
            if (ActiveCharacter is Character) ActiveCharacter = level.Characters[1];
            else ActiveCharacter = level.Characters[0];
            foreach (var guy in level.Characters) guy.CurrentTimePoints = guy.MaxTimePoints;
            if (ActiveCharacter is WildCreature)
            {
                WildCreature creature = (WildCreature)ActiveCharacter;
                EnemyAI(creature);
                EndTurnButton_Click(sender, e);
            }
            UpdateAmmoLabel();
            UpdateMovePointsLabel();
        }

        //end turn button

        private System.Windows.Forms.Timer timer;

        private void timer_Tick(object sender, EventArgs e)
        {
            if (ActiveCharacter.pictureBox.Location.X < ActiveCharacter.Y * 64)
            {
                ActiveCharacter.pictureBox.Location = new Point(ActiveCharacter.pictureBox.Location.X + 8, ActiveCharacter.pictureBox.Location.Y);
            }
            else if (ActiveCharacter.pictureBox.Location.X > ActiveCharacter.Y * 64)
            {
                ActiveCharacter.pictureBox.Location = new Point(ActiveCharacter.pictureBox.Location.X - 8, ActiveCharacter.pictureBox.Location.Y);
            }
            else if (ActiveCharacter.pictureBox.Location.Y < ActiveCharacter.X * 64)
            {
                ActiveCharacter.pictureBox.Location = new Point(ActiveCharacter.pictureBox.Location.X, ActiveCharacter.pictureBox.Location.Y + 8);
            }
            else if (ActiveCharacter.pictureBox.Location.Y > ActiveCharacter.X * 64)
            {
                ActiveCharacter.pictureBox.Location = new Point(ActiveCharacter.pictureBox.Location.X, ActiveCharacter.pictureBox.Location.Y - 8);
            }
            else
            {
                timer.Stop();
            }
        }

        private void UpdateMovePointsLabel()
        {
            if (ActiveCharacter is Character)
            {
                OdLabel.Visible = true;
                OdLabel.Text = "Move points: " + ActiveCharacter.CurrentTimePoints;
            } else
            {
                OdLabel.Visible= false;
            }
        }

        private void UpdateAmmoLabel()
        {
            if (ActiveCharacter is Character)
            {
                Character character = ActiveCharacter as Character; 
                AmmoLabel.Visible = true;
                if (character.ActiveWeapon != null) AmmoLabel.Text = "Current ammo: " + character.ActiveWeapon.CurAmmo;
                else AmmoLabel.Text = "Weapon is not equipped";
            } else
            {
                AmmoLabel.Visible= false;
            }
        }

        public void EnemyAI(WildCreature enemy)
        {

            int EnemyNum = enemy.X * level.Field.Width + enemy.Y;
            List<Items.Item> Items = new List<Items.Item>();
            Inventory inv = new Inventory(Items);
            Character target = new Character();
            int CharacterNum = level.FindClosestCharacter(level.Connection, enemy.X, enemy.Y, ref target);
            while (enemy.CurrentTimePoints > 0)
            {
                try
                {
                    if (enemy.CurrentTimePoints < 1) break;
                    //mutShooting.WaitOne();
                    if (!level.Characters.Contains(target)) break;
                    level.BeatEnemyWildCreature(enemy, target);
                    if (target.Health >= 0) progressBar2.Value = target.Health;
                    if (!level.Characters.Contains(target))
                    {
                        this.Controls.Remove(target.pictureBox);
                        break;
                        //System.Threading.Thread.Sleep(100000);
                    }   
                    //mutShooting.ReleaseMutex();
                }      
                catch    
                {       
                    if (enemy.CurrentTimePoints < enemy.TimePointCostPerStep) break;
                    int DirY = level.Next[EnemyNum, CharacterNum] % level.Field.Width;
                    int DirX = (level.Next[EnemyNum, CharacterNum] - DirY) / level.Field.Width;
                    level.TakeStep(enemy, DirX, DirY);
                    timer.Start();
                    while (timer.Enabled)
                    {
                        Application.DoEvents(); // обновляем графический интерфейс
                        Thread.Sleep(100); // замораживаем поток на 100 миллисекунд
                    }
                    EnemyNum = (enemy.X * level.Field.Width) + enemy.Y;
                }
            }

        }

        //

    }

    
}
