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

    public class Block {

        public float x;
        public float y;

        public float w;
        public float h;

        public float rad;

        public Boolean ul;
        public Boolean ur;
        public Boolean dl;
        public Boolean dr;

        public Color color;

        public Block(float x, float y, float w, float h,Color color) {

            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;

            this.color = color;
        }

        public Block setRadius(float rad, Boolean ul, Boolean ur, Boolean dr, Boolean dl) {

            this.rad = rad;

            this.ul = ul;
            this.ur = ur;
            this.dl = dl;
            this.dr = dr;

            return this;
        }

        public void draw(SpriteBatch sb){

            sb.Draw(Game1.point, new Rectangle((int)(x + rad), (int)y, (int)(w - 2 * rad), (int)h), color); //SOLID CENTER

            sb.Draw(Game1.point, new Rectangle((int)x, (int)(y + rad), (int)rad, (int)(h - 2 * rad)), color); //SOLID LEFT
            sb.Draw(Game1.point, new Rectangle((int)(x + w - rad), (int)(y + rad), (int)rad, (int)(h - 2 * rad)), color); //SOLID LEFT

            if (ul) { sb.Draw(Game1.point, new Rectangle((int)x, (int)y, (int)rad, (int)rad), Color.Red); } //CORNER UP LEFT
            else { sb.Draw(Game1.point, new Rectangle((int)x, (int)y, (int)rad, (int)rad), color); }

            if (ur) { sb.Draw(Game1.point, new Rectangle((int)(x + w - rad), (int)y, (int)rad, (int)rad), Color.Red); } //CORNER UP RIGHT
            else { sb.Draw(Game1.point, new Rectangle((int)(x + w - rad), (int)y, (int)rad, (int)rad), color); }

            if (dl) { sb.Draw(Game1.point, new Rectangle((int)x, (int)(y + h - rad), (int)rad, (int)rad), Color.Red); } //CORNER DOWN LEFT
            else { sb.Draw(Game1.point, new Rectangle((int)x, (int)(y + h - rad), (int)rad, (int)rad), color); }

            if (dr) { sb.Draw(Game1.point, new Rectangle((int)(x + w - rad), (int)(y + h - rad), (int)rad, (int)rad), Color.Red); } //CORNER DOWN RIGHT
            else { sb.Draw(Game1.point, new Rectangle((int)(x + w - rad), (int)(y + h - rad), (int)rad, (int)rad), color); }
        }

    }
}