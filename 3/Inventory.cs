using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testdll;

namespace WindowsFormsAppGame
{
    public class Inventory
    {
        private List<Items.Item> items;
        public Inventory(List<Items.Item> Items)
        {
            items = Items;
        }

        public List<Items.Item> Items { get { return items; } set { items = value; } }
        public int getItemCount()
        {
            return items.Count;
        }
        public void addItem(Items.Item item)
        {
            items.Add(item);
        }
    }
}