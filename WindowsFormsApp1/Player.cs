﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class Player
    {
        public Image _spritesAnimation;
        public int up_left_x, up_left_y,up_right_x,up_right_y,down_left_x,down_left_y,down_right_x,down_right_y,dirX,dirY;
        public Size _scale;
        public int currentFrame = 0;
        public int currentAnimation = 1;
        public Image part;
        public int speed;
        public Player(Size _scale,int _x, int _y, Image _spriteAnimation)
        {
            this._scale = _scale;
            this.up_left_x = _x;
            this.up_left_y = _y;
            this.up_right_x = this.up_left_x + 192;
            this.up_right_y = this.up_left_y;
            this.down_left_x = this.up_left_x;
            this.down_left_y = this.up_left_y + 192;
            this.down_right_x =this.up_right_x + 192;
            this.down_right_y = this.up_right_y + 192;
            this._spritesAnimation = _spriteAnimation;
            speed = 2;
        }

        public void move()
        {
            up_left_x += dirX;
            up_left_y += dirY;
            up_right_x += dirX + 192;
            up_right_y += dirY;
            down_left_x += dirX;
            down_left_y += dirY + 192;
            down_right_x += dirX + 192;
            down_right_y += dirY + 192;
        }  

        public void ChangeMap(int from, int to)
        {
            var x = 0;
            var y = 0;
            switch (to)
            {
                case 1102:
                    if (from == 1002) { x = 6; y = 3; }
                    if (from == 1103) { x = 7; y = 6; }
                    break;
                case 1103:
                    if (from == 1102) { x = 4; y = 3; }
                    if (from == 1104) { x = 3; y = 2; }
                    break;
                case 1104:
                    if (from == 1103) { x = 2; y = 2; }
                    break;
                case 1000:
                    if (from == 1001){x = 3; y = 3; }
                    break;
                case 1001:
                    if (from == 999) { x = 3; y = 3; }
                    if (from == 1000) { x = 10; y = 3; }
                    if (from == 1002) { x = 15; y = 3; }
                    if (from == 901) { x = 19; y = 5; }
                    break;
                case 1002:
                    if (from == 1001) { x = 3; y = 3; }
                    if (from == 902) { x = 2; y = 2; }
                    if (from == 1003) { x = 5; y = 4; }
                    if (from == 1102) { x = 5;y = 6; }
                    break;
                case 1003:
                    if (from == 1002) { x = 3; y = 9; }
                    if (from == 903) { x = 4;y = 6; }
                    break;
                case 901:
                    if (from == 1001) { x = 4; y = 16; }
                    if (from == 902) { x = 16; y = 16; }
                    break;
                case 902:
                    if (from == 901) { x = 3; y = 17; }
                    if (from == 902) { x = 0; y = 0; }
                    if (from == 1002) { x = 0; y = 0; }
                    break;
                case 903:
                    if (from == 1003) { x = 3; y = 9; }
                    break;
            }
            up_left_x = 196 * x;
            up_left_y = 196 * y;
            Form1.delta = new Point(196 * 2 - 196 * x, 196 * 1 - 196 * y );
        }
    }

    internal class Pope
    {
        public Image _spritesAnimation;
        public int x, y;
        public Size _scale;
        public int currentFrame = 0;
        public int currentAnimation = 1;
        public Image part;
    }

    internal class DoorIn
    {
        public Image door;
        public int x, y;
        public Size scale;
        public Image part;
        public bool InBound { get; set; }
        public bool closed { get; set; }

        public DoorIn(Size scale, int x, int y, Image door)
        {
            this.scale = scale;
            this.x = x;
            this.y = y;
            this.door = door;
            closed = false;
        }

        public static void ChangeMap()
        {
            Form1.CurrentMapStatus--;
            Form1.CurrentMap = Form1.Map[Form1.CurrentMapStatus].Item3;
            Form1.width = Form1.Map[Form1.CurrentMapStatus].Item1;
            Form1.height = Form1.Map[Form1.CurrentMapStatus].Item2;
        }
    }

    internal class DoorOut
    {
        public Image door;
        public int x, y;
        public Size scale;
        public Image part;
        public bool InBound { get; set; }
        public bool closed { get; set; }

        public DoorOut(Size scale, int x, int y, Image door)
        {
            this.scale = scale;
            this.x = x;
            this.y = y;
            this.door = door;
            closed = false;
        }

        public static void ChangeMap()
        {
            Form1.CurrentMapStatus++;
            Form1.CurrentMap = Form1.Map[Form1.CurrentMapStatus].Item3;
            Form1.width = Form1.Map[Form1.CurrentMapStatus].Item1;
            Form1.height = Form1.Map[Form1.CurrentMapStatus].Item2;
        }
    }

    internal class DoorUp
    {
        public Image door;
        public int x, y;
        public Size scale;
        public Image part;
        public bool InBound { get; set; }
        public bool closed { get; set; }

        public DoorUp(Size scale, int x, int y, Image door)
        {
            this.scale = scale;
            this.x = x;
            this.y = y;
            this.door = door;
            closed = false;
        }

        public static void ChangeMap()
        {
            Form1.CurrentMapStatus-=100;
            Form1.CurrentMap = Form1.Map[Form1.CurrentMapStatus].Item3;
            Form1.width = Form1.Map[Form1.CurrentMapStatus].Item1;
            Form1.height = Form1.Map[Form1.CurrentMapStatus].Item2;
        }
    }

    internal class DoorDown
    {
        public Image door;
        public int x, y;
        public Size scale;
        public Image part;
        public bool InBound { get; set; }
        public bool closed { get; set; }

        public DoorDown(Size scale, int x, int y, Image door)
        {
            this.scale = scale;
            this.x = x;
            this.y = y;
            this.door = door;
            closed = false;
        }

        public static void ChangeMap()
        {
            Form1.CurrentMapStatus+=100;
            Form1.CurrentMap = Form1.Map[Form1.CurrentMapStatus].Item3;
            Form1.width = Form1.Map[Form1.CurrentMapStatus].Item1;
            Form1.height = Form1.Map[Form1.CurrentMapStatus].Item2;
        }
    }
}