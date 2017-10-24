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

        public bool ul;
        public bool ur;
        public bool dl;
        public bool dr;

        public Color color;

        public Block setCorners(bool ul, bool ur, bool dr, bool dl) {

            this.ul = ul;
            this.ur = ur;
            this.dl = dl;
            this.dr = dr;

            return this;
        }

        public void draw(SpriteBatch sb,float x, float y, float w, float h, float rad, Color color){

            sb.Draw(Game1.point, new Rectangle((int)(x + rad), (int)y, (int)(w - 2 * rad), (int)h), color); //SOLID CENTER

            sb.Draw(Game1.point, new Rectangle((int)x, (int)(y + rad), (int)rad, (int)(h - 2 * rad)), color); //SOLID LEFT
            sb.Draw(Game1.point, new Rectangle((int)(x + w - rad), (int)(y + rad), (int)rad, (int)(h - 2 * rad)), color); //SOLID RIGHT
            
            for(int i = 0;i < 10;i++) {
              if (ul) { sb.Draw(Game1.corner_ul, new Rectangle((int)x + i, (int)y + i, (int)rad, (int)rad), color); } //CORNER UP LEFT
              else { sb.Draw(Game1.point, new Rectangle((int)x, (int)y, (int)rad, (int)rad), color); }
            }

            if (ur) { sb.Draw(Game1.corner_ur, new Rectangle((int)(x + w - rad), (int)y, (int)rad, (int)rad), color); } //CORNER UP RIGHT
            else { sb.Draw(Game1.point, new Rectangle((int)(x + w - rad), (int)y, (int)rad, (int)rad), color); }

            if (dl) { sb.Draw(Game1.corner_dl, new Rectangle((int)x, (int)(y + h - rad), (int)rad, (int)rad), color); } //CORNER DOWN LEFT
            else { sb.Draw(Game1.point, new Rectangle((int)x, (int)(y + h - rad), (int)rad, (int)rad), color); }

            if (dr) { sb.Draw(Game1.corner_dr, new Rectangle((int)(x + w - rad), (int)(y + h - rad), (int)rad, (int)rad), color); } //CORNER DOWN RIGHT
            else { sb.Draw(Game1.point, new Rectangle((int)(x + w - rad), (int)(y + h - rad), (int)rad, (int)rad), color); }
        }

    }
}