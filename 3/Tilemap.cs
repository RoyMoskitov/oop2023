using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//namespace WindowsFormsAppGame
//{
//    public class Tilemap
//    {
//        public Panel Parent { get; }
//        public Level Level { get; }

//        public Tilemap(int Width, int Height, int TileSize, Color DefultColor, Panel Parent)
//        {
//            typeof(Panel).InvokeMember("DoubleBuffered",
//            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
//            null, Parent, new object[] { true });
//            this.TileSize = TileSize;
//            this.Width = Width;
//            this.Height = Height;
//            this.Parent = Parent;
//            for (int i = 0; i < Width; i++)
//            {
//                for (int j = 0; j < Height; j++)
//                {
//                    Tiles[i, j] = new Tile(i, j, TileSize, DefultColor);
//                }
//            }
//            DrawTilemap();
//        }
//        public void DrawTilemap()
//        {
//            Bitmap Result = new Bitmap(Parent.Width, Parent.Height);
//            Graphics WorkWith = Graphics.FromImage(Result);
//            Pen ThePen = new Pen(Color.AliceBlue, 1);
//            SolidBrush TheBrush = new SolidBrush(Color.AliceBlue);
//            for (int i = 0; i < Width; i++)
//            {
//                for (int j = 0; j < Height; j++)
//                {
//                    ThePen.Color = Tiles[i, j].DefultColor;
//                    TheBrush.Color = Tiles[i, j].DefultColor;
//                    WorkWith.FillRectangle(TheBrush, i * TileSize, j * TileSize, TileSize, TileSize);
//                    foreach (var item in Tiles[i, j].Images)
//                    {
//                        WorkWith.DrawImage(item, i * TileSize, j * TileSize, TileSize, TileSize);
//                    }
//                }
//            }
//            Parent.BackgroundImage = Result;
//        }
//    }
//}
