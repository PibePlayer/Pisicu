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

    public class ScreenJoinActivity{
        
        TextBox title;

        InputBox id;

        TextBox id_tbox;

        Button join;

        public ScreenJoinActivity(){
            
            title = new TextBox("Unirse a una Actividad", 0.01f, 0.07f, 0.7f, 0.05f).setColor(ColorBank.midnightblue).setRadius(60, true).centerText(TextBox.center.xy).centerX();

            id_tbox = new TextBox("ID", 0, 0.365f, 0.7f, 0.035f).setColor(ColorBank.alizarin).centerX().centerText(TextBox.center.y).setRadius(30,true,true,false,false);
 
            id = new InputBox(0, 0.395f, 0.7f, 0.07f, "Identificación").centerX().setRadius(30, false, false, true, true).setStroke(6,ColorBank.alizarin);
            join = new Button("Ingresar", 0, 0.5f, 0.7f, 0.1f).setColor(ColorBank.alizarin).centerX().setRadius(50, true, true, true, true);

            ScreenController.add(ScreenHall.profile);
            ScreenController.add(title);
            ScreenController.add(join);
            ScreenController.add(id_tbox);
            ScreenController.add(id);
        }

        public void draw(SpriteBatch sb){
        
        }

        public void update(ref Socket ws){
            
            if(GamePad.GetState(0).IsButtonDown(Buttons.Back)){
                ScreenController.set(Screen.ACTIVITY);
            };

            if(join.touch){
                
                join.touch = false;

                ws.Emit("join", "ASD123"); //id.str
            }
        }
    }
}