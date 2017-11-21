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

    public class ScreenCreateActivity{
        
        TextBox title;

        public ScreenCreateActivity(){
            
            title = new TextBox("Crear una Actividad", 0.01f, 0.07f, 0.7f, 0.05f).setColor(ColorBank.midnightblue).setRadius(60, true).centerText(TextBox.center.xy).centerX();

            ScreenController.add(ScreenHall.profile);
            ScreenController.add(title);
        }

        public void draw(SpriteBatch sb){
        
        }

        public void update(ref Socket ws){
            
            if(GamePad.GetState(0).IsButtonDown(Buttons.Back)){
                ScreenController.set(Screen.ACTIVITY);
            };
        }
    }
}