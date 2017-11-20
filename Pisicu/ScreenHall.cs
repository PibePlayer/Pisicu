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

    public class ScreenHall{
        
        Button button;

        public ScreenHall(){
            
            button = new Button(Game1.point, 0, 0.7f, 0.7f, 0.1f).setColor(ColorBank.alizarin).centerX().setRadius(50, true, true, true, true);
            
            ScreenController.add(button);
        }

        public void draw(SpriteBatch sb){
            
        }

        public void update(ref Socket ws){
            
        }
    }
}