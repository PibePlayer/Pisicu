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

namespace Pisicu {

    public class ScreenHome {

        Button start;

        public ScreenHome() {

            start = new Button("Iniciar",Game1.WIDTH * 0.25f,400,Game1.WIDTH * 0.5f,100);

            ScreenController.buttons.Add(start);
        }

        public void draw(SpriteBatch sb) {

        }

        public void update() {

            if(start.touch) {
                ScreenController.set(Screen.LOAD);
            }
        }
    }
}