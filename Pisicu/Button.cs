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
        public bool solid = true;

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

        public Button setRadius(int rad, bool ul, bool ur, bool dr, bool dl) {
            
            this.rad = rad;
            block.setCorners(ul, ur, dr, dl);

            return this;
        }

        public Button setRadius(int rad, bool all) {
            
            this.rad = rad;
            block.setCorners(all, all, all, all);

            return this;
        }

        public Button setStroke(int stroke,Color stroke_color) {

            solid = false;
            block.setStroke(stroke,stroke_color);

            return this;
        }

        public Button setColor(Color color) {
            
            this.color = color;
            return this;
        }

        public void draw(SpriteBatch sb) {

            color = (touch) ? new Color(color.R, color.G, color.B) : color;

            block.draw(sb,solid, x, y, w, h, rad, color);
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