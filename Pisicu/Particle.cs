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
using Microsoft.Xna.Framework.Input.Touch;

namespace Pisicu{

    public class Particle{

        public float x;
        public float y;

        public float vx;
        public float vy;

        public float w;

        public Color c;

        public Particle(float x,float y,ref Random rnd) {

            this.x = x;
            this.y = y;

            vy = (float) (0.01f + rnd.NextDouble() * 12f);
            vx = (float) (-7f + rnd.NextDouble() * 14f);

            w = (float) (10f + rnd.NextDouble() * 10f);

            c = new Color(rnd.Next(255),rnd.Next(255),rnd.Next(255));
        }

        public void draw(SpriteBatch sb,ref Random rnd) {

            x += vx;
            y += vy;

            vy += 0.05f;

            sb.Draw(Game1.point,new Rectangle((int) x,(int) y,(int) w,(int) w),c);
        }
    }
}