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

    public class ScreenFinish {

        public ParticleRain pr;

        public ScreenFinish() {
            
            pr = new ParticleRain();
        }

        public void draw(SpriteBatch sb) {

            pr.draw(sb);
        }

        public void update() {

        }
    }
}