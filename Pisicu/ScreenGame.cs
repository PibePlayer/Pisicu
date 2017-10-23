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

    public class ScreenGame{
        
        public TextBox tbox;
        public List<Button> buttons = new List<Button>();

        public ScreenGame(string q, string op1, string op2, string op3){
            
            tbox = new TextBox(q, 0, 0.12f, 0.7f, 0.1f).centerX();

            string[] n = {op1, op2, op3};

            for(int i = 0; i < n.Length; i++){
                buttons.Add(new Button(n[i], 0,0.5f + i * 0.15f ,0.7f, 0.08f).centerX());
                ScreenController.buttons.Add(buttons[i]);
            }

            ScreenController.textboxes.Add(tbox);
        }

        public void draw(SpriteBatch sb){

        }

        public void update(ref Socket ws) {

            if (buttons[0].touch) {
                ws.Emit("next", ++Game1.COUNT);
                buttons[0].touch = false;
            }
        }
    }
}