using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pisicu{

    public class Button{

        public float x;
        public float y;

        public float w;
        public float h;

        public float rad = 30;

        public Boolean ul = false;
        public Boolean ur = false;
        public Boolean dl = false;
        public Boolean dr = false;

        public Boolean touch = false;

        Color color;

        public string str;
        public Text text;

        public Block block;

        public Button(string str, float x, float y, float w, float h){

            this.x = Game1.WIDTH * x;
            this.y = Game1.HEIGHT * y;

            this.w = Game1.WIDTH * w;
            this.h = Game1.HEIGHT * h;

            color = ColorBank.turquoise;

            this.str = str;

            float xx = x + 10;
            float yy = y + 10;

            text = new Text(str, xx, yy);
            block = new Block();
        }

        public Button setRadius(int rad,Boolean ul,Boolean ur,Boolean dr,Boolean dl) {
            
            this.rad = rad;

            block.setCorners(ul, ur, dr, dl);
            return this;
        }

        public void draw(SpriteBatch sb) {

            color = (touch) ? new Color(06, 168, 136) : new Color(26, 188, 156);

            block.draw(sb, x, y, w, h, rad, color);
            text.draw(sb);
        }

        public Button centerX() {

            x = (Game1.WIDTH - w) / 2;

            centerText();

            return this;
        }

        public Button centerY() {

            y = (Game1.HEIGHT - h) / 2;

            centerText();

            return this;
        }

         public void centerText() {

            float xx = x + (w - Game1.font.MeasureString(str).X * text.scale) / 2;
            float yy = y + (h - Game1.font.MeasureString(str).Y * text.scale) / 2;

            text = new Text(str, xx, yy);
        }
    }
}