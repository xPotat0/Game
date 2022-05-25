using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item
{
    public class Item
    {
        internal string Describes { get; set; }
    }

    public class Bible : Item
    {
        public bool InBound { get; set; }
        public Bible()
        {
            Describes = "Книга священика Вангорича";
        }
    }
    public class Scissors : Item
    {
        public Scissors()
        {
            Describes = "Садовые ножницы. Могут разрезать лианы или кусты";
        }
    }

    public class Key : Item
    {
        public Key()
        {
            Describes = "Ключ.\nМожет открыть большинство дверей";
        }
    }

    public class Heartflower : Item
    {
        public Image flower;
        public int x, y;
        public Size scale;
        public bool InBound { get; set; }
        public Heartflower(Size scale, int x, int y, Image flower)
        {
            this.scale = scale;
            this.x = x;
            this.y = y;
            this.flower = flower;
        }

        public Heartflower()
        {
            Describes = "Сердцецвет.\nПульсирует жизненной энергией.";
        }
    }

    public class WaterLily : Item
    {
        public Image flower;
        public int x, y;
        public Size scale;
        public bool InBound { get; set; }
        public WaterLily(Size scale, int x, int y, Image flower)
        {
            this.scale = scale;
            this.x = x;
            this.y = y;
            this.flower = flower;
        }
        public WaterLily()
        {
            Describes = "Водяная лилия.\nС редким шансом может вырости на кувшинке";
        }
    }

    public class Notebook : Item
    {
        public Image book;
        public int x, y;
        public Size scale;
        public bool InBound { get; set; }
        public Notebook(Size scale, int x, int y, Image book)
        {
            this.scale = scale;
            this.x = x;
            this.y = y;
            this.book = book;
        }
    }
}
