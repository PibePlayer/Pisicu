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

    public class Text{
        
        public string str;

        public float x;
        public float y;

        public float scale = Game1.HEIGHT / 1000;

        public Text(string str, float x, float y){
            
            this.str = str;

            this.x = x;
            this.y = y;
        }

        public void draw(SpriteBatch sb){
            sb.DrawString(Game1.font, str,new Vector2(x,y), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}