using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool isPressedAnyKey = false, isPressedleft = false, isPressedUp = false, isPressedRight = false, isPressedDown = false,
            isPressedAct = false,
            openInv = false, openNote = false, CanOpenNote = false, openHELP;
        private bool left = false, up = false, right = false, down = false;
        private int x=0,y=0;
        Graphics grap;
        Player player;
        DoorIn leftDoor;
        DoorOut rightDoor;
        DoorUp upDoor;
        DoorDown downDoor;
        Tuple<Item.Bible, bool> bible;
        Tuple<Item.EmptyBottle, bool> emptyBottle;
        Tuple<Item.HealingPotion, bool> HealingPotion;
        Tuple<Item.Notebook, bool> Notebook;
        Tuple<Item.WaterLily, bool> waterLily;
        Tuple<Item.Heartflower,bool> heartflower1;
        Tuple<Item.Heartflower, bool> heartflower2;
        Tuple<Item.Heartflower, bool> heartflower3;//Не забыть инициализировать новые объекты в Form1()
        public static Image HeroImg, GrassImg, WallImg, Keyboard, InventoryGr/*Pope*/;

        public static int height = 12;
        public static int width = 14;

        public static int inDynObj = 0;
        public static Point delta;
        public static string[,] MapMeadow = new string[30, 15]
            {
                { "wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt"},
                { "wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt"},
                { "wt","wt","11","6","6","6","6","13","5","lg","5","5","5","wt","wt"},
                { "wt","wt","12","4","4","4","7","2","5","lg","g","5","5","wt","wt"},
                { "wt","wt","5","5","5","g","8","2","5","5","5","5","5","wt","wt"},
                { "wt","wt","5","lg","5","5","8","2","5","5","5","g","5","wt","wt"},
                { "wt","wt","5","5","5","5","8","2","5","5","5","5","g","wt","wt"},
                { "wt","wt","5","wl","wlh","5","8","2","5","5","5","5","5","wt","wt"},
                { "wt","wt","5","wc","wch","5","8","2","5","b","g","5","5","wt","wt"},
                { "wt","wt","5","wr","wrh","5","8","2","5","5","5","5","5","wt","wt"},
                { "wt","wt","5","5","5","5","8","2","5","g","5","5","5","wt","wt"},
                { "wt","wt","5","11","13","5","8","2","5","5","5","5","g","wt","wt"},
                { "wt","wt","lb","8","3","6","9","2","g","5","5","g","5","wt","wt"},
                { "wt","wt","5","12","4","4","4","14","5","5","5","5","5","wt","wt"},
                { "wt","wt","5","g","5","5","g","b","lg","5","5","5","5","wt","wt"},
                { "wt","wt","5","5","5","5","5","5","5","5","5","5","5","wt","wt"},
                { "wt","wt","5","5","5","5","5","5","5","5","5","5","5","wt","wt"},
                { "wt","wt","5","5","5","5","5","5","5","5","5","5","5","wt","wt"},
                { "wt","wt","5","5","5","5","5","5","5","5","5","5","5","wt","wt"},
                { "wt","wt","5","5","5","5","5","5","5","5","5","5","5","wt","wt"},
                { "wt","wt","wt","5","5","5","5","5","5","5","5","5","5","wt","wt"},
                { "wt","wt","wt","wt","5","5","5","5","5","5","5","5","5","wt","wt"},
                { "wt","wt","wt","wt","wt","wt","wt","5","wt","wt","wt","wt","wt","wt","wt"},
                { "wt","wt","5","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt"},
                { "wt","wt","5","5","5","wt","wt","wt","wt","wt","wt","5","5","wt","wt"},
                { "wt","wt","5","5","5","5","5","5","5","5","5","5","5","wt","wt"},
                { "wt","wt","5","5","5","5","5","5","5","5","5","5","5","wt","wt"},
                { "wt","wt","5","5","5","5","5","5","5","5","5","5","5","wt","wt"},
                { "wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt"},
                { "wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt"}
            };

        public static string[,] MapForest = new string[20, 20]
        {
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","5","lg","5","5","wt","wt","5","wt","wt","wt","wt","wt","wt","wt","wt","lg","wt","wt" },
            {"wt","wt","wt","g","mg","g","mg","lg","5","5","wt","wt","wt","wt","wt","wt","wt","g","wt","wt" },
            {"wt","wt","wt","5","5","lg","mg","lb","g","5","mg","5","wt","wt","wt","wt","5","lg","wt","wt" },
            {"wt","wt","wt","wt","he","5","wt","wt","wt","5","5","g","5","wt","5","lg","g","5","wt","wt" },
            {"wt","wt","wt","wt","lg","wt","wt","wt","wt","5","5","5","5","lg","5","lg","wt","wt","wt","wt" },
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","5","5","g","lg","mg","mg","wt","wt","wt","wt" },
            {"wt","w10","wt","wt","wt","wt","wt","wt","wt","wt","lg","5","5","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","w20","wt","wt","wt","wt","wt","wt","wt","wt","5","5","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","w30","5","5","wt","wt","wt","wt","wt","wt","5","lb","5","5","wt","wt","wt","wt","wt","wt" },
            {"wt","w11","5","b","5","wt","wt","wt","wt","5","mg","5","5","lg","5","wt","wt","wt","wt","wt" },
            {"wt","w20","g","he","lg","wt","wt","wt","5","lg","g","5","b","5","5","wt","wt","wt","wt","wt" },
            {"wt","w31","lg","g","5","5","wt","wt","5","5","5","5","5","g","5","5","wt","wt","wt","wt" },
            {"wt","w10","5","5","5","5","wt","5","5","g","5","b","5","5","5","5","wt","wt","wt","wt" },
            {"wt","w20","5","lg","5","mg","lg","g","5","5","5","5","5","5","lg","5","wt","wt","wt","wt" },
            {"wt","w30","mg","5","g","5","lg","lg","5","5","5","wt","wt","wt","5","g","wt","wt","wt","wt" },
            {"wt","w11","5","lg","5","5","mg","5","5","5","5","wt","wt","wt","5","5","5","5","wt","wt" },
            {"wt","w20","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","w30","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" }
        };

        public static string[,] MapGrandForest = new string[20, 20]
        {
            {"wt","wt","wt","wt","wt","w10","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","wt","wt","wt","w30","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","5","5","5","w10","wt","wt","wt","5","5","5","5","5","5","5","wt","wt","wt","wt" },
            {"wt","wt","5","5","5","w20","lg","wt","wt","5","5","5","wt","wt","wt","5","wt","wt","wt","wt" },
            {"wt","wt","5","5","5","w31","g","5","wt","5","5","wt","wt","wt","5","5","5","5","wt","wt" },
            {"wt","wt","5","5","5","w10","5","5","5","5","5","5","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","5","5","5","w20","lg","mg","wt","5","5","5","5","wt","5","5","5","5","wt","wt" },
            {"wt","wt","5","5","5","w31","g","5","wt","wt","wt","5","5","wt","5","5","5","5","wt","wt" },
            {"wt","wt","5","5","5","w10","5","wt","wt","wt","wt","wt","wt","wt","wt","5","wt","wt","wt","wt" },
            {"wt","wt","5","5","5","w21","g","5","wt","wt","5","wt","wt","wt","wt","5","wt","wt","wt","wt" },
            {"wt","wt","5","5","5","w31","5","g","5","5","5","5","5","5","wt","5","wt","5","wt","wt" },
            {"wt","wt","5","5","5","w10","lg","5","wt","5","5","wt","wt","g","5","g","wt","wt","wt","wt" },
            {"wt","wt","5","5","5","w20","5","5","wt","5","5","wt","wt","wt","lg","5","wt","wt","wt","wt" },
            {"wt","wt","5","5","5","w30","lg","lb","wt","mg","wt","wt","wt","wt","5","5","wt","wt","wt","wt" },
            {"wt","wt","5","5","5","w11","g","lg","wt","5","wt","he","b","wt","5","lg","wt","wt","wt","wt" },
            {"wt","wt","5","5","5","w20","lg","wt","wt","lg","wt","b","lb","wt","5","5","lg","5","wt","wt" },
            {"wt","wt","5","5","5","w30","wt","wt","wt","g","lg","g","g","wt","wt","wt","g","wt","wt","wt" },
            {"wt","wt","5","5","5","w10","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","lg","wt","wt","wt" },
            {"wt","wt","wt","wt","wt","w20","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","wt","wt","wt","w30","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" }
        };

        public static string[,] MapCrossroad = new string[12, 10]
        {
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","5","wt","wt","wt","5","wt","wt","wt" },
            {"wt","wt","5","5","wt","wt","5","wt","wt","wt" },
            {"wt","wt","5","5","5","5","5","wt","wt","wt" },
            {"wt","wt","wt","5","5","5","5","5","wt","wt" },
            {"wt","wt","wt","5","5","5","5","wt","wt","wt" },
            {"wt","wt","wt","5","5","5","5","wt","wt","wt" },
            {"wt","wt","wt","5","5","5","5","wt","wt","wt" },
            {"wt","wt","wt","wt","wt","5","5","wt","wt","wt" },
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" }
        };

        public static string[,] MapWithChurch = new string[9, 12]
        {
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","5","5","5","5","5","5","5","5","wt","wt" },
            {"wt","wt","wfl","wfl","wchl","w_w","5","5","5","5","wt","wt" },
            {"wt","wt","wfc","wfc","wchw","w_e","5","5","5","5","wt","wt" },
            {"wt","wt","wfr","wfr","wchr","w_w","5","5","5","5","wt","wt" },
            {"wt","wt","5","5","5","5","5","5","5","5","wt","wt" },
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" }
        };

        public static string[,] MapChurch = new string[7, 12]
        {
            {"0","0","0","0","0","0","0","0","0","0","0","0" },
            {"0","wfl","wfl","wfl","wfl","wfl","wfl","wfl","wfl","wchl","w_w","0" },
            {"0","w_w","f","f","w_w","f","f","f","f","f","w_w","0" },
            {"0","w_w","f","f","wX","f","f","f","f","f","w_e","0" },
            {"0","w_w","f","f","f","f","f","f","f","f","w_w","0" },
            {"0","wfr","wfr","wfr","wfr","wfr","wfr","wfr","wfr","wchr","w_w","0" },
            {"0","0","0","0","0","0","0","0","0","0","0","0" }
        };

        public static string[,] MapHouse = new string[7, 7]
       {
            {"0","0","0","0","0","0","0" },
            {"0","wl","wl","wl","wl","wlh","0" },
            {"5","wh","f","f","f","wch","5" },
            {"5","wwi","f","f","f","wwo","lg"},
            {"5","wh","f","f","f","wch","lg" },
            {"0","wr","wr","wr","wr","wrh","0" },
            {"0","0","0","0","0","0","0" }
       };

        public static string[,] MapWithHuntsman = new string[14, 12]
        {
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt", "wt", "wt", "5", "5", "5", "5", "5", "5", "5", "wt" ,"wt"},
            {"wt", "wt", "wt", "5", "5", "5", "5", "5", "5", "5", "wt", "wt"},
            {"wt", "wt", "wt", "5", "5", "5", "5", "5", "5", "5", "wt", "wt"},
            {"wt", "wt", "wt", "5", "5", "5", "5", "5", "8", "2", "wt", "wt"},
            {"wt", "wt", "5", "11", "6", "6", "6", "6", "9", "2", "wt", "wt"},
            {"wt", "wt", "wt", "12", "4", "4", "4", "4", "7", "2","wt", "wt"},
            {"wt", "wt", "wt" ,"5", "5", "5", "5", "5", "8", "2", "wt", "wt"},
            {"wt","wt","w_le", "w_h_lr", "w_h_lu", "w_h_ld", "5", "5", "9", "2", "wt", "wt"},
            {"wt","wt","w_ce", "w_r_e", "w_h_w", "w_h_e", "5", "5", "5", "5", "wt", "wt"},
            {"wt","wt","w_re", "w_h_rr", "w_h_ru", "w_h_rd", "5", "5", "5", "5", "wt", "wt"},
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" },
            {"wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt","wt" }
        };

        public static string[,] MapHuntsmanHouse = new string[9, 8]
        {
            {"0","0","0","0","0","0","0","0" },
            {"0","w_le","w_h_lr","w_h_lr","w_h_lr","w_h_lr","w_h_lr","w_h_ld" },
            {"0","w_ce","f","f","f","f","f","w_h_cd" },
            {"0","w_ce","f","f","f","f","f","w_h_cd" },
            {"0","w_ce","f","f","f","f","f","w_h_e" },
            {"0","w_ce","f","f","f","f","f","w_h_cd" },
            {"0","w_ce","f","f","f","f","f","w_h_cd" },
            {"0","w_re","w_h_rr","w_h_rr","w_h_rr","w_h_rr","w_h_rr","w_h_rd" },
            {"0","0","0","0","0","0","0","0" }
        };

        public static string[,] MapHuntsmanHouseSecondFloor = new string[7, 8]
        {
            {"0","0","0","0","0","0","0","0" },
            {"0","w_le","w_h_lr","w_h_lr","w_h_lr","w_h_lr","w_h_lr","w_h_ld" },
            {"0","w_ce","f","f","f","f","f","w_h_cd" },
            {"0","w_ce","f","f","f","f","f","w_h_cd" },
            {"0","w_ce","f","f","f","f","f","w_h_cd" },
            {"0","w_re","w_h_rr","w_h_rr","w_h_rr","w_h_rr","w_h_rr","w_h_rd" },
            {"0","0","0","0","0","0","0","0" }
        };

        public static string[,] CurrentMap = MapWithHuntsman;
        public static int CurrentMapStatus = 1102;
        public static Tuple<int,int,string[,]>[] Map = new Tuple<int, int, string[,]>[2000];
        int sideOfMapObject = 64;

        public Form1()
        {
            this.ClientSize = new Size(960, 720);

            Map[1000] = Tuple.Create(7, 7, MapHouse);
            Map[1001] = Tuple.Create(30, 15, MapMeadow);
            Map[1002] = Tuple.Create(12, 10, MapCrossroad);
            Map[902] = Tuple.Create(20, 20, MapForest);
            Map[901] = Tuple.Create(20, 20, MapGrandForest);
            Map[1003] = Tuple.Create(9, 12, MapWithChurch);
            Map[903] = Tuple.Create(7, 12, MapChurch);
            Map[1102] = Tuple.Create(14, 12, MapWithHuntsman);
            Map[1103] = Tuple.Create(9, 8, MapHuntsmanHouse);
            Map[1104] = Tuple.Create(7, 8, MapHuntsmanHouseSecondFloor);

            HeroImg = new Bitmap("C:\\Users\\111\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\Hero.png");
            GrassImg = new Bitmap("C:\\Users\\111\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\Grass.png");
            Keyboard = new Bitmap("C:\\Users\\111\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\Keyboard.png");
            InventoryGr = new Bitmap("C:\\Users\\111\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\inventory.png");


            player = new Player(new Size(192, 192), 196*10, 196*6, HeroImg);
            rightDoor = new DoorOut(new Size(196, 196), 0, 0, GrassImg);
            leftDoor = new DoorIn(new Size(196, 196), 0, 0, GrassImg);
            upDoor = new DoorUp(new Size(196, 196), 0, 0, GrassImg);
            downDoor = new DoorDown(new Size(196, 196), 0, 0, GrassImg);

            Notebook = Tuple.Create(new Item.Notebook(new Size(64,64),0,0,InventoryGr),true);
            waterLily = Tuple.Create(new Item.WaterLily(new Size(196, 196), 0, 0, GrassImg),true);
            heartflower1 = Tuple.Create(new Item.Heartflower(new Size(196,196),0,0, GrassImg),true);
            heartflower2 = Tuple.Create(new Item.Heartflower(new Size(196, 196), 0, 0, GrassImg), true);
            heartflower3 = Tuple.Create(new Item.Heartflower(new Size(196, 196), 0, 0, GrassImg), true);
            bible = Tuple.Create(new Item.Bible(new Size(64, 64), 0, 0, InventoryGr), true);
            emptyBottle = Tuple.Create(new Item.EmptyBottle(new Size(64, 64), 0, 0, InventoryGr), true);
            HealingPotion = Tuple.Create(new Item.HealingPotion(new Size(64, 64), 0, 0, InventoryGr), true);

            delta = new Point(196 * 2 - player.up_left_x, 196 * 1 - player.up_left_y);

            this.KeyDown += new KeyEventHandler(GameKeyDown);
            this.KeyUp += new KeyEventHandler(GameKeyUp);

            var timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(Update);
            timer.Start();

            this.Paint += new PaintEventHandler(OnPaint);

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void playAniimation(Graphics grap)
        {
            grap.DrawImage(player._spritesAnimation, player.up_left_x + delta.X, player.up_left_y + delta.Y, new Rectangle(new Point(192 * player.currentFrame, 192 * player.currentAnimation), new Size(192, 192)), GraphicsUnit.Pixel);
        }

        private void Update(object sender, EventArgs e)
        {
            if (player.currentFrame == 8)
                player.currentFrame = 0;
            player.currentFrame++;
            Invalidate();
        }

        private void GameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { PlayerUp(); }
            if (e.KeyCode == Keys.A) { PlayerLeft(); }
            if (e.KeyCode == Keys.S) { PlayerDown(); }
            if (e.KeyCode == Keys.D) { PlayerRight(); }
            if (e.KeyCode == Keys.F) { isPressedAct = true; }
            if (e.KeyCode == Keys.I) { if (openInv) openInv = false; else openInv = true; }
            if (e.KeyCode == Keys.Q) { if (CanOpenNote) { if (openNote) openNote = false; else openNote = true; } }
            if (e.KeyCode == Keys.H) { if (openHELP) openHELP = false; else openHELP = true; }
            if (e.KeyCode == Keys.Left) { left = true; }
            if (e.KeyCode == Keys.Up) { up = true; }
            if (e.KeyCode == Keys.Right) { right = true; }
            if (e.KeyCode == Keys.Down) { down = true; }
        }

        private void PlayerRight()
        {
            isPressedAnyKey = true;
            player.currentAnimation = 2;
            player.dirX = 2;
            if (GetCell((player.up_left_x + player.dirX + 192 - 50), player.up_left_y + 50)[0] != 'w' &&
                GetCell(player.up_left_x + 192 - 50, player.up_left_y + player.dirY + 192 - 50)[0] != 'w')
            {
                player.move();
                if (player.up_left_x > 400 && player.up_left_x < 196*width - 685)
                    delta.X -= player.dirX;
            }
            //Inventory.Take(new Item.Key());
        }

        private void PlayerDown()
        {
            isPressedAnyKey = true;
            player.currentAnimation = 1;
            player.dirY = 2;
            if (GetCell(player.up_left_x + 50 + 20, player.up_left_y + player.dirY + 192 + 10)[0] != 'w'
                && GetCell(player.up_left_x + 192 - 50, player.up_left_y + player.dirY + 192 + 10)[0] != 'w')
            {
                player.move();
                if (player.up_left_y > 400 && player.up_left_y < 196*height - 400)
                    delta.Y -= player.speed;
            }
        }

        private void PlayerLeft()
        {
            isPressedAnyKey = true;
            player.currentAnimation = 3;
            player.dirX = -2;
            if (GetCell(player.up_left_x + player.dirX + 70, player.up_left_y + 50)[0] != 'w' &&
                GetCell(player.up_left_x + player.dirX + 70, player.up_left_y + 192 - 50)[0] != 'w')
            {
                player.move();
                if (player.up_left_x > 400 && player.up_left_x < 196 * width - 685)
                    delta.X += player.speed;
            }
            //Inventory.Drop("Key");
        }

        private void PlayerUp()
        {
            isPressedAnyKey = true;
            player.currentAnimation = 4;
            player.dirY = -2;
            if (GetCell(player.up_left_x + 70, player.up_left_y + player.dirY + 50)[0] != 'w' &&
                GetCell(player.up_left_x + 192 - 50, player.up_left_y + player.dirY + 50)[0] != 'w')
            {
                player.move();
                if (player.up_left_y > 400 && player.up_left_y < 196 * height - 400)
                    delta.Y += player.speed;
            }
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { isPressedAnyKey = false; player.dirY = 0; }
            if (e.KeyCode == Keys.A) { isPressedAnyKey = false; player.dirX = 0; }
            if (e.KeyCode == Keys.S) { isPressedAnyKey = false; player.dirY = 0; }
            if (e.KeyCode == Keys.D) { isPressedAnyKey = false; player.dirX = 0; }
            if (e.KeyCode == Keys.F) { isPressedAct = false; }
            if (e.KeyCode == Keys.Left) { left = false; }
            if (e.KeyCode == Keys.Up) { up = false; }
            if (e.KeyCode == Keys.Right) { right = false; }
            if (e.KeyCode == Keys.Down) { down = false; }
        }

        private void playStatic(Graphics grap)
        {
            grap.DrawImage(player._spritesAnimation, player.up_left_x + delta.X, player.up_left_y + delta.Y, new Rectangle(new Point(0 * player.currentFrame, 192 * player.currentAnimation), new Size(192, 192)), GraphicsUnit.Pixel);
        }

        private void CreateMap(Graphics gr)
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    GetMapCellToDraw(gr, x, y);
        }

        private void GetMapCellToDraw(Graphics gr, int x, int y)
        {
            if (CurrentMap[x, y] == "g")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(0, 0), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "lg")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "b")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 2, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "lb")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 3, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "mg")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 4, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "hf")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 5, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "he")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 6, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "wh")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 4, 196 * 1), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "wlh")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 3, 196 * 1), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "wch")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 7, 196 * 1), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "wrh")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 8, 196 * 1), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "wl")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 5, 196 * 2), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "wc")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 6, 196 * 2), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "wr")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(1372, 196 * 2), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "wwo")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 6, 196 * 1), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "wwi")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 5, 196 * 1), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "wt")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 7, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "f")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 8, 196 * 2), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "0")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 8, 196 * 4), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "1")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 0, 196 * 1), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "2")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 1), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "3")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 2, 196 * 1), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "4")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 0, 196 * 2), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "5")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 2), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "6")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 2, 196 * 2), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "7")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 0, 196 * 3), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "8")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 3), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "9")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 2, 196 * 3), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "11")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 3, 196 * 2), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "12")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 4, 196 * 2), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "13")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 3, 196 * 3), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "14")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 4, 196 * 3), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "15")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 5, 196 * 3), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "w10")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 0, 196 * 4), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "w20")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 4), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "w30")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 2, 196 * 4), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "w11")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 3, 196 * 4), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "w21")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 4, 196 * 4), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "w31")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 6, 196 * 4), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "w_w")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 2, 196 * 6), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "w_e")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 5), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "wchl")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 3, 196 * 5), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "wchw")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 5, 196 * 5), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "wchr")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 6, 196 * 5), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "wfl")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 4, 196 * 5), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "wfr")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 7, 196 * 5), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "wfc")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 8, 196 * 5), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "wX")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 0, 196 * 6), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "w_h_ld")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 3, 196 * 6), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "w_h_lu")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 4, 196 * 6), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "w_h_ru")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 5, 196 * 6), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "w_h_cd")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 6, 196 * 6), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "w_h_e")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 7, 196 * 6), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "w_h_cu")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 8, 196 * 6), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "w_h_w")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 0, 196 * 7), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "w_h_rd")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 7), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "w_h_rr")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 2, 196 * 7), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "w_h_lr")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 3, 196 * 7), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "w_T")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 4, 196 * 7), new Size(196, 196)), GraphicsUnit.Pixel);
            else if (CurrentMap[x, y] == "w_le")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 6, 196 * 7), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "w_re")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 7, 196 * 7), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "w_ce")
            {
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 1, 196 * 0), new Size(196, 196)), GraphicsUnit.Pixel);
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 8, 196 * 7), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            else if (CurrentMap[x, y] == "w_r_e")
                gr.DrawImage(GrassImg, x * 196 + delta.X, y * 196 + delta.Y, new Rectangle(new Point(196 * 0, 196 * 8), new Size(196, 196)), GraphicsUnit.Pixel);
            else
                throw new Exception(Text = "Клетка не объявлена: " + CurrentMap[x, y] + x.ToString() + ":" + y.ToString());
        }

        private string GetCell(int dx,int dy)
        {
            int x = dx / 199;
            int y = dy / 199;
            if (x > 0 && x < width && y > 0 && y < height)
                return CurrentMap[x, y];
            else
                return ".";
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            CreateMap(gr);
            Interaction(gr);
            if (isPressedAnyKey)
                playAniimation(gr);
            else
                playStatic(gr);
            CanInterplay(gr);
            DrawInterface(gr);
            DrawInventory(gr);
            DrawNotebook(gr);
            HELP(gr);
        }

        private void HELP(Graphics gr)
        {
            var list = new List<string>()
            {
                "Открыть/закрыть записную книжку" ,
                "Взаимодействие с объектом.\nЕсли с объектом можно взаимодействовать, то над игроком загорится сигнал" ,
                "Открыть/закрыть инвентарь" ,
                "Движение вверх" ,
                "Движение влево" ,
                "Движение вниз" ,
                "Движение вправо" ,
            };
            if (openHELP)
            {
                for (var i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        gr.DrawImage(InventoryGr, i * 64, j * 64, new Rectangle(new Point(64 * 9,0), new Size(64, 64)), GraphicsUnit.Pixel);
                    }
                }

                for(var i = 0; i < 7; i++)
                {
                    gr.DrawImage(Keyboard, 50, i * 64, new Rectangle(new Point(64 * i + 64, 0), new Size(64, 64)), GraphicsUnit.Pixel);
                    gr.DrawString(Text = list[i], new Font("Franklin Gothic Medium", 15, FontStyle.Italic), new SolidBrush(Color.Black), new Point(120, i * 64 + 10));
                }
            }
        }

        private void CanInterplay(Graphics gr)
        {
            if (inDynObj == 1)
                gr.DrawImage(Keyboard, player.up_left_x + 60 + delta.X, player.up_left_y - 80 + delta.Y, new Rectangle(new Point(128, 0), new Size(64, 64)), GraphicsUnit.Pixel);

            if (!rightDoor.closed)
            {
                if ((player.up_left_x - 50 > rightDoor.x && player.up_left_x < rightDoor.x + 196 + 100)
                    &&
                    (player.up_left_y - 50 > rightDoor.y && player.up_left_y < rightDoor.y + 196 + 100))
                    rightDoor.InBound = true;
                else
                    rightDoor.InBound = false;
            }
            else
            {
                if ((player.up_left_x - 50 > rightDoor.x && player.up_left_x < rightDoor.x + 196 + 100)
                       &&
                       (player.up_left_y - 50 > rightDoor.y && player.up_left_y < rightDoor.y + 196 + 100)
                       /*&& Inventory.InInventory("Key")*/)
                    rightDoor.InBound = true;
                else
                    rightDoor.InBound = false;
            }
            if (!downDoor.closed)
            {
                if ((player.up_left_x - 50 > downDoor.x && player.up_left_x < downDoor.x + 196 + 100)
                &&
                (player.up_left_y - 50 > downDoor.y && player.up_left_y < downDoor.y + 196 + 100))
                    downDoor.InBound = true;
                else
                    downDoor.InBound = false;
            }
            else
            {
                if ((player.up_left_x - 50 > downDoor.x && player.up_left_x < downDoor.x + 196 + 100)
                &&
                (player.up_left_y - 50 > downDoor.y && player.up_left_y < downDoor.y + 196 + 100)
                /*&& Inventory.InInventory("Key")*/)
                    downDoor.InBound = true;
                else
                    downDoor.InBound = false;
            }


            if (!leftDoor.closed)
            {
                if ((player.up_left_x - 50 > leftDoor.x && player.up_left_x < leftDoor.x + 196 + 100)
                    &&
                    (player.up_left_y - 50 > leftDoor.y && player.up_left_y < leftDoor.y + 196 + 100))
                    leftDoor.InBound = true;
                else
                    leftDoor.InBound = false;
            }
            else
            {
                if ((player.up_left_x - 50 > leftDoor.x && player.up_left_x < leftDoor.x + 196 + 100)
                    &&
                    (player.up_left_y - 50 > leftDoor.y && player.up_left_y < leftDoor.y + 196 + 100)
                   /* && Inventory.InInventory("Key")*/)
                    leftDoor.InBound = true;
                else
                    leftDoor.InBound = false;
            }

            if (!upDoor.closed)
            {
                if ((player.up_left_x - 50 > upDoor.x && player.up_left_x < upDoor.x + 196 + 100)
                &&
                (player.up_left_y - 50 > upDoor.y && player.up_left_y < upDoor.y + 196 + 100))
                    upDoor.InBound = true;
                else
                    upDoor.InBound = false;
            } 
            else
            {
                if ((player.up_left_x - 50 > upDoor.x && player.up_left_x < upDoor.x + 196 + 100)
                &&
                (player.up_left_y - 50 > upDoor.y && player.up_left_y < upDoor.y + 196 + 100)
                /*&& Inventory.InInventory("Key")*/)
                    upDoor.InBound = true;
                else
                    upDoor.InBound = false;
            }

            if ((player.up_left_x - 50 > heartflower1.Item1.x && player.up_left_x < heartflower1.Item1.x + 196 + 100)
               &&
               (player.up_left_y - 50 > heartflower1.Item1.y && player.up_left_y < heartflower1.Item1.y + 196 + 100))
                heartflower1.Item1.InBound = true;
            else
                heartflower1.Item1.InBound = false;

            if ((player.up_left_x - 50 > heartflower2.Item1.x && player.up_left_x < heartflower2.Item1.x + 196 + 100)
               &&
               (player.up_left_y - 50 > heartflower2.Item1.y && player.up_left_y < heartflower2.Item1.y + 196 + 100))
                heartflower2.Item1.InBound = true;
            else
                heartflower2.Item1.InBound = false;

            if ((player.up_left_x - 50 > heartflower3.Item1.x && player.up_left_x < heartflower3.Item1.x + 196 + 100)
               &&
               (player.up_left_y - 50 > heartflower3.Item1.y && player.up_left_y < heartflower3.Item1.y + 196 + 100))
                heartflower3.Item1.InBound = true;
            else
                heartflower3.Item1.InBound = false;

            if ((player.up_left_x - 50 > waterLily.Item1.x && player.up_left_x < waterLily.Item1.x + 196 + 100)
               &&
               (player.up_left_y - 50 > waterLily.Item1.y && player.up_left_y < waterLily.Item1.y + 196 + 200))
                waterLily.Item1.InBound = true;
            else
                waterLily.Item1.InBound = false;

            if ((player.up_left_x - 50 > Notebook.Item1.x && player.up_left_x < Notebook.Item1.x + 196 + 100)
               &&
               (player.up_left_y - 50 > Notebook.Item1.y && player.up_left_y < Notebook.Item1.y + 196 + 200))
                Notebook.Item1.InBound = true;
            else
                Notebook.Item1.InBound = false;

            if ((player.up_left_x - 50 > emptyBottle.Item1.x && player.up_left_x < emptyBottle.Item1.x + 196 + 100)
               &&
               (player.up_left_y - 50 > emptyBottle.Item1.y && player.up_left_y < emptyBottle.Item1.y + 196 + 200))
                emptyBottle.Item1.InBound = true;
            else
                emptyBottle.Item1.InBound = false;
        }

        private void DrawInterface(Graphics gr)
        {
            gr.DrawImage(InventoryGr, 0, 0, new Rectangle(new Point(64 * 7, 0), new Size(64, 64)), GraphicsUnit.Pixel);
            gr.DrawImage(Keyboard, 0, 64, new Rectangle(new Point(64 * 3, 0), new Size(64, 64)), GraphicsUnit.Pixel);    //Рисовка интерфейса "Инвентарь"

            gr.DrawImage(InventoryGr, 0, 64 * 10 + 16, new Rectangle(new Point(64 * 8, 0), new Size(64, 64)), GraphicsUnit.Pixel);
            gr.DrawImage(Keyboard, 0, 64 * 9 + 16, new Rectangle(new Point(64 * 8, 0), new Size(64, 64)), GraphicsUnit.Pixel);  //Рисовка интерфейса "Помощник"

             if(!Notebook.Item2)
             {
                gr.DrawImage(InventoryGr, 196 * 5 - 84, 0, new Rectangle(new Point(64 * 6, 0), new Size(64, 64)), GraphicsUnit.Pixel);
                gr.DrawImage(Keyboard, 196 * 5 - 84, 64, new Rectangle(new Point(64 * 1, 0), new Size(64, 64)), GraphicsUnit.Pixel); //Рисовка интерфейса "Задачник"
             }
        }

        private void Interaction(Graphics gr)
        {
            SelectCurMap(gr);
            if (rightDoor.InBound)
            {
                if (isPressedAct)
                {
                    var from = CurrentMapStatus;
                    DoorOut.ChangeMap();
                    player.ChangeMap(from, CurrentMapStatus);
                }
                inDynObj = 1;
            }
            else
                inDynObj = 0;
            if (leftDoor.InBound)
            {
                    if (isPressedAct)
                    {
                        var from = CurrentMapStatus;
                        DoorIn.ChangeMap();
                        player.ChangeMap(from, CurrentMapStatus);
                    }
                inDynObj = 1;
            }                
            if (upDoor.InBound)
            {
                if (isPressedAct)
                {
                    var from = CurrentMapStatus;
                    DoorUp.ChangeMap();
                    player.ChangeMap(from, CurrentMapStatus);
                }
                inDynObj = 1;
            }
            if (downDoor.InBound)
            {
                if (isPressedAct)
                {
                    var from = CurrentMapStatus;
                    DoorDown.ChangeMap();
                    player.ChangeMap(from,CurrentMapStatus);
                }
                inDynObj = 1;
            }
            if (heartflower1.Item1.InBound)
            {
                if (isPressedAct)
                {
                    Inventory.Take(new Item.Heartflower());
                    heartflower1.Item1.x = -90;
                    heartflower1.Item1.y = -90;
                    heartflower1 = Tuple.Create(heartflower1.Item1, false);
                }
                inDynObj = 1;
            }
            if (heartflower2.Item1.InBound)
            {
                if (isPressedAct)
                {
                    Inventory.Take(new Item.Heartflower());
                    heartflower2.Item1.x = -90;
                    heartflower2.Item1.y = -90;
                    heartflower2 = Tuple.Create(heartflower2.Item1, false);
                }
                inDynObj = 1;
            }
            if (heartflower3.Item1.InBound)
            {
                if (isPressedAct)
                {
                    Inventory.Take(new Item.Heartflower());
                    heartflower3.Item1.x = -90;
                    heartflower3.Item1.y = -90;
                    heartflower3 = Tuple.Create(heartflower3.Item1, false);
                }
                inDynObj = 1;
            }
            if (waterLily.Item1.InBound)
            {
                if (isPressedAct)
                {
                    Inventory.Take(new Item.WaterLily());
                    waterLily.Item1.x = -90;
                    waterLily.Item1.y = -90;
                    waterLily = Tuple.Create(waterLily.Item1, false);
                }
                inDynObj = 1;
            }
            if (Notebook.Item1.InBound)
            {
                if (isPressedAct)
                {
                    CanOpenNote = true;
                    Notebook.Item1.x = -90;
                    Notebook.Item1.y = -90;
                    Notebook = Tuple.Create(Notebook.Item1, false);
                }
                inDynObj = 1;
            }
            if (emptyBottle.Item1.InBound)
            {
                if (isPressedAct)
                {
                    Inventory.Take(new Item.EmptyBottle());
                    emptyBottle.Item1.x = -90 + delta.X;
                    emptyBottle.Item1.y = -90 + delta.Y;
                    emptyBottle = Tuple.Create(emptyBottle.Item1, false);
                }
                inDynObj = 1;
            }
            if (HealingPotion.Item1.InBound)
            {
                if (isPressedAct)
                {
                    Inventory.Take(new Item.HealingPotion());
                    HealingPotion.Item1.x = -90 + delta.X;
                    HealingPotion.Item1.y = -90 + delta.Y;
                    HealingPotion = Tuple.Create(HealingPotion.Item1, false);
                }
                inDynObj = 1;
            }
        }

        private void SelectCurMap(Graphics gr)
        {
            if(CurrentMapStatus == 901)
                DrawDynObjGrandForest(gr);
            if (CurrentMapStatus == 1000)
                DrawDynObjHouse(gr);
            if (CurrentMapStatus == 1001)
                DrawDynObjMeadow(gr);
            if (CurrentMapStatus == 902)
                DrawDynObjForest(gr);
            if (CurrentMapStatus == 1002)
                DrawDynObjCrossroad(gr);
            if (CurrentMapStatus == 1003)
                DrawDynObjMapWithChurch(gr);
            if (CurrentMapStatus == 1102)
                DrawDynObjMapWithHuntsman(gr);
            if (CurrentMapStatus == 1103)
                DrawDynObjMapHuntsmanHouse(gr);
            if (CurrentMapStatus == 1104)
                DrawDynObjHuntsmanHouseSecondFloor(gr);
            if (CurrentMapStatus == 903)
                DrawDynObjChurch(gr);
        }

        private void DrawDynObjGrandForest(Graphics gr)
        {
            var g = 3 * 196 + delta.X;
            var h = 16 * 196 + delta.Y;
            downDoor.x = g - delta.X;
            downDoor.y = h - delta.Y;
            gr.DrawImage(GrassImg, g + 196, h + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            var c = 16 * 196 + delta.X;
            var d = 15 * 196 + delta.Y;
            rightDoor.x = c - delta.X;
            rightDoor.y = d - delta.Y;
            gr.DrawImage(GrassImg, c + 196, d + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            if (waterLily.Item2)
            { 
                var a = 9 * 196 + delta.X;
                var b = 4 * 196 + delta.Y;
                waterLily.Item1.x = a - delta.X;
                waterLily.Item1.y = b - delta.Y;
                gr.DrawImage(GrassImg, a + 196, b + 196, new Rectangle(new Point(196 * 5, 196 * 4), new Size(196, 196)), GraphicsUnit.Pixel); 
            }
            if (heartflower1.Item2)
            {
                var aa = 13 * 196 + delta.X;
                var bb = 10 * 196 + delta.Y;
                heartflower1.Item1.x = aa - delta.X;
                heartflower1.Item1.y = bb - delta.Y;
                gr.DrawImage(GrassImg, aa + 196, bb + 196, new Rectangle(new Point(980, 0), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            //
            leftDoor.x = -50 + delta.X;
            leftDoor.y = -50 + delta.Y;
            upDoor.x = -50 + delta.X;
            upDoor.y = -50 + delta.Y;
            heartflower2.Item1.x = -50 + delta.X;
            heartflower2.Item1.y = -50 + delta.Y;
            heartflower3.Item1.x = -50 + delta.X;
            heartflower3.Item1.y = -50 + delta.Y;
            leftDoor.closed = false;
            rightDoor.closed = false;
            downDoor.closed = false;
            upDoor.closed = false;
            emptyBottle.Item1.x = -50 + delta.X;
            emptyBottle.Item1.y = 50 + delta.Y;
        }

        private void DrawDynObjHouse(Graphics gr)
        {
            var a = 4 * 196 + delta.X;
            var b = 3 * 196 + delta.Y;
            rightDoor.x = a - delta.X;
            rightDoor.y = b - delta.Y;
            if (Notebook.Item2)
            {
                var c = 3 * 196 + delta.X;
                var d = 2 * 196 + delta.Y;
                Notebook.Item1.x = c - delta.X;
                Notebook.Item1.y = d - delta.Y;
                gr.DrawImage(InventoryGr, c + 196 + 50, d + 196 + 50, new Rectangle(new Point(64 * 5, 0), new Size(64, 64)), GraphicsUnit.Pixel);
            }
            //
            downDoor.x = -50 + delta.X;
            downDoor.y = -50 + delta.Y;
            leftDoor.x = -50 + delta.Y;
            leftDoor.y = -50 + delta.X;
            upDoor.x = -50 + delta.X;
            upDoor.y = -50 + delta.Y;
            heartflower1.Item1.x = -50 + delta.X;
            heartflower1.Item1.y = -50 + delta.Y;
            heartflower2.Item1.x = -50 + delta.X;
            heartflower2.Item1.y = -50 + delta.Y;
            heartflower3.Item1.x = -50 + delta.X;
            heartflower3.Item1.y = -50 + delta.Y;
            waterLily.Item1.x = -50 + delta.X;
            waterLily.Item1.y = -50 + delta.Y;
            leftDoor.closed = false;
            rightDoor.closed = false;
            downDoor.closed = false;
            upDoor.closed = false;
            emptyBottle.Item1.x = -50 + delta.X;
            emptyBottle.Item1.y = 50 + delta.Y;
        }

        private void DrawDynObjMeadow(Graphics gr)
        {
            var a = 27 * 196 + delta.X;
            var b = 5 * 196 + delta.Y;
            rightDoor.x = a - delta.X;
            rightDoor.y = b - delta.Y;
            gr.DrawImage(GrassImg, a + 196 , b + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            var c = 10 * 196 + delta.X;
            var d = 2 * 196 + delta.Y;
            leftDoor.x = c - delta.X;
            leftDoor.y = d - delta.Y;
            var e = 10 * 196 + delta.X;
            var f = 1 * 196 + delta.Y;
            upDoor.x = e - delta.X;
            upDoor.y = f - delta.Y;
            gr.DrawImage(GrassImg, e + 196, f + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            //
            downDoor.x = -50 + delta.X;
            downDoor.y = -50 + delta.Y;
            heartflower1.Item1.x = -50 + delta.X;
            heartflower1.Item1.y = -50 + delta.Y;
            heartflower2.Item1.x = -50 + delta.X;
            heartflower2.Item1.y = -50 + delta.Y;
            heartflower3.Item1.x = -50 + delta.X;
            heartflower3.Item1.y = -50 + delta.Y;
            waterLily.Item1.x = -50 + delta.X;
            waterLily.Item1.y = -50 + delta.Y;
            leftDoor.closed = false;
            rightDoor.closed = true;
            downDoor.closed = false;
            upDoor.closed = false;
            emptyBottle.Item1.x = -50 + delta.X;
            emptyBottle.Item1.y = 50 + delta.Y;
        }

        private void DrawDynObjForest(Graphics gr)
        {
            var g = 16 * 196 + delta.X;
            var h = 16 * 196 + delta.Y;
            downDoor.x = g - delta.X;
            downDoor.y = h - delta.Y;
            gr.DrawImage(GrassImg, g + 196, h + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            var c = 1 * 196 + delta.X;
            var d = 16 * 196 + delta.Y;
            leftDoor.x = c - delta.X;
            leftDoor.y = d - delta.Y;
            gr.DrawImage(GrassImg, c + 196, d + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            if (heartflower2.Item2)
            {
                var aa = 11 * 196 + delta.X;
                var bb = 2 * 196 + delta.Y;
                heartflower2.Item1.x = aa - delta.X;
                heartflower2.Item1.y = bb - delta.Y;
                gr.DrawImage(GrassImg, aa + 196, bb + 196, new Rectangle(new Point(980, 0), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            if (heartflower3.Item2)
            {
                var aa = 4 * 196 + delta.X;
                var bb = 3 * 196 + delta.Y;
                heartflower3.Item1.x = aa - delta.X;
                heartflower3.Item1.y = bb - delta.Y;
                gr.DrawImage(GrassImg, aa + 196, bb + 196, new Rectangle(new Point(980, 0), new Size(196, 196)), GraphicsUnit.Pixel);
            }
            //
            rightDoor.x = -50 + delta.X;
            rightDoor.y = -50 + delta.Y;
            upDoor.x = -50 + delta.X;
            upDoor.y = -50 + delta.Y;
            heartflower1.Item1.x = -50 + delta.X;
            heartflower1.Item1.y = -50 + delta.Y;
            waterLily.Item1.x = -50 + delta.X;
            waterLily.Item1.y = -50 + delta.Y;
            leftDoor.closed = false;
            rightDoor.closed = false;
            downDoor.closed = false;
            upDoor.closed = false;
            emptyBottle.Item1.x = -50 + delta.X;
            emptyBottle.Item1.y = 50 + delta.Y;
        }

        private void DrawDynObjCrossroad(Graphics gr)
        {
            var a = 4 * 196 + delta.X;
            var b = 6 * 196 + delta.Y;
            downDoor.x = a - delta.X;
            downDoor.y = b - delta.Y;
            gr.DrawImage(GrassImg, a + 196, b + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            var c = 1 * 196 + delta.X;
            var d = 5 * 196 + delta.Y;
            leftDoor.x = c - delta.X;
            leftDoor.y = d - delta.Y;
            gr.DrawImage(GrassImg, c + 196, d + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            var e = 1 * 196 + delta.X;
            var f = 1 * 196 + delta.Y;
            upDoor.x = e - delta.X;
            upDoor.y = f - delta.Y;
            gr.DrawImage(GrassImg, e + 196, f + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            var i = 8 * 196 + delta.X;
            var j = 5 * 196 + delta.Y;
            rightDoor.x = i - delta.X;
            rightDoor.y = j - delta.Y;
            gr.DrawImage(GrassImg, i + 196, j + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            // 
            heartflower1.Item1.x = -50 + delta.X;
            heartflower1.Item1.y = -50 + delta.Y;
            heartflower2.Item1.x = -50 + delta.X;
            heartflower2.Item1.y = -50 + delta.Y;
            heartflower3.Item1.x = -50 + delta.X;
            heartflower3.Item1.y = -50 + delta.Y;
            waterLily.Item1.x = -50 + delta.X;
            waterLily.Item1.y = -50 + delta.Y;
            leftDoor.closed = true;
            rightDoor.closed = false;
            downDoor.closed = false;
            upDoor.closed = false;
            emptyBottle.Item1.x = -50 + delta.X;
            emptyBottle.Item1.y = 50 + delta.Y;
        }

        private void DrawDynObjMapWithChurch(Graphics gr)
        {
            downDoor.x = -50 + delta.X;
            downDoor.y = -50 + delta.Y;
            var c = 1 * 196 + delta.X;
            var d = 7 * 196 + delta.Y;
            leftDoor.x = c - delta.X;
            leftDoor.y = d - delta.Y;
            gr.DrawImage(GrassImg, c + 196, d + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            var e = 3 * 196 + delta.X;
            var f = 5 * 196 + delta.Y;
            upDoor.x = e - delta.X;
            upDoor.y = f - delta.Y;
            gr.DrawImage(GrassImg, e + 196, f + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            rightDoor.x = -50 + delta.X;
            rightDoor.y = -50 + delta.Y;
            // 
            heartflower1.Item1.x = -50 + delta.X;
            heartflower1.Item1.y = -50 + delta.Y;
            heartflower2.Item1.x = -50 + delta.X;
            heartflower2.Item1.y = -50 + delta.Y;
            heartflower3.Item1.x = -50 + delta.X;
            heartflower3.Item1.y = -50 + delta.Y;
            waterLily.Item1.x = -50 + delta.X;
            waterLily.Item1.y = -50 + delta.Y;
            leftDoor.closed = false;
            rightDoor.closed = false;
            downDoor.closed = false;
            upDoor.closed = false;
            emptyBottle.Item1.x = -50 + delta.X;
            emptyBottle.Item1.y = 50 + delta.Y;
        }

        private void DrawDynObjChurch(Graphics gr)
        {
            var a = 2 * 196 + delta.X;
            var b = 8 * 196 + delta.Y;
            downDoor.x = a - delta.X;
            downDoor.y = b - delta.Y;
            leftDoor.x = -50 + delta.X;
            leftDoor.y = -50 + delta.Y;
            upDoor.x = -50 + delta.X;
            upDoor.y = -50 + delta.Y;
            rightDoor.x = -50 + delta.X;
            rightDoor.y = -50 + delta.Y;
            // 
            heartflower1.Item1.x = -50 + delta.X;
            heartflower1.Item1.y = -50 + delta.Y;
            heartflower2.Item1.x = -50 + delta.X;
            heartflower2.Item1.y = -50 + delta.Y;
            heartflower3.Item1.x = -50 + delta.X;
            heartflower3.Item1.y = -50 + delta.Y;
            waterLily.Item1.x = -50 + delta.X;
            waterLily.Item1.y = -50 + delta.Y;
            leftDoor.closed = true;
            rightDoor.closed = false;
            downDoor.closed = false;
            upDoor.closed = false;
            emptyBottle.Item1.x = -50 + delta.X;
            emptyBottle.Item1.y = 50 + delta.Y;
        }

        private void DrawDynObjMapWithHuntsman(Graphics gr)
        {
            var a = 9 * 196 + delta.X;
            var b = 5 * 196 + delta.Y;
            var c = 5 * 196 + delta.X;
            var d = 1 * 196 + delta.Y;
            downDoor.x = -50 + delta.X;
            downDoor.y = -50 + delta.Y;
            leftDoor.x = -50 + delta.X;
            leftDoor.y = -50 + delta.Y;
            upDoor.x = c - delta.X;
            upDoor.y = d - delta.Y;
            rightDoor.x = a - delta.X;
            rightDoor.y = b - delta.Y;
            gr.DrawImage(GrassImg, a + 196, b + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            gr.DrawImage(GrassImg, c + 196, d + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            // 
            heartflower1.Item1.x = -50 + delta.X;
            heartflower1.Item1.y = -50 + delta.Y;
            heartflower2.Item1.x = -50 + delta.X;
            heartflower2.Item1.y = -50 + delta.Y;
            heartflower3.Item1.x = -50 + delta.X;
            heartflower3.Item1.y = -50 + delta.Y;
            waterLily.Item1.x = -50 + delta.X;
            waterLily.Item1.y = -50 + delta.Y;
            leftDoor.closed = false;
            rightDoor.closed = false;
            downDoor.closed = false;
            upDoor.closed = false;
            emptyBottle.Item1.x = -50 + delta.X;
            emptyBottle.Item1.y = 50 + delta.Y;
        }

        private void DrawDynObjMapHuntsmanHouse(Graphics gr)
        {
            var a = 2 * 196 + delta.X;
            var b = 1 * 196 + delta.Y;
            var c = 3 * 196 + delta.X;
            var d = 5 * 196 + delta.Y;
            downDoor.x = -50 + delta.X;
            downDoor.y = -50 + delta.Y;
            leftDoor.x = c - delta.X;
            leftDoor.y = d - delta.Y;
            upDoor.x = -50 + delta.X;
            upDoor.y = - 50 + delta.Y;
            rightDoor.x = a - delta.X;
            rightDoor.y = b - delta.Y;
            gr.DrawImage(GrassImg, a + 196, b + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            gr.DrawImage(GrassImg, c + 196, d + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            // 
            heartflower1.Item1.x = -50 + delta.X;
            heartflower1.Item1.y = -50 + delta.Y;
            heartflower2.Item1.x = -50 + delta.X;
            heartflower2.Item1.y = -50 + delta.Y;
            heartflower3.Item1.x = -50 + delta.X;
            heartflower3.Item1.y = -50 + delta.Y;
            waterLily.Item1.x = -50 + delta.X;
            waterLily.Item1.y = -50 + delta.Y;
            leftDoor.closed = false;
            rightDoor.closed = false;
            downDoor.closed = false;
            upDoor.closed = false;
            emptyBottle.Item1.x = -50 + delta.X;
            emptyBottle.Item1.y = 50 + delta.Y;
        }

        private void DrawDynObjHuntsmanHouseSecondFloor(Graphics gr)
        {
            var a = 1 * 196 + delta.X;
            var b = 1 * 196 + delta.Y;
            downDoor.x = -50 + delta.X;
            downDoor.y = -50 + delta.Y;
            leftDoor.x = a - delta.X;
            leftDoor.y = b - delta.Y;
            upDoor.x = -50 + delta.X;
            upDoor.y = -50 + delta.Y;
            rightDoor.x = -50 + delta.X;
            rightDoor.y = -50 + delta.Y;
            gr.DrawImage(GrassImg, a + 196, b + 196, new Rectangle(new Point(1176, 392), new Size(196, 196)), GraphicsUnit.Pixel);
            if (emptyBottle.Item2)
            {
                var c = 3 * 196 + delta.X;
                var d = 1 * 196 + delta.Y;
                emptyBottle.Item1.x = c - delta.X;
                emptyBottle.Item1.y = d - delta.Y;
                gr.DrawImage(InventoryGr, c + 196 + 50, d + 196 + 50, new Rectangle(new Point(64 * 0, 64 * 1), new Size(64, 64)), GraphicsUnit.Pixel);
            }
            // 
            heartflower1.Item1.x = -50 + delta.X;
            heartflower1.Item1.y = -50 + delta.Y;
            heartflower2.Item1.x = -50 + delta.X;
            heartflower2.Item1.y = -50 + delta.Y;
            heartflower3.Item1.x = -50 + delta.X;
            heartflower3.Item1.y = -50 + delta.Y;
            waterLily.Item1.x = -50 + delta.X;
            waterLily.Item1.y = -50 + delta.Y;
            leftDoor.closed = true;
            rightDoor.closed = false;
            downDoor.closed = false;
            upDoor.closed = false;
        }

        private void DrawInventory(Graphics gr)
        {
            var i = 0;
            var j = 0;
            if (openInv)
            {
                for (int a = 0; a < 5; a++)
                {
                    for (int b = 0; b < 15; b++)
                    {
                        gr.DrawImage(InventoryGr, a * 64, b * 64, new Rectangle(new Point(0, 0), new Size(64, 64)), GraphicsUnit.Pixel);
                    }
                }
                if (left) { if (x - 1 == -1) { if (y > 0) { y--; x = 3; } } else x--; }
                if (right) { if (x + 1 == 4) { if (y < 5) { y++; x = 0; } } else x++; }
                gr.DrawRectangle(new Pen(Color.White), x * 64, y * 64 + 64, 64, 64);

                GetDescription(gr);

                foreach (var item in Inventory.inventory)
                {
                    var a = 0;
                    if (item is Item.Bible)
                    {
                        a = 64;
                        gr.DrawImage(InventoryGr, i * 64, j * 64 + 64, new Rectangle(new Point(64*1, 0), new Size(64, 64)), GraphicsUnit.Pixel);
                        i++;
                        if (i == 4) { i = 0; j++; }
                    }
                    if (item is Item.Scissors)
                    {
                        a = 128;
                        gr.DrawImage(InventoryGr, i * 64, j * 64 + 64, new Rectangle(new Point(64*2, 0), new Size(64, 64)), GraphicsUnit.Pixel);
                        i++;
                        if (i == 4) { i = 0; j++; }
                    }
                    if (item is Item.Heartflower)
                    {
                        a = 196;
                        gr.DrawImage(InventoryGr, i * 64, j * 64 + 64, new Rectangle(new Point(64*3, 0), new Size(64, 64)), GraphicsUnit.Pixel);
                        i++;
                        if (i == 4) { i = 0; j++; }
                    }
                    if (item is Item.WaterLily)
                    {
                        a = 196;
                        gr.DrawImage(InventoryGr, i * 64, j * 64 + 64, new Rectangle(new Point(64*4, 0), new Size(64, 64)), GraphicsUnit.Pixel);
                        i++;
                        if (i == 4) { i = 0; j++; }
                    }
                    if (item is Item.Key)
                    {
                        a = 196;
                        gr.DrawImage(InventoryGr, i * 64, j * 64 + 64, new Rectangle(new Point(64 * 2, 64*1), new Size(64, 64)), GraphicsUnit.Pixel);
                        i++;
                        if (i == 4) { i = 0; j++; }
                    }
                    if (item is Item.EmptyBottle)
                    {
                        a = 196;
                        gr.DrawImage(InventoryGr, i * 64, j * 64 + 64, new Rectangle(new Point(64 * 0, 64 * 1), new Size(64, 64)), GraphicsUnit.Pixel);
                        i++;
                        if (i == 4) { i = 0; j++; }
                    }
                    if (item is Item.HealingPotion)
                    {
                        a = 196;
                        gr.DrawImage(InventoryGr, i * 64, j * 64 + 64, new Rectangle(new Point(64 * 1, 64 * 1), new Size(64, 64)), GraphicsUnit.Pixel);
                        i++;
                        if (i == 4) { i = 0; j++; }
                    }

                }
            }
        }

        private void DrawNotebook(Graphics gr)
        {
            if(openNote)
            {
                for (int a = 0; a < 6; a++)
                {
                    for (int b = 0; b < 15; b++)
                    {
                        gr.DrawImage(InventoryGr, a * 64 + 64*9, b * 64, new Rectangle(new Point(64*9, 0), new Size(64, 64)), GraphicsUnit.Pixel);
                    }
                }
            }
        }

        private void GetDescription(Graphics gr)
        {
            try
            {
                gr.DrawString(Text = Inventory.inventory[x + y * 4].Describes, new Font("Franklin Gothic Medium", 15, FontStyle.Italic), new SolidBrush(Color.White), new Point(30, 64*8));
            }
            catch
            {
                gr.DrawString(Text = "", new Font("Franklin Gothic Heavy", 15, FontStyle.Underline), new SolidBrush(Color.Red), new Point(30, 64*8));
            }
        }

        public static void Main()
		{
			Application.Run(new Form1());
		}
	}
}
