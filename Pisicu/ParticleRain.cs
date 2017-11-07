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

    public class ParticleRain{

        Random rnd = new Random();

        List<Particle> ps = new List<Particle>();

        public ParticleRain() {

            for(int i = 0;i < 1000;i++) {
                ps.Add(new Particle(rnd.Next(Game1.WIDTH),-rnd.Next(150,800),ref rnd));
            }
        }

        public void draw(SpriteBatch sb) {
            
            foreach(Particle p in ps) {
                p.draw(sb,ref rnd);
            }
        }
    }
}