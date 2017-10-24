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
using Microsoft.Xna.Framework.Input.Touch;

namespace Pisicu{

    public class TextBox{
        
        public string str;

        public float x;
        public float y;

        public float w;
        public float h;

        public float rad;

        public Text text;
        public Block block;

        public Color color;
        
        public TextBox(string str, float x, float y, float w, float h){
            
            this.str = str;

            this.x = Game1.WIDTH * x;
            this.y = Game1.HEIGHT * y;

            this.w = Game1.WIDTH * w;
            this.h = Game1.HEIGHT * h;

            float xx = x + 10;
            float yy = y + 10;

            text = new Text(str, xx, yy);

            color = new Color(52, 73, 94);
            block = new Block();
        }

        public TextBox setRadius(int rad, bool ul, bool ur, bool dr, bool dl){

            this.rad = rad;

            block.setCorners(ul, ur, dr, dl);
            return this;
        }

        public TextBox setColor(Color color) {
            
             this.color = color;
             return this;
        }

        public TextBox centerX() {

            x = (Game1.WIDTH - w) / 2;

            centerText();

            return this;
        }

        public TextBox centerY() {

            y = (Game1.HEIGHT - h) / 2;

            centerText();

            return this;
        }

        public void centerText() {

            float xx = x + (w - Game1.font.MeasureString(str).X * text.scale) / 2;
            float yy = y + (h - Game1.font.MeasureString(str).Y * text.scale) / 2;

            text = new Text(str, xx, yy);
        }

        public void draw(SpriteBatch sb){

            block.draw(sb, x, y, w, h, rad, color);

            text.draw(sb);
        }
    }
}