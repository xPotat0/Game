using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Inventory
    {
        static int index = 0;
        public static List<Item.Item> inventory = new List<Item.Item>();
        public static List<string> inve = new List<string>();
        public static void Take(Item.Item item)
        {
            inventory.Add(item);
            if (item is Item.Bible)
                inve.Add("Bible");
            if (item is Item.Scissors)
                inve.Add("Scissors");
            if (item is Item.Heartflower)
                inve.Add("Heartflower");
            if (item is Item.WaterLily)
                inve.Add("WaterLily");
            if (item is Item.Key)
                inve.Add("Key");
            if (item is Item.EmptyBottle)
                inve.Add("EmptyBottle");
            if (item is Item.HealingPotion)
                inve.Add("HealingPotion");
        }

        public static void Drop(string item)
        {
            if (InInventory(item))
            {
                var count = ToDrop(item);
                inventory.RemoveAt(count);
                inve.RemoveAt(count);
            }
        }

        public static int ToDrop(string str)
        {
            for (var i = 0; i < inve.Count; i++)
                if (inve[i] == str) return i;
            throw new Exception("Lol");
        }

        public static bool InInventory(string item)
        {

            bool a = false;
            foreach (var e in inve)
            {
                if (e == item)
                    a = true;
            }
            return a;
        }
    }
}
