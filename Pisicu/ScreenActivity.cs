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

    public class ScreenActivity{
        
        TextBox title;
        Button join;
        Button create;
       
        public ScreenActivity(){

            title = new TextBox("Actividad", 0.01f, 0.07f, 0.5f, 0.05f).setColor(ColorBank.midnightblue).setRadius(60, true).centerText(TextBox.center.xy).centerX();

            join = new Button("Unirse", 0, 0.4f, 0.7f, 0.1f).setColor(ColorBank.alizarin).centerX().setRadius(50, true, true, false, false);
            create = new Button("Crear", 0, 0.5075f, 0.7f, 0.1f).setColor(ColorBank.alizarin).centerX().setRadius(50, false, false, true, true);

            ScreenController.add(ScreenHall.profile);
            ScreenController.add(title);

            ScreenController.add(join);
            ScreenController.add(create);
        }

        public void draw(SpriteBatch sb){
        
        }

        public void update(ref Socket ws){
            
            if(GamePad.GetState(0).IsButtonDown(Buttons.Back)){
                ScreenController.set(Screen.HALL);
            };

            if(join.touch){

                join.touch = false;
                ScreenController.set(Screen.JOIN_ACTIVITY);

            }else if(create.touch){
                
                create.touch = false;
                ScreenController.set(Screen.CREATE_ACTIVITY);
            }
        }
    }
}
