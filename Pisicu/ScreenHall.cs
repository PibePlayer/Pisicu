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
        
        Button activity;
        public static TextBox profile;

        public ScreenHall(){
            
            profile = new TextBox("@" + User.name, 0.01f, (0.01f * Game1.WIDTH) / Game1.HEIGHT, 0.98f, 0.05f).setColor(ColorBank.amethyst).setRadius(30, true).centerText(TextBox.center.y);
            activity = new Button(Game1.icon_activity, 0, 0.7f, 0.2f, (0.2f * Game1.WIDTH) / Game1.HEIGHT).setColor(ColorBank.alizarin).centerX().centerY().setRadius(50, true, true, true, true);
            
            ScreenController.add(activity);
            ScreenController.add(profile);
        }

        public void draw(SpriteBatch sb){
            
        }

        public void update(ref Socket ws){
            
            if(activity.touch){

                activity.touch = false;

                ScreenController.set(Screen.ACTIVITY);
            }

        }
    }
}