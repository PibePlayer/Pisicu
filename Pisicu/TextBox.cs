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

        public enum center {x, y, xy};
        
        public string str;

        public float x;
        public float y;

        public float xx { get { return text.x; } set { text = new Text(str, value, text.y); } }
        public float yy { get { return text.y; } set { text = new Text(str, text.x, value); } }

        public float w;
        public float h;

        public float rad;

        public Text text;
        public Block block;

        public bool solid = true;

        public Color color;
        
        public TextBox(string str, float x, float y, float w, float h){
            
            this.str = str;

            this.x = Game1.WIDTH * x;
            this.y = Game1.HEIGHT * y;

            this.w = Game1.WIDTH * w;
            this.h = Game1.HEIGHT * h;

            float xx = x * Game1.WIDTH + 30;
            float yy = y * Game1.HEIGHT + 30;

            text = new Text(str, xx, yy);

            color = new Color(52, 73, 94);
            block = new Block();
        }

        public TextBox setRadius(int rad, bool ul, bool ur, bool dr, bool dl){

            this.rad = rad;
            block.setCorners(ul, ur, dr, dl);

            return this;
        }

        public TextBox setRadius(int rad, bool all){
            return setRadius(rad, all, all, all, all);
        }

        public TextBox setStroke(int stroke,Color stroke_color) {
                    
            solid = true;
            block.setStroke(stroke,stroke_color);

            return this;
        }

        public TextBox setColor(Color color) {
            
             this.color = color;
             return this;
        }

        public TextBox centerX() {

            x = (Game1.WIDTH - w) / 2;
            xx += x;

            return this;
        }

        public TextBox centerY() {

            y = (Game1.HEIGHT - h) / 2;
            yy += y;

            return this;
        }

        public TextBox centerText(center mode = center.xy) {

            if (mode == center.x || mode == center.xy) {
                xx = x + (w - Game1.font.MeasureString(str).X * text.scale) / 2;
            }
            if (mode == center.y || mode == center.xy) {
                yy = y + (h - Game1.font.MeasureString(str).Y * text.scale) / 2;
            }

            return this;
        }

        public void draw(SpriteBatch sb){

            block.draw(sb, solid, x, y, w, h, rad, color);

            text.draw(sb);
        }
    }
}
