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
using Quobject.SocketIoClientDotNet.Client;

namespace Pisicu{

    public class ScreenLoad{

        Button b;

        public static bool connecting = false;

        public ScreenLoad() {

            b = new Button("...", 0, 0, 0.7f, 0.1f).centerX().centerY().setRadius(50,true,true, true, true);

            ScreenController.buttons.Add(b);
        }

        public void draw(SpriteBatch sb) {
            b.draw(sb);
        }

        public void update(ref Socket ws) {

            if (!connecting){
                connecting = true;
                ws.Connect();
            }
        }
    }
}