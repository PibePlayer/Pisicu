using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using Microsoft.Xna.Framework.Input.Touch;

namespace Pisicu{

    public class InputBox {

        public float x;
        public float y;

        public float w;
        public float h;

        public float rad;

        Color color;

        public bool touch;

        public string label;
        public string str = "";
        public Task<String> kb;

        Text text;

        public Block block;

        public InputBox(float x, float y, float w, float h, string label) {

            this.x = Game1.WIDTH * x;
            this.y = Game1.HEIGHT * y;

            this.w = Game1.WIDTH * w;
            this.h = Game1.HEIGHT * h;

            color = ColorBank.midnightblue;

            this.label = label;

            text = new Text(str,x + 20,y + 20);
            block = new Block();
        }

        public InputBox centerX() {

            x = (Game1.WIDTH - w) / 2;
            centerText();

            return this;
        }

        public InputBox centerY() {

            y = (Game1.HEIGHT - h) / 2;
            centerText();

            return this;
        }

        public InputBox setRadius(int rad, Boolean ul, Boolean ur, Boolean dr, Boolean dl){

            this.rad = rad;

            block.setCorners(ul, ur, dr, dl);
            return this;
        }

        public void centerText() {

            float xx = x + (w - Game1.font.MeasureString(str).X * text.scale) / 2;
            float yy = y + (h - Game1.font.MeasureString(str).Y * text.scale) / 2;

            text = new Text(str, xx, yy);
        }

        public void draw(SpriteBatch sb){

            update();

            block.draw(sb,x,y,w,h,rad,color);

            text.draw(sb);
        }

        public void update() {

            if(touch) {
                write();
                touch = false;
            }

            if (kb != null){

                str = (kb.IsCompleted) ? kb.Result ?? str : str;
                centerText();
                text.str = (label != "Password") ? str : new StringBuilder().Append('*', str.Length).ToString();
            }
        }

        public void write() {

            kb = KeyboardInput.Show(label, "", text.str, (label == "Password"));
        }
    }
}